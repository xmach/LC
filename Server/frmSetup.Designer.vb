<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetup))
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtRounds = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.chkShowInstructions = New System.Windows.Forms.CheckBox
        Me.txtPlayers = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdSave = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtMeanings = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtPort
        '
        Me.txtPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPort.Location = New System.Drawing.Point(257, 76)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(162, 26)
        Me.txtPort.TabIndex = 50
        Me.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 79)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(204, 20)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "Port # (Requires restart)"
        '
        'txtRounds
        '
        Me.txtRounds.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRounds.Location = New System.Drawing.Point(257, 44)
        Me.txtRounds.Name = "txtRounds"
        Me.txtRounds.Size = New System.Drawing.Size(162, 26)
        Me.txtRounds.TabIndex = 48
        Me.txtRounds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(159, 20)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "Number of Rounds"
        '
        'chkShowInstructions
        '
        Me.chkShowInstructions.AutoSize = True
        Me.chkShowInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowInstructions.Location = New System.Drawing.Point(247, 201)
        Me.chkShowInstructions.Name = "chkShowInstructions"
        Me.chkShowInstructions.Size = New System.Drawing.Size(172, 24)
        Me.chkShowInstructions.TabIndex = 46
        Me.chkShowInstructions.Text = "Show Instructions"
        Me.chkShowInstructions.UseVisualStyleBackColor = True
        '
        'txtPlayers
        '
        Me.txtPlayers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlayers.Location = New System.Drawing.Point(257, 12)
        Me.txtPlayers.Name = "txtPlayers"
        Me.txtPlayers.Size = New System.Drawing.Size(162, 26)
        Me.txtPlayers.TabIndex = 45
        Me.txtPlayers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 20)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Number of Players "
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(12, 319)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(407, 27)
        Me.cmdSave.TabIndex = 43
        Me.cmdSave.Text = "Save and Close"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(8, 201)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(228, 20)
        Me.Label25.TabIndex = 97
        Me.Label25.Text = "Main Window Start Position"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(12, 143)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(197, 20)
        Me.Label20.TabIndex = 92
        Me.Label20.Text = "Initial Number of Words"
        '
        'txtMeanings
        '
        Me.txtMeanings.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMeanings.Location = New System.Drawing.Point(257, 108)
        Me.txtMeanings.Name = "txtMeanings"
        Me.txtMeanings.Size = New System.Drawing.Size(162, 26)
        Me.txtMeanings.TabIndex = 101
        Me.txtMeanings.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 20)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Meanings"
        '
        'frmSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 358)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtMeanings)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtRounds)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkShowInstructions)
        Me.Controls.Add(Me.txtPlayers)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSetup"
        Me.Text = "Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRounds As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkShowInstructions As System.Windows.Forms.CheckBox
    Friend WithEvents txtPlayers As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtMeanings As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
