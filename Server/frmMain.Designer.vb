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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.Main = New System.Windows.Forms.TabPage
        Me.llESI = New System.Windows.Forms.LinkLabel
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.cmdEnd = New System.Windows.Forms.Button
        Me.cmdExchange = New System.Windows.Forms.Button
        Me.cmdSetup2 = New System.Windows.Forms.Button
        Me.cmdGameSetup = New System.Windows.Forms.Button
        Me.cmdLoad = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdBegin = New System.Windows.Forms.Button
        Me.cmdReset = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblConnections = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblLocalHost = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblIP = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMessages = New System.Windows.Forms.TextBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Status = New System.Windows.Forms.TabPage
        Me.txtTime = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPeriod = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabControl1.SuspendLayout()
        Me.Main.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Status.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Main)
        Me.TabControl1.Controls.Add(Me.Status)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(2, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1014, 731)
        Me.TabControl1.TabIndex = 0
        '
        'Main
        '
        Me.Main.BackColor = System.Drawing.SystemColors.Control
        Me.Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Main.Controls.Add(Me.llESI)
        Me.Main.Controls.Add(Me.Label7)
        Me.Main.Controls.Add(Me.Label8)
        Me.Main.Controls.Add(Me.cmdPrint)
        Me.Main.Controls.Add(Me.GroupBox2)
        Me.Main.Controls.Add(Me.GroupBox1)
        Me.Main.Controls.Add(Me.txtMessages)
        Me.Main.Controls.Add(Me.DataGridView1)
        Me.Main.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Main.Location = New System.Drawing.Point(4, 25)
        Me.Main.Name = "Main"
        Me.Main.Padding = New System.Windows.Forms.Padding(3)
        Me.Main.Size = New System.Drawing.Size(1006, 702)
        Me.Main.TabIndex = 0
        Me.Main.Text = "Main"
        '
        'llESI
        '
        Me.llESI.AutoSize = True
        Me.llESI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llESI.Location = New System.Drawing.Point(5, 649)
        Me.llESI.Name = "llESI"
        Me.llESI.Size = New System.Drawing.Size(409, 16)
        Me.llESI.TabIndex = 32
        Me.llESI.TabStop = True
        Me.llESI.Text = "Economic Science Institute, Chapman University 2008-11 ©"
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(652, 649)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(347, 32)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Designed By: Jeffrey Kirchner, Your Name Here, and Faculty Names Here"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(5, 668)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(383, 16)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Programmed By: Jeffrey Kirchner and Your Name Here"
        '
        'cmdPrint
        '
        Me.cmdPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdPrint.Image = CType(resources.GetObject("cmdPrint.Image"), System.Drawing.Image)
        Me.cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdPrint.Location = New System.Drawing.Point(476, 650)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(73, 34)
        Me.cmdPrint.TabIndex = 29
        Me.cmdPrint.Text = "Print "
        Me.cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.cmdExit)
        Me.GroupBox2.Controls.Add(Me.cmdEnd)
        Me.GroupBox2.Controls.Add(Me.cmdExchange)
        Me.GroupBox2.Controls.Add(Me.cmdSetup2)
        Me.GroupBox2.Controls.Add(Me.cmdGameSetup)
        Me.GroupBox2.Controls.Add(Me.cmdLoad)
        Me.GroupBox2.Controls.Add(Me.cmdSave)
        Me.GroupBox2.Controls.Add(Me.cmdBegin)
        Me.GroupBox2.Controls.Add(Me.cmdReset)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(237, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(762, 119)
        Me.GroupBox2.TabIndex = 28
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Control"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(507, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "TestSend"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Image = CType(resources.GetObject("cmdExit.Image"), System.Drawing.Image)
        Me.cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExit.Location = New System.Drawing.Point(630, 43)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(117, 44)
        Me.cmdExit.TabIndex = 34
        Me.cmdExit.Text = "     Exit"
        '
        'cmdEnd
        '
        Me.cmdEnd.Enabled = False
        Me.cmdEnd.Image = CType(resources.GetObject("cmdEnd.Image"), System.Drawing.Image)
        Me.cmdEnd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEnd.Location = New System.Drawing.Point(507, 43)
        Me.cmdEnd.Name = "cmdEnd"
        Me.cmdEnd.Size = New System.Drawing.Size(117, 44)
        Me.cmdEnd.TabIndex = 33
        Me.cmdEnd.Text = "       End Early"
        '
        'cmdExchange
        '
        Me.cmdExchange.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExchange.Location = New System.Drawing.Point(384, 21)
        Me.cmdExchange.Name = "cmdExchange"
        Me.cmdExchange.Size = New System.Drawing.Size(88, 44)
        Me.cmdExchange.TabIndex = 32
        Me.cmdExchange.Text = "       Symbols"
        '
        'cmdSetup2
        '
        Me.cmdSetup2.Image = CType(resources.GetObject("cmdSetup2.Image"), System.Drawing.Image)
        Me.cmdSetup2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSetup2.Location = New System.Drawing.Point(384, 69)
        Me.cmdSetup2.Name = "cmdSetup2"
        Me.cmdSetup2.Size = New System.Drawing.Size(117, 44)
        Me.cmdSetup2.TabIndex = 31
        Me.cmdSetup2.Text = "     Score" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     Matrix"
        '
        'cmdGameSetup
        '
        Me.cmdGameSetup.Image = CType(resources.GetObject("cmdGameSetup.Image"), System.Drawing.Image)
        Me.cmdGameSetup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGameSetup.Location = New System.Drawing.Point(261, 43)
        Me.cmdGameSetup.Name = "cmdGameSetup"
        Me.cmdGameSetup.Size = New System.Drawing.Size(101, 44)
        Me.cmdGameSetup.TabIndex = 30
        Me.cmdGameSetup.Text = "     Game " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "     Setup"
        '
        'cmdLoad
        '
        Me.cmdLoad.Image = CType(resources.GetObject("cmdLoad.Image"), System.Drawing.Image)
        Me.cmdLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLoad.Location = New System.Drawing.Point(138, 69)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(117, 44)
        Me.cmdLoad.TabIndex = 29
        Me.cmdLoad.Text = "      Load"
        '
        'cmdSave
        '
        Me.cmdSave.Image = CType(resources.GetObject("cmdSave.Image"), System.Drawing.Image)
        Me.cmdSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSave.Location = New System.Drawing.Point(138, 19)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(117, 44)
        Me.cmdSave.TabIndex = 28
        Me.cmdSave.Text = "      Save"
        '
        'cmdBegin
        '
        Me.cmdBegin.Image = CType(resources.GetObject("cmdBegin.Image"), System.Drawing.Image)
        Me.cmdBegin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBegin.Location = New System.Drawing.Point(15, 19)
        Me.cmdBegin.Name = "cmdBegin"
        Me.cmdBegin.Size = New System.Drawing.Size(117, 44)
        Me.cmdBegin.TabIndex = 27
        Me.cmdBegin.Text = "      Begin"
        '
        'cmdReset
        '
        Me.cmdReset.Image = CType(resources.GetObject("cmdReset.Image"), System.Drawing.Image)
        Me.cmdReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdReset.Location = New System.Drawing.Point(15, 69)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(117, 44)
        Me.cmdReset.TabIndex = 26
        Me.cmdReset.Text = "       Reset"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblConnections)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblLocalHost)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblIP)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(5, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(226, 119)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Status"
        '
        'lblConnections
        '
        Me.lblConnections.AutoSize = True
        Me.lblConnections.Location = New System.Drawing.Point(105, 65)
        Me.lblConnections.Name = "lblConnections"
        Me.lblConnections.Size = New System.Drawing.Size(16, 16)
        Me.lblConnections.TabIndex = 5
        Me.lblConnections.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(93, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Connections"
        '
        'lblLocalHost
        '
        Me.lblLocalHost.AutoSize = True
        Me.lblLocalHost.Location = New System.Drawing.Point(105, 43)
        Me.lblLocalHost.Name = "lblLocalHost"
        Me.lblLocalHost.Size = New System.Drawing.Size(75, 16)
        Me.lblLocalHost.TabIndex = 3
        Me.lblLocalHost.Text = "Localhost"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Host"
        '
        'lblIP
        '
        Me.lblIP.AutoSize = True
        Me.lblIP.Location = New System.Drawing.Point(105, 21)
        Me.lblIP.Name = "lblIP"
        Me.lblIP.Size = New System.Drawing.Size(68, 16)
        Me.lblIP.TabIndex = 1
        Me.lblIP.Text = "127.0.0.1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "IP Address"
        '
        'txtMessages
        '
        Me.txtMessages.Location = New System.Drawing.Point(1, 687)
        Me.txtMessages.Multiline = True
        Me.txtMessages.Name = "txtMessages"
        Me.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMessages.Size = New System.Drawing.Size(997, 27)
        Me.txtMessages.TabIndex = 26
        Me.txtMessages.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column5, Me.Column3, Me.Column4})
        Me.DataGridView1.Location = New System.Drawing.Point(2, 132)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(997, 512)
        Me.DataGridView1.TabIndex = 25
        '
        'Status
        '
        Me.Status.BackColor = System.Drawing.SystemColors.Control
        Me.Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Status.Controls.Add(Me.txtTime)
        Me.Status.Controls.Add(Me.Label2)
        Me.Status.Controls.Add(Me.txtPeriod)
        Me.Status.Controls.Add(Me.Label4)
        Me.Status.Controls.Add(Me.DataGridView2)
        Me.Status.Location = New System.Drawing.Point(4, 25)
        Me.Status.Name = "Status"
        Me.Status.Padding = New System.Windows.Forms.Padding(3)
        Me.Status.Size = New System.Drawing.Size(1006, 702)
        Me.Status.TabIndex = 1
        Me.Status.Text = "Status"
        '
        'txtTime
        '
        Me.txtTime.BackColor = System.Drawing.Color.White
        Me.txtTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTime.Location = New System.Drawing.Point(13, 664)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.ReadOnly = True
        Me.txtTime.Size = New System.Drawing.Size(64, 26)
        Me.txtTime.TabIndex = 39
        Me.txtTime.Text = "-"
        Me.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 641)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 20)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Time"
        '
        'txtPeriod
        '
        Me.txtPeriod.BackColor = System.Drawing.Color.White
        Me.txtPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriod.Location = New System.Drawing.Point(83, 664)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.ReadOnly = True
        Me.txtPeriod.Size = New System.Drawing.Size(64, 26)
        Me.txtPeriod.TabIndex = 37
        Me.txtPeriod.Text = "1"
        Me.txtPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(84, 641)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 20)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Period"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToResizeColumns = False
        Me.DataGridView2.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4})
        Me.DataGridView2.Location = New System.Drawing.Point(2, 6)
        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(997, 380)
        Me.DataGridView2.TabIndex = 35
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn1.HeaderText = "Property 1"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 85
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn2.HeaderText = "Property 2"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn2.Width = 85
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn3.HeaderText = "Property 3"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn3.Width = 85
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn4.HeaderText = "Property 4"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn4.Width = 85
        '
        'Timer1
        '
        '
        'Timer2
        '
        '
        'Timer3
        '
        '
        'PrintDocument1
        '
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.Document = Me.PrintDocument1
        Me.PrintDialog1.UseEXDialog = True
        '
        'Column1
        '
        Me.Column1.HeaderText = "ID"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 50
        '
        'Column2
        '
        Me.Column2.HeaderText = "Name"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column5
        '
        Me.Column5.HeaderText = "IP"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 550
        '
        'Column3
        '
        Me.Column3.HeaderText = "Status"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 200
        '
        'Column4
        '
        Me.Column4.HeaderText = "Score"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 734)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.Text = "Server"
        Me.TabControl1.ResumeLayout(False)
        Me.Main.ResumeLayout(False)
        Me.Main.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Status.ResumeLayout(False)
        Me.Status.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Main As System.Windows.Forms.TabPage
    Friend WithEvents Status As System.Windows.Forms.TabPage
    Friend WithEvents llESI As System.Windows.Forms.LinkLabel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmdEnd As System.Windows.Forms.Button
    Friend WithEvents cmdExchange As System.Windows.Forms.Button
    Friend WithEvents cmdSetup2 As System.Windows.Forms.Button
    Friend WithEvents cmdGameSetup As System.Windows.Forms.Button
    Friend WithEvents cmdLoad As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdBegin As System.Windows.Forms.Button
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblConnections As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblLocalHost As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblIP As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMessages As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtTime As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPeriod As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
