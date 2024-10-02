<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SessionEntry
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SessionEntry))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.save = New System.Windows.Forms.ToolStripButton()
        Me.cancel = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.Host = New System.Windows.Forms.Label()
        Me.cbxProtocol = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.nupPort = New System.Windows.Forms.NumericUpDown()
        Me.txtuser = New System.Windows.Forms.TextBox()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxProfile = New System.Windows.Forms.ComboBox()
        Me.cbInteractive = New System.Windows.Forms.CheckBox()
        Me.txtSockets = New System.Windows.Forms.TextBox()
        Me.lblSockets = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip1.SuspendLayout()
        CType(Me.nupPort, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.save, Me.cancel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(295, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'save
        '
        Me.save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.save.Image = Global.ACLI_Session_Manager.My.Resources.Resources.save_icon1
        Me.save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.save.Name = "save"
        Me.save.Size = New System.Drawing.Size(23, 22)
        Me.save.Text = "save"
        '
        'cancel
        '
        Me.cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.cancel.Image = Global.ACLI_Session_Manager.My.Resources.Resources.ban_sign_icon1
        Me.cancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cancel.Name = "cancel"
        Me.cancel.Size = New System.Drawing.Size(23, 22)
        Me.cancel.Text = "cancel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Name"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(53, 28)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(230, 20)
        Me.txtName.TabIndex = 1
        '
        'txtHost
        '
        Me.txtHost.Location = New System.Drawing.Point(53, 54)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(230, 20)
        Me.txtHost.TabIndex = 2
        '
        'Host
        '
        Me.Host.AutoSize = True
        Me.Host.Location = New System.Drawing.Point(1, 61)
        Me.Host.Name = "Host"
        Me.Host.Size = New System.Drawing.Size(29, 13)
        Me.Host.TabIndex = 1
        Me.Host.Text = "Host"
        '
        'cbxProtocol
        '
        Me.cbxProtocol.FormattingEnabled = True
        Me.cbxProtocol.Location = New System.Drawing.Point(53, 81)
        Me.cbxProtocol.Name = "cbxProtocol"
        Me.cbxProtocol.Size = New System.Drawing.Size(121, 21)
        Me.cbxProtocol.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Protocol"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(181, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Port"
        '
        'nupPort
        '
        Me.nupPort.Location = New System.Drawing.Point(213, 80)
        Me.nupPort.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.nupPort.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nupPort.Name = "nupPort"
        Me.nupPort.Size = New System.Drawing.Size(70, 20)
        Me.nupPort.TabIndex = 4
        Me.nupPort.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'txtuser
        '
        Me.txtuser.Location = New System.Drawing.Point(53, 134)
        Me.txtuser.Name = "txtuser"
        Me.txtuser.Size = New System.Drawing.Size(230, 20)
        Me.txtuser.TabIndex = 6
        '
        'txtpassword
        '
        Me.txtpassword.Location = New System.Drawing.Point(53, 160)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassword.Size = New System.Drawing.Size(230, 20)
        Me.txtpassword.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1, 115)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Profile"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "User"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(1, 167)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Password"
        '
        'cbxProfile
        '
        Me.cbxProfile.FormattingEnabled = True
        Me.cbxProfile.Location = New System.Drawing.Point(53, 107)
        Me.cbxProfile.Name = "cbxProfile"
        Me.cbxProfile.Size = New System.Drawing.Size(230, 21)
        Me.cbxProfile.TabIndex = 5
        '
        'cbInteractive
        '
        Me.cbInteractive.AutoSize = True
        Me.cbInteractive.Location = New System.Drawing.Point(207, 189)
        Me.cbInteractive.Name = "cbInteractive"
        Me.cbInteractive.Size = New System.Drawing.Size(76, 17)
        Me.cbInteractive.TabIndex = 8
        Me.cbInteractive.Text = "Interactive"
        Me.ToolTip1.SetToolTip(Me.cbInteractive, "ACLI Interactive mode")
        Me.cbInteractive.UseVisualStyleBackColor = True
        '
        'txtSockets
        '
        Me.txtSockets.Location = New System.Drawing.Point(53, 186)
        Me.txtSockets.Name = "txtSockets"
        Me.txtSockets.Size = New System.Drawing.Size(135, 20)
        Me.txtSockets.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.txtSockets, "Listen Sockets")
        '
        'lblSockets
        '
        Me.lblSockets.AutoSize = True
        Me.lblSockets.Location = New System.Drawing.Point(1, 189)
        Me.lblSockets.Name = "lblSockets"
        Me.lblSockets.Size = New System.Drawing.Size(46, 13)
        Me.lblSockets.TabIndex = 1
        Me.lblSockets.Text = "Sockets"
        '
        'SessionEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(295, 218)
        Me.Controls.Add(Me.txtSockets)
        Me.Controls.Add(Me.cbInteractive)
        Me.Controls.Add(Me.cbxProfile)
        Me.Controls.Add(Me.nupPort)
        Me.Controls.Add(Me.cbxProtocol)
        Me.Controls.Add(Me.txtpassword)
        Me.Controls.Add(Me.txtuser)
        Me.Controls.Add(Me.txtHost)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblSockets)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Host)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SessionEntry"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "SessionEntry"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.nupPort, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents save As ToolStripButton
    Friend WithEvents cancel As ToolStripButton
    Friend WithEvents Label1 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtHost As TextBox
    Friend WithEvents Host As Label
    Friend WithEvents cbxProtocol As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents nupPort As NumericUpDown
    Friend WithEvents txtuser As TextBox
    Friend WithEvents txtpassword As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbxProfile As ComboBox
    Friend WithEvents cbInteractive As CheckBox
    Friend WithEvents txtSockets As TextBox
    Friend WithEvents lblSockets As Label
    Friend WithEvents ToolTip1 As ToolTip
End Class
