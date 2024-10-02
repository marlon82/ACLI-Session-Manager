
Imports System.ComponentModel
Imports System.Runtime.InteropServices

<ToolboxBitmap(GetType(TabControl))>
Public Class ClosableTabControl
    Inherits TabControl

    <DllImport("user32.dll")>
    Public Shared Function SetParent(ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As IntPtr
    End Function

    Private dicButtons As New Dictionary(Of Button, TabPage)

    Private blnShow As Boolean = True
    Private imgImage As Image

    Public Event CloseClick As CancelEventHandler

    <Browsable(True), DefaultValue(True), Category("Behavior"), Description("Show / Hide Close Button(s)")>
    Public Property Show() As Boolean

        Get

            Return blnShow

        End Get

        Set(ByVal value As Boolean)

            blnShow = value

            For Each btn In dicButtons.Keys

                btn.Visible = blnShow

            Next

            Repos()

        End Set

    End Property

    <Browsable(True), DefaultValue(True), Category("Appearance"), Description("Close Image")>
    Public Property TabPageImage() As Image

        Get

            Return imgImage

        End Get

        Set(ByVal value As Image)

            imgImage = value

        End Set

    End Property

    Protected Overrides Sub OnCreateControl()

        MyBase.OnCreateControl()

        Repos()

    End Sub

    Protected Overrides Sub OnControlAdded(ByVal e As ControlEventArgs)

        MyBase.OnControlAdded(e)

        Dim tpCurrent As TabPage = DirectCast(e.Control, TabPage)
        Dim rtCurrent As Rectangle =
           Me.GetTabRect(Me.TabPages.IndexOf(tpCurrent))

        Dim btnClose As New Button

        btnClose.Image = My.Resources.close

        btnClose.ImageAlign = ContentAlignment.MiddleRight
        btnClose.TextAlign = ContentAlignment.MiddleLeft

        btnClose.Size = New Size(rtCurrent.Height - 1, rtCurrent.Height - 1)
        btnClose.Location = New Point(rtCurrent.X + rtCurrent.Width - rtCurrent.Height - 1 , rtCurrent.Y + 1)

        SetParent(btnClose.Handle, Me.Handle)

        AddHandler btnClose.Click, AddressOf OnCloseClick

        dicButtons.Add(btnClose, tpCurrent)

    End Sub

    Protected Overrides Sub OnLayout(ByVal lea As LayoutEventArgs)

        MyBase.OnLayout(lea)
        Repos()

    End Sub


    Protected Overridable Sub OnCloseClick(ByVal sender As Object, ByVal e As EventArgs)

        If Not DesignMode Then

            Dim btnClose As Button = DirectCast(sender, Button)
            Dim tpCurrent As TabPage = dicButtons(btnClose)
            Dim cea As New CancelEventArgs

            RaiseEvent CloseClick(sender, cea)

            If Not cea.Cancel Then

                If TabPages.Count > 1 Then

                    btnClose.Dispose()
                    TabPages.Remove(tpCurrent)

                    Repos()


                End If

            End If

        End If

    End Sub

    Public Sub Repos()

        For Each but In dicButtons

            Repos(but.Value)

        Next

    End Sub

    Public Sub Repos(ByVal tpCurrent As TabPage)

        Dim btnClose As Button = CloseButton(tpCurrent)

        If btnClose IsNot Nothing Then

            Dim tpIndex As Integer = TabPages.IndexOf(tpCurrent)

            If tpIndex >= 0 Then

                Dim rctCurrent As Rectangle = GetTabRect(tpIndex)

                If SelectedTab Is tpCurrent Then

                    btnClose.Size = New Size(rctCurrent.Height - 1, rctCurrent.Height - 1)
                    btnClose.Location = New Point(rctCurrent.X + rctCurrent.Width - rctCurrent.Height, rctCurrent.Y + 1)

                    btnClose.Visible = Show
                    btnClose.BringToFront()

                End If
            End If
        End If

    End Sub

    'Public Sub Repos(ByVal tpCurrent As TabPage)

    '    Dim btnClose As Button = CloseButton(tpCurrent)

    '    If btnClose IsNot Nothing Then

    '        Dim tpIndex As Integer = TabPages.IndexOf(tpCurrent)

    '        If tpIndex >= 0 Then

    '            Dim rctCurrent As Rectangle = GetTabRect(tpIndex)

    '            If SelectedTab Is tpCurrent Then

    '                btnClose.Size = New Size(rctCurrent.Height - 1, rctCurrent.Height - 1)
    '                btnClose.Location = New Point(rctCurrent.X + rctCurrent.Width - rctCurrent.Height, rctCurrent.Y + 1)

    '            Else

    '                btnClose.Size = New Size(rctCurrent.Height - 3, rctCurrent.Height - 2)
    '                btnClose.Location = New Point(rctCurrent.X + rctCurrent.Width - rctCurrent.Height - 1, rctCurrent.Y + 1)

    '            End If

    '            btnClose.Visible = Show
    '            btnClose.BringToFront()

    '        End If

    '    End If

    'End Sub

    Protected Function CloseButton(ByVal tpCurrent As TabPage) As Button

        Return (From item In dicButtons Where item.Value Is
           tpCurrent Select item.Key).FirstOrDefault

    End Function
End Class
