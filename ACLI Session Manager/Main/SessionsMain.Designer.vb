<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SessionsMain
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SessionsMain))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.Launch = New System.Windows.Forms.ToolStripButton()
        Me.tsbtQuickConnect = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tssbSessionHandling = New System.Windows.Forms.ToolStripSplitButton()
        Me.tsmiNewSession = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiEditSession = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiDeleteSession = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tssbImport = New System.Windows.Forms.ToolStripSplitButton()
        Me.tsmiSecureCRT = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiXIQ = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tssbSettings = New System.Windows.Forms.ToolStripSplitButton()
        Me.tsmiSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiProfileManager = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tbContainWindow = New System.Windows.Forms.ToolStripTextBox()
        Me.tsbtUpdate = New System.Windows.Forms.ToolStripButton()
        Me.TVSessions = New CodersLab.Windows.Controls.TreeView()
        Me.cmsSessions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LaunchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.NewSessionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.btFilter = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsslFilter = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStrip1.SuspendLayout()
        Me.cmsSessions.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Launch, Me.tsbtQuickConnect, Me.ToolStripSeparator1, Me.tssbSessionHandling, Me.ToolStripSeparator2, Me.tssbImport, Me.ToolStripSeparator4, Me.tssbSettings, Me.ToolStripSeparator9, Me.tbContainWindow, Me.tsbtUpdate})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(467, 31)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'Launch
        '
        Me.Launch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Launch.Image = Global.ACLI_Session_Manager.My.Resources.Resources.terminal_icon1
        Me.Launch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Launch.Name = "Launch"
        Me.Launch.Size = New System.Drawing.Size(29, 28)
        Me.Launch.Text = "Launch"
        '
        'tsbtQuickConnect
        '
        Me.tsbtQuickConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtQuickConnect.Image = Global.ACLI_Session_Manager.My.Resources.Resources.QuickConnect2
        Me.tsbtQuickConnect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtQuickConnect.Name = "tsbtQuickConnect"
        Me.tsbtQuickConnect.Size = New System.Drawing.Size(29, 28)
        Me.tsbtQuickConnect.Text = "Quick Launch"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'tssbSessionHandling
        '
        Me.tssbSessionHandling.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tssbSessionHandling.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiNewSession, Me.tsmiEditSession, Me.tsmiDeleteSession})
        Me.tssbSessionHandling.Image = Global.ACLI_Session_Manager.My.Resources.Resources.computer_icon1
        Me.tssbSessionHandling.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tssbSessionHandling.Name = "tssbSessionHandling"
        Me.tssbSessionHandling.Size = New System.Drawing.Size(39, 28)
        Me.tssbSessionHandling.Text = "Session"
        Me.tssbSessionHandling.ToolTipText = "Session"
        '
        'tsmiNewSession
        '
        Me.tsmiNewSession.Image = Global.ACLI_Session_Manager.My.Resources.Resources.computer_icon1
        Me.tsmiNewSession.Name = "tsmiNewSession"
        Me.tsmiNewSession.Size = New System.Drawing.Size(172, 26)
        Me.tsmiNewSession.Text = "new Session"
        '
        'tsmiEditSession
        '
        Me.tsmiEditSession.Image = Global.ACLI_Session_Manager.My.Resources.Resources.pencil_icon1
        Me.tsmiEditSession.Name = "tsmiEditSession"
        Me.tsmiEditSession.Size = New System.Drawing.Size(172, 26)
        Me.tsmiEditSession.Text = "edit Session"
        '
        'tsmiDeleteSession
        '
        Me.tsmiDeleteSession.Image = Global.ACLI_Session_Manager.My.Resources.Resources.sign_error_icon1
        Me.tsmiDeleteSession.Name = "tsmiDeleteSession"
        Me.tsmiDeleteSession.Size = New System.Drawing.Size(172, 26)
        Me.tsmiDeleteSession.Text = "delete"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'tssbImport
        '
        Me.tssbImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tssbImport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiSecureCRT, Me.tsmiXIQ})
        Me.tssbImport.Image = Global.ACLI_Session_Manager.My.Resources.Resources.box_in_icon1
        Me.tssbImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tssbImport.Name = "tssbImport"
        Me.tssbImport.Size = New System.Drawing.Size(39, 28)
        Me.tssbImport.Text = "Import Sessions"
        '
        'tsmiSecureCRT
        '
        Me.tsmiSecureCRT.Image = Global.ACLI_Session_Manager.My.Resources.Resources.box_in_icon1
        Me.tsmiSecureCRT.Name = "tsmiSecureCRT"
        Me.tsmiSecureCRT.Size = New System.Drawing.Size(224, 26)
        Me.tsmiSecureCRT.Text = "from SecureCRT"
        '
        'tsmiXIQ
        '
        Me.tsmiXIQ.Image = Global.ACLI_Session_Manager.My.Resources.Resources.box_in_icon1
        Me.tsmiXIQ.Name = "tsmiXIQ"
        Me.tsmiXIQ.Size = New System.Drawing.Size(224, 26)
        Me.tsmiXIQ.Text = "from XMC/XIQ-SE"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'tssbSettings
        '
        Me.tssbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tssbSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiSettings, Me.tsmiProfileManager, Me.AboutToolStripMenuItem})
        Me.tssbSettings.Image = Global.ACLI_Session_Manager.My.Resources.Resources.cogs_icon1
        Me.tssbSettings.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tssbSettings.Name = "tssbSettings"
        Me.tssbSettings.Size = New System.Drawing.Size(39, 28)
        Me.tssbSettings.Text = "settings"
        '
        'tsmiSettings
        '
        Me.tsmiSettings.Image = Global.ACLI_Session_Manager.My.Resources.Resources.cogs_icon1
        Me.tsmiSettings.Name = "tsmiSettings"
        Me.tsmiSettings.Size = New System.Drawing.Size(198, 26)
        Me.tsmiSettings.Text = "settings"
        '
        'tsmiProfileManager
        '
        Me.tsmiProfileManager.Image = Global.ACLI_Session_Manager.My.Resources.Resources.group_user_icon
        Me.tsmiProfileManager.Name = "tsmiProfileManager"
        Me.tsmiProfileManager.Size = New System.Drawing.Size(198, 26)
        Me.tsmiProfileManager.Text = "Profile Manager"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = Global.ACLI_Session_Manager.My.Resources.Resources.info_sign_icon1
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(198, 26)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
        '
        'tbContainWindow
        '
        Me.tbContainWindow.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tbContainWindow.Name = "tbContainWindow"
        Me.tbContainWindow.Size = New System.Drawing.Size(119, 31)
        Me.tbContainWindow.ToolTipText = "containing window"
        '
        'tsbtUpdate
        '
        Me.tsbtUpdate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbtUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtUpdate.Image = Global.ACLI_Session_Manager.My.Resources.Resources.update_system_software_icon1
        Me.tsbtUpdate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtUpdate.Name = "tsbtUpdate"
        Me.tsbtUpdate.Size = New System.Drawing.Size(29, 28)
        Me.tsbtUpdate.Text = "check for update"
        '
        'TVSessions
        '
        Me.TVSessions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TVSessions.ContextMenuStrip = Me.cmsSessions
        Me.TVSessions.ImageIndex = 0
        Me.TVSessions.ImageList = Me.ImageList1
        Me.TVSessions.Location = New System.Drawing.Point(0, 66)
        Me.TVSessions.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TVSessions.Name = "TVSessions"
        Me.TVSessions.SelectedImageIndex = 0
        Me.TVSessions.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.TVSessions.SelectionMode = CodersLab.Windows.Controls.TreeViewSelectionMode.MultiSelect
        Me.TVSessions.ShowNodeToolTips = True
        Me.TVSessions.Size = New System.Drawing.Size(465, 400)
        Me.TVSessions.TabIndex = 1
        '
        'cmsSessions
        '
        Me.cmsSessions.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.cmsSessions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LaunchToolStripMenuItem, Me.ToolStripSeparator6, Me.NewSessionToolStripMenuItem, Me.NewFolderToolStripMenuItem, Me.ToolStripSeparator7, Me.EditToolStripMenuItem, Me.CloneToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.cmsSessions.Name = "cmsSessions"
        Me.cmsSessions.Size = New System.Drawing.Size(163, 172)
        '
        'LaunchToolStripMenuItem
        '
        Me.LaunchToolStripMenuItem.Image = Global.ACLI_Session_Manager.My.Resources.Resources.terminal_icon1
        Me.LaunchToolStripMenuItem.Name = "LaunchToolStripMenuItem"
        Me.LaunchToolStripMenuItem.Size = New System.Drawing.Size(162, 26)
        Me.LaunchToolStripMenuItem.Text = "launch"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(159, 6)
        '
        'NewSessionToolStripMenuItem
        '
        Me.NewSessionToolStripMenuItem.Image = Global.ACLI_Session_Manager.My.Resources.Resources.computer_icon1
        Me.NewSessionToolStripMenuItem.Name = "NewSessionToolStripMenuItem"
        Me.NewSessionToolStripMenuItem.Size = New System.Drawing.Size(162, 26)
        Me.NewSessionToolStripMenuItem.Text = "new Session"
        '
        'NewFolderToolStripMenuItem
        '
        Me.NewFolderToolStripMenuItem.Image = Global.ACLI_Session_Manager.My.Resources.Resources.folder_icon1
        Me.NewFolderToolStripMenuItem.Name = "NewFolderToolStripMenuItem"
        Me.NewFolderToolStripMenuItem.Size = New System.Drawing.Size(162, 26)
        Me.NewFolderToolStripMenuItem.Text = "new Folder"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(159, 6)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Image = Global.ACLI_Session_Manager.My.Resources.Resources.pencil_icon1
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(162, 26)
        Me.EditToolStripMenuItem.Text = "edit"
        '
        'CloneToolStripMenuItem
        '
        Me.CloneToolStripMenuItem.Image = Global.ACLI_Session_Manager.My.Resources.Resources.duplicate
        Me.CloneToolStripMenuItem.Name = "CloneToolStripMenuItem"
        Me.CloneToolStripMenuItem.Size = New System.Drawing.Size(162, 26)
        Me.CloneToolStripMenuItem.Text = "clone"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Image = Global.ACLI_Session_Manager.My.Resources.Resources.sign_error_icon1
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(162, 26)
        Me.DeleteToolStripMenuItem.Text = "delete"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "folder_icon.png")
        Me.ImageList1.Images.SetKeyName(1, "computer_icon.png")
        Me.ImageList1.Images.SetKeyName(2, "ssh.png")
        Me.ImageList1.Images.SetKeyName(3, "tablet_icon.png")
        Me.ImageList1.Images.SetKeyName(4, "rdp.png")
        '
        'txtFilter
        '
        Me.txtFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFilter.Location = New System.Drawing.Point(0, 36)
        Me.txtFilter.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(415, 22)
        Me.txtFilter.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtFilter, "enter your search text and hit ENTER")
        '
        'btFilter
        '
        Me.btFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btFilter.BackgroundImage = Global.ACLI_Session_Manager.My.Resources.Resources.search_icon_481
        Me.btFilter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btFilter.Location = New System.Drawing.Point(424, 33)
        Me.btFilter.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btFilter.Name = "btFilter"
        Me.btFilter.Size = New System.Drawing.Size(37, 28)
        Me.btFilter.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.btFilter, "clear filter")
        Me.btFilter.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslFilter})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 476)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(467, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslFilter
        '
        Me.tsslFilter.Name = "tsslFilter"
        Me.tsslFilter.Size = New System.Drawing.Size(447, 20)
        Me.tsslFilter.Spring = True
        Me.tsslFilter.Text = "Filter"
        Me.tsslFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tsslFilter.Visible = False
        '
        'SessionsMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 498)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btFilter)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.TVSessions)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "SessionsMain"
        Me.Text = "ACLI Session Manager"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.cmsSessions.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents Launch As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tbContainWindow As ToolStripTextBox
    Friend WithEvents tsbtUpdate As ToolStripButton
    Friend WithEvents TVSessions As CodersLab.Windows.Controls.TreeView
    Friend WithEvents txtFilter As TextBox
    Friend WithEvents btFilter As Button
    Friend WithEvents cmsSessions As ContextMenuStrip
    Friend WithEvents LaunchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents NewSessionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsslFilter As ToolStripStatusLabel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents CloneToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents tssbImport As ToolStripSplitButton
    Friend WithEvents tsmiSecureCRT As ToolStripMenuItem
    Friend WithEvents tsmiXIQ As ToolStripMenuItem
    Friend WithEvents tsbtQuickConnect As ToolStripButton
    Friend WithEvents tssbSettings As ToolStripSplitButton
    Friend WithEvents tsmiSettings As ToolStripMenuItem
    Friend WithEvents tsmiProfileManager As ToolStripMenuItem
    Friend WithEvents tssbSessionHandling As ToolStripSplitButton
    Friend WithEvents tsmiNewSession As ToolStripMenuItem
    Friend WithEvents tsmiEditSession As ToolStripMenuItem
    Friend WithEvents tsmiDeleteSession As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
End Class
