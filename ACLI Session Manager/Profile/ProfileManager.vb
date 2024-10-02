Public Class ProfileManager

    Public selectedrowID As Integer = 0
    Private Sub ProfileManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvProfiles.DataSource = ProfileTable
    End Sub
    Sub ChangeSaveState(ByVal isSaved As Boolean)
        Select Case isSaved
            Case True
                tsslSaveState.Text = "saved"
                tsslSaveState.Visible = False
            Case False
                tsslSaveState.Text = "profiles not saved"
                tsslSaveState.Visible = True
                tsslSaveState.Image = My.Resources.warning_shield_icon
        End Select
    End Sub
    Private Sub tsbtEdit_Click(sender As Object, e As EventArgs) Handles tsbtEdit.Click
        Dim index As Integer = dgvProfiles.SelectedRows(0).Cells(0).Value.ToString
        If Not index = 0 Then

            ProfileEntry.EditEntry = True
            ProfileEntry.EditID = index
            ProfileEntry.Show()
        Else
            MsgBox("Default profile entry can not be modified", MsgBoxStyle.Information, "Default profile")
        End If
        dgvProfiles.Columns(3).Visible = False
    End Sub

    Private Sub tsbtNew_Click(sender As Object, e As EventArgs) Handles tsbtNew.Click
        ProfileEntry.Show()
    End Sub

    Private Sub dgvProfiles_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProfiles.CellClick
        Dim index As Integer
        index = e.RowIndex
        Dim selectedRow As DataGridViewRow
        selectedRow = dgvProfiles.Rows(e.RowIndex)
        selectedrowID = selectedRow.Cells(0).Value.ToString
    End Sub

    Private Sub tsbtsave_Click(sender As Object, e As EventArgs) Handles tsbtsave.Click
        SaveCSV(ProfileTable, "Profiles")
        ChangeSaveState(True)
    End Sub

    Private Sub tsbDelete_Click(sender As Object, e As EventArgs) Handles tsbDelete.Click
        Dim index As Integer = dgvProfiles.SelectedRows(0).Cells(0).Value.ToString
        If Not index = 0 Then
            Dim myRow() As Data.DataRow
            myRow = ProfileTable.Select("ProfileID = '" & index & "'")

            If MsgBox("Do you really want to delete Profile " & myRow(0)("name") & "?", MsgBoxStyle.YesNoCancel, "Delete Profile") = MsgBoxResult.Yes Then
                ProfileTable.Rows.Remove(myRow(0))
                ChangeSaveState(False)
            End If
        Else
            MsgBox("Default profile entry can not be deleted", MsgBoxStyle.Information, "Default profile")
        End If
    End Sub
End Class