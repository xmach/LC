Public Class MatrixRow
    Public Sub New()

    End Sub

    Public Sub New(ByVal fm As String, ByVal sm As String, ByVal fs As Integer, ByVal ss As Integer)
        Me.firstMeaning = fm
        Me.secondMeaning = sm
        Me.firstScore = fs
        Me.secondScore = ss
    End Sub
    Public firstMeaning As String
    Public secondMeaning As String

    Public firstScore As Integer
    Public secondScore As Integer
End Class
