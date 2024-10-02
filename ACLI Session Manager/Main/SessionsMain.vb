
Imports System.IO
Imports System.Text
Imports AutoUpdaterDotNET
Imports NLog

Public Class SessionsMain

    Public ActiveSearch As Boolean = False

    Public LastExpandedTag As String = ""
    Public ExpandLastTag As String = ""
    Public selectedLastNodeFolder As TreeNode

    Public targetF As New NLog.Targets.FileTarget

    Private Sub SessionsMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.Title & " v" & System.String.Format("{0}.{1:00}", My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.MinorRevision) & " (b" & My.Application.Info.Version.Revision & ")"
        'AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\.acli\")
        Debug.Print(My.Settings.DefaultFolderPath)
        If My.Settings.DefaultFolderPath = "" Then
            My.Settings.DefaultFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\.acli\"
        End If

        SessionsFolder = My.Settings.DefaultFolderPath & "ACLISessionManager\Sessions"
        Debug.Print(My.Settings.DefaultFolderPath)
        targetF.ArchiveNumbering = NLog.Targets.ArchiveNumberingMode.Date
        targetF.ArchiveDateFormat = "yyyyMMdd"
        targetF.ArchiveFileName = "ACLISessionManager/log.{#}.txt"
        targetF.ArchiveEvery = NLog.Targets.FileArchivePeriod.Day
        targetF.FileName = My.Settings.DefaultFolderPath & "ACLISessionManager/log.txt"
        targetF.KeepFileOpen = False
        targetF.Layout = "${longdate} - ${level} - ${message}"

        Dim LLevel As NLog.LogLevel = NLog.LogLevel.Info

        Select Case My.Settings.LogLevel
            Case "Info"
                LLevel = NLog.LogLevel.Info
            Case "Debug"
                LLevel = NLog.LogLevel.Debug
            Case "Error"
                LLevel = NLog.LogLevel.Error
            Case "Warning"
                LLevel = NLog.LogLevel.Warn
            Case "Trace"
                LLevel = NLog.LogLevel.Trace
            Case "Fatal"
                LLevel = NLog.LogLevel.Fatal
        End Select

        NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(targetF, LLevel)


        dict_protocol.Add(0, "telnet")
        dict_protocol.Add(1, "ssh")
        dict_protocol.Add(2, "terminal")
        dict_protocol.Add(3, "rdp")


        ProfileTable = LoadCSV("Profiles", "profile")
        BuildTreeView()
        Debug.Print("SessionsCount:" & TVSessions.Nodes.Count)
        bgwXIQSEImport.WorkerReportsProgress = True

        If My.Settings.ChecforUpdateonStartup = True Then CheckforUpdate()
    End Sub

    Private Sub NewSessionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewSessionToolStripMenuItem.Click
        CreateNewSession()
    End Sub

    Sub CreateNewSession()
        If TVSessions.SelectedNodes.Count > 0 Then
            If Not TVSessions.SelectedNodes(0) Is Nothing Then

                'New
                SessionEntry.NewSessionPath = TVSessions.SelectedNodes(0).Tag
                SessionEntry.EditMode = SessionEntry.EditModeEnum.NewSession
                SessionEntry.Show()

            End If
        End If
    End Sub

    Private Sub NewFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewFolderToolStripMenuItem.Click
        Dim newfolder As String = InputBox("New Folder:", "New Folder", "")
        If newfolder IsNot "" Then

            For Each c In Path.GetInvalidFileNameChars()
                newfolder = newfolder.Replace(c, "_").Trim
            Next

            My.Computer.FileSystem.CreateDirectory(IO.Path.GetDirectoryName(TVSessions.SelectedNodes(0).Tag) & "\" & newfolder)

            BuildTreeView()
        End If
    End Sub

    Sub CloneSession()
        If TVSessions.SelectedNodes.Count > 1 Then
            MsgBox("Multiclone not supported")

        ElseIf TVSessions.SelectedNodes.Count = 1 Then
            If Not TVSessions.SelectedNodes(0).Tag = "Sessions" Then

                If isDirectory(TVSessions.SelectedNodes(0).Tag) Then
                    MsgBox("Folder clone not supported")
                Else 'Session
                    SessionEntry.EditSessionEntryFile = TVSessions.SelectedNodes(0).Tag

                    Dim NewSessionFile As String = TVSessions.SelectedNodes(0).Tag
                    Dim NewSessionName As String = InputBox("New Session name:", "Clone of " & Path.GetFileName(TVSessions.SelectedNodes(0).Tag), "Clone of " & Path.GetFileName(TVSessions.SelectedNodes(0).Tag))
                    If NewSessionName IsNot "" Then
                        NewSessionFile = NewSessionFile.Replace(Path.GetFileName(TVSessions.SelectedNodes(0).Tag), NewSessionName)
                        Dim OldSessInf As New SessionInfo
                        OldSessInf = getSessionInfo(TVSessions.SelectedNodes(0).Tag)

                        Dim NewSessInf As New SessionInfo

                        NewSessInf.name = NewSessionName
                        NewSessInf.host = OldSessInf.host
                        NewSessInf.protocol = OldSessInf.protocol
                        NewSessInf.username = OldSessInf.username
                        NewSessInf.password = OldSessInf.password
                        NewSessInf.profile = OldSessInf.profile
                        NewSessInf.port = OldSessInf.port
                        saveSessionInfo(NewSessionFile, NewSessInf)


                        BuildTreeView()

                    End If
                End If

            End If
        Else

        End If

    End Sub

    Public Sub ExpandLastTagSub()

        Dim temp As String = ExpandLastTag
        temp = temp.Replace(SessionsFolder & "\", "")
        temp = temp.Replace(FolderSessionIni, "")
        Dim Expansion() As String = temp.Split("\")
        For i = 0 To Expansion.Length - 1
            Debug.Print(Expansion(i))
            Debug.Print("Level: " & SessionsFolder & "\" & Expansion(i) & FolderSessionIni)
        Next

        'TVSessions.SelectedNode = selectedLastNodeFolder

    End Sub

    Private Sub cmsSessions_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmsSessions.Opening

        'If TVSessions.SelectedNode.SelectedImageIndex = 0 Then NewSessionToolStripMenuItem.Enabled = False Else NewSessionToolStripMenuItem.Enabled = True
        Try
            If TVSessions.SelectedNodes(0).SelectedImageIndex >= 1 Then
                NewFolderToolStripMenuItem.Enabled = False
                NewSessionToolStripMenuItem.Enabled = False
                LaunchToolStripMenuItem.Enabled = True
                CloneToolStripMenuItem.Enabled = True
            Else
                NewFolderToolStripMenuItem.Enabled = True
                NewSessionToolStripMenuItem.Enabled = True
                LaunchToolStripMenuItem.Enabled = False
                CloneToolStripMenuItem.Enabled = False
            End If
            If TVSessions.SelectedNodes(0).Nodes Is Nothing Then
                DeleteToolStripMenuItem.Enabled = False
            Else
                DeleteToolStripMenuItem.Enabled = True
            End If
        Catch ex As Exception
            e.Cancel = True
        End Try

    End Sub

    Private Sub TVSessions_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TVSessions.NodeMouseClick
        ''TVSessions.SelectedNodes(0) = e.Node
        ''UncheckNodes()
        'If TVSessions.SelectedNodes.Count > 1 Then
        '    Dim myRow() As Data.DataRow
        '    myRow = SessionTable.Select("ID = '" & TVSessions.SelectedNodes(0).Name & "'")
        '    If myRow.Length = 1 Then
        '        myRow(0)("TreeFolderOpen") = TVSessions.SelectedNodes(0).IsExpanded
        '    End If
        'End If

    End Sub

    Private Sub LaunchToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaunchToolStripMenuItem.Click
        LaunchSession(TVSessions.SelectedNodes)
    End Sub


    'Sub LaunchSession(ByVal host As String)
    Sub LaunchSession(MultiSessionNodes As CodersLab.Windows.Controls.NodesCollection)

        Dim SortedArr As New List(Of String)
        For Each node As TreeNode In MultiSessionNodes
            SortedArr.Add(node.Tag)
        Next
        SortedArr.Sort()

        For Each item In SortedArr

            'For Each n As TreeNode In MultiSessionNodes

            Dim SessInf As New SessionInfo
            SessInf = getSessionInfo(item)

            If item.EndsWith(FolderSessionIni) Then 'Folder

            Else
                Dim User, Pass, Mode As String
                If Not SessInf.profile = 0 Then
                    Dim myProfileRow() As Data.DataRow
                    myProfileRow = ProfileTable.Select("ProfileID = '" & SessInf.profile & "'")

                    User = myProfileRow(0)("user")
                    Pass = DecryptString_Aes(myProfileRow(0)("pass"))
                Else
                    User = SessInf.username
                    Pass = SessInf.password
                End If
                Dim UserString As String = ""
                If User <> Nothing Or Not User = "" Then
                    UserString = User
                    If Pass <> Nothing Or Not Pass = "" Then
                        UserString = UserString & ":" & Pass
                    End If
                    If SessInf.protocol = 1 Then 'ssh
                        UserString = " -l " & UserString & " "
                    ElseIf SessInf.protocol = 0 Then 'telnet
                        UserString = " " & UserString & "@"
                    Else 'trmsrv
                        UserString = ""
                    End If
                End If

                If SessInf.interactive = True Then
                    Mode = " "
                    'Mode = " -t "
                    If SessInf.protocol = 2 Then
                        Mode = " -n "
                    End If
                Else
                    Mode = " -n "
                End If


                Dim Sockets As String = SessInf.sockets

                If Not Sockets = "" Then
                    Sockets = "-s """ & Sockets & """ "
                End If

                Dim Hosts, TabName, Porti As String
                Hosts = SessInf.host
                If SessInf.port >= 1 Then
                    Porti = " " & Convert.ToString(SessInf.port)
                Else
                    Porti = ""
                End If
                'Dim ProcRuns As Boolean
                Dim WindowName As String = tbContainWindow.Text
                If WindowName = "" Then
                    WindowName = "ACLI"
                End If

                If SessInf.protocol = 2 Then
                    TabName = Hosts & ":" & Convert.ToString(SessInf.port)
                Else
                    TabName = Hosts
                End If
                'ProcRuns = CheckIfRunning(WindowName)


                If SessInf.protocol = 3 Then 'rdp

                    RDP.Show()
                    If Not SessInf.profile = 0 Then
                        Dim myProfileRow() As Data.DataRow
                        myProfileRow = ProfileTable.Select("ProfileID = '" & SessInf.profile & "'")

                        SessInf.username = myProfileRow(0)("user")
                        SessInf.password = DecryptString_Aes(myProfileRow(0)("pass"))
                    End If
                    RDP.NewSession(SessInf)
                Else
                    Dim pHelp As New ProcessStartInfo
                    pHelp.FileName = "console.exe"
                    Log.Debug("reuse -i """ & WindowName & """ -w """ & WindowName & """ -n " & SessInf.name & " -r """ & Mode & UserString & Sockets & Hosts & Porti & """")
                    Debug.Print("reuse -i """ & WindowName & """ -w """ & WindowName & """ -n " & SessInf.name & " -r """ & Mode & UserString & Sockets & Hosts & Porti & """")
                    pHelp.Arguments = "reuse -i """ & WindowName & """ -w """ & WindowName & """ -n " & SessInf.name & " -r """ & Mode & UserString & Sockets & Hosts & Porti & """"
                    'Debug.Print("-reuse -i " & myRow(0)("name") & " -w " & myRow(0)("name") & " -r -l " & myRow(0)("user") & ":" & myRow(0)("pass") & " " & myRow(0)("host"))
                    'pHelp.Arguments = "-reuse -i " & myRow(0)("name") & " -w " & myRow(0)("name") & " -r -l " & myRow(0)("user") & ":" & myRow(0)("pass") & " " & myRow(0)("host")
                    pHelp.UseShellExecute = True
                    pHelp.WindowStyle = ProcessWindowStyle.Normal
                    Dim proc As Process = Process.Start(pHelp)
                    System.Threading.Thread.Sleep(1000)
                End If



                'Dim pHelp As New ProcessStartInfo
                'pHelp.FileName = "acli.bat"
                'pHelp.Arguments = "-l " & myRow(0)("user") & ":" & myRow(0)("pass") & " " & myRow(0)("host")
                'pHelp.UseShellExecute = True
                'pHelp.WindowStyle = ProcessWindowStyle.Normal
                'Dim proc As Process = Process.Start(pHelp)
                '"%ACLIDIR%\acli.bat" -l admin[:password] 192.168.10.1
            End If
        Next
    End Sub

    Dim p() As Process

    Private Function CheckIfRunning(ByVal ProcName As String) As Boolean
        p = Process.GetProcesses
        For Each prc In p
            Debug.Print("Title:" & prc.MainWindowTitle)
            Debug.Print("Name:" & prc.ProcessName)
        Next

        If p.Count > 0 Then
            ' Process is running
            CheckIfRunning = True
        Else
            ' Process is not running
            CheckIfRunning = False
        End If
        Return CheckIfRunning
    End Function

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click, tsmiEditSession.Click
        EditNode()

    End Sub
    Private Function GetCheck(ByVal node As TreeNodeCollection) As List(Of
TreeNode)
        Dim lN As New List(Of TreeNode)
        For Each n As TreeNode In node
            If n.Checked Then lN.Add(n)
            lN.AddRange(GetCheck(n.Nodes))
        Next

        Return lN
    End Function
    Sub EditNode()

        If TVSessions.SelectedNodes.Count > 1 Then

            SessionEntry.EditMode = SessionEntry.EditModeEnum.MultiEditSession
            SessionEntry.MultiSessionNodes = TVSessions.SelectedNodes
            SessionEntry.Show()

        ElseIf TVSessions.SelectedNodes.Count = 1 Then
            If Not TVSessions.SelectedNodes(0).Tag = SessionsFolder & FolderSessionIni Then

                If isDirectory(TVSessions.SelectedNodes(0).Tag) Then 'Folder

                    SessionEntry.EditSessionOrgName = GetFolderName(TVSessions.SelectedNodes(0).Tag)
                    SessionEntry.EditMode = SessionEntry.EditModeEnum.FolderEdit
                    SessionEntry.EditSessionEntryFile = TVSessions.SelectedNodes(0).Tag
                    SessionEntry.Show()
                Else 'Session
                    SessionEntry.EditSessionOrgName = IO.Path.GetFileName(TVSessions.SelectedNodes(0).Tag).Replace(".ini", "")
                    SessionEntry.EditMode = SessionEntry.EditModeEnum.EditSession
                    SessionEntry.EditSessionEntryFile = TVSessions.SelectedNodes(0).Tag
                    SessionEntry.Show()
                End If
            Else

                SessionEntry.EditSessionOrgName = GetFolderName(TVSessions.SelectedNodes(0).Tag)
                SessionEntry.EditMode = SessionEntry.EditModeEnum.FolderEdit
                'SessionEntry.EditSessionEntryName = TVSessions.SelectedNode.Text
                SessionEntry.EditRootFolder = True
                SessionEntry.EditSessionEntryFile = TVSessions.SelectedNodes(0).Tag
                SessionEntry.Show()
            End If
        Else

        End If
    End Sub

    Private Sub TVSessions_AfterLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles TVSessions.AfterLabelEdit
        e.CancelEdit = True ' Switch OFF standard edit-end and set values manuell.

        If IsNothing(TVSessions.SelectedNode) Then Return ' Unknown error - impossible.
        If IsNothing(e.Label) Then Return ' Canceled from user.

        If 1 > e.Label.Length Then ' Set x.Text = F(x.Name)
            TVSessions.SelectedNodes(0).Text = "NodeDefaultText_" + TVSessions.SelectedNodes(0).Name
        Else
            TVSessions.SelectedNodes(0).Text = e.Label ' Same as by "standard edit-end"
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click, tsmiDeleteSession.Click
        deleteSessionEntry(sender.ToString)
    End Sub

    Sub deleteSessionEntry(ByVal Caller As String)
        Debug.Print("Caled Byte: " & Caller)
        Try
            If Not TVSessions.SelectedNodes(0).Tag.ToString.EndsWith(FolderSessionIni) Then
                If IO.File.Exists(TVSessions.SelectedNodes(0).Tag) Then
                    If MsgBox("Do you realy want to delete the session?", MsgBoxStyle.YesNoCancel, "Delete Session") = MsgBoxResult.Yes Then
                        IO.File.Delete(TVSessions.SelectedNodes(0).Tag)
                    End If
                End If
            Else
                If IO.Directory.Exists(Path.GetDirectoryName(TVSessions.SelectedNodes(0).Tag)) Then
                    If MsgBox("Do you realy want to delete the folder and all subfolder/sessions?", MsgBoxStyle.YesNoCancel, "Delete Sessions") = MsgBoxResult.Yes Then
                        IO.Directory.Delete(Path.GetDirectoryName(TVSessions.SelectedNodes(0).Tag), True)
                    End If
                End If
            End If
            BuildTreeView()
        Catch ex As Exception
            Debug.Print("no node selected")
        End Try


    End Sub

    Private Sub tsmiProfileManager_Click(sender As Object, e As EventArgs) Handles tsmiProfileManager.Click
        ProfileManager.Show()
    End Sub

    Private Sub delete_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        deleteSessionEntry(sender.ToString)
    End Sub

    Private Sub editSession_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        EditNode()
    End Sub

    Private Sub Launch_Click(sender As Object, e As EventArgs) Handles Launch.Click
        LaunchSession(TVSessions.SelectedNodes)
    End Sub

    Public Sub Search()
        ActiveSearch = True
        BuildTreeView()







        'TVSessions.Nodes.Add("0", "Sessions", 0, 0)
        'For Each dr As DataRow In SessionTable.Rows
        '    Debug.Print("TreeNodeParentID:" & dr("TreeNodeParentID"))
        '    Log.Debug("TreeNodeParentID:" & dr("TreeNodeParentID"))
        '    Dim myNode() As TreeNode
        '    myNode = TVSessions.Nodes.Find(dr("TreeNodeParentID"), True)
        '    Log.Debug("TreeNodeType:" & dr("TreeNodeType"))
        '    Debug.Print("TreeNodeType:" & dr("TreeNodeType"))
        '    Debug.Print("ID:" & dr("ID"))
        '    Log.Debug("ID:" & dr("ID"))
        '    Debug.Print("Name:" & dr("name"))
        '    Log.Debug("Name:" & dr("name"))
        '    Try
        '        If dr("TreeNodeType") = 0 Then 'Folder
        '            Dim nNode As New TreeNode
        '            nNode.Tag = dr("ID")
        '            nNode.Text = dr("name")
        '            nNode.ImageIndex = 0
        '            nNode.SelectedImageIndex = 0
        '            nNode.ToolTipText = dr("host")
        '            myNode(0).Nodes.Add(nNode)
        '            'myNode(0).Nodes.Add(dr("ID"), dr("name"), 0, 0)
        '        Else 'Session
        '            If Convert.ToString(dr("name")).ToLower.Contains(txtFilter.Text) Then
        '                Dim nNode As New TreeNode
        '                nNode.Tag = dr("ID")
        '                nNode.Text = dr("name")
        '                nNode.ImageIndex = 1
        '                nNode.SelectedImageIndex = 1
        '                nNode.ToolTipText = dr("host") & "#" & dr("port")
        '                myNode(0).Nodes.Add(nNode)
        '                'myNode(0).Nodes.Add(dr("ID"), dr("name"), 1, 1)
        '            End If
        '        End If

        '    Catch ex As Exception
        '        Log.Error("searchbar: " & ex.Message)
        '    End Try
        'Next



        'TVSessions.TreeViewNodeSorter = New Level0NodeSorter
        'TVSessions.ExpandAll()
        'ColorNodes(txtFilter.Text.ToUpper)
        'tsslFilter.Visible = True
        'tsslFilter.Text = "found " & Convert.ToInt32(matchedNodes.Count / 2) & " matches" ' out of " & Convert.ToInt32(matchedNodes.Count + unmatchedNodes.Count)
        'TVSessions.Sort()
        TVSessions.ExpandAll()
    End Sub
















    Dim matchedNodes As List(Of TreeNode) = New List(Of TreeNode)
    Dim unmatchedNodes As List(Of TreeNode) = New List(Of TreeNode)
    Private Sub ColorNodes(ByVal Filter As String)
        matchedNodes.Clear()
        unmatchedNodes.Clear()
        If Not String.IsNullOrEmpty(Filter) Then
            TVSessions.BeginUpdate()
            For Each node As TreeNode In TVSessions.Nodes
                FindRecursive(node, Filter)
            Next
            TVSessions.EndUpdate()

        End If
        For Each match In matchedNodes
            match.BackColor = Color.Yellow
            match.EnsureVisible()
        Next
        For Each match In unmatchedNodes
            match.BackColor = TVSessions.BackColor
        Next




    End Sub
    Private Sub FindRecursive(treeNode As TreeNode, ByVal Filter As String)
        treeNode.BackColor = Color.White
        If treeNode.Text.ToUpper.Contains(Filter) Then
            matchedNodes.Add(treeNode)
        Else
            unmatchedNodes.Add(treeNode)
        End If

        'If treeNode.Nodes.Count = 0 Then
        '    Debug.Print(treeNode.Text)
        '    TVSessions.Nodes.Remove(treeNode)
        'Else
        For Each node As TreeNode In treeNode.Nodes
            ' Try
            If node.Text.ToUpper.Contains(Filter) Then
                matchedNodes.Add(node)
            Else
                unmatchedNodes.Add(node)
            End If
            FindRecursive(node, Filter)
            'Catch ex As Exception
            'Debug.Print("ERROR: node filter: " & ex.Message)
            'End Try

        Next
        'End If
    End Sub







    Private Sub btFilter_Click(sender As Object, e As EventArgs) Handles btFilter.Click
        txtFilter.Text = ""
        ActiveSearch = False
        'TVSessions.CollapseAll()
        BuildTreeView()

        tsslFilter.Visible = False
    End Sub

    Private Sub tsmiSecureCRT_Click(sender As Object, e As EventArgs) Handles tsmiSecureCRT.Click
        Import_SecureCRT()
    End Sub

    Sub Import_SecureCRT()
        Dim fbd As New FolderBrowserDialog
        If fbd.ShowDialog = DialogResult.OK Then
            'Create RootNode for SecureCRT
            ImportCRTSesions(fbd.SelectedPath)

            For Each tn As TreeNode In TVSessions.Nodes
                tn.Expand()
            Next
        End If
    End Sub

    Private Sub tsmiNewSession_Click_1(sender As Object, e As EventArgs) Handles tsmiNewSession.Click
        CreateNewSession()
    End Sub

    Private Sub tsbtUpdate_Click(sender As Object, e As EventArgs) Handles tsbtUpdate.Click
        CheckforUpdate()
    End Sub
    Sub CheckforUpdate()
        AutoUpdater.ShowSkipButton = False
        AutoUpdater.Start("https://www.xiosoft.net/downloads/ACLISessionMgr/ACLISessionMgr.update")
    End Sub

    Private Sub TVSessions_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TVSessions.NodeMouseDoubleClick
        If e.Button = MouseButtons.Left Then
            UncheckNodes()
            e.Node.Checked = True

            If My.Settings.DoubleClickAction = "launch" Then LaunchSession(TVSessions.SelectedNodes) Else EditNode()

        End If
    End Sub

    Sub UncheckNodes()
        For Each node As TreeNode In TVSessions.Nodes
            node.Checked = False
            CheckChildren(node, False)
        Next
    End Sub

    Private Sub CheckChildren(rootNode As TreeNode, isChecked As Boolean)
        For Each node As TreeNode In rootNode.Nodes
            node.Checked = isChecked
        Next
    End Sub

    Private Sub TVSessions_AfterCollapse(sender As Object, e As TreeViewEventArgs) Handles TVSessions.AfterCollapse
        If ActiveSearch = False Then
            e.Node.Nodes.Clear()
            e.Node.Nodes.Add("*EMPTY*")
        End If
    End Sub

    Private Sub TVSessions_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles TVSessions.BeforeExpand

        addChildNodes(e.Node, e.Node.Tag.ToString)
        LastExpandedTag = e.Node.Tag.ToString
        selectedLastNodeFolder = e.Node
    End Sub



    Sub addChildNodes(tn As TreeNode, FolderName As String)
        tn.Nodes.Clear()
        FolderName = IO.Path.GetDirectoryName(FolderName)
        Dim inspectDirectoryInfo As IO.DirectoryInfo = New IO.DirectoryInfo(FolderName)

        For Each directoryInfoItem As IO.DirectoryInfo In inspectDirectoryInfo.GetDirectories

            Dim NewFolderNode As New TreeNode
            NewFolderNode.Name = directoryInfoItem.Name
            Debug.Print("TreeNodeType: Folder")
            Debug.Print("Tag:" & directoryInfoItem.FullName)
            Debug.Print("Name:" & directoryInfoItem.Name)
            Log.Debug("TreeNodeType: Folder")
            Log.Debug("Tag:" & directoryInfoItem.FullName)
            Log.Debug("Name:" & directoryInfoItem.Name)
            NewFolderNode.Name = directoryInfoItem.FullName & FolderSessionIni
            NewFolderNode.Tag = directoryInfoItem.FullName & FolderSessionIni
            NewFolderNode.Text = directoryInfoItem.Name


            NewFolderNode.ImageKey = returnIconImageName("folder", True)
            NewFolderNode.SelectedImageKey = returnIconImageName("folder", True)
            'NewFolderNode.ImageIndex = returnIconImageName("folder", False)
            'NewFolderNode.SelectedImageIndex = returnIconImageName("folder", False)
            NewFolderNode.Nodes.Add("*EMPTY*")
            NewFolderNode.ToolTipText = directoryInfoItem.Name

            If ActiveSearch = True Then
                If directoryInfoItem.Name.Contains(txtFilter.Text) Then
                    NewFolderNode.BackColor = Color.Yellow
                End If
            End If

            tn.Nodes.Add(NewFolderNode)


        Next

        For Each fileItem As String In IO.Directory.GetFiles(FolderName, "*.ini", IO.SearchOption.TopDirectoryOnly)
            'For Each fileItem As IO.FileInfo In inspectDirectoryInfo.GetFiles
            If Not IO.Path.GetFileName(fileItem) = "__FolderData__.ini" Then

                Dim newNode As New TreeNode
                Dim SessInf As New SessionInfo
                SessInf = getSessionInfo(fileItem)

                Debug.Print("TreeNodeType: File")
                Debug.Print("Tag:" & fileItem)
                Debug.Print("Name:" & IO.Path.GetFileName(fileItem))
                Log.Debug("TreeNodeType: File")
                Log.Debug("Tag:" & fileItem)
                Log.Debug("Name:" & IO.Path.GetFileName(fileItem))
                newNode.Name = fileItem
                newNode.Tag = fileItem
                newNode.Text = SessInf.name



                Select Case SessInf.protocol
                    Case 0
                        newNode.ImageKey = returnIconImageName("telnet", True)
                        newNode.SelectedImageKey = returnIconImageName("telnet", True)
                        newNode.ImageIndex = returnIconImageName("telnet", False)
                        newNode.SelectedImageIndex = returnIconImageName("telnet", False)
                    Case 1
                        newNode.ImageKey = returnIconImageName("ssh", True)
                        newNode.SelectedImageKey = returnIconImageName("ssh", True)
                        newNode.ImageIndex = returnIconImageName("ssh", False)
                        newNode.SelectedImageIndex = returnIconImageName("ssh", False)
                    Case 2
                        newNode.ImageKey = returnIconImageName("trmsrv", True)
                        newNode.SelectedImageKey = returnIconImageName("trmsrv", True)
                        newNode.ImageIndex = returnIconImageName("trmsrv", False)
                        newNode.SelectedImageIndex = returnIconImageName("trmsrv", False)
                    Case 3
                        newNode.ImageKey = returnIconImageName("rdp", True)
                        newNode.SelectedImageKey = returnIconImageName("rdp", True)
                        newNode.ImageIndex = returnIconImageName("rdp", False)
                        newNode.SelectedImageIndex = returnIconImageName("rdp", False)
                End Select
                newNode.ToolTipText = SessInf.host & "#" & SessInf.port

                If ActiveSearch = True Then
                    If newNode.Name.Contains(txtFilter.Text) Or SessInf.host.Contains(txtFilter.Text) Then
                        newNode.BackColor = Color.Yellow
                        tn.Nodes.Add(newNode)
                    End If
                Else
                    tn.Nodes.Add(newNode)
                End If

            End If
        Next


    End Sub

    Function returnIconImageName(ByVal method As String, ByVal asString As Boolean) As String
        Dim ImageName As String = ""
        Dim ImageID As Integer = 0

        Select Case method
            Case "folder" 'telnet
                ImageName = "folder_icon.png"
                ImageID = 0
            Case "telnet"
                ImageName = "computer_icon.png"
                ImageID = 1
            Case "ssh"
                ImageName = "ssh.png"
                ImageID = 2
            Case "trmsrv"
                ImageName = "tablet_icon.png"
                ImageID = 3
            Case "rdp"
                ImageName = "rdp.png"
                ImageID = 4
            Case "new"
                ImageName = "ssh.png"
                ImageID = 2
        End Select
        Select Case asString
            Case True
                Return ImageName
            Case False
                Return ImageID
        End Select
    End Function


    Private Sub CloneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloneToolStripMenuItem.Click
        CloneSession()
    End Sub


    Private Sub tsmiXIQ_Click(sender As Object, e As EventArgs) Handles tsmiXIQ.Click
        XIQ_SE_import.ShowDialog()
    End Sub
    Private previousNode As TreeNode = Nothing

    Private Sub tsmiSettings_Click(sender As Object, e As EventArgs) Handles tsmiSettings.Click
        SettingsFrm.Show()
    End Sub

    Private Sub tsbtQuickConnect_Click(sender As Object, e As EventArgs) Handles tsbtQuickConnect.Click
        QuickLaunch.Show()
    End Sub

    Private Sub txtFilter_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFilter.KeyDown
        If e.KeyCode = Keys.Enter Then
            Search()
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub






#Region "TreeView"

#End Region
End Class
