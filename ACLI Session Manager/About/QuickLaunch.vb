Public Class QuickLaunch
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim User, Pass, Mode As String
        If Not cbxProfile.SelectedValue = 0 Then
            Dim myProfileRow() As Data.DataRow
            myProfileRow = ProfileTable.Select("ProfileID = '" & cbxProfile.SelectedValue & "'")

            User = myProfileRow(0)("user")
            Pass = DecryptString_Aes(myProfileRow(0)("pass"))
        Else
            User = txtuser.Text
            Pass = txtpassword.Text
        End If
        Dim UserString As String = ""
        If User <> Nothing Or Not User = "" Then
            UserString = User
            If Pass <> Nothing Or Not Pass = "" Then
                UserString = UserString & ":" & Pass
            End If
            If cbxProtocol.SelectedValue = 1 Then 'ssh
                UserString = " -l " & UserString & " "
            ElseIf cbxProtocol.SelectedValue = 0 Then 'telnet
                UserString = " " & UserString & "@"
            Else 'trmsrv
                UserString = ""
            End If
        End If

        If rbInteractive.Checked = True Then
            Mode = " "
            'Mode = " -t "
        Else
            Mode = " -n "
        End If

        Dim TabName, Hosts, Porti As String
        Hosts = txtHost.Text
        If nupPort.Value >= 1 Then
            Porti = " " & Convert.ToString(nupPort.Value)
        Else
            Porti = ""
        End If

        Dim Sockets As String = txtSockets.Text

        If Not Sockets = "" Then
            Sockets = "-s """ & Sockets & """ "
        End If

        'Dim ProcRuns As Boolean
        Dim WindowName As String = tbContainWindow.Text
        If WindowName = "" Then
            WindowName = "ACLI"
        End If
        If cbxProtocol.SelectedValue = 2 Then
            TabName = Hosts & ":" & nupPort.Validate.ToString

        Else
            TabName = Hosts
        End If
        'ProcRuns = CheckIfRunning(WindowName)

        Dim pHelp As New ProcessStartInfo
        pHelp.FileName = "console.exe"
        If cbxProtocol.SelectedValue = 3 Then
            RDP.Show()
            Dim SessInf As New SessionInfo
            If Not cbxProfile.SelectedValue = 0 Then
                Dim myProfileRow() As Data.DataRow
                myProfileRow = ProfileTable.Select("ProfileID = '" & cbxProfile.SelectedValue & "'")

                SessInf.username = myProfileRow(0)("user")
                SessInf.password = DecryptString_Aes(myProfileRow(0)("pass"))
            Else
                SessInf.username = txtuser.Text
                SessInf.password = txtpassword.Text
            End If
            SessInf.host = txtHost.Text
            RDP.NewSession(SessInf)
        Else
            Log.Debug("reuse -i """ & WindowName & """ -w """ & WindowName & """ -n " & TabName & " -r """ & Mode & UserString & Sockets & Hosts & Porti & """")
            Debug.Print("reuse -i """ & WindowName & """ -w """ & WindowName & """ -n " & TabName & " -r """ & Mode & UserString & Sockets & Hosts & Porti & """")
            pHelp.Arguments = "reuse -i """ & WindowName & """ -w """ & WindowName & """ -n " & TabName & " -r """ & Mode & UserString & Sockets & Hosts & Porti & """"
            pHelp.UseShellExecute = True
            pHelp.WindowStyle = ProcessWindowStyle.Normal
            Dim proc As Process = Process.Start(pHelp)
            System.Threading.Thread.Sleep(1000)
        End If


        If Not cbKeepWindowOpen.Checked Then Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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
        rbInteractive.Enabled = True
        rbTransparent.Enabled = True
        tbContainWindow.Enabled = True
        If cbxProtocol.SelectedValue = 0 Then 'telnet
            nupPort.Value = 23
            rbInteractive.Checked = True
            txtuser.Enabled = True
            txtpassword.Enabled = True
            cbxProfile.Enabled = True
        ElseIf cbxProtocol.SelectedValue = 1 Then 'ssh
            nupPort.Value = 22
            rbInteractive.Checked = True
            txtuser.Enabled = True
            txtpassword.Enabled = True
            cbxProfile.Enabled = True
        ElseIf cbxProtocol.SelectedValue = 3 Then 'rdp
            nupPort.Value = 3389
            rbInteractive.Checked = False
            txtuser.Enabled = True
            txtpassword.Enabled = True
            cbxProfile.Enabled = True
            txtSockets.Enabled = False
            rbInteractive.Enabled = False
            rbTransparent.Enabled = False
            tbContainWindow.Enabled = False
        Else 'trmsrv
            nupPort.Value = 7000
            rbTransparent.Checked = True
            txtuser.Enabled = False
            txtpassword.Enabled = False
            cbxProfile.Enabled = False
        End If
    End Sub

    Private Sub QuickConnect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Dim Prot As String = ""
        dict_protocol.TryGetValue(My.Settings.QuickLaunchProtocol, Prot)
        cbxProtocol.SelectedIndex = cbxProtocol.FindString(Prot)
        cbKeepWindowOpen.Checked = My.Settings.QuickLaunchWindowOpen
        If My.Settings.DefaultMode = "Interactive" Then rbInteractive.Checked = True Else rbTransparent.Checked = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub
End Class