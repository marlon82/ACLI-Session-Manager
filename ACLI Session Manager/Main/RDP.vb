Imports System.Windows.Controls.Primitives
Imports AxMSTSCLib
Imports MSTSCLib


Public Class RDP

    Private Sub RDP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tcRDP.TabPages.Clear()
        Dim temp() As String = My.Settings.RDPResolution.Split("x")
        Dim NewWinSize As Size
        NewWinSize.Width = temp(0) + 26
        NewWinSize.Height = temp(1) + 72
        Me.Size = NewWinSize

    End Sub
    Sub NewSession(ByVal SessInf As SessionInfo)
        Try
            Dim rdpconnection As New AxMsTscAxNotSafeForScripting
            Dim NewRDPPage As New TabPage
            If SessInf.name = Nothing Then
                NewRDPPage.Text = SessInf.host & "   "
                NewRDPPage.Name = SessInf.host
            Else
                NewRDPPage.Text = SessInf.name & "   "
                NewRDPPage.Name = SessInf.name
            End If
            Me.tcRDP.TabPages.Add(NewRDPPage)
            NewRDPPage.Controls.Add(rdpconnection)

            rdpconnection.Dock = DockStyle.Fill
            rdpconnection.Server = SessInf.host
            Dim temp() As String = My.Settings.RDPResolution.Split("x")

            rdpconnection.DesktopWidth = temp(0)
            rdpconnection.DesktopHeight = temp(1)
            rdpconnection.AdvancedSettings.EnableCredSspSupport = True
            rdpconnection.AdvancedSettings.RDPPort = SessInf.port
            rdpconnection.UserName = SessInf.username
            rdpconnection.AdvancedSettings.ClearTextPassword = SessInf.password
            'Dim isSecured As IMsTscNonScriptable =
            '    DirectCast(rdpconnection.GetOcx(), IMsTscNonScriptable)

            'isSecured.ClearTextPassword = SessInf.password
            rdpconnection.Connect()
        Catch ex As Exception
            MessageBox.Show("Cannot Connect to: " + SessInf.host + " Reason:  " + ex.Message, "Cannot Connect", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub tcRDP_CloseClick(sender As Object, e As System.ComponentModel.CancelEventArgs)
        If tcRDP.TabPages.Count = 1 Then
            Me.Close()

        End If
    End Sub
End Class