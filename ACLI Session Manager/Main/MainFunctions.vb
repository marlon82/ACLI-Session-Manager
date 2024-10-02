Imports System.Net
Imports System.ComponentModel

Imports RestSharp
Imports RestSharp.Authenticators
Imports NLog
Imports System.Web
Imports System.IO
Imports System.Text
Imports System.Net.Sockets


Module MainFunctions

    Public ProfileTable As DataTable = getProfileTable()
    Public ProfileBS As New BindingSource
    Public ProfileDV As New DataView

    Public XIQInput As New XIQSettings

    Public SessionsFolder As String
    Public FolderSessionIni As String = "\__FolderData__.ini"

    Public Log As Logger = LogManager.GetCurrentClassLogger()
    Public WithEvents bgwXIQSEImport As New BackgroundWorker

#Region "API Queries"

    Public Query_GetBearerToken As String = "/oauth/token/access-token?grant_type=client_credentials"

    Public Query_GetAllDevices As String = "{
  network {
    devices {
      deviceDisplayFamily
      sitePath
      sysName
      ip
      firmware
      sysLocation
      sysUpTime
      up
      deviceData {
        profileName
        deviceDisplayType
      }
    }
  }
  administration {
    profiles {
      profileName
      authCred {
        userName
        loginPassword
        type
      }
    }
  }
}
"


#End Region


