Imports LC
Imports System.IO
Imports System.Xml.Serialization
Imports System.Text

Public Class Playor
    Private m_id As String
    Private m_score As Integer
    Private m_countpart As Playor
    Private m_name As String
    Private m_vaca As Vocabulary
    Private m_socketKey As String
    Private m_myIPAddress As String
    Private m_group As Group
    Private m_cost As Integer

    Public Sub New()

    End Sub


    Public Property ID() As String
        Get
            Return Me.m_id
        End Get

        Set(ByVal value As String)
            Me.m_id = value
        End Set
    End Property


    Public Property Name() As String
        Get
            Return Me.m_name
        End Get

        Set(ByVal value As String)
            Me.m_name = value
        End Set
    End Property

    Public Property Vocabulary() As Vocabulary
        Get
            Return Me.m_vaca
        End Get
        Set(ByVal value As Vocabulary)
            Me.m_vaca = value
        End Set
    End Property



    Public Property socketKey() As String
        Get
            Return Me.m_socketKey
        End Get
        Set(ByVal value As String)
            Me.m_socketKey = value
        End Set
    End Property
    ''' <summary>
    ''' the other playor(group)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Counterpart() As Playor
        Get
            Return Me.m_countpart
        End Get
        Set(ByVal value As Playor)
            Me.m_countpart = value
        End Set
    End Property

    Public Property Score() As Integer
        Get
            Return Me.m_score
        End Get
        Set(ByVal value As Integer)
            Me.m_score = value
        End Set
    End Property

    Public Property Cost() As Integer
        Get
            Return Me.m_cost
        End Get
        Set(ByVal value As Integer)
            Me.m_cost = value
        End Set
    End Property


    Public Property myIPAddress() As String
        Get
            Return m_myIPAddress
        End Get
        Set(ByVal value As String)
            m_myIPAddress = value
        End Set
    End Property

    'Private m_IPAddress As String
    'Public Property IPAddress() As String
    '    Get
    '        Return m_IPAddress
    '    End Get
    '    Set(ByVal value As String)
    '        m_IPAddress = value
    '    End Set
    'End Property

    Public Property Group() As Group
        Get
            Return Me.m_group
        End Get
        Set(ByVal value As Group)
            Me.m_group = value
        End Set
    End Property
    Public Sub requsetIP(ByVal wsk_Col As WinsockCollection)
        Try
            'TODO wsk_Col.Send(MsgType.requestIP.ToString(), socketNumber, Me.ID)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SendVocabularyToClient(ByVal wsk_Col As WinsockCollection, ByVal voca As LC.Vocabulary)
        Try
            Dim message As New LC.MessageBag
            message.MsgType = MsgType.Server_languageDecision
            message.Vocabulary = voca
            Dim msgStr As String = LC.XmlHelper.XmlSerialize(message, Encoding.UTF8)

            wsk_Col.Send(Me.ID, msgStr)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SendScoreMatrixToClient(ByVal wsk_Col As WinsockCollection, ByVal matrix As ScoreMatrix)
        Try
            Dim message As New LC.MessageBag
            message.MsgType = MsgType.Server_feedbackScoreMatrix
            message.scoreMatrix = matrix
            Dim msgStr As String = LC.XmlHelper.XmlSerialize(message, Encoding.UTF8)

            wsk_Col.Send(Me.ID, msgStr)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DisplayInstruction(ByVal wsk_Col As WinsockCollection)
        Try
            Dim message As New LC.MessageBag
            message.MsgType = MsgType.Server_readInstruction
            Dim msgStr As String = LC.XmlHelper.XmlSerialize(message, Encoding.UTF8)
            wsk_Col.Send(Me.ID, msgStr)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ShowPhase1(ByVal wsk_Col As WinsockCollection, ByVal decision As String, ByVal scoreMatrix As ScoreMatrix)
        Try
            Dim message As New LC.MessageBag
            message.Phase1Decision = decision
            message.MsgType = MsgType.Server_feedbackPhase1Decision
            message.scoreMatrix = scoreMatrix
            Dim msgStr As String = LC.XmlHelper.XmlSerialize(message, Encoding.UTF8)
            wsk_Col.Send(Me.ID, msgStr)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ShowResultOfARound(ByVal wsk_Col As WinsockCollection, ByVal Decisions As String(), ByVal scores As Integer)
        Try
            Dim message As New LC.MessageBag
            message.MsgType = MsgType.Server_feedbackPhase1Decision
            message.Score = scores
            message.Decision = Decisions
            Dim msgStr As String = LC.XmlHelper.XmlSerialize(message, Encoding.UTF8)

            wsk_Col.Send(Me.ID, msgStr)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    'Public Sub ProcessMsg(ByVal msg As LC.MessageBag)
    '    'TODO
    '    'handle the status
    '    Me.Group.ProcessMsg(msg, Me)
    'End Sub
End Class