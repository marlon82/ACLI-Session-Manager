<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class QuickLaunch
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QuickLaunch))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cbxProfile = New System.Windows.Forms.ComboBox()
        Me.nupPort = New System.Windows.Forms.NumericUpDown()
        Me.cbxProtocol = New System.Windows.Forms.ComboBox()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.txtuser = New System.Windows.Forms.TextBox()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Host = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbContainWindow = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.rbInteractive = New System.Windows.Forms.RadioButton()
        Me.rbTransparent = New System.Windows.Forms.RadioButton()
        Me.cbKeepWindowOpen = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtSockets = New System.Windows.Forms.TextBox()
        CType(Me.nupPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(225, 219)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(144, 219)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = "connect"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cbxProfile
        '
        Me.cbxProfile.FormattingEnabled = True
        Me.cbxProfile.Location = New System.Drawing.Point(70, 65)
        Me.cbxProfile.Name = "cbxProfile"
        Me.cbxProfile.Size = New System.Drawing.Size(230, 21)
        Me.cbxProfile.TabIndex = 4
        '
        'nupPort
        '
        Me.nupPort.Location = New System.Drawing.Point(230, 38)
        Me.nupPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nupPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupPort.Name = "nupPort"
        Me.nupPort.Size = New System.Drawing.Size(70, 20)
        Me.nupPort.TabIndex = 3
        Me.nupPort.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'cbxProtocol
        '
        Me.cbxProtocol.FormattingEnabled = True
        Me.cbxProtocol.Location = New System.Drawing.Point(70, 39)
        Me.cbxProtocol.Name = "cbxProtocol"
        Me.cbxProtocol.Size = New System.Drawing.Size(121, 21)
        Me.cbxProtocol.TabIndex = 2
        '
        'txtpassword
        '
        Me.txtpassword.Location = New System.Drawing.Point(70, 118)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassword.Size = New System.Drawing.Size(230, 20)
        Me.txtpassword.TabIndex = 6
        '
        'txtuser
        '
        Me.txtuser.Location = New System.Drawing.Point(70, 92)
        Me.txtuser.Name = "txtuser"
        Me.txtuser.Size = New System.Drawing.Size(230, 20)
        Me.txtuser.TabIndex = 5
        '
        'txtHost
        '
        Me.txtHost.Location = New System.Drawing.Point(70, 12)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(230, 20)
        Me.txtHost.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(197, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Port"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Password"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "User"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Profile"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Protocol"
        '
        'Host
        '
        Me.Host.AutoSize = True
        Me.Host.Location = New System.Drawing.Point(11, 15)
        Me.Host.Name = "Host"
        Me.Host.Size = New System.Drawing.Size(29, 13)
        Me.Host.TabIndex = 13
        Me.Host.Text = "Host"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 173)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "containing window"
        '
        'tbContainWindow
        '
        Me.tbContainWindow.Location = New System.Drawing.Point(112, 170)
        Me.tbContainWindow.Name = "tbContainWindow"
        Me.tbContainWindow.Size = New System.Drawing.Size(188, 20)
        Me.tbContainWindow.TabIndex = 7
        Me.tbContainWindow.Text = "QuickLaunch"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 199)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "mode"
        '
        'rbInteractive
        '
        Me.rbInteractive.AutoSize = True
        Me.rbInteractive.Checked = True
        Me.rbInteractive.Location = New System.Drawing.Point(114, 197)
        Me.rbInteractive.Name = "rbInteractive"
        Me.rbInteractive.Size = New System.Drawing.Size(75, 17)
        Me.rbInteractive.TabIndex = 14
        Me.rbInteractive.TabStop = True
        Me.rbInteractive.Text = "Interactive"
        Me.rbInteractive.UseVisualStyleBackColor = True
        '
        'rbTransparent
        '
        Me.rbTransparent.AutoSize = True
        Me.rbTransparent.Location = New System.Drawing.Point(225, 196)
        Me.rbTransparent.Name = "rbTransparent"
        Me.rbTransparent.Size = New System.Drawing.Size(82, 17)
        Me.rbTransparent.TabIndex = 14
        Me.rbTransparent.Text = "Transparent"
        Me.rbTransparent.UseVisualStyleBackColor = True
        '
        'cbKeepWindowOpen
        '
        Me.cbKeepWindowOpen.AutoSize = True
        Me.cbKeepWindowOpen.Location = New System.Drawing.Point(14, 225)
        Me.cbKeepWindowOpen.Name = "cbKeepWindowOpen"
        Me.cbKeepWindowOpen.Size = New System.Drawing.Size(116, 17)
        Me.cbKeepWindowOpen.TabIndex = 15
        Me.cbKeepWindowOpen.Text = "keep window open"
        Me.cbKeepWindowOpen.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 147)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Sockets"
        '
        'txtSockets
        '
        Me.txtSockets.Location = New System.Drawing.Point(70, 144)
        Me.txtSockets.Name = "txtSockets"
        Me.txtSockets.Size = New System.Drawing.Size(230, 20)
        Me.txtSockets.TabIndex = 6
        '
        'QuickLaunch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(318, 253)
        Me.Controls.Add(Me.cbKeepWindowOpen)
        Me.Controls.Add(Me.rbTransparent)
        Me.Controls.Add(Me.rbInteractive)
        Me.Controls.Add(Me.cbxProfile)
        Me.Controls.Add(Me.nupPort)
        Me.Controls.Add(Me.cbxProtocol)
        Me.Controls.Add(Me.tbContainWindow)
        Me.Controls.Add(Me.txtSockets)
        Me.Controls.Add(Me.txtpassword)
        Me.Controls.Add(Me.txtuser)
        Me.Controls.Add(Me.txtHost)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Host)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "QuickLaunch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "QuickLaunch"
        CType(Me.nupPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents cbxProfile As ComboBox
    Friend WithEvents nupPort As NumericUpDown
    Friend WithEvents cbxProtocol As ComboBox
    Friend WithEvents txtpassword As TextBox
    Friend WithEvents txtuser As TextBox
    Friend WithEvents txtHost As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Host As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tbContainWindow As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents rbInteractive As RadioButton
    Friend WithEvents rbTransparent As RadioButton
    Friend WithEvents cbKeepWindowOpen As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtSockets As TextBox
End Class
