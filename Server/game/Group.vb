Imports LC
Public Class Group

    Private m_playors As Playor()
    Private m_status As StatusBase
    Private m_winsock_collection As LC.WinsockCollection
    'Private m_vocabulary() As Vocabulary
    Private m_decision() As String
    Private m_msgReceived() As Boolean
    Private m_scoreMatrix As LC.ScoreMatrix
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

    Public Property WinsockCollection() As LC.WinsockCollection
        Get
            Return Me.m_winsock_collection
        End Get
        Set(ByVal value As LC.WinsockCollection)
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

    Public Property ScoreMatrix() As LC.ScoreMatrix
        Get
            Return Me.m_scoreMatrix
        End Get
        Set(ByVal value As LC.ScoreMatrix)
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

    ''' <summary>
    ''' true if both playor's message received(with same msg type)
    ''' </summary>
    Public Function AllRequiredClientMsgReceived(ByVal mtype As LC.MsgType) As Boolean

        For i As Integer = 0 To m_msgFromAllPlayors.Length - 1
            Dim containThisType As Boolean = False
            For j As Integer = 0 To m_msgFromAllPlayors(i).Count - 1
                If m_msgFromAllPlayors(i)(j).MsgType = mtype Then
                    containThisType = True
                    Exit For
                End If
            Next
            If Not containThisType Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Sub New(ByVal p As Playor())
        Me.m_playors = p

        Me.m_status = New StatusConnected(Me)
        Me.m_status.Group = Me
        Me.m_decision = New String(p.Length - 1) {}
        m_msgReceived = New Boolean(p.Length - 1) {}
        Me.m_msgFromAllPlayors = New List(Of LC.MessageBag)(p.Length - 1) {}

        For index As Integer = 0 To m_msgFromAllPlayors.Length - 1
            Me.m_msgFromAllPlayors(index) = New List(Of LC.MessageBag)()
        Next
        m_currentRound = 0
    End Sub


    Protected Sub BackupMessage()
        'TODO 

        For index As Integer = 0 To m_msgFromAllPlayors.Length - 1
            Dim msgs As LC.MessageBag() = Me.m_msgFromAllPlayors(index).ToArray()
            Me.m_msgFromAllPlayors(index).Clear()
            'Write To Message File
            LC.ModuleEventLog.WriteLCMessage(msgs)
        Next
    End Sub

    Public Sub RegisterPhase1Decision(ByVal m As MessageBag)
        Dim playor As Playor = Game.FindPlayorById(Game.playerList, m.clientID)
        Dim playorIndex As Integer = Array.IndexOf(Me.m_playors, playor)
        Me.Decision(playorIndex) = m.Phase1Decision
    End Sub

    Public Sub ProcessMsg(ByVal msg As LC.MessageBag, ByVal playor As Playor)
        Dim playorIndex As Integer = Array.IndexOf(Me.m_playors, playor)
        Me.m_msgFromAllPlayors(playorIndex).Add(msg)
        Me.Status.ReceiveMsg(msg)
        If Not String.IsNullOrEmpty(msg.PlayorName) Then
            Me.m_playors(playorIndex).Name = msg.PlayorName
        End If
    End Sub

    ''' <summary>
    ''' signal both playor to begin
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Begin()
        If TypeOf Me.Status Is StatusConnected Then
            'TODO Me.m_status.ReceiveMsg(MsgType.beginGame, Nothing)
            Me.m_currentRound = 1
            For index As Integer = 0 To Me.Playors.Length - 1
                Me.Playors(index).DisplayInstruction(Me.WinsockCollection)
            Next
        Else
            Throw New Exception("Game already started")
        End If
    End Sub

    Public Sub NewRound()
        Me.Status = New StatusNewRound(Me)
        Me.SendVocabulary()
    End Sub

    Public Sub SendVocabulary()
        For index As Integer = 0 To Me.Playors.Length - 1
            Me.Playors(index).SendVocabularyToClient(Me.m_winsock_collection, Me.Playors(index).Vocabulary)
        Next
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
        Dim newCommonWords As New List(Of Tuple(Of String, String))()
        For index As Integer = 0 To Me.Playors.Length - 1
            Dim msg As LC.MessageBag = FindMsgByType(Me.m_msgFromAllPlayors(index), MsgType.Client_sendLearnInvent)
            Dim cost As Integer = 0
            cost += msg.learn
            cost += 0.5 * msg.invent.Length * (msg.invent.Length + 1)
            m_playors(index).Cost -= cost

            'for learn : move another playor's private list to common list
            Dim learnedWords As List(Of Tuple(Of String, String)) = Playors(1 - index).Vocabulary.Learn(msg.learn)
            'Playors(index).Vocabulary.m_commlist = newCommonlist
            newCommonWords.AddRange(learnedWords)

            'for invent
            For priSymIndex As Integer = 0 To msg.invent.Length - 1
                Playors(index).Vocabulary.AddPrivateList(msg.invent(priSymIndex).Item1, msg.invent(priSymIndex).Item2)
            Next
        Next
        'refresh both playors' common list
        For index As Integer = 0 To Me.Playors.Length - 1
            For j As Integer = 0 To newCommonWords.Count - 1
                Playors(index).Vocabulary.AddCommonList(newCommonWords(j).Item1, newCommonWords(j).Item2)
            Next
        Next
    End Sub

    Private Function FindMsgByType(ByVal list As IList(Of LC.MessageBag), ByVal mtype As MsgType)

        For index As Integer = 0 To list.Count - 1
            If list(index).MsgType = mtype Then
                Return list(index)
            End If
        Next
        Return Nothing
    End Function

    ''' <summary>
    '''collect all playor's final decision and update their score
    ''' </summary>
    Public Sub ShowResult()
        Dim playor1Decision As String = Nothing

        For index As Integer = 0 To Me.m_msgFromAllPlayors(0).Count - 1
            ' the phase 2 decision(if exists) will override phase 1 decision
            If m_msgFromAllPlayors(0)(index).MsgType = LC.MsgType.Client_sendPhase1Decision Then
                playor1Decision = m_msgFromAllPlayors(0)(index).Phase1Decision
            End If
            If m_msgFromAllPlayors(0)(index).MsgType = LC.MsgType.Client_sendPhase2Decision Then
                playor1Decision = m_msgFromAllPlayors(0)(index).Phase2Decision
            End If
        Next

        Dim playor2Decision As String = Nothing
        For index As Integer = 0 To Me.m_msgFromAllPlayors(1).Count - 1
            ' the phase 2 decision(if exists) will override phase 1 decision
            If m_msgFromAllPlayors(1)(index).MsgType = LC.MsgType.Client_sendPhase1Decision Then
                playor2Decision = m_msgFromAllPlayors(1)(index).Phase1Decision
            End If
            If m_msgFromAllPlayors(1)(index).MsgType = LC.MsgType.Client_sendPhase2Decision Then
                playor2Decision = m_msgFromAllPlayors(1)(index).Phase2Decision
            End If
        Next
        'the final decision 
        Me.Decision = New String() {playor1Decision, playor2Decision}

        Dim result As Tuple(Of Integer, Integer) = Me.ScoreMatrix.GetScore(playor1Decision, playor2Decision)
        If result Is Nothing Then
            Throw New Exception("Can't find score in matrix by:" + playor1Decision + "," + playor2Decision)
        End If
        Me.Playors(0).Score += result.Item1
        Me.Playors(1).Score += result.Item2

        For index As Integer = 0 To Me.Playors.Length - 1
            Me.Playors(index).ShowResultOfARound(Me.WinsockCollection, Me.m_decision, Me.Playors(index).Score)

        Next

    End Sub

    'random select 1 playor to observe the other's phase 1 decision
    Public Sub RandomShowPhase1()
        Dim randNumber As Integer = modRand.rand(99, 0)
        Dim playorIndex = randNumber Mod 2

        Me.Playors(playorIndex).ShowPhase1(Me.WinsockCollection, Me.Decision(1 - playorIndex), Me.ScoreMatrix)
    End Sub



    ''' <summary>
    ''' every 2 playor into 1 group(game) 
    ''' </summary>
    ''' <param name="playorlist"></param>
    ''' <param name="grouplist"></param>
    ''' <param name="vocabularyList"></param>
    ''' <param name="iniScore"></param>
    ''' <remarks></remarks>
    Public Shared Sub MakeGroups(ByVal playorlist As Playor(), _
                                ByVal grouplist As Group(), _
                                ByVal vocabularyList As List(Of Vocabulary), _
                                ByVal iniScore As Integer, _
                                ByVal cooperateMatrix As ScoreMatrix, _
                                ByVal competeMatrix As ScoreMatrix, _
                                ByVal sockCol As WinsockCollection)
        Dim groupIndex As Integer = 0

        For index As Integer = 0 To playorlist.Length - 1
            If (index Mod 2 = 0) Then
                Dim p() As Playor = New Playor(1) {playorlist(index), playorlist(index + 1)}
                grouplist(groupIndex) = New Group(p)
                grouplist(groupIndex).ScoreMatrix = cooperateMatrix
                grouplist(groupIndex).WinsockCollection = sockCol
                groupIndex += 1
            End If
            playorlist(index).Group = grouplist(groupIndex - 1)
            playorlist(index).Score = iniScore
            playorlist(index).Vocabulary = vocabularyList(index)
        Next

    End Sub


End Class