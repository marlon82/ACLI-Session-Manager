<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProfileManager
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProfileManager))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbtNew = New System.Windows.Forms.ToolStripButton()
        Me.tsbtEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbtsave = New System.Windows.Forms.ToolStripButton()
        Me.dgvProfiles = New System.Windows.Forms.DataGridView()
        Me.ProfileID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.profname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.user = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pass = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsslSaveState = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvProfiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtNew, Me.tsbtEdit, Me.tsbDelete, Me.tsbtsave})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(403, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbtNew
        '
        Me.tsbtNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtNew.Image = Global.ACLI_Session_Manager.My.Resources.Resources.add_sign_icon
        Me.tsbtNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtNew.Name = "tsbtNew"
        Me.tsbtNew.Size = New System.Drawing.Size(23, 22)
        Me.tsbtNew.Text = "new profile"
        '
        'tsbtEdit
        '
        Me.tsbtEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtEdit.Image = Global.ACLI_Session_Manager.My.Resources.Resources.pencil_icon1
        Me.tsbtEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtEdit.Name = "tsbtEdit"
        Me.tsbtEdit.Size = New System.Drawing.Size(23, 22)
        Me.tsbtEdit.Text = "edit Profile"
        '
        'tsbDelete
        '
        Me.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDelete.Image = Global.ACLI_Session_Manager.My.Resources.Resources.ban_sign_icon1
        Me.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(23, 22)
        Me.tsbDelete.Text = "delete Profile"
        '
        'tsbtsave
        '
        Me.tsbtsave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbtsave.Image = Global.ACLI_Session_Manager.My.Resources.Resources.save_icon1
        Me.tsbtsave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtsave.Name = "tsbtsave"
        Me.tsbtsave.Size = New System.Drawing.Size(23, 22)
        Me.tsbtsave.Text = "save Profiles"
        '
        'dgvProfiles
        '
        Me.dgvProfiles.AllowUserToAddRows = False
        Me.dgvProfiles.AllowUserToDeleteRows = False
        Me.dgvProfiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvProfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProfiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProfileID, Me.profname, Me.user, Me.pass})
        Me.dgvProfiles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProfiles.Location = New System.Drawing.Point(0, 25)
        Me.dgvProfiles.MultiSelect = False
        Me.dgvProfiles.Name = "dgvProfiles"
        Me.dgvProfiles.ReadOnly = True
        Me.dgvProfiles.RowHeadersVisible = False
        Me.dgvProfiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProfiles.Size = New System.Drawing.Size(403, 218)
        Me.dgvProfiles.TabIndex = 1
        '
        'ProfileID
        '
        Me.ProfileID.DataPropertyName = "ProfileID"
        Me.ProfileID.HeaderText = "ID"
        Me.ProfileID.Name = "ProfileID"
        Me.ProfileID.ReadOnly = True
        Me.ProfileID.Width = 43
        '
        'profname
        '
        Me.profname.DataPropertyName = "name"
        Me.profname.HeaderText = "Name"
        Me.profname.Name = "profname"
        Me.profname.ReadOnly = True
        Me.profname.Width = 60
        '
        'user
        '
        Me.user.DataPropertyName = "user"
        Me.user.HeaderText = "Username"
        Me.user.Name = "user"
        Me.user.ReadOnly = True
        Me.user.Width = 80
        '
        'pass
        '
        Me.pass.DataPropertyName = "pass"
        Me.pass.HeaderText = "Password"
        Me.pass.Name = "pass"
        Me.pass.ReadOnly = True
        Me.pass.Visible = False
        Me.pass.Width = 78
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslSaveState})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 221)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(403, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslSaveState
        '
        Me.tsslSaveState.Name = "tsslSaveState"
        Me.tsslSaveState.Size = New System.Drawing.Size(119, 17)
        Me.tsslSaveState.Text = "ToolStripStatusLabel1"
        Me.tsslSaveState.Visible = False
        '
        'ProfileManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(403, 243)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.dgvProfiles)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ProfileManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ProfileManager"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvProfiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsbtNew As ToolStripButton
    Friend WithEvents tsbtEdit As ToolStripButton
    Friend WithEvents tsbDelete As ToolStripButton
    Friend WithEvents tsbtsave As ToolStripButton
    Friend WithEvents dgvProfiles As DataGridView
    Friend WithEvents ProfileID As DataGridViewTextBoxColumn
    Friend WithEvents profname As DataGridViewTextBoxColumn
    Friend WithEvents user As DataGridViewTextBoxColumn
    Friend WithEvents pass As DataGridViewTextBoxColumn
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsslSaveState As ToolStripStatusLabel
End Class
