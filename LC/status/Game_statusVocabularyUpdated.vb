Public Class StatusVocabularyUpdated
    Inherits StatusBase


    Public Overrides Sub ReceiveMsg(ByVal m As LC.MessageBag)
        If m.MsgType = MsgType.Client_sendPhase1Decision Then

            If Me.Game.AllRequiredClientMsgReceived Then
                Me.Game.RandomShowPhase1()
                Me.Game.Status = New StatusWaitingPhase2Decision
            End If
        End If
    End Sub
End Class
