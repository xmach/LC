Imports LC
Public Class Group

    Private m_Players As Player()
    Private m_status As StatusBase
    Private m_winsock_collection As LC.WinsockCollection
    'Private m_vocabulary() As Vocabulary
    Private m_decision() As String
    Private m_msgReceived() As Boolean
    Private m_scoreMatrix As LC.ScoreMatrix
    Private m_msgFromAllPlayers() As List(Of LC.MessageBag)
    'Private m_currentRound As Integer

    Private Event StatusUpdated(ByVal sender As Object, ByVal e As System.EventArgs)

    'Public Property CurrentRound() As Integer
    '    Get
    '        Return Me.m_currentRound
    '    End Get
    '    Set(ByVal value As Integer)
    '        m_currentRound = value
    '    End Set
    'End Property

    Public Property Status() As StatusBase
        Get
            Return Me.m_status
        End Get
        Set(ByVal value As StatusBase)
            Me.m_status = value

        End Set
    End Property

    Public Property Players() As Player()
        Get
            Return Me.m_players
        End Get
        Set(ByVal value As Player())
            Me.m_Players = value
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

    Public Property MsgFromAllPlayers() As List(Of MessageBag)()
        Get
            Return m_msgFromAllPlayers
        End Get
        Set(ByVal value As List(Of MessageBag)())
            m_msgFromAllPlayers = value
        End Set
    End Property

    ''' <summary>
    ''' true if both Player's message received(with same msg type)
    ''' </summary>
    Public Function AllRequiredClientMsgReceived(ByVal mtype As LC.MsgType) As Boolean

        For i As Integer = 0 To MsgFromAllPlayers.Length - 1
            Dim containThisType As Boolean = False
            For j As Integer = 0 To MsgFromAllPlayers(i).Count - 1
                If MsgFromAllPlayers(i)(j).MsgType = mtype Then
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

    Public Sub New(ByVal p As Player())
        Me.m_Players = p

        Me.m_status = New StatusConnected(Me)
        Me.m_status.Group = Me
        Me.m_decision = New String(p.Length - 1) {}
        m_msgReceived = New Boolean(p.Length - 1) {}
        Me.MsgFromAllPlayers = New List(Of LC.MessageBag)(p.Length - 1) {}

        For index As Integer = 0 To MsgFromAllPlayers.Length - 1
            Me.MsgFromAllPlayers(index) = New List(Of LC.MessageBag)()
        Next
        'm_currentRound = 0
    End Sub

    Public Sub RegisterPhase1Decision(ByVal m As MessageBag)
        Dim p As Player = Game.FindPlayerById(Game.playerList, m.clientID)
        p.Phase1_decision = m.Phase1Decision
        Dim PlayerIndex As Integer = Array.IndexOf(Me.m_Players, p)
        Me.Decision(PlayerIndex) = m.Phase1Decision
    End Sub

    Public Sub RegisterPhase2Decision(ByVal m As MessageBag)
        Dim p As Player = Game.FindPlayerById(Game.playerList, m.clientID)
        p.Phase2_decision = m.Phase1Decision
        Dim PlayerIndex As Integer = Array.IndexOf(Me.m_Players, p)
        Me.Decision(PlayerIndex) = m.Phase2Decision
    End Sub

    Public Sub ProcessMsg(ByVal msg As LC.MessageBag, ByVal Player As Player)
        Dim PlayerIndex As Integer = Array.IndexOf(Me.m_Players, Player)
        Me.MsgFromAllPlayers(PlayerIndex).Add(msg)
        Me.Status.ReceiveMsg(msg)
        If Not String.IsNullOrEmpty(msg.PlayerName) Then
            Me.m_Players(PlayerIndex).Name = msg.PlayerName
        End If
    End Sub



    Public Sub NewRound()
        Me.Status = New StatusNewRound(Me)
        'reset player 
        For index As Integer = 0 To Me.Players.Length - 1
            Me.Players(index).Num_of_invent = CType(Nothing, Nullable(Of Integer))
            Me.Players(index).Num_of_learn = CType(Nothing, Nullable(Of Integer))
            Me.Players(index).Phase1_decision = Nothing
            Me.Players(index).Phase2_decision = Nothing
        Next
        Me.SendVocabulary()
    End Sub

    Public Sub SendVocabulary()
        For index As Integer = 0 To Me.Players.Length - 1
            Me.Players(index).SendVocabularyToClient(Me.m_winsock_collection, Me.Players(index).Vocabulary, Game.meanings, Game.CurrentRoundNumber)
        Next
    End Sub

    Public Sub ShowScoreMatrix()
        For index As Integer = 0 To Me.Players.Length - 1
            Me.Players(index).SendScoreMatrixToClient(Me.WinsockCollection, Me.m_scoreMatrix)
        Next
    End Sub

    ''' <summary>
    ''' update UpdateVocabulary and compute cost
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateVocabulary()
        'TODO
        'Deserialize the input ,then update vocabulary
        'Player id = xxx
        ' for the common part ,remove it from other's private list to all common list
        ' for the private part ,add
        'calculate cost
        Dim newCommonWords As New List(Of Tuple(Of String, String))()
        For index As Integer = 0 To Me.Players.Length - 1
            Dim msg As LC.MessageBag = FindMsgByType(Me.MsgFromAllPlayers(index), MsgType.Client_sendLearnInvent)
            Me.Players(index).Num_of_learn = msg.learn
            Me.Players(index).Num_of_invent = CType(IIf(msg.invent Is Nothing, 0, msg.invent.Length), Integer)
            Dim cost As Integer = 0
            cost += msg.learn
            If Not msg.invent Is Nothing Then
                cost += Convert.ToInt32(0.5 * msg.invent.Length * (msg.invent.Length + 1))
            End If
            m_Players(index).Cost = cost

            'for learn : move another Player's private list to common list
            Dim learnedWords As List(Of Tuple(Of String, String)) = Players(1 - index).Vocabulary.Learn(msg.learn)
            'Players(index).Vocabulary.m_commlist = newCommonlist
            newCommonWords.AddRange(learnedWords)
            If Not msg.invent Is Nothing Then
                'for invent
                For priSymIndex As Integer = 0 To msg.invent.Length - 1
                    Players(index).Vocabulary.AddPrivateList(msg.invent(priSymIndex).Item1, msg.invent(priSymIndex).Item2)
                Next
            End If
        Next
        'refresh both Players' common list
        For index As Integer = 0 To Me.Players.Length - 1
            For j As Integer = 0 To newCommonWords.Count - 1
                Players(index).Vocabulary.AddCommonList(newCommonWords(j).Item1, newCommonWords(j).Item2)
            Next
        Next
    End Sub

    Private Function FindMsgByType(ByVal list As IList(Of LC.MessageBag), ByVal mtype As MsgType) As MessageBag

        For index As Integer = 0 To list.Count - 1
            If list(index).MsgType = mtype Then
                Return list(index)
            End If
        Next
        Return Nothing
    End Function

    ''' <summary>
    '''collect all Player's final decision and update their score
    ''' </summary>
    Public Sub ShowResult()
        Dim Player1Decision As String = Nothing

        For index As Integer = 0 To Me.MsgFromAllPlayers(0).Count - 1
            ' the phase 2 decision(if exists) will override phase 1 decision
            If MsgFromAllPlayers(0)(index).MsgType = LC.MsgType.Client_sendPhase1Decision Then
                Player1Decision = MsgFromAllPlayers(0)(index).Phase1Decision
            End If
            If MsgFromAllPlayers(0)(index).MsgType = LC.MsgType.Client_sendPhase2Decision Then
                Player1Decision = MsgFromAllPlayers(0)(index).Phase2Decision
            End If
        Next

        Dim Player2Decision As String = Nothing
        For index As Integer = 0 To Me.MsgFromAllPlayers(1).Count - 1
            ' the phase 2 decision(if exists) will override phase 1 decision
            If MsgFromAllPlayers(1)(index).MsgType = LC.MsgType.Client_sendPhase1Decision Then
                Player2Decision = MsgFromAllPlayers(1)(index).Phase1Decision
            End If
            If MsgFromAllPlayers(1)(index).MsgType = LC.MsgType.Client_sendPhase2Decision Then
                Player2Decision = MsgFromAllPlayers(1)(index).Phase2Decision
            End If
        Next
        'the final decision 
        Me.Decision = New String() {Player1Decision, Player2Decision}

        Dim result As Tuple(Of Integer, Integer) = Me.ScoreMatrix.GetScore(Player1Decision, Player2Decision)
        If result Is Nothing Then
            Throw New Exception("Can't find score in matrix by:" + Player1Decision + "," + Player2Decision)
        End If
        Me.Players(0).Score += result.Item1
        Me.Players(1).Score += result.Item2
        Me.Players(0).Score -= Me.Players(0).Cost
        Me.Players(1).Score -= Me.Players(1).Cost
        For index As Integer = 0 To Me.Players.Length - 1
            Me.Players(index).ShowResultOfARound(Me.WinsockCollection, Me.m_decision, Me.Players(index).Score)

        Next

    End Sub

    'random select 1 Player to observe the other's phase 1 decision
    Public Sub RandomShowPhase1()
        Dim randNumber As Integer = modRand.rand(99, 0)
        Dim PlayerIndex = randNumber Mod 2

        Me.Players(PlayerIndex).ShowPhase1(Me.WinsockCollection, Me.Decision(1 - PlayerIndex), Me.ScoreMatrix)
    End Sub







End Class
