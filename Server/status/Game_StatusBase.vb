Imports LC

Public MustInherit Class StatusBase
    Public MustOverride Sub ReceiveMsg(ByVal m As LC.MessageBag)


    Protected m_game As Group
    Public Property Group() As Group
        Get
            Return Me.m_game
        End Get
        Set(ByVal value As Group)
            Me.m_game = value
        End Set
    End Property
    Public Sub New(ByVal g As Group)
        Me.m_game = g
    End Sub




End Class