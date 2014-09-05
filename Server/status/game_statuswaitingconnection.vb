Public Class StatusWaitingConnection
    Inherits StatusBase


    Public Overrides Sub ReceiveMsg(ByVal m As LC.MessageBag)

    End Sub

    Public Sub New(ByVal g As Group)
        MyBase.New(g)

    End Sub
End Class
