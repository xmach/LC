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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmdSubmit = New System.Windows.Forms.Button()
        Me.grdmatrix = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboMeanings = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlPhase2 = New System.Windows.Forms.Panel()
        Me.lblCounterPartPhase1 = New System.Windows.Forms.Label()
        CType(Me.grdmatrix, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPhase2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSubmit
        '
        Me.cmdSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSubmit.Location = New System.Drawing.Point(61, 318)
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
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdmatrix.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grdmatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdmatrix.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdmatrix.Location = New System.Drawing.Point(38, 21)
        Me.grdmatrix.Name = "grdmatrix"
        Me.grdmatrix.ReadOnly = True
        Me.grdmatrix.RowTemplate.Height = 23
        Me.grdmatrix.Size = New System.Drawing.Size(376, 154)
        Me.grdmatrix.TabIndex = 38
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(3, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(283, 34)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Another sender has instructed his/her" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "chooser to choose"
        '
        'cboMeanings
        '
        Me.cboMeanings.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.cboMeanings.FormattingEnabled = True
        Me.cboMeanings.Location = New System.Drawing.Point(142, 284)
        Me.cboMeanings.Name = "cboMeanings"
        Me.cboMeanings.Size = New System.Drawing.Size(48, 28)
        Me.cboMeanings.TabIndex = 40
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(19, 284)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 17)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Please choose"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(217, 284)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(179, 17)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "in the next period game"
        '
        'pnlPhase2
        '
        Me.pnlPhase2.Controls.Add(Me.lblCounterPartPhase1)
        Me.pnlPhase2.Controls.Add(Me.Label1)
        Me.pnlPhase2.Location = New System.Drawing.Point(23, 181)
        Me.pnlPhase2.Name = "pnlPhase2"
        Me.pnlPhase2.Size = New System.Drawing.Size(409, 57)
        Me.pnlPhase2.TabIndex = 45
        '
        'lblCounterPartPhase1
        '
        Me.lblCounterPartPhase1.AutoSize = True
        Me.lblCounterPartPhase1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCounterPartPhase1.Location = New System.Drawing.Point(316, 25)
        Me.lblCounterPartPhase1.Name = "lblCounterPartPhase1"
        Me.lblCounterPartPhase1.Size = New System.Drawing.Size(57, 17)
        Me.lblCounterPartPhase1.TabIndex = 40
        Me.lblCounterPartPhase1.Text = "Label2"
        '
        'frmDecision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 369)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlPhase2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboMeanings)
        Me.Controls.Add(Me.grdmatrix)
        Me.Controls.Add(Me.cmdSubmit)
        Me.Name = "frmDecision"
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboMeanings As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlPhase2 As System.Windows.Forms.Panel
    Friend WithEvents lblCounterPartPhase1 As System.Windows.Forms.Label
End Class