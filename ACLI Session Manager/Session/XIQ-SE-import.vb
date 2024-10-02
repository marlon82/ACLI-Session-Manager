Public Class XIQ_SE_import
    Private Sub btcancel_Click(sender As Object, e As EventArgs) Handles btcancel.Click
        Me.Close()
    End Sub

    Private Sub btimport_Click(sender As Object, e As EventArgs) Handles btimport.Click
        import()

    End Sub

    Sub import()
        If tbUrl.Text IsNot "" And tbxiquser.Text IsNot "" And tbxiqpassword.Text IsNot "" And tbxiqimportfolder.Text IsNot "" Then

            XIQInput.XMCServer = "https://" & tbUrl.Text & ":8443"
            XIQInput.XMCUser = tbxiquser.Text
            XIQInput.XMCPassword = tbxiqpassword.Text
            XIQInput.NewFolderName = tbxiqimportfolder.Text
            XIQInput.SessionCreds = cbsessioncreds.Checked
            XIQInput.SessionUser = tbsessionuser.Text
            XIQInput.SessionPassword = tbsessionpassword.Text
            XIQInput.ImportProfiles = cbImportProfiles.Checked

            bgwXIQSEImport.RunWorkerAsync()
        Else
            MsgBox("The XIQ-SE URL, Username, Password and the folder name inputs are needed!", MsgBoxStyle.Information)
        End If
    End Sub
    Sub ChangeState(ByVal Fin As Boolean, Optional ByVal success As Boolean = False, Optional ByVal message As String = "")
        Select Case Fin
            Case True
                pbXIQ.Visible = False
                btimport.Enabled = True
                btcancel.Enabled = True
                If success = True Then tsslXIQ.Text = "import successfull" Else tsslXIQ.Text = "failure - " & message
            Case False
                pbXIQ.Visible = True
                btimport.Enabled = False
                btcancel.Enabled = False
                tsslXIQ.Text = "import in Progress"
        End Select
    End Sub

    Private Sub tbxiqimportfolder_KeyDown(sender As Object, e As KeyEventArgs) Handles tbxiqimportfolder.KeyDown
        If e.KeyCode = Keys.Enter Then
            import()
        End If
    End Sub

    Private Sub cbsessioncreds_CheckedChanged(sender As Object, e As EventArgs) Handles cbsessioncreds.CheckedChanged
        If cbsessioncreds.Checked = True Then
            gbsessioncreds.Enabled = True
        Else
            gbsessioncreds.Enabled = False
        End If
    End Sub

End Class