''' <summary>
''' radom selected to send phase 1 data to odd playor
''' </summary>
''' <remarks></remarks>
Public Class StatusWaitingPhase2Decision
    Inherits StatusBase


    Public Overrides Sub ReceiveMsg(ByVal m As LC.MessageBag)
        If m.MsgType = LC.MsgType.Client_sendPhase2Decision Then
            Me.Group.Status = New StatusPhase2DecisionMade(Me.Group)
            'send result to both playors
            Me.Group.ShowResult()
        End If
    End Sub

    Public Sub New(ByVal g As Group)
        MyBase.New(g)

    End Sub
End Class
