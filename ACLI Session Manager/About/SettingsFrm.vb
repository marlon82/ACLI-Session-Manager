Public Class SettingsFrm
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsbtsave.Click
        If rbDoubleClickActionLaunch.Checked = True Then My.Settings.DoubleClickAction = "launch" Else My.Settings.DoubleClickAction = "edit"
        If rbInteractive.Checked = True Then My.Settings.DefaultMode = "Interactive" Else My.Settings.DefaultMode = "Transparent"

        My.Settings.LogLevel = cbLogLevel.SelectedItem
        My.Settings.ChecforUpdateonStartup = cbCheckforUpdateonStartup.Checked
        My.Settings.QuickLaunchWindowOpen = cbQuickLaunchKeepWindowOpen.Checked
        My.Settings.QuickLaunchProtocol = "1"
        My.Settings.DefaultFolderPath = tbFolderPath.Text
        My.Settings.RDPResolution = cbRDPResolution.SelectedItem
        My.Settings.SecureCRTImportOnlysshtelntrdp = cbSecureCRTImportOnlytelnetsshrdp.Checked
        Me.Close()
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.DoubleClickAction = "launch" Then rbDoubleClickActionLaunch.Checked = True Else rbDoubleClickActionEdit.Checked = True
        If My.Settings.DefaultMode = "Interactive" Then rbInteractive.Checked = True Else rbTransparent.Checked = True
        cbSecureCRTImportOnlytelnetsshrdp.Checked = My.Settings.SecureCRTImportOnlysshtelntrdp
        tbFolderPath.Text = My.Settings.DefaultFolderPath
        cbQuickLaunchKeepWindowOpen.Checked = My.Settings.QuickLaunchWindowOpen
        cbLogLevel.SelectedItem = My.Settings.LogLevel
        cbCheckforUpdateonStartup.Checked = My.Settings.ChecforUpdateonStartup
        cbRDPResolution.SelectedItem = My.Settings.RDPResolution
    End Sub

    Private Sub tsbtclose_Click(sender As Object, e As EventArgs) Handles tsbtclose.Click
        Me.Close()
    End Sub

    Private Sub btFolderPath_Click(sender As Object, e As EventArgs) Handles btFolderPath.Click
        Dim fbd As New FolderBrowserDialog
        fbd.Description = "Please select the default folder for saving sessions and profiles"
        fbd.RootFolder = Environment.SpecialFolder.UserProfile
        fbd.SelectedPath = My.Settings.DefaultFolderPath
        If fbd.ShowDialog = DialogResult.OK Then
            tbFolderPath.Text = fbd.SelectedPath
        End If
    End Sub

End Class