#Region "XIQ-SE BackgroundWorker"


    Public Function EncodeBase64(ByVal input As String) As String
        Return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input))
    End Function

    Public Function DecodeBase64(ByVal input As String) As String
        Try
            Dim mod4 As Integer = input.Length Mod 4

            If mod4 > 0 Then
                input += New String("="c, 4 - mod4)
            End If


            'Log.Debug("decode base64: " & input)
            'Log.Debug("   input : " & input)
            'Log.debug("   outputfromBase64: " & Convert.FromBase64String(input).ToString)
            Log.Debug("   outpututf8: " & System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(input)))
            Return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(input))
        Catch ex As Exception
            Log.Error(ex.Message)
        End Try

    End Function

    ReadOnly UnixEpoch As New DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local)
    ReadOnly MaxUnixSeconds As Double = (DateTime.MaxValue - UnixEpoch).TotalSeconds
    Public Function UnixTimeStampToDateTime(unixTimeStamp As Double) As DateTime
        Return If(unixTimeStamp > MaxUnixSeconds, UnixEpoch.AddMilliseconds(unixTimeStamp), UnixEpoch.AddSeconds(unixTimeStamp))
    End Function


    Private Sub bgwXIQSEImport_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwXIQSEImport.DoWork
        Dim Info As New XMCInfo
        Log.Debug("bgwGetXMCInfo_DoWork - Gather XMC System Info")

        Dim Query As String = Query_GetAllDevices
        'Gather Group Values (MACs)
        Dim Client As New RestClient(XIQInput.XMCServer)
        Dim request As New RestRequest("/nbi/graphql/?query=" & Query, Method.GET)
        Dim response As New RestResponse

        Info.SessionCreds = XIQInput.SessionCreds
        Info.SessionUser = XIQInput.SessionUser
        Info.SessionPassword = XIQInput.SessionPassword
        Info.ImportProfiles = XIQInput.ImportProfiles

        Log.Info("   connecting to XMC/XIQ-SE using username and password")
        Client.Authenticator = New HttpBasicAuthenticator(XIQInput.XMCUser, XIQInput.XMCPassword)


        request.AddHeader("Accept", "application/json")
        request.AddHeader("Content-Type", "application/json")

        'request.AddHeader("Authorization", "Bearer " & settings.XMCToken)

        request.Timeout = 5000

        Log.Debug("Client: " & Client.BaseUrl.ToString)
        'Log.debug("Request body: " & request.Body.ToString)
        Log.Debug("Request Method: " & request.Method.ToString)
        Log.Debug("Request Params: " & request.Parameters.ToString)
        System.Net.ServicePointManager.ServerCertificateValidationCallback = Function(se As Object, cert As System.Security.Cryptography.X509Certificates.X509Certificate, chain As System.Security.Cryptography.X509Certificates.X509Chain, sslerror As System.Net.Security.SslPolicyErrors) True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        response = Client.Execute(request)

        If response.StatusCode = HttpStatusCode.OK Then
            Log.Debug("   response OK:")
            'Log.Debug("      " & response.Content.ToString)


            Dim XMCResponseL1 As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(response.Content) 'data Object
            Dim XMCResponseL2 As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(XMCResponseL1.SelectToken("data").ToString) 'accessControl Object
            Dim XMCResponseL3adm As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(XMCResponseL2.SelectToken("administration").ToString)
            Dim XMCResponseL3net As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(XMCResponseL2.SelectToken("network").ToString) 'group Object
            Info.Devices = Newtonsoft.Json.Linq.JArray.Parse(XMCResponseL3net.SelectToken("devices").ToString)
            Info.Profiles = Newtonsoft.Json.Linq.JArray.Parse(XMCResponseL3adm.SelectToken("profiles").ToString)
            Info.Connected = True
            Info.Status = response.StatusCode.ToString
            Log.Info("   connected to XMC/XIQ-SE")
            'Log.Debug("      " & response.Content.ToString)

        Else
            Info.Connected = False
            Info.Status = response.StatusCode.ToString
            Info.Message = response.Content.ToString
            Log.Error("   failed to connect to XMC/XIQ-SE")
            Log.Debug("      " & response.Content.ToString)

        End If


        bgwXIQSEImport.ReportProgress(100, Info)
    End Sub

    Private Sub bgwGetXMCInfo_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwXIQSEImport.ProgressChanged
        Dim XIQSEInfo As XMCInfo = e.UserState

        If XIQSEInfo.Connected Then


            Dim NewFolderPath As String = SessionsFolder & "\" & XIQInput.NewFolderName
            Dim RootFolderPath As String = SessionsFolder & "\" & XIQInput.NewFolderName
            Dim ParentFolderPath As String = SessionsFolder & "\" & XIQInput.NewFolderName
            Dim NewSessionFile As String

            If IO.Directory.Exists(NewFolderPath) = False Then
                My.Computer.FileSystem.CreateDirectory(NewFolderPath)
            End If


            For Each Device In XIQSEInfo.Devices
                Log.Debug(vbCrLf & "Device:")
                Log.Debug(Device.ToString)
                Dim ParentNodeText As String = Device.SelectToken("sitePath").ToString
                ParentNodeText = ParentNodeText.Replace("/World", "")
                Dim temp() As String
                If ParentNodeText = "" Then
                    'no need to create subfolder
                    ParentFolderPath = RootFolderPath
                Else
                    ParentNodeText = ParentNodeText.Substring(1, ParentNodeText.Length - 1)
                    temp = ParentNodeText.Split("/")
                    For x = 0 To temp.Length - 1
                        Log.Debug("SubFolder:" & temp(x))
                        If Not temp(x) = "" Then

                            If IO.Directory.Exists(ParentFolderPath & "\" & temp(x)) Then
                                ParentFolderPath = ParentFolderPath & "\" & temp(x)
                            Else
                                If x = 0 Then
                                    'ParentNodeID = RootIndex
                                    ParentFolderPath = RootFolderPath
                                End If

                                For Each c In IO.Path.GetInvalidFileNameChars()
                                    temp(x) = temp(x).Replace(c, "_").Trim
                                Next
                                My.Computer.FileSystem.CreateDirectory(ParentFolderPath & "\" & temp(x))
                                ParentFolderPath = ParentFolderPath & "\" & temp(x)
                                'ParentNodeID = newSessionEntry(temp(x), TreeNodeType.Folder, ParentNodeID, 1)
                            End If
                        End If

                    Next
                End If
                Dim EntryName, EntryIP, EntryProtocol, EntryUsername, EntryPassword As String
                Dim EntryProf, EntryPort As Integer
                EntryName = Device.SelectToken("sysName").ToString
                EntryIP = Device.SelectToken("ip").ToString
                If EntryName = "" Then EntryName = EntryIP
                EntryPort = 0


                'check profiles
                Dim DevProf As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(Device.SelectToken("deviceData").ToString)

                For Each Prof In XIQSEInfo.Profiles
                    If Prof.SelectToken("profileName").ToString = DevProf.SelectToken("profileName").ToString Then

                        Dim Auth As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(Prof.SelectToken("authCred").ToString)
                        Log.Debug("Name " & Prof.SelectToken("profileName").ToString)

                        If XIQSEInfo.SessionCreds = True Then
                            EntryProf = 0
                            EntryUsername = XIQSEInfo.SessionUser
                            EntryPassword = XIQSEInfo.SessionPassword
                            EntryProtocol = Auth.SelectToken("type").ToString
                        Else
                            EntryUsername = Auth.SelectToken("userName").ToString
                            EntryPassword = Auth.SelectToken("loginPassword").ToString
                            EntryProtocol = Auth.SelectToken("type").ToString
                        End If

                        If XIQSEInfo.SessionCreds = True And XIQSEInfo.ImportProfiles = False Then
                        Else
                            If CheckIfProfileExists(XIQInput.NewFolderName & "_" & DevProf.SelectToken("profileName").ToString) = False Then
                                EntryProf = returnNextFreeProfileID()
                                ProfileTable.Rows.Add(EntryProf, XIQInput.NewFolderName & "_" & DevProf.SelectToken("profileName").ToString, EntryUsername, EncryptString_Aes(EntryPassword))
                                SaveCSV(ProfileTable, "Profiles")
                                EntryUsername = ""
                                EntryPassword = ""
                            Else
                                Dim myRow() As Data.DataRow
                                myRow = ProfileTable.Select("name = '" & XIQInput.NewFolderName & "_" & DevProf.SelectToken("profileName").ToString & "'")
                                EntryProf = myRow(0)("ProfileID")
                                EntryUsername = ""
                                EntryPassword = ""

                            End If
                        End If


                        Exit For
                    End If
                Next




                NewSessionFile = EntryName

                For Each c In IO.Path.GetInvalidFileNameChars()
                    NewSessionFile = NewSessionFile.Replace(c, "_").Trim
                Next
                NewSessionFile = ParentFolderPath & "\" & NewSessionFile & ".ini"
                Dim sessInf As New SessionInfo

                sessInf.name = EntryName
                sessInf.host = EntryIP
                sessInf.username = EntryUsername
                sessInf.password = EntryPassword
                sessInf.profile = EntryProf
                If My.Settings.DefaultMode = "Interactive" Then
                    sessInf.interactive = True
                Else
                    sessInf.interactive = False
                End If
                sessInf.sockets = ""

                If EntryProtocol.Contains("Telnet") Then
                    If EntryPort = 0 Then EntryPort = 23
                    sessInf.protocol = 0
                ElseIf EntryProtocol.Contains("SSH") Then
                    If EntryPort = 0 Then EntryPort = 22
                    sessInf.protocol = 1
                End If

                sessInf.port = Convert.ToInt32(EntryPort)

                saveSessionInfo(NewSessionFile, sessInf)
            Next




            BuildTreeView()

        Else

        End If


        XIQ_SE_import.ChangeState(True, XIQSEInfo.Connected, XIQSEInfo.Status)
    End Sub

    Function CheckIfProfileExists(ByVal Profilename As String) As Boolean
        Dim myRow() As Data.DataRow

        myRow = ProfileTable.Select("name = '" & Profilename & "'")
        If myRow.Length = 0 Then
            Return False
        Else
            Return True
        End If
        Return False
    End Function



#End Region


    Enum TreeNodeType
        Folder = 0
        Session = 1
    End Enum
    Public Enum SessionProtocol
        telnet = 0
        ssh = 1
        serial = 2
        rdp = 3
    End Enum

    Public dict_protocol As New Dictionary(Of Int16, String)


    Function isDirectory(ByVal path As String) As Boolean


        If path.EndsWith("__FolderData__.ini") Then
            Return True
        Else
            Return False
        End If

    End Function

    Function getSessionInfo(ByVal sessionfile As String)
        Dim info As New SessionInfo
        If IO.File.Exists(sessionfile) = True Then

            Dim reader As New StreamReader(sessionfile, Encoding.Default)
            Dim a As String
            Dim temp() As String

            info.name = IO.Path.GetFileName(sessionfile).Replace(".ini", "")
            info.port = 22
            info.protocol = 1
            info.interactive = True
            info.profile = 0
            info.username = ""
            info.password = ""
            info.sockets = ""

            Do
                a = reader.ReadLine
                If Not a = Nothing Then
                    If a.StartsWith("name") Then
                        temp = a.Split("=")
                        info.name = temp(1)
                    End If
                    If a.StartsWith("host") Then
                        temp = a.Split("=")
                        info.host = temp(1)
                    End If
                    If a.StartsWith("prot") Then
                        temp = a.Split("=")
                        info.protocol = temp(1)
                    End If
                    If a.StartsWith("port") Then
                        temp = a.Split("=")
                        info.port = temp(1)
                    End If
                    If a.StartsWith("profile") Then
                        temp = a.Split("=")
                        info.profile = temp(1)
                    End If
                    If a.StartsWith("username") Then
                        temp = a.Split("=")
                        info.username = temp(1)
                    End If
                    If a.StartsWith("password") Then
                        temp = a.Split("=")
                        If Not temp(1) = "" Then
                            info.password = DecryptString_Aes(temp(1))
                            'info.password = temp(1)
                        End If
                    End If
                    If a.StartsWith("interactive") Then
                        temp = a.Split("=")
                        info.interactive = temp(1)
                    End If
                    If a.StartsWith("sockets") Then
                        temp = a.Split("=")
                        info.sockets = temp(1)
                    End If
                End If
            Loop Until a Is Nothing
            reader.Close()
        Else
            info.name = GetFolderName(sessionfile)
            info.port = 22
            info.protocol = 1
            info.interactive = True
            info.profile = 0
            info.username = ""
            info.password = ""
            info.sockets = ""
        End If

        Return info
    End Function

    Function GetFolderName(ByVal path As String) As String
        Dim temp() As String = path.Split("\")
        Return temp(temp.Length - 2)
    End Function


    Sub saveSessionInfo(ByVal sessionfile As String, ByVal info As SessionInfo)
        Try
            Dim file As System.IO.StreamWriter

            file = My.Computer.FileSystem.OpenTextFileWriter(sessionfile, False)
            file.WriteLine("name=" & info.name)
            file.WriteLine("host=" & info.host)
            file.WriteLine("port=" & info.port)
            file.WriteLine("profile=" & info.profile)
            file.WriteLine("username=" & info.username)
            If info.password = "" Then
                file.WriteLine("password=")
            Else
                file.WriteLine("password=" & EncryptString_Aes(info.password))
            End If
            file.WriteLine("protocol=" & info.protocol)
            file.WriteLine("interactive=" & info.interactive)
            file.WriteLine("sockets=" & info.sockets)
            file.Close()
        Catch ex As Exception
            MsgBox("Error while writing ini file: " & ex.Message & vbCrLf & "Provided filename:" & sessionfile, MsgBoxStyle.Critical, "Error writing ini file")
            Log.Error("Error while writing ini file: " & ex.Message)
            Log.Error("Provided filename:" & sessionfile)
        End Try
    End Sub

    Function getProfileTable() As DataTable
        Dim table As New DataTable
        table.TableName = "profile"

        table.Columns.Add("ProfileID", GetType(Integer))
        table.Columns.Add("name", GetType(String))
        table.Columns.Add("user", GetType(String))
        table.Columns.Add("pass", GetType(String))

        'table.Rows.Add(1, "customer1", "user", "password")
        'table.Rows.Add(2, "customer2", "rwa", "rwa")
        Return table
    End Function

    Function returnNextFreeProfileID()
        Dim ID As Integer
        ID = ProfileTable.Rows.Count
        Return ID
    End Function

    Public Function WriteCSV(ByVal input As String) As String
        Try

        Catch ex As Exception

        End Try

        Try
            If (input Is Nothing) Then
                Return String.Empty
            End If

            Dim containsQuote As Boolean = False
            Dim containsComma As Boolean = False
            Dim len As Integer = input.Length
            Dim i As Integer = 0
            Do While ((i < len) _
                        AndAlso ((containsComma = False) _
                        OrElse (containsQuote = False)))
                Dim ch As Char = input(i)
                If (ch = Microsoft.VisualBasic.ChrW(34)) Then
                    containsQuote = True
                ElseIf (ch = Microsoft.VisualBasic.ChrW(44)) Then
                    containsComma = True
                End If

                i = (i + 1)
            Loop

            If containsQuote AndAlso containsComma Then input = input.Replace("""", """""")

            If containsComma Then
                Return """" & input & """"
            Else
                Return input
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Function

    Public Sub SaveCSV(ByVal table As DataTable, ByVal FileName As String)


        table.WriteXmlSchema(My.Settings.DefaultFolderPath & "ACLISessionManager\" & FileName & "_sh.ini", True)
        table.WriteXml(My.Settings.DefaultFolderPath & "ACLISessionManager\" & FileName & "_dt.ini", True)


    End Sub

    Function LoadCSV(ByVal FileName As String, ByVal TableMode As String)
        Dim table As New DataTable
        Dim File2Load As String = My.Settings.DefaultFolderPath & "ACLISessionManager\" & FileName

        If IO.File.Exists(File2Load & "_sh.ini") = True And IO.File.Exists(File2Load & "_dt.ini") = True Then

            'neu
            table.TableName = TableMode
            table.ReadXmlSchema(File2Load & "_sh.ini")
            table.ReadXml(File2Load & "_dt.ini")

        Else
            Select Case TableMode
                Case "profile"
                    table = getProfileTable()
                    table.Rows.Add(0, "NONE", "NONE", EncryptString_Aes("NONE"))
            End Select
        End If




        Return table
    End Function
    Sub BuildTreeView()

        SessionsMain.TVSessions.Nodes.Clear()
        Dim tn As New TreeNode
        tn.Tag = SessionsFolder & FolderSessionIni
        tn.Name = SessionsFolder & FolderSessionIni
        tn.Text = "Sessions"
        tn.SelectedImageIndex = 0
        tn.ImageIndex = 0
        tn.Nodes.Add("*EMPTY*")
        tn.ToolTipText = "Sessions"
        SessionsMain.TVSessions.Nodes.Add(tn)
        'PopulateTreeView(SessionsFolder, SessionsMain.TVSessions.Nodes(0))

        If Not IO.Directory.Exists(SessionsFolder) Then
            IO.Directory.CreateDirectory(SessionsFolder)
        End If


        Debug.Print("SessionsCount:" & SessionsMain.TVSessions.Nodes.Count)


        SessionsMain.TVSessions.Nodes(0).Expand()
        'SessionsMain.TVSessions.TreeViewNodeSorter = New CustomNodeSorter
        SessionsMain.TVSessions.TreeViewNodeSorter = New Level0NodeSorter()
        SessionsMain.TVSessions.Sort()

    End Sub


    'Sub PopulateTreeView(ByVal dir As String, ByVal parentNode As TreeNode)

    '    Dim inspectDirectoryInfo As IO.DirectoryInfo = New IO.DirectoryInfo(dir)

    '    For Each directoryInfoItem As IO.DirectoryInfo In inspectDirectoryInfo.GetDirectories
    '        Dim directoryTreeNode As New TreeNode
    '        directoryTreeNode.Tag = directoryInfoItem.FullName
    '        directoryTreeNode.Text = directoryInfoItem.Name
    '        parentNode.Nodes.Add(directoryTreeNode)

    '        Debug.Print("SessionsCount:" & SessionsMain.TVSessions.Nodes.Count)

    '        For Each fileItem As IO.FileInfo In inspectDirectoryInfo.GetFiles
    '            Dim fileNode As New TreeNode
    '            fileNode.Tag = fileItem.FullName
    '            fileNode.Text = fileItem.Name
    '            parentNode.Nodes.Add(fileNode)
    '        Next

    '        PopulateTreeView(directoryInfoItem.FullName, directoryTreeNode)
    '    Next
    'End Sub




    Sub ImportCRTSesions(ByVal Dir As String)
        Dim Foldername As String = InputBox("Please provide a root folder name", "root folder name", "SecureCRT")
        If Foldername = "" Then Foldername = "SecureCRT"

        Dim NewFolderPath As String = SessionsFolder & "\" & Foldername
        Dim RootFolderPath As String = SessionsFolder & "\" & Foldername
        Dim ParentFolderPath As String = SessionsFolder & "\" & Foldername
        Dim NewSessionFile As String
        If IO.Directory.Exists(NewFolderPath) = False Then
            My.Computer.FileSystem.CreateDirectory(NewFolderPath)

            For Each filename As String In IO.Directory.GetFiles(Dir, "*.ini", IO.SearchOption.AllDirectories)
                ' Log.debug("Filename" & filename)
                If Not IO.Path.GetFileName(filename) = "__FolderData__.ini" Then

                    Dim EntryName, EntryProtocol, EntryPort As String
                    NewSessionFile = IO.Path.GetFileName(filename)
                    EntryName = NewSessionFile.Replace(".ini", "")

                    NewSessionFile = IO.Path.GetFileName(filename)

                    Dim temp() As String

                    Dim ParentNodeText As String
                    ParentNodeText = filename
                    ParentNodeText = ParentNodeText.Replace(Dir, "")
                    ParentNodeText = ParentNodeText.Replace(IO.Path.GetFileName(filename), "")

                    Log.Debug("ParentNodeText" & ParentNodeText)
                    If ParentNodeText = "\" Then
                        'no need to create subfolder
                        ParentFolderPath = RootFolderPath
                    Else
                        'subfolder needs to be created
                        ParentNodeText = ParentNodeText.Substring(1, ParentNodeText.Length - 2)
                        temp = ParentNodeText.Split("\")

                        For x = 0 To temp.Length - 1
                            Debug.Print("SubFolder:" & temp(x))
                            Log.Debug("SubFolder:" & temp(x))
                            If Not temp(x) = "" Then
                                If IO.Directory.Exists(ParentFolderPath & "\" & temp(x)) Then
                                    If Not temp.Length = 1 Then
                                        'ParentNodeID = GetNodeID(temp(x))
                                        ParentFolderPath = ParentFolderPath & "\" & temp(x)
                                    End If
                                Else
                                    If x = 0 Then
                                        ParentFolderPath = RootFolderPath
                                    End If
                                    For Each c In IO.Path.GetInvalidFileNameChars()
                                        temp(x) = temp(x).Replace(c, "_").Trim
                                    Next
                                    My.Computer.FileSystem.CreateDirectory(ParentFolderPath & "\" & temp(x))
                                    ParentFolderPath = ParentFolderPath & "\" & temp(x)
                                    'ParentNodeID = newSessionEntry(temp(x), TreeNodeType.Folder, ParentNodeID, 1)
                                End If
                            End If

                        Next
                    End If


                    For Each c In IO.Path.GetInvalidFileNameChars()
                        NewSessionFile = NewSessionFile.Replace(c, "_").Trim
                    Next
                    NewSessionFile = ParentFolderPath & "\" & NewSessionFile
                    Dim SR As IO.StreamReader = New IO.StreamReader(filename)
                    Dim sessInf As New SessionInfo
                    Dim i As Long = 0
                    Dim line As String = SR.ReadLine()

                    Dim IgnoreSession As Boolean = False

                    sessInf.name = EntryName
                    sessInf.host = ""
                    sessInf.protocol = 0
                    sessInf.username = ""
                    sessInf.port = 0
                    If My.Settings.DefaultMode = "Interactive" Then
                        sessInf.interactive = True
                    Else
                        sessInf.interactive = False
                    End If
                    sessInf.sockets = ""
                    Do

                        'S:"Hostname"=10.210.3.18
                        'S:"Protocol Name"=SSH2
                        'S:"Username"=root


                        If Not line = "" Then
                            If line.Contains("S:""Hostname""") Then
                                temp = line.Split("=")
                                sessInf.host = temp(1)
                                Debug.Print("Host:" & temp(1))
                            End If
                            If line.Contains("S:""Protocol Name""") Then

                                temp = line.Split("=")
                                EntryProtocol = temp(1)
                                Debug.Print("Protocol:" & temp(1))
                                Select Case EntryProtocol
                                    Case "Telnet"
                                        sessInf.protocol = 0
                                    Case "SSH"
                                        sessInf.protocol = 1
                                    Case "SSH2"
                                        sessInf.protocol = 1
                                    Case "RDP"
                                        sessInf.protocol = 3
                                End Select
                                If My.Settings.SecureCRTImportOnlysshtelntrdp = True Then
                                    If EntryProtocol = "SSH" Or EntryProtocol = "SSH2" Or EntryProtocol = "Telnet" Or EntryProtocol = "RDP" Then
                                        IgnoreSession = False
                                    Else
                                        IgnoreSession = True
                                    End If
                                End If

                            End If
                            If line.Contains("S:""Username""") Then
                                temp = line.Split("=")
                                sessInf.username = temp(1)
                                Debug.Print("user:" & temp(1))
                            End If
                            If line.Contains("S:""Password V2""") Then
                                temp = line.Split("=")
                                sessInf.password = temp(1)
                                Debug.Print("password:" & temp(1))
                            End If
                            If line.Contains("D:""Port""") Then
                                temp = line.Split("=")
                                EntryPort = temp(1)
                                EntryPort = Convert.ToInt64(EntryPort, 16)
                            End If


                        End If
                        line = SR.ReadLine
                    Loop While Not line = String.Empty

                    If sessInf.host = "10.230.1.20" Then
                        Debug.Print("now")
                    End If

                    If EntryProtocol.Contains("Telnet") Then
                        If EntryPort = "" Then
                            sessInf.port = 23
                            sessInf.protocol = 0
                        Else
                            If checkforInt(EntryPort) Then
                                sessInf.port = EntryPort
                                sessInf.protocol = 0
                            Else
                                sessInf.port = 23
                                sessInf.protocol = 0
                            End If
                        End If
                    ElseIf EntryProtocol.Contains("SSH") Then
                        If EntryPort = "" Then
                            sessInf.port = 22
                            sessInf.protocol = 1
                        Else
                            If checkforInt(EntryPort) Then
                                sessInf.port = EntryPort
                                sessInf.protocol = 1
                            Else
                                sessInf.port = 22
                                sessInf.protocol = 1
                            End If
                        End If
                    ElseIf EntryProtocol.Contains("RDP") Then
                        If EntryPort = "" Then
                            sessInf.port = 3389
                            sessInf.protocol = 3
                        Else
                            If checkforInt(EntryPort) Then
                                sessInf.port = EntryPort
                                sessInf.protocol = 3
                            Else
                                sessInf.port = 3389
                                sessInf.protocol = 3
                            End If
                        End If
                    End If
                    If sessInf.port = 0 Then
                        sessInf.port = 23
                        sessInf.protocol = 0
                        Log.Debug("no port detect in import from " & sessInf.name)
                    End If
                    If IgnoreSession = False Then
                        saveSessionInfo(NewSessionFile, sessInf)
                    Else
                        Log.Info("ignoring session from " & filename)
                    End If

                    'myNode(0).Nodes.Add(newIndex, EntryName)
                    SR.Close()

                End If
            Next



        End If



        BuildTreeView()
    End Sub

    Function checkforInt(value As String) As Boolean
        Dim res As Integer
        If Integer.TryParse(value, res) Then
            Return True
        Else
            Return False
        End If


    End Function

    Private Function AESE(ByVal plaintext As String, ByVal key As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim SHA256 As System.Security.Cryptography.SHA256
        Dim ciphertext As String = ""
        Try
            AES.GenerateIV()
            AES.Key = SHA256.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(key))

            AES.Mode = System.Security.Cryptography.CipherMode.CBC
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(plaintext)
            ciphertext = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))

            Return Convert.ToBase64String(AES.IV) & Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))

        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Private Function AESD(ByVal ciphertext As String, ByVal key As String) As String
        Dim AES As New System.Security.Cryptography.RijndaelManaged
        Dim SHA256 As System.Security.Cryptography.SHA256
        Dim plaintext As String = ""
        Dim iv As String = ""
        Try
            Dim ivct = ciphertext.Split({"=="}, StringSplitOptions.None)
            iv = ivct(0) & "=="
            ciphertext = If(ivct.Length = 3, ivct(1) & "==", ivct(1))

            AES.Key = SHA256.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(key))
            AES.IV = Convert.FromBase64String(iv)
            AES.Mode = System.Security.Cryptography.CipherMode.CBC
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = AES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(ciphertext)
            plaintext = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
            Return plaintext
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function


