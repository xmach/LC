Public Class StatusWaitingPhase1Decision
    Inherits StatusBase


    Public Overrides Sub ReceiveMsg(ByVal m As MessageBag)
        If m.MsgType = MsgType.Client_sendPhase1Decision Then
            If Me.Game.AllRequiredClientMsgReceived Then
                Me.Game.Status = New StatusWaitingPhase2Decision
            End If
        End If
    End Sub
End Class
