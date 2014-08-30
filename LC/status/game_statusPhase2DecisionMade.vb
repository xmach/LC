Public Class StatusPhase2DecisionMade
    Inherits StatusBase


    Public Overrides Sub ReceiveMsg(ByVal m As LC.MessageBag)
        If m.MsgType = MsgType.Client_newRound Then
            If Game.AllRequiredClientMsgReceived Then
                Me.Game.Status = New StatusNewRound()
            End If
        End If
    End Sub
End Class
