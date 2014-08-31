<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDecision
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdSubmit = New System.Windows.Forms.Button()
        Me.grdmatrix = New System.Windows.Forms.DataGridView()
        Me.a = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboMeanings = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblCounterpartDecision = New System.Windows.Forms.Label()
        Me.pnlPhase2 = New System.Windows.Forms.Panel()
        CType(Me.grdmatrix, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPhase2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSubmit
        '
        Me.cmdSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSubmit.Location = New System.Drawing.Point(93, 314)
        Me.cmdSubmit.Name = "cmdSubmit"
        Me.cmdSubmit.Size = New System.Drawing.Size(296, 31)
        Me.cmdSubmit.TabIndex = 32
        Me.cmdSubmit.Text = "Submit"
        Me.cmdSubmit.UseVisualStyleBackColor = True
        '
        'grdmatrix
        '
        Me.grdmatrix.AllowUserToAddRows = False
        Me.grdmatrix.AllowUserToDeleteRows = False
        Me.grdmatrix.AllowUserToResizeColumns = False
        Me.grdmatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdmatrix.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.a, Me.Column2, Me.Column3})
        Me.grdmatrix.Location = New System.Drawing.Point(38, 21)
        Me.grdmatrix.Name = "grdmatrix"
        Me.grdmatrix.ReadOnly = True
        Me.grdmatrix.RowTemplate.Height = 23
        Me.grdmatrix.Size = New System.Drawing.Size(351, 133)
        Me.grdmatrix.TabIndex = 38
        '
        'a
        '
        Me.a.HeaderText = "a"
        Me.a.Name = "a"
        Me.a.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "b"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "c"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(305, 12)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "'s sender has instructed his/her chooser to choose"
        '
        'cboMeanings
        '
        Me.cboMeanings.FormattingEnabled = True
        Me.cboMeanings.Location = New System.Drawing.Point(127, 284)
        Me.cboMeanings.Name = "cboMeanings"
        Me.cboMeanings.Size = New System.Drawing.Size(48, 20)
        Me.cboMeanings.TabIndex = 40
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(155, 250)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 12)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Instructoin to chooser"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 287)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 12)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Please choose"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(181, 287)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(143, 12)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "in the next period game"
        '
        'lblCounterpartDecision
        '
        Me.lblCounterpartDecision.AutoSize = True
        Me.lblCounterpartDecision.Location = New System.Drawing.Point(352, 9)
        Me.lblCounterpartDecision.Name = "lblCounterpartDecision"
        Me.lblCounterpartDecision.Size = New System.Drawing.Size(0, 12)
        Me.lblCounterpartDecision.TabIndex = 44
        '
        'pnlPhase2
        '
        Me.pnlPhase2.Controls.Add(Me.Label1)
        Me.pnlPhase2.Controls.Add(Me.lblCounterpartDecision)
        Me.pnlPhase2.Location = New System.Drawing.Point(22, 181)
        Me.pnlPhase2.Name = "pnlPhase2"
        Me.pnlPhase2.Size = New System.Drawing.Size(409, 40)
        Me.pnlPhase2.TabIndex = 45
        '
        'frmPhase2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 369)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlPhase2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboMeanings)
        Me.Controls.Add(Me.grdmatrix)
        Me.Controls.Add(Me.cmdSubmit)
        Me.Name = "frmPhase2"
        Me.ShowIcon = False
        Me.Text = "Reconfirm your choice"
        CType(Me.grdmatrix, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPhase2.ResumeLayout(False)
        Me.pnlPhase2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSubmit As System.Windows.Forms.Button
    Friend WithEvents grdmatrix As System.Windows.Forms.DataGridView
    Friend WithEvents a As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboMeanings As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblCounterpartDecision As System.Windows.Forms.Label
    Friend WithEvents pnlPhase2 As System.Windows.Forms.Panel
End Class
