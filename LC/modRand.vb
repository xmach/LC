Module modRand
    'random number generator
    Dim tempRand As New Random

    Public Function rand(ByVal upper As Integer, ByVal lower As Integer) As Integer
        Return tempRand.Next(lower, upper + 1)
    End Function
End Module
