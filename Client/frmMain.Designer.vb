<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.txtMessages = New System.Windows.Forms.TextBox()
        Me.gbStatus = New System.Windows.Forms.GroupBox()
        Me.txtProfit = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.lblCounterPart = New System.Windows.Forms.Label()
        Me.grdCommon = New System.Windows.Forms.DataGridView()
        Me.numLearn = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblLearnCost = New System.Windows.Forms.Label()
        Me.numInvent = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblInventCost = New System.Windows.Forms.Label()
        Me.grdInventWords = New System.Windows.Forms.DataGridView()
        Me.colSymbol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMeaning = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grdPrivate = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbStatus.SuspendLayout()
        CType(Me.grdCommon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLearn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numInvent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdInventWords, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdPrivate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtMessages
        '
        Me.txtMessages.BackColor = System.Drawing.Color.White
        Me.txtMessages.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMessages.Location = New System.Drawing.Point(10, 639)
        Me.txtMessages.Name = "txtMessages"
        Me.txtMessages.ReadOnly = True
        Me.txtMessages.Size = New System.Drawing.Size(994, 29)
        Me.txtMessages.TabIndex = 6
        '
        'gbStatus
        '
        Me.gbStatus.Controls.Add(Me.txtProfit)
        Me.gbStatus.Controls.Add(Me.Label1)
        Me.gbStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbStatus.Location = New System.Drawing.Point(895, 433)
        Me.gbStatus.Name = "gbStatus"
        Me.gbStatus.Size = New System.Drawing.Size(109, 200)
        Me.gbStatus.TabIndex = 5
        Me.gbStatus.TabStop = False
        Me.gbStatus.Text = "Status"
        Me.gbStatus.Visible = False
        '
        'txtProfit
        '
        Me.txtProfit.BackColor = System.Drawing.Color.White
        Me.txtProfit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProfit.Location = New System.Drawing.Point(21, 63)
        Me.txtProfit.Name = "txtProfit"
        Me.txtProfit.ReadOnly = True
        Me.txtProfit.Size = New System.Drawing.Size(73, 26)
        Me.txtProfit.TabIndex = 7
        Me.txtProfit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Earnings"
        '
        'Timer1
        '
        '
        'Timer2
        '
        '
        'lblCounterPart
        '
        Me.lblCounterPart.AutoSize = True
        Me.lblCounterPart.Location = New System.Drawing.Point(10, 13)
        Me.lblCounterPart.Name = "lblCounterPart"
        Me.lblCounterPart.Size = New System.Drawing.Size(119, 12)
        Me.lblCounterPart.TabIndex = 7
        Me.lblCounterPart.Text = "Your CounterPart is"
        '
        'grdCommon
        '
        Me.grdCommon.AllowUserToAddRows = False
        Me.grdCommon.AllowUserToDeleteRows = False
        Me.grdCommon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdCommon.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.grdCommon.Location = New System.Drawing.Point(90, 52)
        Me.grdCommon.Name = "grdCommon"
        Me.grdCommon.RowTemplate.Height = 23
        Me.grdCommon.Size = New System.Drawing.Size(350, 118)
        Me.grdCommon.TabIndex = 8
        '
        'numLearn
        '
        Me.numLearn.Location = New System.Drawing.Point(123, 266)
        Me.numLearn.Name = "numLearn"
        Me.numLearn.Size = New System.Drawing.Size(66, 21)
        Me.numLearn.TabIndex = 9
        Me.numLearn.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(31, 235)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "I want to"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(48, 266)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "learn"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(48, 303)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "learn"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(216, 271)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(212, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "words from Red Group at cost"
        '
        'lblLearnCost
        '
        Me.lblLearnCost.AutoSize = True
        Me.lblLearnCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblLearnCost.Location = New System.Drawing.Point(445, 271)
        Me.lblLearnCost.Name = "lblLearnCost"
        Me.lblLearnCost.Size = New System.Drawing.Size(16, 16)
        Me.lblLearnCost.TabIndex = 14
        Me.lblLearnCost.Tag = "1"
        Me.lblLearnCost.Text = "1"
        '
        'numInvent
        '
        Me.numInvent.Location = New System.Drawing.Point(123, 303)
        Me.numInvent.Name = "numInvent"
        Me.numInvent.Size = New System.Drawing.Size(66, 21)
        Me.numInvent.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(216, 302)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(402, 16)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "words from that is understood only by my chooser at cost "
        '
        'lblInventCost
        '
        Me.lblInventCost.AutoSize = True
        Me.lblInventCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblInventCost.Location = New System.Drawing.Point(637, 302)
        Me.lblInventCost.Name = "lblInventCost"
        Me.lblInventCost.Size = New System.Drawing.Size(16, 16)
        Me.lblInventCost.TabIndex = 17
        Me.lblInventCost.Tag = "1"
        Me.lblInventCost.Text = "1"
        '
        'grdInventWords
        '
        Me.grdInventWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdInventWords.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSymbol, Me.colMeaning})
        Me.grdInventWords.Location = New System.Drawing.Point(123, 341)
        Me.grdInventWords.Name = "grdInventWords"
        Me.grdInventWords.RowTemplate.Height = 23
        Me.grdInventWords.Size = New System.Drawing.Size(305, 112)
        Me.grdInventWords.TabIndex = 18
        '
        'colSymbol
        '
        Me.colSymbol.HeaderText = "Use to refer"
        Me.colSymbol.Name = "colSymbol"
        '
        'colMeaning
        '
        Me.colMeaning.HeaderText = "to"
        Me.colMeaning.Name = "colMeaning"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 12)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Common List"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(446, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 12)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Private List"
        '
        'grdPrivate
        '
        Me.grdPrivate.AllowUserToAddRows = False
        Me.grdPrivate.AllowUserToDeleteRows = False
        Me.grdPrivate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPrivate.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column5, Me.Column6})
        Me.grdPrivate.Location = New System.Drawing.Point(540, 52)
        Me.grdPrivate.Name = "grdPrivate"
        Me.grdPrivate.RowTemplate.Height = 23
        Me.grdPrivate.Size = New System.Drawing.Size(344, 118)
        Me.grdPrivate.TabIndex = 21
        '
        'Column1
        '
        Me.Column1.HeaderText = "a"
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "b"
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        Me.Column3.HeaderText = "c"
        Me.Column3.Name = "Column3"
        '
        'Column4
        '
        Me.Column4.HeaderText = "a"
        Me.Column4.Name = "Column4"
        '
        'Column5
        '
        Me.Column5.HeaderText = "b"
        Me.Column5.Name = "Column5"
        '
        'Column6
        '
        Me.Column6.HeaderText = "c"
        Me.Column6.Name = "Column6"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 678)
        Me.ControlBox = False
        Me.Controls.Add(Me.grdPrivate)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.grdInventWords)
        Me.Controls.Add(Me.lblInventCost)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.numInvent)
        Me.Controls.Add(Me.lblLearnCost)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.numLearn)
        Me.Controls.Add(Me.grdCommon)
        Me.Controls.Add(Me.lblCounterPart)
        Me.Controls.Add(Me.txtMessages)
        Me.Controls.Add(Me.gbStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmMain"
        Me.Text = "Client"
        Me.gbStatus.ResumeLayout(False)
        Me.gbStatus.PerformLayout()
        CType(Me.grdCommon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLearn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numInvent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdInventWords, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdPrivate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMessages As System.Windows.Forms.TextBox
    Friend WithEvents gbStatus As System.Windows.Forms.GroupBox
    Friend WithEvents txtProfit As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents lblCounterPart As System.Windows.Forms.Label
    Friend WithEvents grdCommon As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents numLearn As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblLearnCost As System.Windows.Forms.Label
    Friend WithEvents numInvent As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblInventCost As System.Windows.Forms.Label
    Friend WithEvents grdInventWords As System.Windows.Forms.DataGridView
    Friend WithEvents colSymbol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMeaning As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents grdPrivate As System.Windows.Forms.DataGridView
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
