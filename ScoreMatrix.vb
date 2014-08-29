''' <summary>
''' the 3*3 matrix for different decision
''' </summary>
''' <remarks></remarks>
Public Class ScoreMatrix

    Public Sub New()

    End Sub
    ''' <summary>
    ''' how many meanings,default  is 3
    ''' </summary>
    ''' <remarks></remarks>
    Public MeaningCount As Integer = 3
    ''' <summary>
    ''' if MeaningCount=3 ,Rows : 3*3=9 row
    ''' </summary>
    ''' <remarks></remarks>
    Public Rows() As MatrixRow = New MatrixRow(MeaningCount * MeaningCount - 1) {}

    ''' <summary>
    ''' initialize from ini file 
    ''' </summary>
    ''' <param name="iniFileName"></param>
    ''' <param name="meanings"></param>
    ''' <param name="iniKeyName">the cooperate or compete matrix</param>
    ''' <remarks></remarks>
    Public Sub ReadFromFile(ByVal iniFileName As String, ByVal meanings As String(), ByVal iniKeyName As String)
        If meanings.Length <> Me.MeaningCount Then
            Me.MeaningCount = meanings.Length
            Me.Rows = New MatrixRow(MeaningCount * MeaningCount - 1) {}
        End If

        Dim rowIndex = 0
        'read all score rule
        For x As Integer = 0 To meanings.Length - 1
            For y As Integer = 0 To meanings.Length - 1
                Dim key1 As String = meanings(x) + "," + meanings(y)
                Dim scoreLine As String = getINI(iniFileName, iniKeyName, key1)

                If scoreLine <> "?" Then
                    Dim score As String() = scoreLine.Split(","c)
                    Dim matrixrow As New MatrixRow(meanings(x), meanings(y), Integer.Parse(score(0)), Integer.Parse(score(1)))
                    Me.Rows(rowIndex) = matrixrow
                    rowIndex += 1
                End If
            Next

        Next
    End Sub

    'save the settings
    Public Sub WriteToFile(ByVal iniFilename)
        'TODO 
    End Sub

    'Find score by both playor's decision
    Public Function GetScore(ByVal meaning1 As String, ByVal meaning2 As String) As Tuple(Of Integer, Integer)

        For index As Integer = 0 To Me.Rows.Length - 1
            If Rows(index).firstMeaning = meaning1 AndAlso Rows(index).secondMeaning = meaning2 Then
                Return New Tuple(Of Integer, Integer)(Rows(index).firstScore, Rows(index).secondScore)
            End If
        Next
        Return Nothing
    End Function

    Public Sub UpdateScore(ByVal meaning1 As String, ByVal meaning2 As String, ByVal score1 As Integer, ByVal score2 As Integer)

        For index As Integer = 0 To Me.Rows.Length - 1

            If Rows(index).firstMeaning = meaning1 AndAlso Rows(index).secondMeaning = meaning2 Then
                Rows(index).firstScore = score1
                Rows(index).secondScore = score2
                Return
            End If
        Next
    End Sub
End Class
