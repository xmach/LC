''' <summary>
''' radom selected to send phase 1 data to odd playor
''' </summary>
''' <remarks></remarks>
Public Class StatusWaitingPhase2Decision
    Inherits StatusBase


    Public Overrides Sub ReceiveMsg(ByVal m As LC.MessageBag)
        If m.MsgType = MsgType.Client_sendPhase2Decision Then
            Me.Game.Status = New StatusPhase2DecisionMade
            'TODO send result to both playors
            Me.Game.ShowResultAndNewRound()
        End If
    End Sub
End Class
