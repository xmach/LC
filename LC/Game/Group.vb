Public Class Group

    Private m_playors As Playor()
    Private m_status As StatusBase
    Private m_winsock_collection As WinsockCollection
    'Private m_vocabulary() As Vocabulary
    Private m_decision() As String
    Private m_msgReceived() As Boolean
    Private m_scoreMatrix As ScoreMatrix
    Private m_msgFromAllPlayors() As List(Of LC.MessageBag)
    Private m_currentRound As Integer

    Private Event StatusUpdated(ByVal sender As Object, ByVal e As System.EventArgs)

    Public ReadOnly Property currentRound() As Integer
        Get
            Return Me.m_currentRound
        End Get
    End Property

    Public Property Status() As StatusBase
        Get
            Return Me.m_status
        End Get
        Set(ByVal value As StatusBase)
            Me.m_status = value
            'backup every new round
            If TypeOf value Is StatusNewRound Then
                Me.BackupMessage()
            End If
        End Set
    End Property

    Public Property Playors() As Playor()
        Get
            Return Me.m_playors
        End Get
        Set(ByVal value As Playor())
            Me.m_playors = value
        End Set
    End Property

    Public Property WinsockCollection() As WinsockCollection
        Get
            Return Me.m_winsock_collection
        End Get
        Set(ByVal value As WinsockCollection)
            Me.m_winsock_collection = value
        End Set
    End Property

    'Public Property Vocabulary() As Vocabulary()
    '    Get
    '        Return Me.m_vocabulary
    '    End Get
    '    Set(ByVal value As Vocabulary())
    '        Me.m_vocabulary = value
    '    End Set
    'End Property

    Public Property ScoreMatrix() As ScoreMatrix
        Get
            Return Me.m_scoreMatrix
        End Get
        Set(ByVal value As ScoreMatrix)
            Me.m_scoreMatrix = value
        End Set
    End Property

    

    Public Property Decision() As String()
        Get
            Return Me.m_decision
        End Get
        Set(ByVal value As String())
            Me.m_decision = value
        End Set
    End Property

    Public ReadOnly Property AllRequiredClientMsgReceived() As Boolean
        Get
            'true if all playor's message received
            Dim firstPlayorMsgCount = Me.m_msgFromAllPlayors(0).Count

            For index As Integer = 1 To m_msgFromAllPlayors.Length - 1
                If m_msgFromAllPlayors(index).Count <> firstPlayorMsgCount Then
                    Return False
                End If
            Next
            Return True
        End Get
    End Property

    Public Sub New(ByVal p As Playor())
        Me.m_playors = p

        Me.m_status = New StatusConnected()
        Me.m_status.Game = Me
        Me.m_decision = New String(p.Length - 1) {}
        m_msgReceived = New Boolean(p.Length - 1) {}
        Me.m_msgFromAllPlayors = New List(Of MessageBag)(p.Length - 1) {}

        For index As Integer = 0 To m_msgFromAllPlayors.Length - 1
            Me.m_msgFromAllPlayors(index) = New List(Of MessageBag)()
        Next
        m_currentRound = 0
    End Sub

    Protected Sub BackupMessage()
        'TODO 

        For index As Integer = 0 To m_msgFromAllPlayors.Length - 1
            Dim msgs As MessageBag() = Me.m_msgFromAllPlayors(index).ToArray()
            Me.m_msgFromAllPlayors(index).Clear()
            'Write To Message File
            ModuleEventLog.WriteLCMessage(msgs)
        Next
    End Sub

    ''' <summary>
    ''' signal both playor to 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Begin()
        If TypeOf Me.m_status Is StatusConnected Then
            'TODO Me.m_status.ReceiveMsg(MsgType.beginGame, Nothing)
            Me.m_currentRound = 1
            For index As Integer = 0 To Me.Playors.Length - 1
                Me.Playors(index).DisplayInstruction(Me.WinsockCollection)
            Next
        Else
            Throw New Exception("Game already started")
        End If
    End Sub

    Public Sub SendVocabulary()
        If TypeOf Me.m_status Is StatusNewRound Then
            For index As Integer = 0 To Me.Playors.Length - 1
                Me.Playors(index).SendVocabularyToClient(Me.m_winsock_collection, Me.Playors(index).Vocabulary)
            Next
        Else
            Throw New Exception("Game already started")
        End If
    End Sub

    Public Sub ShowScoreMatrix()
        For index As Integer = 0 To Me.Playors.Length - 1
            Me.Playors(index).SendScoreMatrixToClient(Me.WinsockCollection, Me.m_scoreMatrix)
        Next
    End Sub

    ''' <summary>
    ''' update UpdateVocabulary and compute cost
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateVocabulary()
        'TODO
        'Deserialize the input ,then update vocabulary
        'playor id = xxx
        ' for the common part ,remove it from other's private list to all common list
        ' for the private part ,add

        'calculate cost

        For index As Integer = 0 To Me.m_playors.Length - 1
            Dim msg As LC.MessageBag = Me.m_msgFromAllPlayors(index)(0)
            Dim cost As Integer = 0
            cost += msg.learn
            cost += 0.5 * msg.invent.Length * (msg.invent.Length + 1)
            m_playors(index).Score -= cost
        Next


    End Sub

    Public Sub ShowResultAndNewRound()
        'collect all playor's final decision and update their score
        Dim firstDecision As String = Nothing

        For index As Integer = 0 To Me.m_msgFromAllPlayors(0).Count - 1
            ' the phase 2 decision(if exists) will override phase 1 decision
            If m_msgFromAllPlayors(0)(index).MsgType = MsgType.Client_sendPhase1Decision Then
                firstDecision = m_msgFromAllPlayors(0)(index).Phase1Decision
            End If
            If m_msgFromAllPlayors(0)(index).MsgType = MsgType.Client_sendPhase2Decision Then
                firstDecision = m_msgFromAllPlayors(0)(index).Phase2Decision
            End If
        Next

        Dim secondDecision As String = Nothing
        For index As Integer = 0 To Me.m_msgFromAllPlayors(1).Count - 1
            ' the phase 2 decision(if exists) will override phase 1 decision
            If m_msgFromAllPlayors(1)(index).MsgType = MsgType.Client_sendPhase1Decision Then
                firstDecision = m_msgFromAllPlayors(1)(index).Phase1Decision
            End If
            If m_msgFromAllPlayors(1)(index).MsgType = MsgType.Client_sendPhase2Decision Then
                firstDecision = m_msgFromAllPlayors(1)(index).Phase2Decision
            End If
        Next
        'the final decision 
        Me.Decision = New String() {firstDecision, secondDecision}

        Dim result As Tuple(Of Integer, Integer) = Me.ScoreMatrix.GetScore(firstDecision, secondDecision)
        If result Is Nothing Then
            Throw New Exception("Can't find score in matrix by:" + firstDecision + "," + secondDecision)
        End If
        Me.Playors(0).Score += result.Item1
        Me.Playors(1).Score += result.Item2

        For index As Integer = 0 To Me.Playors.Length - 1
            Me.Playors(index).ShowResultOfARound(Me.WinsockCollection, Me.m_decision, New Integer() {Me.Playors(0).Score, Me.Playors(1).Score})
        Next

    End Sub

    'random select 1 playor to observe the other's phase 1 decision
    Public Sub RandomShowPhase1()
        Dim randNumber As Integer = modRand.rand(0, 99)
        Dim playorIndex = randNumber Mod 2

        Me.Playors(playorIndex).ShowPhase1(Me.WinsockCollection, Me.Decision(1 - playorIndex))
    End Sub

    Public Sub ProcessMsg(ByVal msg As LC.MessageBag, ByVal playor As Playor)
        Dim playorIndex As Integer = Array.IndexOf(Me.m_playors, playor)
        Me.m_msgFromAllPlayors(playorIndex).Add(msg)
        Me.Status.ReceiveMsg(msg)
    End Sub

    ''' <summary>
    ''' every 2 playor into 1 group(game) 
    ''' </summary>
    ''' <param name="playorlist"></param>
    ''' <param name="grouplist"></param>
    ''' <param name="vocabularyList"></param>
    ''' <param name="iniScore"></param>
    ''' <remarks></remarks>
    Public Shared Sub MakeGroups(ByVal playorlist As LC.Playor(), _
                                ByVal grouplist As LC.Group(), _
                                ByVal vocabularyList As List(Of Vocabulary), _
                                ByVal iniScore As Integer, _
                                ByVal cooperateMatrix As ScoreMatrix, _
                                ByVal competeMatrix As ScoreMatrix, _
                                ByVal sockCol As WinsockCollection)
        Dim groupIndex As Integer = 0

        For index As Integer = 0 To playorlist.Length - 1
            If (index Mod 2 = 0) Then
                Dim p() As LC.Playor = New LC.Playor(1) {playorlist(index), playorlist(index + 1)}
                grouplist(groupIndex) = New LC.Group(p)
                grouplist(groupIndex).ScoreMatrix = cooperateMatrix
                grouplist(groupIndex).WinsockCollection = sockCol
                groupIndex += 1
            End If
            playorlist(index).Game = grouplist(groupIndex - 1)
            playorlist(index).Score = iniScore
            playorlist(index).Vocabulary = vocabularyList(index)
        Next

    End Sub
End Class
