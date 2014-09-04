<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLangChange
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
        Me.lstPrivate = New System.Windows.Forms.ListView
        Me.lstComm = New System.Windows.Forms.ListView
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblInventCost = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.numInvent = New System.Windows.Forms.NumericUpDown
        Me.lblLearnCost = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.numLearn = New System.Windows.Forms.NumericUpDown
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtNewWord3 = New System.Windows.Forms.TextBox
        Me.txtNewWord2 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtNewWord1 = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboMeaning3 = New System.Windows.Forms.ComboBox
        Me.cboMeaning2 = New System.Windows.Forms.ComboBox
        Me.cboMeaning1 = New System.Windows.Forms.ComboBox
        CType(Me.numInvent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLearn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstPrivate
        '
        Me.lstPrivate.Location = New System.Drawing.Point(413, 33)
        Me.lstPrivate.Name = "lstPrivate"
        Me.lstPrivate.Size = New System.Drawing.Size(307, 216)
        Me.lstPrivate.TabIndex = 36
        Me.lstPrivate.UseCompatibleStateImageBehavior = False
        '
        'lstComm
        '
        Me.lstComm.Location = New System.Drawing.Point(24, 33)
        Me.lstComm.Name = "lstComm"
        Me.lstComm.Size = New System.Drawing.Size(327, 216)
        Me.lstComm.TabIndex = 35
        Me.lstComm.UseCompatibleStateImageBehavior = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(411, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 13)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Private List"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(54, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Common List"
        '
        'lblInventCost
        '
        Me.lblInventCost.AutoSize = True
        Me.lblInventCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblInventCost.Location = New System.Drawing.Point(627, 368)
        Me.lblInventCost.Name = "lblInventCost"
        Me.lblInventCost.Size = New System.Drawing.Size(16, 16)
        Me.lblInventCost.TabIndex = 32
        Me.lblInventCost.Tag = "1"
        Me.lblInventCost.Text = "3"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(206, 368)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(402, 16)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "words from that is understood only by my chooser at cost "
        '
        'numInvent
        '
        Me.numInvent.Location = New System.Drawing.Point(113, 369)
        Me.numInvent.Name = "numInvent"
        Me.numInvent.Size = New System.Drawing.Size(66, 20)
        Me.numInvent.TabIndex = 30
        Me.numInvent.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'lblLearnCost
        '
        Me.lblLearnCost.AutoSize = True
        Me.lblLearnCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblLearnCost.Location = New System.Drawing.Point(435, 335)
        Me.lblLearnCost.Name = "lblLearnCost"
        Me.lblLearnCost.Size = New System.Drawing.Size(16, 16)
        Me.lblLearnCost.TabIndex = 29
        Me.lblLearnCost.Tag = "1"
        Me.lblLearnCost.Text = "1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(206, 335)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(212, 16)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "words from Red Group at cost"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(38, 369)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 16)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "learn"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(38, 329)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 16)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "learn"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(21, 296)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "I want to"
        '
        'numLearn
        '
        Me.numLearn.Location = New System.Drawing.Point(113, 329)
        Me.numLearn.Name = "numLearn"
        Me.numLearn.Size = New System.Drawing.Size(66, 20)
        Me.numLearn.TabIndex = 24
        Me.numLearn.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Button1.Location = New System.Drawing.Point(343, 498)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 25)
        Me.Button1.TabIndex = 49
        Me.Button1.Text = "Submit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(309, 468)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 16)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "to refer"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(309, 428)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 16)
        Me.Label13.TabIndex = 44
        Me.Label13.Text = "to refer"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(309, 393)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 16)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "to refer"
        '
        'txtNewWord3
        '
        Me.txtNewWord3.Location = New System.Drawing.Point(148, 468)
        Me.txtNewWord3.Name = "txtNewWord3"
        Me.txtNewWord3.Size = New System.Drawing.Size(100, 20)
        Me.txtNewWord3.TabIndex = 42
        '
        'txtNewWord2
        '
        Me.txtNewWord2.Location = New System.Drawing.Point(148, 428)
        Me.txtNewWord2.Name = "txtNewWord2"
        Me.txtNewWord2.Size = New System.Drawing.Size(100, 20)
        Me.txtNewWord2.TabIndex = 41
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(109, 433)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 16)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "use"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(109, 473)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 16)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "use"
        '
        'txtNewWord1
        '
        Me.txtNewWord1.Location = New System.Drawing.Point(148, 393)
        Me.txtNewWord1.Name = "txtNewWord1"
        Me.txtNewWord1.Size = New System.Drawing.Size(100, 20)
        Me.txtNewWord1.TabIndex = 38
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(109, 398)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 16)
        Me.Label9.TabIndex = 37
        Me.Label9.Text = "use"
        '
        'cboMeaning3
        '
        Me.cboMeaning3.FormattingEnabled = True
        Me.cboMeaning3.Location = New System.Drawing.Point(531, 468)
        Me.cboMeaning3.Name = "cboMeaning3"
        Me.cboMeaning3.Size = New System.Drawing.Size(121, 21)
        Me.cboMeaning3.TabIndex = 50
        '
        'cboMeaning2
        '
        Me.cboMeaning2.FormattingEnabled = True
        Me.cboMeaning2.Location = New System.Drawing.Point(531, 426)
        Me.cboMeaning2.Name = "cboMeaning2"
        Me.cboMeaning2.Size = New System.Drawing.Size(121, 21)
        Me.cboMeaning2.TabIndex = 51
        '
        'cboMeaning1
        '
        Me.cboMeaning1.FormattingEnabled = True
        Me.cboMeaning1.Location = New System.Drawing.Point(531, 388)
        Me.cboMeaning1.Name = "cboMeaning1"
        Me.cboMeaning1.Size = New System.Drawing.Size(121, 21)
        Me.cboMeaning1.TabIndex = 52
        '
        'frmLangChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(840, 535)
        Me.ControlBox = False
        Me.Controls.Add(Me.cboMeaning1)
        Me.Controls.Add(Me.cboMeaning2)
        Me.Controls.Add(Me.cboMeaning3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtNewWord3)
        Me.Controls.Add(Me.txtNewWord2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtNewWord1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lstPrivate)
        Me.Controls.Add(Me.lstComm)
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
        Me.Name = "frmLangChange"
        Me.ShowIcon = False
        Me.Text = "frmLangChange"
        CType(Me.numInvent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLearn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstPrivate As System.Windows.Forms.ListView
    Friend WithEvents lstComm As System.Windows.Forms.ListView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblInventCost As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents numInvent As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblLearnCost As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents numLearn As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtNewWord3 As System.Windows.Forms.TextBox
    Friend WithEvents txtNewWord2 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtNewWord1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboMeaning3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboMeaning2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboMeaning1 As System.Windows.Forms.ComboBox
End Class