End Module

Public Class Level0NodeSorter
    Implements System.Collections.IComparer

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim node As System.Windows.Forms.TreeNode = TryCast(x, System.Windows.Forms.TreeNode)
        Return If(node.Level = 0 AndAlso node.Nodes.Count > 0, 1, 0)
    End Function
End Class

Friend Class CustomNodeSorter
    Implements System.Collections.IComparer

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        ' cast the parameters to tree nodes...
        Dim clsNodeX As TreeNode = DirectCast(x, TreeNode)
        Dim clsNodeY As TreeNode = DirectCast(y, TreeNode)
        ' compare based on the level within the tree - you can
        ' modify this to match whatever criteria you want...
        If Not clsNodeX.Parent Is Nothing Then
            ' child nodes should be sorted descending...
            Return clsNodeX.Text.CompareTo(clsNodeY.Text) * +1
        Else
            ' parent nodes should be sorted ascending...
            Return clsNodeX.Text.CompareTo(clsNodeY.Text)
        End If

    End Function
End Class

Public Class XMCInfo
    Private bConnected As Boolean
    Private sAnfrage As String
    Private sStatus As String
    Private sMessage As String
    Private jDevices As Newtonsoft.Json.Linq.JArray
    Private jProfiles As Newtonsoft.Json.Linq.JArray
    Private bSessionCreds As Boolean
    Private sSessionUser As String
    Private sSessionPassword As String
    Private bImportProfiles As Boolean


    Public Property Devices() As Newtonsoft.Json.Linq.JArray
        Get
            Devices = jDevices
        End Get
        Set(ByVal Value As Newtonsoft.Json.Linq.JArray)
            jDevices = Value
        End Set
    End Property
    Public Property Profiles() As Newtonsoft.Json.Linq.JArray
        Get
            Profiles = jProfiles
        End Get
        Set(ByVal Value As Newtonsoft.Json.Linq.JArray)
            jProfiles = Value
        End Set
    End Property

    Public Property Connected() As Boolean
        Get
            Connected = bConnected
        End Get
        Set(ByVal Value As Boolean)
            bConnected = Value
        End Set
    End Property
    Public Property Anfrage() As String
        Get
            Anfrage = sAnfrage
        End Get
        Set(ByVal Value As String)
            sAnfrage = Value
        End Set
    End Property
    Public Property Status() As String
        Get
            Status = sStatus
        End Get
        Set(ByVal Value As String)
            sStatus = Value
        End Set
    End Property
    Public Property Message() As String
        Get
            Message = sMessage
        End Get
        Set(ByVal Value As String)
            sMessage = Value
        End Set
    End Property
    Public Property SessionCreds() As Boolean
        Get
            SessionCreds = bSessionCreds
        End Get
        Set(ByVal Value As Boolean)
            bSessionCreds = Value
        End Set
    End Property
    Public Property SessionUser() As String
        Get
            SessionUser = sSessionUser
        End Get
        Set(ByVal Value As String)
            sSessionUser = Value
        End Set
    End Property

    Public Property SessionPassword() As String
        Get
            SessionPassword = sSessionPassword
        End Get
        Set(ByVal Value As String)
            sSessionPassword = Value
        End Set
    End Property
    Public Property ImportProfiles() As Boolean
        Get
            ImportProfiles = bImportProfiles
        End Get
        Set(ByVal Value As Boolean)
            bImportProfiles = Value
        End Set
    End Property
