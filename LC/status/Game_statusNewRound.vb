''' <summary>
''' instructions finished or last round finished
''' </summary>
''' <remarks></remarks>
Public Class StatusNewRound
    Inherits StatusBase

    Public Overrides Sub ReceiveMsg(ByVal m As LC.MessageBag)
        If m.MsgType = LC.MsgType.Client_sendLearnInvent Then
            If Group.AllRequiredClientMsgReceived(m.MsgType) Then
                Me.Group.UpdateVocabulary()
                Me.Group.Status = New StatusVocabularyUpdated(Me.Group)
                Me.Group.ShowScoreMatrix()
            End If
        End If
    End Sub

    Public Sub New(ByVal g As Group)
        MyBase.New(g)

    End Sub
End Class
