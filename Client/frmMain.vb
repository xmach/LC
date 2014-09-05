Imports System.Windows.Forms
Imports LC
Imports System.Text

Public Class frmMain
    'Private m_frmInstructions As frmInstructions = New frmInstructions()

    Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try

            'if ALT+K are pressed kill the client
            'if ALT+Q are pressed bring up connection box
            If e.Alt = True Then
                If CInt(e.KeyValue) = CInt(Keys.K) Then
                    If MessageBox.Show("Close Program?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                    modMain.closing = True
                    Me.Close()
                ElseIf CInt(e.KeyValue) = CInt(Keys.Q) Then
                    frmConnect.Show()
                End If
            End If
        Catch ex As Exception
            appEventLog_Write("error frmChat_KeyDown:", ex)
        End Try
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            sfile = System.Windows.Forms.Application.StartupPath & "\client.ini"

            'take IP from command line
            Dim commandLine As String = Command()

            If commandLine <> "" Then
                writeINI(sfile, "Settings", "ip", commandLine)
            End If

            'connect
            serverIPAddress = getINI(sfile, "Settings", "ip")
            serverPortNumber = getINI(sfile, "Settings", "port")
            localPortNumber = getINI(sfile, "Settings", "localport")
            connect()

        Catch ex As Exception
            appEventLog_Write("errorfrmChat_Load :", ex)
        End Try

    End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    Try

    '    Catch ex As Exception
    '        appEventLog_Write("error Timer1_Tick:", ex)
    '    End Try
    'End Sub



    'Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
    '    Try

    '    Catch ex As Exception
    '        appEventLog_Write("error Timer2_Tick client:", ex)
    '    End Try
    'End Sub

    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If Not modMain.closing Then e.Cancel = True
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub



    Public Sub DisplayLanguageDecision(ByVal m As LC.MessageBag)
        'TODO 
        'MessageBox.Show("DisplayLanguageDecision")
        Dim f As New frmLangChange()
        f.Meaning = modMain.m_meanings
        f.Vocabulary = m.Vocabulary
        f.Symbols = m.symbols

        f.ShowDialog()
        Dim message As New LC.MessageBag()
        message.MsgType = MsgType.Client_sendLearnInvent
        message.learn = f.LearnNum
        message.invent = f.Invent
        modMain.wskClient.Send(LC.XmlHelper.XmlSerialize(message, System.Text.Encoding.UTF8))
    End Sub

    Public Sub DisplayResult(ByVal m As MessageBag)
        Dim f As New frmResult()
        f.DisplayMsg = "Your score is:" & m.Score.ToString()
        f.ShowDialog()
        Dim message As New LC.MessageBag()
        message.MsgType = MsgType.Client_newRound
        modMain.wskClient.Send(LC.XmlHelper.XmlSerialize(message, System.Text.Encoding.UTF8))
    End Sub

    Public Sub DisplayPhase1Decision(ByVal m As MessageBag)
        Dim f As New frmDecision
        f.IsPhase2 = False
        f.ScoreMatrix = m.scoreMatrix
        f.ShowDialog()
        Dim message As New LC.MessageBag()
        message.MsgType = MsgType.Client_sendPhase1Decision
        message.Phase1Decision = f.Phase1Decision
        modMain.wskClient.Send(LC.XmlHelper.XmlSerialize(message, System.Text.Encoding.UTF8))
    End Sub

    Public Sub DisplayPhase2Decision(ByVal m As MessageBag)
        Dim f As New frmDecision
        f.IsPhase2 = True
        f.Phase1Decision = m.Phase1Decision
        f.ScoreMatrix = m.scoreMatrix
        f.ShowDialog()
        Dim message As New LC.MessageBag()
        message.MsgType = MsgType.Client_sendPhase2Decision
        message.Phase2Decision = f.Phase2Decision
        modMain.wskClient.Send(LC.XmlHelper.XmlSerialize(message, System.Text.Encoding.UTF8))
    End Sub

    Public Sub DisplayInstructions()
        Dim f As New frmInstructions()
        f.ShowDialog()
        'send 
        Dim message As New LC.MessageBag()
        message.MsgType = MsgType.Client_finishedInstructions
        modMain.wskClient.Send(LC.XmlHelper.XmlSerialize(message, System.Text.Encoding.UTF8))
    End Sub



End Class