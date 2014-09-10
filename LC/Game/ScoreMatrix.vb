''' <summary>
''' the 3*3 matrix for different decision
''' </summary>
''' <remarks></remarks>
Public Class ScoreMatrix

    Public Sub New()

    End Sub

    ''' <summary>
    ''' if MeaningCount=3 ,Rows : 3*3=9 row
    ''' </summary>
    ''' <remarks></remarks>
    Public Rows As List(Of MatrixRow) = New List(Of MatrixRow)

    ''' <summary>
    ''' if contains any row that both player get negtive score , the matrix is compete type
    ''' otherwise cooperate type
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property GameType() As GameType
        Get
            For index As Integer = 0 To Me.Rows.Count - 1
                If Me.Rows(index).firstScore < 0 AndAlso Me.Rows(index).secondScore < 0 Then
                    Return LC.GameType.Compete
                End If
            Next
            Return LC.GameType.Cooperate
        End Get
    End Property

    'Public Sub ReadFromFile(ByVal iniFileName As String, ByVal meanings As String(), ByVal iniKeyName As String)
    '    If meanings.Length <> Me.MeaningCount Then
    '        Me.MeaningCount = meanings.Length
    '        Me.Rows = New MatrixRow(MeaningCount * MeaningCount - 1) {}
    '    End If

    '    Dim rowIndex = 0
    '    'read all score rule
    '    For x As Integer = 0 To meanings.Length - 1
    '        For y As Integer = 0 To meanings.Length - 1
    '            Dim key1 As String = meanings(x) + "," + meanings(y)
    '            Dim scoreLine As String = getINI(iniFileName, iniKeyName, key1)

    '            If scoreLine <> "?" Then
    '                Dim score As String() = scoreLine.Split(","c)
    '                Dim matrixrow As New MatrixRow(meanings(x), meanings(y), Integer.Parse(score(0)), Integer.Parse(score(1)))
    '                Me.Rows(rowIndex) = matrixrow
    '                rowIndex += 1
    '            End If
    '        Next

    '    Next
    'End Sub

    ''' <summary>
    ''' the input file contains n rows, each row is score matrix for each round .
    ''' each row contains 18 columns ,mapping to 9 cells in the score matrix
    ''' column 0,2,4,6,8,10,12,14,16 is score for first playor 
    ''' column 1,3,5,7,9,11,13,15,17 is score for second playor
    ''' </summary>
    ''' <param name="fileName">csv file name</param>
    ''' <remarks></remarks>
    Public Shared Function ReadFromFile(ByVal fileName As String, ByVal numofRound As Integer, ByVal meanings As String()) As ScoreMatrix()
        Dim allLines As String() = IO.File.ReadAllLines(fileName)
        'the last line may contains blank
        If String.IsNullOrEmpty(allLines(allLines.Length - 1).Trim()) Then
            Array.Resize(allLines, allLines.Length - 1)
        End If
        If allLines.Length <> numofRound Then
            Throw New Exception("There are " & numofRound.ToString() & " rounds,the parameter for score matrix should alson contain " & numofRound & " rows")
        End If

        Dim numofColmns = meanings.Length * meanings.Length * 2

        Dim allRoundMatrixs As New List(Of ScoreMatrix)()

        For index As Integer = 0 To allLines.Length - 1
            Dim m As New ScoreMatrix()
            'each row split into 18 columns
            Dim colStr As String() = allLines(index).Split(","c)
            If colStr.Length < numofColmns Then
                Throw New Exception("Each row should contain " & 18 & " columns")
            End If

            For i As Integer = 0 To meanings.Length - 1
                For j As Integer = 0 To meanings.Length - 1
                    Dim matrixrow As New MatrixRow(meanings(i), _
                                                    meanings(j), _
                                                    colStr(2 * (i + j)), _
                                                    colStr((2 * (i + j)) + 1))
                    m.Rows.Add(matrixrow)
                Next
            Next
            allRoundMatrixs.Add(m)
        Next
        Return allRoundMatrixs.ToArray()
    End Function

    Public Shared Sub WriteToFile(ByVal fileName As String, ByVal meanings As String(), ByVal ms As ScoreMatrix())
        'each item in array into 1 line in file
        Dim writer As New IO.StreamWriter(New IO.FileStream(fileName, IO.FileMode.Create))
        Dim sb As New Text.StringBuilder()

        For mIndex As Integer = 0 To ms.Length - 1 'for all rounds
            Dim mx As ScoreMatrix = ms(mIndex)
            For i As Integer = 0 To meanings.Length - 1
                For j As Integer = 0 To meanings.Length - 1
                    Dim scores As Tuple(Of Integer, Integer) = mx.GetScore(meanings(i), meanings(j))
                    sb.Append(scores.Item1.ToString())
                    sb.Append(",")
                    sb.Append(scores.Item2.ToString())
                    sb.Append(",")
                Next
            Next
            'writer 1 matrix into 1 line
            writer.WriteLine(sb.ToString())
            sb.Length = 0
        Next
        writer.Close()
    End Sub

    'Find score by both playor's decision
    Public Function GetScore(ByVal meaning1 As String, ByVal meaning2 As String) As Tuple(Of Integer, Integer)

        For index As Integer = 0 To Me.Rows.Count - 1
            If Rows(index).firstMeaning = meaning1 AndAlso Rows(index).secondMeaning = meaning2 Then
                Return New Tuple(Of Integer, Integer)(Rows(index).firstScore, Rows(index).secondScore)
            End If
        Next
        Return Nothing
    End Function

    Public Sub UpdateScore(ByVal meaning1 As String, ByVal meaning2 As String, ByVal score1 As Integer, ByVal score2 As Integer)

        For index As Integer = 0 To Me.Rows.Count - 1

            If Rows(index).firstMeaning = meaning1 AndAlso Rows(index).secondMeaning = meaning2 Then
                Rows(index).firstScore = score1
                Rows(index).secondScore = score2
                Return
            End If
        Next
    End Sub
End Class
