Public Class StatusPhase2DecisionMade
    Inherits StatusBase


    Public Overrides Sub ReceiveMsg(ByVal m As LC.MessageBag)
        If m.MsgType = LC.MsgType.Client_newRound Then
            If Group.AllRequiredClientMsgReceived(m.MsgType) Then
                If Game.ReadyForNewRound Then
                    Game.NextRound()
                End If
            End If
        End If
    End Sub

    Public Sub New(ByVal g As Group)
        MyBase.New(g)

    End Sub
End Class
