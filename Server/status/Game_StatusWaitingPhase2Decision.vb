''' <summary>
''' radom selected to send phase 1 data to odd Player
''' </summary>
''' <remarks></remarks>
Public Class StatusWaitingPhase2Decision
    Inherits StatusBase


    Public Overrides Sub ReceiveMsg(ByVal m As LC.MessageBag)
        If m.MsgType = LC.MsgType.Client_sendPhase2Decision Then
            Me.Group.RegisterPhase2Decision(m)
            Me.Group.Status = New StatusPhase2DecisionMade(Me.Group)
            'send result to both Players
            Me.Group.ShowResult()
        End If
    End Sub

    Public Sub New(ByVal g As Group)
        MyBase.New(g)

    End Sub
End Class
