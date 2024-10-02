Public Class SessionEntry

    Public MultiSessionEdit As Boolean = False
    Public MultiSessionNodes As CodersLab.Windows.Controls.NodesCollection
    'Public EditSessionEntry As Boolean = False
    'Public EditSessionEntryID As Integer
    Public EditSessionEntryFile As String
    Public EditSessionOrgName As String
    Public NewSessionPath As String
    'Public EditSessionEntryName As String

    Public Enum EditModeEnum
        NewSession = 0
        EditSession = 1
        MultiEditSession = 2
        FolderEdit = 3
    End Enum
    Public EditRootFolder As Boolean = False
    Public EditMode As EditModeEnum = EditModeEnum.NewSession

    Public Loading As Boolean = True
    Private Sub SessionEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With cbxProfile
            .DisplayMember = "name"
            .ValueMember = "ProfileID"
            .DataSource = ProfileTable
        End With
        With cbxProtocol
            .DisplayMember = "Value"
            .ValueMember = "Key"
            .DataSource = New BindingSource(dict_protocol, Nothing)
        End With
        'cbxProtocol.DataSource = [Enum].GetValues(GetType(SessionProtocol))
        Select Case EditMode
            Case EditModeEnum.EditSession
                Me.Icon = My.Resources.computer_icon
                Dim EditSessionInf As New SessionInfo
                EditSessionInf = getSessionInfo(EditSessionEntryFile)

                txtName.Text = EditSessionInf.name
                cbxProfile.SelectedIndex = EditSessionInf.profile
                txtHost.Text = EditSessionInf.host
                txtuser.Text = EditSessionInf.username
                txtpassword.Text = EditSessionInf.password
                Dim Prot As String = ""
                dict_protocol.TryGetValue(EditSessionInf.protocol, Prot)
                cbxProtocol.SelectedIndex = cbxProtocol.FindString(Prot)
                If EditSessionInf.port = Nothing Then
                    Select Case Prot
                        Case "Telnet"
                            nupPort.Value = 23
                        Case "SSH"
                            nupPort.Value = 22
                        Case "RDP"
                            nupPort.Value = 3389
                        Case Else
                            cbxProtocol.SelectedIndex = cbxProtocol.FindString("Telnet")
                            nupPort.Value = 23
                    End Select
                Else
                    nupPort.Value = EditSessionInf.port
                End If
                txtSockets.Text = EditSessionInf.sockets
                cbInteractive.Checked = EditSessionInf.interactive
                Me.Text = "edit " & EditSessionInf.name
            Case EditModeEnum.NewSession
                Dim FolderInfo As New SessionInfo
                FolderInfo = getSessionInfo(NewSessionPath)

                cbxProfile.SelectedIndex = FolderInfo.profile
                txtuser.Text = FolderInfo.username
                txtpassword.Text = FolderInfo.password
                Dim Prot As String = ""
                dict_protocol.TryGetValue(FolderInfo.protocol, Prot)
                cbxProtocol.SelectedIndex = cbxProtocol.FindString(Prot)
                nupPort.Value = FolderInfo.port
                txtSockets.Text = FolderInfo.sockets
                cbInteractive.Checked = FolderInfo.interactive

                Me.Icon = My.Resources.computer_icon
            Case EditModeEnum.MultiEditSession
                Me.Icon = My.Resources.computer_icon
                Me.Text = "MultiEdit"
                txtHost.Enabled = False
                txtName.Enabled = False
                nupPort.Enabled = False

                Dim EditSessionInf As New SessionInfo
                EditSessionInf = getSessionInfo(MultiSessionNodes(0).Tag)
                cbxProfile.SelectedIndex = EditSessionInf.profile
                txtuser.Text = EditSessionInf.username
                txtpassword.Text = EditSessionInf.password
                txtSockets.Text = EditSessionInf.sockets
                cbInteractive.Checked = EditSessionInf.interactive
                Dim Prot As String = ""
                dict_protocol.TryGetValue(EditSessionInf.protocol, Prot)
                cbxProtocol.SelectedIndex = cbxProtocol.FindString(Prot)
                nupPort.Value = EditSessionInf.port

            Case EditModeEnum.FolderEdit
                Me.Icon = My.Resources.folder_icon
                Dim EditSessionInf As New SessionInfo
                EditSessionInf = getSessionInfo(EditSessionEntryFile)

                txtName.Text = EditSessionInf.name
                cbxProfile.SelectedIndex = EditSessionInf.profile
                txtHost.Text = EditSessionInf.host
                txtuser.Text = EditSessionInf.username
                txtpassword.Text = EditSessionInf.password
                txtSockets.Text = EditSessionInf.sockets
                cbInteractive.Checked = EditSessionInf.interactive
                Dim Prot As String = ""
                dict_protocol.TryGetValue(EditSessionInf.protocol, Prot)
                cbxProtocol.SelectedIndex = cbxProtocol.FindString(Prot)
                nupPort.Value = EditSessionInf.port
                Me.Text = "edit folder " & EditSessionInf.name
                txtHost.Enabled = False
                nupPort.Enabled = False
                If EditRootFolder = True Then
                    txtName.Enabled = False
                Else
                    txtName.Enabled = True
                End If
        End Select

        Loading = False
    End Sub

    Private Sub ToolStripButtonSave_Click(sender As Object, e As EventArgs) Handles save.Click
        saveSub()
    End Sub

    Sub saveSub()

        Select Case EditMode
            Case EditModeEnum.MultiEditSession
                For Each n As TreeNode In MultiSessionNodes
                    Dim OrgSessionInfo As New SessionInfo
                    OrgSessionInfo = getSessionInfo(n.Tag)
                    Debug.Print(n.Text)
                    Debug.Print(n.Tag)
                    OrgSessionInfo.port = nupPort.Value
                    OrgSessionInfo.profile = cbxProfile.SelectedValue
                    OrgSessionInfo.username = txtuser.Text
                    OrgSessionInfo.password = txtpassword.Text
                    OrgSessionInfo.protocol = cbxProtocol.SelectedValue
                    OrgSessionInfo.interactive = cbInteractive.Checked
                    OrgSessionInfo.sockets = txtSockets.Text
                    saveSessionInfo(n.Tag, OrgSessionInfo)

                Next

            Case EditModeEnum.NewSession

                For Each c In IO.Path.GetInvalidFileNameChars()
                    txtName.Text = txtName.Text.Replace(c, "_").Trim
                Next

                Dim SessInf As New SessionInfo
                SessInf.name = txtName.Text
                SessInf.host = txtHost.Text
                SessInf.port = nupPort.Value
                SessInf.profile = cbxProfile.SelectedValue
                SessInf.username = txtuser.Text
                SessInf.password = txtpassword.Text
                SessInf.protocol = cbxProtocol.SelectedValue
                SessInf.interactive = cbInteractive.Checked
                SessInf.sockets = txtSockets.Text
                saveSessionInfo(IO.Path.GetDirectoryName(NewSessionPath) & "\" & txtName.Text & ".ini", SessInf)
            Case EditModeEnum.EditSession

                If Not EditSessionOrgName = txtName.Text Then
                    IO.File.Delete(EditSessionEntryFile)

                    For Each c In IO.Path.GetInvalidFileNameChars()
                        txtName.Text = txtName.Text.Replace(c, "_").Trim
                    Next

                    EditSessionEntryFile = EditSessionEntryFile.Replace(EditSessionOrgName, txtName.Text)
                End If
                Dim SessInf As New SessionInfo
                SessInf.name = txtName.Text
                SessInf.host = txtHost.Text
                SessInf.port = nupPort.Value
                SessInf.profile = cbxProfile.SelectedValue
                SessInf.username = txtuser.Text
                SessInf.password = txtpassword.Text
                SessInf.protocol = cbxProtocol.SelectedValue
                SessInf.interactive = cbInteractive.Checked
                SessInf.sockets = txtSockets.Text
                saveSessionInfo(EditSessionEntryFile, SessInf)

            Case EditModeEnum.FolderEdit
                If Not EditSessionOrgName = txtName.Text Then
                    Dim orgFolderName As String = IO.Path.GetDirectoryName(EditSessionEntryFile)
                    Dim newFolderName As String = orgFolderName
                    newFolderName = newFolderName.Replace(EditSessionOrgName, txtName.Text)

                    For Each c In IO.Path.GetInvalidFileNameChars()
                        newFolderName = newFolderName.Replace(c, "_").Trim
                    Next
                    IO.Directory.Move(orgFolderName, newFolderName)
                    EditSessionEntryFile = newFolderName & FolderSessionIni
                End If

                Dim SessInf As New SessionInfo
                SessInf.name = txtName.Text
                SessInf.host = txtHost.Text
                SessInf.port = nupPort.Value
                SessInf.profile = cbxProfile.SelectedValue
                SessInf.username = txtuser.Text
                SessInf.password = txtpassword.Text
                SessInf.protocol = cbxProtocol.SelectedValue
                SessInf.interactive = cbInteractive.Checked
                SessInf.sockets = txtSockets.Text
                saveSessionInfo(EditSessionEntryFile, SessInf)

        End Select
        SessionsMain.ExpandLastTag = SessionsMain.LastExpandedTag
        BuildTreeView()
        SessionsMain.ExpandLastTagSub()
        Me.Close()
    End Sub

    Private Sub cbxProfile_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbxProfile.SelectedValueChanged

        If cbxProfile.SelectedValue = 0 Then
            txtuser.ReadOnly = False
            txtpassword.ReadOnly = False
        Else
            txtuser.ReadOnly = True
            txtpassword.ReadOnly = True
            Dim myRow() As Data.DataRow
            myRow = ProfileTable.Select("ProfileID = '" & cbxProfile.SelectedValue & "'")
            txtuser.Text = myRow(0)("user")
            txtpassword.Text = DecryptString_Aes(myRow(0)("pass"))
        End If
    End Sub

    Private Sub cbxProtocol_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbxProtocol.SelectedValueChanged

        txtSockets.Enabled = True
        cbInteractive.Enabled = True
        If cbxProtocol.SelectedValue = 0 Then 'telnet
            nupPort.Value = 23
            txtuser.Enabled = True
            txtpassword.Enabled = True
            cbxProfile.Enabled = True
        ElseIf cbxProtocol.SelectedValue = 1 Then 'ssh
            nupPort.Value = 22
            txtuser.Enabled = True
            txtpassword.Enabled = True
            cbxProfile.Enabled = True
        ElseIf cbxProtocol.SelectedValue = 3 Then 'rdp
            nupPort.Value = 3389
            txtuser.Enabled = True
            txtpassword.Enabled = True
            cbxProfile.Enabled = True

            txtSockets.Enabled = False
            cbInteractive.Enabled = False
        Else 'trmsrv
            txtuser.Enabled = False
            txtpassword.Enabled = False
            cbxProfile.Enabled = False
        End If
    End Sub

    Private Sub cancel_Click(sender As Object, e As EventArgs) Handles cancel.Click
        Me.Close()
    End Sub

    Private Sub txtHost_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHost.KeyDown, txtName.KeyDown
        If e.KeyCode = Keys.Enter Then
            saveSub()
        End If
    End Sub

End Class