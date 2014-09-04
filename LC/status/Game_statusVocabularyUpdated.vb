Public Class StatusVocabularyUpdated
    Inherits StatusBase


    Public Overrides Sub ReceiveMsg(ByVal m As LC.MessageBag)
        If m.MsgType = LC.MsgType.Client_sendPhase1Decision Then
            Me.Group.RegisterPhase1Decision(m)
            If Me.Group.AllRequiredClientMsgReceived(m.MsgType) Then
                Me.Group.RandomShowPhase1()
                Me.Group.Status = New StatusWaitingPhase2Decision(Me.Group)
            End If
        End If
    End Sub

    Public Sub New(ByVal g As Group)
        MyBase.New(g)

    End Sub
End Class
