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
        Me.cmdSubmit = New System.Windows.Forms.Button
        Me.grdmatrix = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboMeanings = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.pnlPhase2 = New System.Windows.Forms.Panel
        Me.lblCounterPartPhase1 = New System.Windows.Forms.Label
        CType(Me.grdmatrix, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPhase2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdSubmit
        '
        Me.cmdSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSubmit.Location = New System.Drawing.Point(61, 344)
        Me.cmdSubmit.Name = "cmdSubmit"
        Me.cmdSubmit.Size = New System.Drawing.Size(296, 34)
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
        Me.grdmatrix.Location = New System.Drawing.Point(38, 23)
        Me.grdmatrix.Name = "grdmatrix"
        Me.grdmatrix.ReadOnly = True
        Me.grdmatrix.RowTemplate.Height = 23
        Me.grdmatrix.Size = New System.Drawing.Size(376, 167)
        Me.grdmatrix.TabIndex = 38
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(245, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "'s sender has instructed his/her chooser to choose"
        '
        'cboMeanings
        '
        Me.cboMeanings.FormattingEnabled = True
        Me.cboMeanings.Location = New System.Drawing.Point(127, 308)
        Me.cboMeanings.Name = "cboMeanings"
        Me.cboMeanings.Size = New System.Drawing.Size(48, 21)
        Me.cboMeanings.TabIndex = 40
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(155, 271)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Instructoin to chooser"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 311)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Please choose"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(181, 311)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 13)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "in the next period game"
        '
        'pnlPhase2
        '
        Me.pnlPhase2.Controls.Add(Me.lblCounterPartPhase1)
        Me.pnlPhase2.Controls.Add(Me.Label1)
        Me.pnlPhase2.Location = New System.Drawing.Point(23, 219)
        Me.pnlPhase2.Name = "pnlPhase2"
        Me.pnlPhase2.Size = New System.Drawing.Size(409, 39)
        Me.pnlPhase2.TabIndex = 45
        '
        'lblCounterPartPhase1
        '
        Me.lblCounterPartPhase1.AutoSize = True
        Me.lblCounterPartPhase1.Location = New System.Drawing.Point(277, 9)
        Me.lblCounterPartPhase1.Name = "lblCounterPartPhase1"
        Me.lblCounterPartPhase1.Size = New System.Drawing.Size(0, 13)
        Me.lblCounterPartPhase1.TabIndex = 45
        '
        'frmDecision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 400)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlPhase2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlPhase2 As System.Windows.Forms.Panel
    Friend WithEvents lblCounterPartPhase1 As System.Windows.Forms.Label
End Class
