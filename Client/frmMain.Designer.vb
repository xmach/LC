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
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("a", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("b", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("c", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"%", "1", "2"}, -1)
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(">")
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("}")
        Dim ListViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("a", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup5 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("b", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("*")
        Dim ListViewItem5 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("@")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.txtMessages = New System.Windows.Forms.TextBox()
        Me.gbStatus = New System.Windows.Forms.GroupBox()
        Me.txtProfit = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.numLearn = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblLearnCost = New System.Windows.Forms.Label()
        Me.numInvent = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblInventCost = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ListView2 = New System.Windows.Forms.ListView()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.a = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gbStatus.SuspendLayout()
        CType(Me.numLearn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numInvent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'numLearn
        '
        Me.numLearn.Location = New System.Drawing.Point(163, 385)
        Me.numLearn.Name = "numLearn"
        Me.numLearn.Size = New System.Drawing.Size(66, 21)
        Me.numLearn.TabIndex = 9
        Me.numLearn.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(71, 354)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "I want to"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(88, 385)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "learn"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(88, 422)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "learn"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(256, 390)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(212, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "words from Red Group at cost"
        '
        'lblLearnCost
        '
        Me.lblLearnCost.AutoSize = True
        Me.lblLearnCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblLearnCost.Location = New System.Drawing.Point(485, 390)
        Me.lblLearnCost.Name = "lblLearnCost"
        Me.lblLearnCost.Size = New System.Drawing.Size(16, 16)
        Me.lblLearnCost.TabIndex = 14
        Me.lblLearnCost.Tag = "1"
        Me.lblLearnCost.Text = "1"
        '
        'numInvent
        '
        Me.numInvent.Location = New System.Drawing.Point(163, 422)
        Me.numInvent.Name = "numInvent"
        Me.numInvent.Size = New System.Drawing.Size(66, 21)
        Me.numInvent.TabIndex = 15
        Me.numInvent.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(256, 421)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(402, 16)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "words from that is understood only by my chooser at cost "
        '
        'lblInventCost
        '
        Me.lblInventCost.AutoSize = True
        Me.lblInventCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblInventCost.Location = New System.Drawing.Point(677, 421)
        Me.lblInventCost.Name = "lblInventCost"
        Me.lblInventCost.Size = New System.Drawing.Size(16, 16)
        Me.lblInventCost.TabIndex = 17
        Me.lblInventCost.Tag = "1"
        Me.lblInventCost.Text = "3"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(107, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 12)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Common List"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(452, 124)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 12)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Private List"
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        ListViewGroup1.Header = "a"
        ListViewGroup1.Name = "ListViewGroupA"
        ListViewGroup2.Header = "b"
        ListViewGroup2.Name = "ListViewGroupB"
        ListViewGroup3.Header = "c"
        ListViewGroup3.Name = "ListViewGroupC"
        Me.ListView1.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3})
        ListViewItem1.Group = ListViewGroup1
        ListViewItem2.Group = ListViewGroup2
        ListViewItem3.Group = ListViewGroup3
        Me.ListView1.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3})
        Me.ListView1.Location = New System.Drawing.Point(62, 151)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(327, 200)
        Me.ListView1.TabIndex = 22
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ListView2
        '
        ListViewGroup4.Header = "a"
        ListViewGroup4.Name = "ListViewGroup1"
        ListViewGroup5.Header = "b"
        ListViewGroup5.Name = "ListViewGroup2"
        Me.ListView2.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup4, ListViewGroup5})
        ListViewItem4.Group = ListViewGroup4
        ListViewItem5.Group = ListViewGroup5
        Me.ListView2.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem4, ListViewItem5})
        Me.ListView2.Location = New System.Drawing.Point(463, 151)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(307, 200)
        Me.ListView2.TabIndex = 23
        Me.ListView2.UseCompatibleStateImageBehavior = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(160, 483)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 16)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "use"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(199, 478)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 21)
        Me.TextBox1.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(160, 552)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 16)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "use"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(160, 515)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 16)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "use"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(199, 510)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 21)
        Me.TextBox2.TabIndex = 28
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(199, 547)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 21)
        Me.TextBox3.TabIndex = 29
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(360, 478)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 16)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "to refer"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(360, 510)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 16)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "to refer"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(360, 547)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 16)
        Me.Label14.TabIndex = 32
        Me.Label14.Text = "to refer"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(463, 473)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(100, 21)
        Me.TextBox4.TabIndex = 33
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(463, 510)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(100, 21)
        Me.TextBox5.TabIndex = 34
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(463, 542)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(100, 21)
        Me.TextBox6.TabIndex = 35
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(393, 586)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "Submit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.a, Me.Column2, Me.Column3})
        Me.DataGridView1.Location = New System.Drawing.Point(91, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(492, 109)
        Me.DataGridView1.TabIndex = 37
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
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 678)
        Me.ControlBox = False
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.ListView2)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblInventCost)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.numInvent)
        Me.Controls.Add(Me.lblLearnCost)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.numLearn)
        Me.Controls.Add(Me.txtMessages)
        Me.Controls.Add(Me.gbStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmMain"
        Me.Text = "Client"
        Me.gbStatus.ResumeLayout(False)
        Me.gbStatus.PerformLayout()
        CType(Me.numLearn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numInvent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMessages As System.Windows.Forms.TextBox
    Friend WithEvents gbStatus As System.Windows.Forms.GroupBox
    Friend WithEvents txtProfit As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents numLearn As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblLearnCost As System.Windows.Forms.Label
    Friend WithEvents numInvent As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblInventCost As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents a As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
