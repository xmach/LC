Imports LC
Public Class frmSetup

    Private Sub frmSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            BindCombo()
            'load paremeters into text boxes from server.ini
            txtPlayers.Text = getINI(sfile, "gameSettings", "numberOfPlayers")
            Me.txtRounds.Text = getINI(sfile, "gameSettings", "numberOfRound")
            chkShowInstructions.Checked = Boolean.Parse(getINI(sfile, "gameSettings", "showInstructions"))
            txtPort.Text = getINI(sfile, "gameSettings", "port")
            txtRounds.Text = getINI(sfile, "gameSettings", "numberOfRound")
            Me.txtMeanings.Text = getINI(sfile, "gameSettings", "meanings")
            Me.txtIniWordsNum.Text = getINI(sfile, "gameSettings", "ininumberofwords")
            Me.txtLS.Text = getINI(sfile, "gameSettings", "ls")
            Dim gameType As String = getINI(sfile, "gameSettings", "gametype")
            Me.cboGameType.SelectedItem = gameType
        Catch ex As Exception
            appEventLog_Write("error frmSetup_Load:", ex)
        End Try
    End Sub

    Private Sub Bindcombo()
        Me.cboGameType.Items.Clear()
        Me.cboGameType.Items.Add(GameType.Cooperate.ToString())
        Me.cboGameType.Items.Add(GameType.Compete.ToString())
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Try
            'write parameter from text boxes into server.ini
            writeINI(sfile, "gameSettings", "numberOfPlayers", txtPlayers.Text)
            writeINI(sfile, "gameSettings", "numberOfRound", txtRounds.Text)
            writeINI(sfile, "gameSettings", "showInstructions", chkShowInstructions.Checked.ToString())
            writeINI(sfile, "gameSettings", "port", txtPort.Text)
            writeINI(sfile, "gameSettings", "meanings", txtMeanings.Text)
            writeINI(sfile, "gameSettings", "ininumberofwords", txtIniWordsNum.Text)
            writeINI(sfile, "gameSettings", "ls", txtLS.Text)
            writeINI(sfile, "gameSettings", "gametype", Me.cboGameType.SelectedItem.ToString())

            'loadParameters()

            Me.Close()
        Catch ex As Exception
            appEventLog_Write("error cmdSave_Click:", ex)
        End Try
    End Sub

End Class
