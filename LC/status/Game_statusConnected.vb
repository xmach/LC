Public Class StatusConnected
    Inherits StatusBase

    'Public Sub New(ByVal g As Game)
    '    MyBase.New(g)
    '    Me.m_game = g

    'End Sub
    Public Overrides Sub ReceiveMsg(ByVal m As LC.MessageBag)
        If m.MsgType = MsgType.Client_finishedInstructions Then
            'TODO and both msg received
            If Game.AllRequiredClientMsgReceived Then
                Me.Game.Status = New StatusNewRound
                Me.Game.SendVocabulary()
            End If
        End If
    End Sub

End Class
