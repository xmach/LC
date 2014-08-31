Imports System.Windows.Forms
Imports LC
Imports System.Text

Public Class frmMain
    Private m_frmInstructions As frmInstructions = New frmInstructions()

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

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try

        Catch ex As Exception
            appEventLog_Write("error Timer1_Tick:", ex)
        End Try
    End Sub



    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try

        Catch ex As Exception
            appEventLog_Write("error Timer2_Tick client:", ex)
        End Try
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If Not modMain.closing Then e.Cancel = True
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

   

    Public Sub DisplayLanguageDecision()
        'TODO 
        MessageBox.Show("DisplayLanguageDecision")
        BindData()
    End Sub

    Private Sub BindData()
        Throw New NotImplementedException()
    End Sub

    Public Sub DisplayInstructions()
        m_frmInstructions.ShowDialog()
        'send 
        Dim message As New LC.MessageBag()
        message.MsgType = MsgType.Client_finishedInstructions
        modMain.wskClient.Send(LC.XmlHelper.XmlSerialize(message, System.Text.Encoding.UTF8))
    End Sub

    'Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
    '    Dim message As New LC.MessageBag()
    '    message.MsgType = MsgType.Client_newRound
    '    modMain.wskClient.Send(LC.XmlHelper.XmlSerialize(message, System.Text.Encoding.UTF8))
    'End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Dim message As New MessageBag()
    '    message.MsgType = MsgType.Client_finishedInstructions
    '    modMain.wskClient.Send(LC.XmlHelper.XmlSerialize(message, System.Text.Encoding.UTF8))

    'End Sub

    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    '    Dim message As New LC.MessageBag()
    '    message.MsgType = MsgType.Client_sendPhase1Decision
    '    message.Phase1Decision = "a"
    '    modMain.wskClient.Send(LC.XmlHelper.XmlSerialize(message, System.Text.Encoding.UTF8))
    'End Sub

    'Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
    '    Dim message As New LC.MessageBag()
    '    message.MsgType = MsgType.Client_sendLearnInvent
    '    message.learn = 1
    '    message.invent = New Tuple(Of String, String)() {New Tuple(Of String, String)("a", "*-*")}
    '    modMain.wskClient.Send(LC.XmlHelper.XmlSerialize(message, System.Text.Encoding.UTF8))
    'End Sub

    'Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

    'End Sub
    Public Sub ShowPhase1(ByVal m As LC.MessageBag)
        Dim f As New frmDecision()
        f.Meanings = modMain.m_meanings
        'f.Phase1Decision = m.Phase1Decision
        f.ScoreMatrix = m.scoreMatrix
        f.IsPhase2 = False
        f.ShowDialog()
        Dim newMsg As New LC.MessageBag()
        newMsg.Phase2Decision = f.Phase1Decision
        newMsg.MsgType = MsgType.Client_sendPhase1Decision
        modMain.wskClient.Send(LC.XmlHelper.XmlSerialize(newMsg, Encoding.UTF8))
    End Sub

    Sub ShowPhase2(ByVal m As LC.MessageBag)
        Dim f As New frmDecision()
        f.Meanings = modMain.m_meanings
        f.Phase1Decision = m.Phase1Decision
        f.ScoreMatrix = m.scoreMatrix
        f.IsPhase2 = True
        f.ShowDialog()
        Dim newMsg As New LC.MessageBag()
        newMsg.Phase2Decision = f.Phase2Decision
        newMsg.MsgType = MsgType.Client_sendPhase2Decision
        modMain.wskClient.Send(LC.XmlHelper.XmlSerialize(newMsg, Encoding.UTF8))
    End Sub

    Sub ShowResult(ByVal m As LC.MessageBag)
        MessageBox.Show("Your score is " & m.Score.ToString() & ",click ok to next round")
        Dim newMsg As New LC.MessageBag()
        newMsg.MsgType = MsgType.Client_newRound
        modMain.wskClient.Send(LC.XmlHelper.XmlSerialize(newmsg, Encoding.UTF8))
    End Sub

End Class
