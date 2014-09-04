Public Class StatusConnected
    Inherits StatusBase

   
    Public Overrides Sub ReceiveMsg(ByVal m As LC.MessageBag)
        If m.MsgType = LC.MsgType.Client_finishedInstructions Then
            If Group.AllRequiredClientMsgReceived(m.MsgType) Then
                Me.Group.Status = New StatusNewRound(Me.Group)
                Me.Group.SendVocabulary()
            End If
        End If
    End Sub

    Public Sub New(ByVal g As Group)
        MyBase.New(g)

    End Sub


End Class
