Public Class ProfileEntry

    Public EditEntry As Boolean = False
    Public EditID As Integer = 0
    Private Sub tsbtcancel_Click(sender As Object, e As EventArgs) Handles tsbtcancel.Click
        Me.Close()
    End Sub

    Private Sub tsbtsave_Click(sender As Object, e As EventArgs) Handles tsbtsave.Click
        If EditEntry = True Then
            Dim myRow() As Data.DataRow
            myRow = ProfileTable.Select("ProfileID = '" & EditID & "'")
            myRow(0)("name") = txtName.Text
            myRow(0)("user") = txtUser.Text
            myRow(0)("pass") = EncryptString_Aes(txtPass.Text)
        Else
            ProfileTable.Rows.Add(returnNextFreeProfileID, txtName.Text, txtUser.Text, EncryptString_Aes(txtPass.Text))
        End If

        ProfileManager.ChangeSaveState(False)
        Me.Close()

    End Sub

    Private Sub ProfileEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If EditEntry = True Then
            Dim myRow() As Data.DataRow
            myRow = ProfileTable.Select("ProfileID = '" & EditID & "'")
            txtName.Text = myRow(0)("name")
            txtUser.Text = myRow(0)("user")
            txtPass.Text = DecryptString_Aes(myRow(0)("pass"))
            Me.Text = "Edit " & myRow(0)("name")

        Else
            Me.Text = "new Profile"
            txtName.Text = ""
            txtUser.Text = ""
            txtPass.Text = ""
        End If
    End Sub

End Class