''' <summary>
''' instructions finished or last round finished
''' </summary>
''' <remarks></remarks>
Public Class StatusNewRound
    Inherits StatusBase

    Public Overrides Sub ReceiveMsg(ByVal m As LC.MessageBag)
        If m.MsgType = MsgType.Client_sendLearnInvent Then
            If Game.AllRequiredClientMsgReceived Then
                Me.Game.UpdateVocabulary()
                Me.Game.Status = New StatusVocabularyUpdated
                Me.Game.ShowScoreMatrix()
            End If
        End If
    End Sub
End Class
