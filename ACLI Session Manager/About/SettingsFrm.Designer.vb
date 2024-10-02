<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsFrm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SettingsFrm))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbtsave = New System.Windows.Forms.ToolStripButton()
        Me.tsbtclose = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rbTransparent = New System.Windows.Forms.RadioButton()
        Me.rbInteractive = New System.Windows.Forms.RadioButton()
        Me.cbQuickLaunchKeepWindowOpen = New System.Windows.Forms.CheckBox()
        Me.btFolderPath = New System.Windows.Forms.Button()
        Me.tbFolderPath = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbCheckforUpdateonStartup = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.cbLogLevel = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbDoubleClickActionEdit = New System.Windows.Forms.RadioButton()
        Me.rbDoubleClickActionLaunch = New System.Windows.Forms.RadioButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cbRDPResolution = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbSecureCRTImportOnlytelnetsshrdp = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtsave, Me.tsbtclose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(444, 27)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbtsave
        '
        Me.tsbtsave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtsave.Image = Global.ACLI_Session_Manager.My.Resources.Resources.save_icon1
        Me.tsbtsave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtsave.Name = "tsbtsave"
        Me.tsbtsave.Size = New System.Drawing.Size(29, 24)
        Me.tsbtsave.Text = "save"
        '
        'tsbtclose
        '
        Me.tsbtclose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtclose.Image = Global.ACLI_Session_Manager.My.Resources.Resources.sign_error_icon1
        Me.tsbtclose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtclose.Name = "tsbtclose"
        Me.tsbtclose.Size = New System.Drawing.Size(29, 24)
        Me.tsbtclose.Text = "close"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 34)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(444, 393)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.cbSecureCRTImportOnlytelnetsshrdp)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.cbQuickLaunchKeepWindowOpen)
        Me.TabPage1.Controls.Add(Me.btFolderPath)
        Me.TabPage1.Controls.Add(Me.tbFolderPath)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.cbCheckforUpdateonStartup)
        Me.TabPage1.Controls.Add(Me.GroupBox5)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage1.Size = New System.Drawing.Size(436, 364)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Main"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbTransparent)
        Me.GroupBox2.Controls.Add(Me.rbInteractive)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 249)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(389, 47)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "default Mode"
        '
        'rbTransparent
        '
        Me.rbTransparent.AutoSize = True
        Me.rbTransparent.Location = New System.Drawing.Point(40, 18)
        Me.rbTransparent.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbTransparent.Name = "rbTransparent"
        Me.rbTransparent.Size = New System.Drawing.Size(101, 20)
        Me.rbTransparent.TabIndex = 38
        Me.rbTransparent.TabStop = True
        Me.rbTransparent.Text = "Transparent"
        Me.rbTransparent.UseVisualStyleBackColor = True
        '
        'rbInteractive
        '
        Me.rbInteractive.AutoSize = True
        Me.rbInteractive.Location = New System.Drawing.Point(157, 18)
        Me.rbInteractive.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbInteractive.Name = "rbInteractive"
        Me.rbInteractive.Size = New System.Drawing.Size(89, 20)
        Me.rbInteractive.TabIndex = 39
        Me.rbInteractive.TabStop = True
        Me.rbInteractive.Text = "Interactive"
        Me.rbInteractive.UseVisualStyleBackColor = True
        '
        'cbQuickLaunchKeepWindowOpen
        '
        Me.cbQuickLaunchKeepWindowOpen.AutoSize = True
        Me.cbQuickLaunchKeepWindowOpen.Location = New System.Drawing.Point(15, 220)
        Me.cbQuickLaunchKeepWindowOpen.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbQuickLaunchKeepWindowOpen.Name = "cbQuickLaunchKeepWindowOpen"
        Me.cbQuickLaunchKeepWindowOpen.Size = New System.Drawing.Size(221, 20)
        Me.cbQuickLaunchKeepWindowOpen.TabIndex = 37
        Me.cbQuickLaunchKeepWindowOpen.Text = "keep QuickLaunch window open"
        Me.cbQuickLaunchKeepWindowOpen.UseVisualStyleBackColor = True
        '
        'btFolderPath
        '
        Me.btFolderPath.Location = New System.Drawing.Point(389, 118)
        Me.btFolderPath.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btFolderPath.Name = "btFolderPath"
        Me.btFolderPath.Size = New System.Drawing.Size(33, 28)
        Me.btFolderPath.TabIndex = 35
        Me.btFolderPath.Text = "..."
        Me.btFolderPath.UseVisualStyleBackColor = True
        '
        'tbFolderPath
        '
        Me.tbFolderPath.Location = New System.Drawing.Point(113, 121)
        Me.tbFolderPath.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbFolderPath.Name = "tbFolderPath"
        Me.tbFolderPath.ReadOnly = True
        Me.tbFolderPath.Size = New System.Drawing.Size(267, 22)
        Me.tbFolderPath.TabIndex = 34
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 124)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 16)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "session folder"
        '
        'cbCheckforUpdateonStartup
        '
        Me.cbCheckforUpdateonStartup.AutoSize = True
        Me.cbCheckforUpdateonStartup.Location = New System.Drawing.Point(11, 331)
        Me.cbCheckforUpdateonStartup.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbCheckforUpdateonStartup.Name = "cbCheckforUpdateonStartup"
        Me.cbCheckforUpdateonStartup.Size = New System.Drawing.Size(216, 20)
        Me.cbCheckforUpdateonStartup.TabIndex = 32
        Me.cbCheckforUpdateonStartup.Text = "check for app update on startup"
        Me.cbCheckforUpdateonStartup.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.cbLogLevel)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Location = New System.Drawing.Point(181, 7)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox5.Size = New System.Drawing.Size(219, 90)
        Me.GroupBox5.TabIndex = 31
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Logging"
        '
        'cbLogLevel
        '
        Me.cbLogLevel.FormattingEnabled = True
        Me.cbLogLevel.Items.AddRange(New Object() {"Info", "Trace", "Debug", "Warning", "Fatal", "Error"})
        Me.cbLogLevel.Location = New System.Drawing.Point(24, 52)
        Me.cbLogLevel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbLogLevel.Name = "cbLogLevel"
        Me.cbLogLevel.Size = New System.Drawing.Size(160, 24)
        Me.cbLogLevel.TabIndex = 25
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(20, 27)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 16)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Log Level"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbDoubleClickActionEdit)
        Me.GroupBox1.Controls.Add(Me.rbDoubleClickActionLaunch)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 7)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(163, 90)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DoubleClick Action"
        '
        'rbDoubleClickActionEdit
        '
        Me.rbDoubleClickActionEdit.AutoSize = True
        Me.rbDoubleClickActionEdit.Location = New System.Drawing.Point(93, 25)
        Me.rbDoubleClickActionEdit.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbDoubleClickActionEdit.Name = "rbDoubleClickActionEdit"
        Me.rbDoubleClickActionEdit.Size = New System.Drawing.Size(50, 20)
        Me.rbDoubleClickActionEdit.TabIndex = 0
        Me.rbDoubleClickActionEdit.TabStop = True
        Me.rbDoubleClickActionEdit.Text = "edit"
        Me.rbDoubleClickActionEdit.UseVisualStyleBackColor = True
        '
        'rbDoubleClickActionLaunch
        '
        Me.rbDoubleClickActionLaunch.AutoSize = True
        Me.rbDoubleClickActionLaunch.Location = New System.Drawing.Point(9, 25)
        Me.rbDoubleClickActionLaunch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbDoubleClickActionLaunch.Name = "rbDoubleClickActionLaunch"
        Me.rbDoubleClickActionLaunch.Size = New System.Drawing.Size(67, 20)
        Me.rbDoubleClickActionLaunch.TabIndex = 0
        Me.rbDoubleClickActionLaunch.TabStop = True
        Me.rbDoubleClickActionLaunch.Text = "launch"
        Me.rbDoubleClickActionLaunch.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cbRDPResolution)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TabPage2.Size = New System.Drawing.Size(436, 364)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "RDP"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cbRDPResolution
        '
        Me.cbRDPResolution.FormattingEnabled = True
        Me.cbRDPResolution.Items.AddRange(New Object() {"640x480", "800x600", "1024x768", "1152x864", "1280x600", "1280x720", "1280x768", "1280x800", "1280x960", "1280x1024", "1360x768", "1366x768", "1400x1050", "1440x900", "1600x900", "1680x1050", "1920x1080"})
        Me.cbRDPResolution.Location = New System.Drawing.Point(136, 7)
        Me.cbRDPResolution.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbRDPResolution.Name = "cbRDPResolution"
        Me.cbRDPResolution.Size = New System.Drawing.Size(255, 24)
        Me.cbRDPResolution.TabIndex = 45
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 16)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "RDP resolution"
        '
        'cbSecureCRTImportOnlytelnetsshrdp
        '
        Me.cbSecureCRTImportOnlytelnetsshrdp.AutoSize = True
        Me.cbSecureCRTImportOnlytelnetsshrdp.Location = New System.Drawing.Point(15, 193)
        Me.cbSecureCRTImportOnlytelnetsshrdp.Name = "cbSecureCRTImportOnlytelnetsshrdp"
        Me.cbSecureCRTImportOnlytelnetsshrdp.Size = New System.Drawing.Size(302, 20)
        Me.cbSecureCRTImportOnlytelnetsshrdp.TabIndex = 42
        Me.cbSecureCRTImportOnlytelnetsshrdp.Text = "SecureCRT Import: only Telnet/SSH and RDP"
        Me.cbSecureCRTImportOnlytelnetsshrdp.UseVisualStyleBackColor = True
        '
        'SettingsFrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 428)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SettingsFrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsbtsave As ToolStripButton
    Friend WithEvents tsbtclose As ToolStripButton
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbDoubleClickActionEdit As RadioButton
    Friend WithEvents rbDoubleClickActionLaunch As RadioButton
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents cbLogLevel As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cbCheckforUpdateonStartup As CheckBox
    Friend WithEvents btFolderPath As Button
    Friend WithEvents tbFolderPath As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents rbInteractive As RadioButton
    Friend WithEvents rbTransparent As RadioButton
    Friend WithEvents cbQuickLaunchKeepWindowOpen As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents cbRDPResolution As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cbSecureCRTImportOnlytelnetsshrdp As CheckBox
End Class
