Imports System.Windows.Forms
Imports LC
Imports System.Text
Imports System.Collections.Specialized

Public Class frmMain
    Private m_Score As Nullable(Of Integer)
    Private m_round As Nullable(Of Integer)
    Public Property MScore As Nullable(Of Integer)
        Get
            Return m_Score
        End Get
        Set(ByVal value As Nullable(Of Integer))
            m_Score = value
        End Set
    End Property

    Public Property MRound() As Nullable(Of Integer)

        Get
            Return Me.m_round
        End Get
        Set(ByVal value As Nullable(Of Integer))
            Me.m_round = value
        End Set
    End Property


    Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try

            'if ALT+K are pressed kill the client
            'if ALT+Q are pressed bring up connection box
            If e.Alt = True Then
                If CInt(e.KeyValue) = CInt(Keys.K) Then
                    If MessageBox.Show("Close Program?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                    modMain.closing = True
                    Application.Exit()
                ElseIf CInt(e.KeyValue) = CInt(Keys.Q) Then
                    frmConnect.ShowDialog()
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

            RefreshDisplay()
            connect()

        Catch ex As Exception
            appEventLog_Write("errorfrmChat_Load :", ex)
        End Try

    End Sub
    Private Sub RefreshDisplay()
        Me.lblCurrentRound.Text = String.Empty
        If Me.m_round.HasValue Then
            Me.lblCurrentRound.Text = Me.m_round.ToString()
        End If
        Me.lblScore.Text = String.Empty
        If Me.MScore.HasValue Then
            Me.lblScore.Text = Me.MScore.ToString()
        End If
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

    Public Sub Reconnect()
        Dim f As New frmConnect()
        f.ShowDialog()
        Dim ip As String = f.ServerIP
        Dim port As String = f.serverPortNumber
        modMain.serverIPAddress = ip
        modMain.serverPortNumber = port
        modMain.connect()
    End Sub

    Public Sub DisplayLanguageDecision(ByVal m As LC.MessageBag)
        'TODO 
        'MessageBox.Show("DisplayLanguageDecision")
        Dim f As New frmLangChange()
        modMain.m_meanings = m.meanings
        f.Meaning = m.meanings
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
        If m.Round.HasValue Then
            Me.MRound = m.Round.Value
        End If
        If m.Score.HasValue Then
            Me.MScore = m.Score.Value
        End If
        Dim f As New frmResult()
        f.DisplayMsg = "Your score is:" & m.Score.ToString()
        f.ShowDialog()
        Dim message As New LC.MessageBag()
        message.MsgType = MsgType.Client_newRound
        modMain.wskClient.Send(LC.XmlHelper.XmlSerialize(message, System.Text.Encoding.UTF8))
    End Sub
    ''' <summary>
    ''' phase 1 decision
    ''' </summary>
    ''' <param name="m"></param>
    ''' <remarks></remarks>
    Public Sub DisplayPhase1Decision(ByVal m As MessageBag)
        Dim f As New frmDecision
        f.IsPhase2 = False
        f.ScoreMatrix = m.scoreMatrix
        f.Meanings = modMain.m_meanings
        f.ShowDialog()
        Dim message As New LC.MessageBag()
        message.MsgType = MsgType.Client_sendPhase1Decision
        message.Phase1Decision = f.Phase1Decision
        modMain.wskClient.Send(LC.XmlHelper.XmlSerialize(message, System.Text.Encoding.UTF8))
    End Sub
    ''' <summary>
    ''' Re confim (phase2) decision
    ''' </summary>
    ''' <param name="m"></param>
    ''' <remarks></remarks>
    Public Sub DisplayPhase2Decision(ByVal m As MessageBag)
        Dim f As New frmDecision
        f.IsPhase2 = True
        f.Phase1Decision = m.Phase1Decision
        f.ScoreMatrix = m.scoreMatrix
        f.Meanings = modMain.m_meanings
        f.ShowDialog()
        Dim message As New LC.MessageBag()
        message.MsgType = MsgType.Client_sendPhase2Decision
        message.Phase2Decision = f.Phase2Decision
        modMain.wskClient.Send(LC.XmlHelper.XmlSerialize(message, System.Text.Encoding.UTF8))
    End Sub

    ''' <summary>
    ''' Read Instructions
    ''' </summary>
    ''' <param name="m"></param>
    ''' <remarks></remarks>
    Public Sub DisplayInstructions(ByVal m As MessageBag)
        If m.Round.HasValue Then
            Me.MRound = m.Round.Value
        End If
        If m.Score.HasValue Then
            Me.MScore = m.Score.Value
        End If
        Dim f As New frmInstructions()
        f.ShowDialog()
        'send 
        Dim message As New LC.MessageBag()
        message.MsgType = MsgType.Client_finishedInstructions
        modMain.wskClient.Send(LC.XmlHelper.XmlSerialize(message, System.Text.Encoding.UTF8))
    End Sub



End Class