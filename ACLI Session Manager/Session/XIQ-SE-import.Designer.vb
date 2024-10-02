<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XIQ_SE_import
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btimport = New System.Windows.Forms.ToolStripButton()
        Me.btcancel = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbUrl = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbxiquser = New System.Windows.Forms.TextBox()
        Me.tbxiqpassword = New System.Windows.Forms.TextBox()
        Me.tbxiqimportfolder = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsslXIQ = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pbXIQ = New System.Windows.Forms.ToolStripProgressBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cbsessioncreds = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.tbsessionuser = New System.Windows.Forms.TextBox()
        Me.tbsessionpassword = New System.Windows.Forms.TextBox()
        Me.gbsessioncreds = New System.Windows.Forms.GroupBox()
        Me.cbImportProfiles = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.gbsessioncreds.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btimport, Me.btcancel})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(309, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btimport
        '
        Me.btimport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btimport.Image = Global.ACLI_Session_Manager.My.Resources.Resources.box_in_icon1
        Me.btimport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btimport.Name = "btimport"
        Me.btimport.Size = New System.Drawing.Size(23, 22)
        Me.btimport.Text = "import"
        '
        'btcancel
        '
        Me.btcancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btcancel.Image = Global.ACLI_Session_Manager.My.Resources.Resources.ban_sign_icon1
        Me.btcancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btcancel.Name = "btcancel"
        Me.btcancel.Size = New System.Drawing.Size(23, 22)
        Me.btcancel.Text = "close"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "XIQ-SE URL"
        '
        'tbUrl
        '
        Me.tbUrl.Location = New System.Drawing.Point(136, 31)
        Me.tbUrl.Name = "tbUrl"
        Me.tbUrl.Size = New System.Drawing.Size(117, 20)
        Me.tbUrl.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "XIQ-SE username"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "XIQ-SE password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 246)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "import to folder"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(94, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "https://"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(252, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = ":8443/"
        '
        'tbxiquser
        '
        Me.tbxiquser.Location = New System.Drawing.Point(150, 57)
        Me.tbxiquser.Name = "tbxiquser"
        Me.tbxiquser.Size = New System.Drawing.Size(103, 20)
        Me.tbxiquser.TabIndex = 2
        '
        'tbxiqpassword
        '
        Me.tbxiqpassword.Location = New System.Drawing.Point(150, 83)
        Me.tbxiqpassword.Name = "tbxiqpassword"
        Me.tbxiqpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbxiqpassword.Size = New System.Drawing.Size(103, 20)
        Me.tbxiqpassword.TabIndex = 3
        '
        'tbxiqimportfolder
        '
        Me.tbxiqimportfolder.Location = New System.Drawing.Point(150, 243)
        Me.tbxiqimportfolder.Name = "tbxiqimportfolder"
        Me.tbxiqimportfolder.Size = New System.Drawing.Size(103, 20)
        Me.tbxiqimportfolder.TabIndex = 8
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslXIQ, Me.pbXIQ})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 266)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(309, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslXIQ
        '
        Me.tsslXIQ.Name = "tsslXIQ"
        Me.tsslXIQ.Size = New System.Drawing.Size(26, 17)
        Me.tsslXIQ.Text = "idle"
        '
        'pbXIQ
        '
        Me.pbXIQ.Name = "pbXIQ"
        Me.pbXIQ.Size = New System.Drawing.Size(100, 16)
        Me.pbXIQ.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbXIQ.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(95, 246)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Sessions\"
        '
        'cbsessioncreds
        '
        Me.cbsessioncreds.AutoSize = True
        Me.cbsessioncreds.Location = New System.Drawing.Point(16, 114)
        Me.cbsessioncreds.Name = "cbsessioncreds"
        Me.cbsessioncreds.Size = New System.Drawing.Size(120, 17)
        Me.cbsessioncreds.TabIndex = 4
        Me.cbsessioncreds.Text = "use own credentials"
        Me.cbsessioncreds.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(25, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "session username"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(25, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "session password"
        '
        'tbsessionuser
        '
        Me.tbsessionuser.Location = New System.Drawing.Point(121, 19)
        Me.tbsessionuser.Name = "tbsessionuser"
        Me.tbsessionuser.Size = New System.Drawing.Size(130, 20)
        Me.tbsessionuser.TabIndex = 5
        '
        'tbsessionpassword
        '
        Me.tbsessionpassword.Location = New System.Drawing.Point(121, 45)
        Me.tbsessionpassword.Name = "tbsessionpassword"
        Me.tbsessionpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbsessionpassword.Size = New System.Drawing.Size(130, 20)
        Me.tbsessionpassword.TabIndex = 6
        '
        'gbsessioncreds
        '
        Me.gbsessioncreds.Controls.Add(Me.cbImportProfiles)
        Me.gbsessioncreds.Controls.Add(Me.tbsessionpassword)
        Me.gbsessioncreds.Controls.Add(Me.Label8)
        Me.gbsessioncreds.Controls.Add(Me.tbsessionuser)
        Me.gbsessioncreds.Controls.Add(Me.Label9)
        Me.gbsessioncreds.Enabled = False
        Me.gbsessioncreds.Location = New System.Drawing.Point(12, 137)
        Me.gbsessioncreds.Name = "gbsessioncreds"
        Me.gbsessioncreds.Size = New System.Drawing.Size(279, 97)
        Me.gbsessioncreds.TabIndex = 9
        Me.gbsessioncreds.TabStop = False
        Me.gbsessioncreds.Text = "session credentials"
        '
        'cbImportProfiles
        '
        Me.cbImportProfiles.AutoSize = True
        Me.cbImportProfiles.Location = New System.Drawing.Point(28, 74)
        Me.cbImportProfiles.Name = "cbImportProfiles"
        Me.cbImportProfiles.Size = New System.Drawing.Size(120, 17)
        Me.cbImportProfiles.TabIndex = 7
        Me.cbImportProfiles.Text = "import xiq-se profiles"
        Me.cbImportProfiles.UseVisualStyleBackColor = True
        '
        'XIQ_SE_import
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(309, 288)
        Me.Controls.Add(Me.gbsessioncreds)
        Me.Controls.Add(Me.cbsessioncreds)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbxiqimportfolder)
        Me.Controls.Add(Me.tbxiqpassword)
        Me.Controls.Add(Me.tbxiquser)
        Me.Controls.Add(Me.tbUrl)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "XIQ_SE_import"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "import XIQ-SE Sessions"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.gbsessioncreds.ResumeLayout(False)
        Me.gbsessioncreds.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btimport As ToolStripButton
    Friend WithEvents btcancel As ToolStripButton
    Friend WithEvents Label1 As Label
    Friend WithEvents tbUrl As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents tbxiquser As TextBox
    Friend WithEvents tbxiqpassword As TextBox
    Friend WithEvents tbxiqimportfolder As TextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents pbXIQ As ToolStripProgressBar
    Friend WithEvents tsslXIQ As ToolStripStatusLabel
    Friend WithEvents Label7 As Label
    Friend WithEvents cbsessioncreds As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents tbsessionuser As TextBox
    Friend WithEvents tbsessionpassword As TextBox
    Friend WithEvents gbsessioncreds As GroupBox
    Friend WithEvents cbImportProfiles As CheckBox
End Class
