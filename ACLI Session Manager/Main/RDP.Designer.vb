<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RDP
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RDP))
        Me.tcRDP = New ACLI_Session_Manager.ClosableTabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.tcRDP.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcRDP
        '
        Me.tcRDP.Controls.Add(Me.TabPage1)
        Me.tcRDP.Controls.Add(Me.TabPage2)
        Me.tcRDP.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcRDP.Location = New System.Drawing.Point(0, 0)
        Me.tcRDP.Name = "tcRDP"
        Me.tcRDP.SelectedIndex = 0
        Me.tcRDP.Size = New System.Drawing.Size(1435, 876)
        Me.tcRDP.TabIndex = 0
        Me.tcRDP.TabPageImage = Nothing
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1427, 847)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(192, 71)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'RDP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1435, 876)
        Me.Controls.Add(Me.tcRDP)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "RDP"
        Me.Text = "RDP"
        Me.tcRDP.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tcRDP As ClosableTabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
End Class
