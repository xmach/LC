<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScoreMatrix
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdSave = New System.Windows.Forms.Button
        Me.grdCooperate = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.grdCompete = New System.Windows.Forms.DataGridView
        CType(Me.grdCooperate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdCompete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(15, 435)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(407, 27)
        Me.cmdSave.TabIndex = 44
        Me.cmdSave.Text = "Save and Close"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'grdCooperate
        '
        Me.grdCooperate.AllowUserToAddRows = False
        Me.grdCooperate.AllowUserToDeleteRows = False
        Me.grdCooperate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCooperate.Location = New System.Drawing.Point(12, 27)
        Me.grdCooperate.Name = "grdCooperate"
        Me.grdCooperate.ReadOnly = True
        Me.grdCooperate.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.grdCooperate.ShowEditingIcon = False
        Me.grdCooperate.Size = New System.Drawing.Size(407, 182)
        Me.grdCooperate.TabIndex = 45
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Cooperate"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 226)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Compete"
        '
        'grdCompete
        '
        Me.grdCompete.AllowUserToAddRows = False
        Me.grdCompete.AllowUserToDeleteRows = False
        Me.grdCompete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCompete.Location = New System.Drawing.Point(12, 242)
        Me.grdCompete.Name = "grdCompete"
        Me.grdCompete.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.grdCompete.ShowEditingIcon = False
        Me.grdCompete.Size = New System.Drawing.Size(407, 160)
        Me.grdCompete.TabIndex = 48
        '
        'frmScoreMatrix
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 501)
        Me.ControlBox = False
        Me.Controls.Add(Me.grdCompete)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grdCooperate)
        Me.Controls.Add(Me.cmdSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmScoreMatrix"
        Me.ShowIcon = False
        Me.Text = "frmScoreMatrix"
        CType(Me.grdCooperate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdCompete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents grdCooperate As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdCompete As System.Windows.Forms.DataGridView
End Class
