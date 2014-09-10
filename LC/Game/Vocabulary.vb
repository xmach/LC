Imports System.Xml.Serialization
Imports System.IO
Imports System.Text
Public Class Vocabulary

    Public m_meaning As List(Of String)

    Public m_commlist As String()()

    Public m_privateList As String()()

    Public ReadOnly Property LS() As Decimal
        Get
            'TODO
            'LS = num of common list / num of total list(common+ private
            Return CType(NumberOfPrivate, Decimal) / (CType(Me.NumberOfCommon, Decimal) + CType(Me.NumberOfPrivate, Decimal))
        End Get
    End Property

   
    Public Sub New()
        m_meaning = New List(Of String)
        m_commlist = New String()() {}
        m_privateList = New String()() {}
    End Sub

    ''' <summary>
    ''' add a symbol to common list
    ''' </summary>
    ''' <param name="meaning"></param>
    ''' <param name="symbol"></param>
    ''' <remarks></remarks>
    Public Sub AddCommonList(ByVal meaning As String, ByVal symbol As String)
        AddSymbol(Me.m_commlist, meaning, symbol)
    End Sub

    Public Sub AddPrivateList(ByVal meaning As String, ByVal symbol As String)
        AddSymbol(Me.m_privateList, meaning, symbol)
    End Sub

    Private Sub AddSymbol(ByRef dict As String()(), ByVal meaning As String, ByVal symbol As String)
        Dim meaningIndex As Integer = m_meaning.IndexOf(meaning)
        If meaningIndex < 0 Then
            m_meaning.Add(meaning)
            meaningIndex = m_meaning.Count - 1
        End If
        If dict.Length <= meaningIndex Then
            Array.Resize(dict, m_meaning.Count)
        End If

        If dict(meaningIndex) Is Nothing Then
            dict(meaningIndex) = New String() {}
        End If
        'Dim symbolList As IList(Of String) = dict(meaning)
        If Array.IndexOf(dict(meaningIndex), symbol) < 0 Then
            'ReDim dict(meaningIndex)(dict(meaningIndex).Length)
            Array.Resize(dict(meaningIndex), dict(meaningIndex).Length + 1)
            dict(meaningIndex)(dict(meaningIndex).Length - 1) = symbol
        End If
    End Sub

    'Shared Function CalculateCost(ByVal numberOfSymbol As Integer)
    '    Return 0.5 * numberOfSymbol * (numberOfSymbol + 1)

    'End Function

    ''' <summary>
    ''' learn N words from private list to common list
    ''' </summary>
    ''' <param name="learnCount">how many words to learn</param>
    ''' <returns>the new common list</returns>
    Public Function Learn(ByVal learnCount As Integer) As List(Of Tuple(Of String, String))
        If learnCount > Me.NumberOfPrivate Then
            Throw New ArgumentException("This vocabulary just contains:" & NumberOfPrivate.ToString() & ", can't learn:" & learnCount.ToString())
        End If
        Dim learnList As New List(Of Tuple(Of String, String))(learnCount)
        For i As Integer = 1 To learnCount
            Dim word As Tuple(Of String, String) = RemovePrivateSymbol()
            learnList.Add(word)
        Next
        Return learnList
    End Function

    Public ReadOnly Property NumberOfPrivate() As Integer
        Get
            Dim count As Integer = 0

            For index As Integer = 0 To Me.m_privateList.Length - 1
                count += Me.m_privateList(index).Length
            Next
            Return count
        End Get
    End Property

    Public ReadOnly Property NumberOfCommon() As Integer
        Get
            Dim count As Integer = 0
            For index As Integer = 0 To Me.m_commlist.Length - 1
                count += Me.m_commlist(index).Length
            Next
            Return count
        End Get
    End Property

    Private Function RemovePrivateSymbol() As Tuple(Of String, String)

        For index As Integer = 0 To Me.m_privateList.Length - 1
            If Not m_privateList(index) Is Nothing AndAlso m_privateList(index).Length > 0 Then
                Dim tup As New Tuple(Of String, String)(Me.m_meaning(index), m_privateList(index)(0))
                If m_privateList(index).Length > 1 Then
                    Array.Copy(m_privateList(index), 1, m_privateList(index), 0, m_privateList(index).Length - 1)
                End If
                Array.Resize(m_privateList(index), m_privateList(index).Length - 1)
                Return tup
            End If
        Next
        Return Nothing
    End Function

    Private Shared Function CopyList(ByVal oldArry As String()())
        Dim newArray As String()() = New String(oldArry.Length - 1)() {}

        For index As Integer = 0 To newArray.Length - 1
            If Not oldArry(index) Is Nothing Then
                newArray(index) = New String(oldArry(index).Length - 1) {}
                Array.Copy(oldArry(index), newArray(index), oldArry(index).Length)
            End If
        Next
        Return newArray
    End Function

    Public Function GetCommonList(ByVal key As String) As ICollection(Of String)
        Dim index As Integer = m_meaning.IndexOf(key)
        If index < 0 Then
            Return Nothing
        End If
        If Me.m_commlist.Length <= (index) Then
            Return New String() {}
        End If
        Dim list As String() = Me.m_commlist(index)
        Return list
    End Function

    Public Function GetPrivateList(ByVal key As String) As ICollection(Of String)
        Dim index As Integer = m_meaning.IndexOf(key)
        If index < 0 Then
            Return Nothing
        End If
        Dim list As String() = Me.m_privateList(index)
        Return list
    End Function


    Public Property Meanings() As List(Of String)
        Get
            Return Me.m_meaning
        End Get
        Set(ByVal value As List(Of String))
            m_meaning = value
        End Set
    End Property

    ''' <summary>
    ''' read from ini file
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReadSymbolFromFile(ByVal fileName As String) As List(Of String)
        Dim allSymString As String = File.ReadAllText(fileName, Encoding.UTF8)
        Dim list As New List(Of String)
        Dim allChars As Char() = allSymString.ToCharArray()
        For index As Integer = 0 To allChars.Length - 1
            list.Add(allChars(index))
        Next
        Return list
    End Function

    ''' <summary>
    ''' Generate Vocabulary for all playors
    ''' </summary>
    ''' <param name="PlayorCount"></param>
    ''' <param name="allSymbol"></param>
    ''' <param name="ls"></param>
    ''' <param name="initalWordCount"></param>
    ''' <param name="meaning"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GenerateVocabulary(ByVal PlayorCount As Integer, ByVal allSymbol As List(Of String), _
            ByVal ls As Decimal, ByVal initalWordCount As Integer, ByVal meaning() As String) As List(Of LC.Vocabulary)
        If PlayorCount Mod 2 <> 0 Then
            Throw New ArgumentException("Playor number should be even")
        End If
        'check how many symbol needed to generate all vocabulary
        'fomula:  numberofSymbol=(LS+1)* initialWordofVocabulary * (playorcount/2)
        'for example, set LS=0.4 ,initialWordofVocabulary=5 ,a group(2) vocabularies share 2 words in common list , 
        'and each contain 3 words in private list.  2+3+3 =7  equals (0.4+1)*5 =7 
        Dim maximumSymbols As Integer = (1 + ls) * initalWordCount * (PlayorCount / 2)
        If allSymbol.Count < maximumSymbols Then
            Throw New ArgumentException("Symbol should contain at least:" + maximumSymbols.ToString() + " items")
        End If

        'Dim charTable As New List(Of KeyValuePair(Of UInteger, UInteger))
        Dim commonWordCount As Integer = Convert.ToInt32(Decimal.Round(CType(initalWordCount, Decimal) * ls))
        Dim privateWordCount As Integer = initalWordCount - commonWordCount


        'initial the list for every playor's vocabulary
        Dim vocabularyList As New List(Of LC.Vocabulary)(PlayorCount)
        For playorIndex As Integer = 1 To PlayorCount
            If playorIndex Mod 2 <> 0 Then 'odd playor

                'add common list
                'for example a b c
                '            ^ &
                'a mapped with ^  , b mapped with & 
                Dim voca As LC.Vocabulary = New LC.Vocabulary()
                For index As Integer = 0 To commonWordCount - 1
                    If (index = meaning.Length) Then index = (index Mod meaning.Length)

                    Dim symbol As String = allSymbol(0)
                    allSymbol.RemoveAt(0)
                    voca.AddCommonList(meaning(index), symbol)
                Next
                'add private list
                'for example a b c
                '            { }

                For index As Integer = 0 To privateWordCount - 1
                    If (index = meaning.Length) Then index = (index Mod meaning.Length)
                    Dim symbol As String = allSymbol(0)
                    allSymbol.RemoveAt(0)
                    voca.AddPrivateList(meaning(index), symbol)
                Next

                vocabularyList.Add(voca)
            Else 'the even playor
                'share same common list with odd playor(copy from previous playor's vocabulary)
                Dim voca As LC.Vocabulary = New LC.Vocabulary()
                Dim previousVoca As LC.Vocabulary = vocabularyList(vocabularyList.Count - 1)

                For Each item As String In previousVoca.Meanings
                    Dim commonWords As ICollection(Of String) = previousVoca.GetCommonList(item)


                    For Each symbol As String In commonWords
                        voca.AddCommonList(item, symbol)
                    Next

                Next
                'add private list
                For index As Integer = 0 To privateWordCount - 1
                    If (index = meaning.Length) Then index = (index Mod meaning.Length)
                    Dim symbol As String = allSymbol(0)
                    allSymbol.RemoveAt(0)
                    voca.AddPrivateList(meaning(index), symbol)
                Next
                vocabularyList.Add(voca)
            End If
        Next
        'print the vocabulary list
        Return vocabularyList
    End Function
    ''' <summary>
    ''' write to csv
    ''' </summary>
    ''' <param name="vocabularyList"></param>
    ''' <param name="output"></param>
    ''' <remarks></remarks>
    Public Shared Sub WriteToCsv(ByVal vocabularyList As List(Of LC.Vocabulary), ByVal output As Stream)
        Dim writer As StreamWriter = New System.IO.StreamWriter(output, System.Text.Encoding.UTF8)
        writer.WriteLine("ID,ListType,Meaning,Symbol")
        Dim sb As New StringBuilder()
        For index As Integer = 0 To vocabularyList.Count - 1
            'writer.WriteLine("voca id:" + index.ToString())
            'writer.WriteLine("  Common list:")
            'sb.Append(index.ToString())
            'sb.Append(",")
            'sb.Append("CommonList,")
            For Each key As String In vocabularyList(index).Meanings
                'writer.Write("      Meaning:" + key + ">")

                For Each symbol As String In vocabularyList(index).GetCommonList(key)
                    'writer.Write(symbol + ",")
                    sb.Append(index.ToString())
                    sb.Append(",CommonList,")
                    sb.Append(key)
                    sb.Append(",")
                    sb.Append(symbol)
                    writer.WriteLine(sb.ToString())
                    sb.Remove(0, sb.Length)
                Next
                'writer.WriteLine()
            Next
            'writer.WriteLine("  Private list:")
            For Each key As String In vocabularyList(index).Meanings
                'writer.Write("      Meaning:" + key + ">")

                For Each symbol As String In vocabularyList(index).GetPrivateList(key)
                    ' writer.Write(symbol + ",")
                    sb.Append(index.ToString())
                    sb.Append(",PrivateList,")
                    sb.Append(key)
                    sb.Append(",")
                    sb.Append(symbol)
                    writer.WriteLine(sb.ToString())
                    sb.Remove(0, sb.Length)
                Next
                'writer.WriteLine()
            Next
        Next
        writer.Close()
    End Sub

    Public Function ContainsSymbol(ByVal symbol As String) As Boolean

        Dim existsCommon As Boolean = ExistsInArray(Me.m_commlist, symbol)
        Dim existsPrivate As Boolean = ExistsInArray(Me.m_privateList, symbol)
        Return existsCommon Or existsPrivate
    End Function

    Private Function ExistsInArray(ByVal arr As String()(), ByVal symbol As String) As Boolean

        For i As Integer = 0 To arr.Length - 1
            If arr(i) Is Nothing Then Continue For
            For j As Integer = 0 To arr(i).Length - 1
                If arr(i)(j) = symbol Then
                    Return True
                End If
            Next
        Next
        Return False
    End Function


End Class