End Class


Public Class SessionInfo
    Private sname As String
    Private shost As String
    Private iport As Integer
    Private iprofile As Integer
    Private susername As String
    Private spassword As String
    Private iprotocol As Integer
    Private binteractive As Boolean
    Private sSockets As String

    Public Property name() As String
        Get
            name = sname
        End Get
        Set(ByVal Value As String)
            sname = Value
        End Set
    End Property
    Public Property host() As String
        Get
            host = shost
        End Get
        Set(ByVal Value As String)
            shost = Value
        End Set
    End Property
    Public Property port() As Integer
        Get
            port = iport
        End Get
        Set(ByVal Value As Integer)
            iport = Value
        End Set
    End Property
    Public Property profile() As Integer
        Get
            profile = iprofile
        End Get
        Set(ByVal Value As Integer)
            iprofile = Value
        End Set
    End Property
    Public Property username() As String
        Get
            username = susername
        End Get
        Set(ByVal Value As String)
            susername = Value
        End Set
    End Property
    Public Property password() As String
        Get
            password = spassword
        End Get
        Set(ByVal Value As String)
            spassword = Value
        End Set
    End Property
    Public Property protocol() As Integer
        Get
            protocol = iprotocol
        End Get
        Set(ByVal Value As Integer)
            iprotocol = Value
        End Set
    End Property
    Public Property interactive() As Boolean
        Get
            interactive = binteractive
        End Get
        Set(ByVal Value As Boolean)
            binteractive = Value
        End Set
    End Property
    Public Property sockets() As String
        Get
            sockets = ssockets
        End Get
        Set(ByVal Value As String)
            ssockets = Value
        End Set
    End Property

End Class


Public Class XIQSettings


    'XMC
    Private sXMCServer As String
    Private sXMCToken As String
    Private bXMCUseToken As Boolean
    Private sXMCClientID As String
    Private sXMCUser As String
    Private sXMCPassword As String
    Private iXMCSleepDeleteTimer As Integer
    Private sNewFolderName As String
    Private bSessionCreds As Boolean
    Private sSessionUser As String
    Private sSessionPassword As String
    Private bImportProfiles As Boolean


    'XMC Login
    Public Property NewFolderName() As String
        Get
            NewFolderName = sNewFolderName
        End Get
        Set(ByVal Value As String)
            sNewFolderName = Value
        End Set
    End Property
    Public Property XMCServer() As String
        Get
            XMCServer = sXMCServer
        End Get
        Set(ByVal Value As String)
            sXMCServer = Value
        End Set
    End Property


    Public Property XMCUser() As String
        Get
            XMCUser = sXMCUser
        End Get
        Set(ByVal Value As String)
            sXMCUser = Value
        End Set
    End Property

    Public Property XMCUseToken() As Boolean
        Get
            XMCUseToken = bXMCUseToken
        End Get
        Set(ByVal Value As Boolean)
            bXMCUseToken = Value
        End Set
    End Property

    Public Property XMCToken() As String
        Get
            XMCToken = sXMCToken
        End Get
        Set(ByVal Value As String)
            sXMCToken = Value
        End Set
    End Property

    Public Property XMCClientID() As String
        Get
            XMCClientID = sXMCClientID
        End Get
        Set(ByVal Value As String)
            sXMCClientID = Value
        End Set
    End Property

    Public Property XMCPassword() As String
        Get
            XMCPassword = sXMCPassword
        End Get
        Set(ByVal Value As String)
            sXMCPassword = Value
        End Set
    End Property
    Public Property XMCSleepDeleteTimer() As Integer
        Get
            XMCSleepDeleteTimer = iXMCSleepDeleteTimer
        End Get
        Set(ByVal Value As Integer)
            iXMCSleepDeleteTimer = Value
        End Set
    End Property
    Public Property SessionCreds() As Boolean
        Get
            SessionCreds = bSessionCreds
        End Get
        Set(ByVal Value As Boolean)
            bSessionCreds = Value
        End Set
    End Property
    Public Property SessionUser() As String
        Get
            SessionUser = sSessionUser
        End Get
        Set(ByVal Value As String)
            sSessionUser = Value
        End Set
    End Property

    Public Property SessionPassword() As String
        Get
            SessionPassword = sSessionPassword
        End Get
        Set(ByVal Value As String)
            sSessionPassword = Value
        End Set
    End Property
    Public Property ImportProfiles() As Boolean
        Get
            ImportProfiles = bImportProfiles
        End Get
        Set(ByVal Value As Boolean)
            bImportProfiles = Value
        End Set
    End Property

End Class