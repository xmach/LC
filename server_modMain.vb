'锘?Programmed by Jeffrey Kirchner and Your Name Here
'kirchner@chapman.edu/jkirchner@gmail.com
'Economic Science Institute, Chapman University 2008-2010 漏

Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports LC

Module modMain
#Region " General Variables "
    Public playerList() As LC.Playor                  'array of players
    Public playerCount As Integer                    'number of players connected
    Public numberOfPlayers As Integer                'number of desired players
    Public sfile As String                           'location of intialization file  
    Public checkin As Integer                        'global counter 
    'Public connectionCount As Integer                'total number of connections made since server start 
    Public portNumber As Integer                     'port number sockect traffic is operation on 
    Public summaryDf As StreamWriter                 'data file
    Public frmServer As New frmMain                  'main form 
    Public filename As String                        'location of data file
    Public filename2 As String                       'location of data file
    Public showInstructions As Boolean               'show client instructions  
    'Public currentInstruction As Integer             'current page of instructions 
    'Public numberofGroups As Integer         'number of groups = number of playors / 2
    Public groupList() As LC.Group 'each group contains 2 playors
    Public ls As Decimal           'language similarity
    Public cooperateMatrix As LC.ScoreMatrix 'the score matrix for cooperate game
    Public competeMatrix As LC.ScoreMatrix 'the score matrix for compete game
    Public meanings() As String ' 
    Public initialNumberofWords As Integer 'initial number of words in vocabulary
    Public numberOfRound As Integer
    Public initScoreOfPlayor As Integer

    Public allSymbols As List(Of String)
    Public allVocabulary As List(Of Vocabulary)

#End Region

    'global variables here
    'Public numberOfPeriods As Integer     'number of periods
    'Public currentPeriod As Integer       'current period 

    'Public instructionX As Integer            'start up locations of windows
    'Public instructionY As Integer
    'Public windowX As Integer
    'Public windowY As Integer

#Region " General Functions "
    Public Sub main(ByVal args() As String)
        'connectionCount = 0
        ModuleEventLog.fileNamePrefix = "ServerLog"
        AppEventLog_Init()
        appEventLog_Write("Load")

        ToggleScreenSaverActive(False)

        Application.EnableVisualStyles()
        Application.Run(frmServer)

        ToggleScreenSaverActive(True)

        appEventLog_Write("Exit")
        AppEventLog_Close()
    End Sub

    'Public Sub takeIP(ByVal sinstr As String, ByVal index As Integer)
    '    Try
    '        playerList(index).myIPAddress = sinstr
    '    Catch ex As Exception
    '        appEventLog_Write("error takeIP:", ex)
    '    End Try
    'End Sub

    Public Function roundUp(ByVal value As Double) As Integer
        Try
            Dim msgtokens() As String

            If InStr(CStr(value), ".") Then
                msgtokens = CStr(value).Split(".")

                roundUp = msgtokens(0)
                roundUp += 1
            Else
                roundUp = value
            End If
        Catch ex As Exception
            Return CInt(value)
            appEventLog_Write("error roundUp:", ex)
        End Try
    End Function

    'Public Function getMyColor(ByVal index As Integer) As Color
    '    Try
    '        'appEventLog_Write("get color")

    '        Select Case index
    '            Case 1
    '                getMyColor = Color.Blue
    '            Case 2
    '                getMyColor = Color.Red
    '            Case 3
    '                getMyColor = Color.Teal
    '            Case 4
    '                getMyColor = Color.Green
    '            Case 5
    '                getMyColor = Color.Purple
    '            Case 6
    '                getMyColor = Color.Orange
    '            Case 7
    '                getMyColor = Color.Brown
    '            Case 8
    '                getMyColor = Color.Gray
    '        End Select
    '    Catch ex As Exception
    '        appEventLog_Write("error getMyColor:", ex)
    '    End Try
    'End Function

    'Public Function colorToId(ByVal str As String) As Integer
    '    Try
    '        Dim i As Integer

    '        'appEventLog_Write("color to id :" & str)

    '        For i = 1 To numberOfPlayers
    '            If str = playerList(i).colorName Then
    '                colorToId = i
    '                Exit Function
    '            End If
    '        Next

    '        colorToId = -1
    '    Catch ex As Exception
    '        Return 0
    '        appEventLog_Write("error colorToId:", ex)
    '    End Try
    'End Function
#End Region

    Public Sub takeMessage(ByVal msg As MessageBag)
        'when a message is received from a client it is parsed here
        'msgtokens(1) has type of message sent, having different types of messages allows you to send different formats for different actions.
        'msgtokens(2) has the semicolon delimited data that is to be parsed and acted upon.  
        'index has the client ID that sent the data.  Client ID is assigned by connection order, indexed from 1.

        Try
            Dim playor As Playor = FindPlayorById(modMain.playerList, (msg.clientID))
            If (playor Is Nothing) Then Return

            playor.ProcessMsg(msg)
            'With frmServer
            '    Dim msgtokens() As String
            '    Dim outstr As String

            '    msgtokens = sinstr.Split("|")

            '    Dim index As Integer
            '    index = msgtokens(0)

            '    Application.DoEvents()

            '    Select Case msgtokens(1) 'case statement to handle each of the different types of messages
            '        Case "01"
            '            updateInstructionDisplay(msgtokens(2), index)
            '        Case "02"
            '            checkin += 1
            '            .DataGridView1.Rows(index - 1).Cells(2).Value = "Waiting"

            '            If checkin = numberOfPlayers Then
            '                showInstructions = False
            '                checkin = 0

            '                MessageBox.Show("Begin Game.", "Start", MessageBoxButtons.OK, MessageBoxIcon.Information)

            '                For i As Integer = 1 To numberOfPlayers
            '                    'TODO playerList(i).finishedInstructions()
            '                    .DataGridView1.Rows(i - 1).Cells(2).Value = "Playing"
            '                Next i

            '            End If
            '        Case "03"
            '            takeIP(msgtokens(2), index)
            '        Case "04"

            '        Case "05"

            '        Case "06"

            '        Case "07"
            '            'TODO playerList(index).takeName(msgtokens(2))
            '            checkin += 1
            '            If checkin = numberOfPlayers Then
            '                outstr = "Name,Earnings,"
            '                summaryDf.WriteLine(outstr)
            '                For i As Integer = 1 To numberOfPlayers

            '                    outstr = .DataGridView1.Rows(i - 1).Cells(1).Value & ","
            '                    outstr &= .DataGridView1.Rows(i - 1).Cells(3).Value & ","
            '                    summaryDf.WriteLine(outstr)
            '                Next

            '                summaryDf.Close()
            '            End If
            '        Case "08"

            '        Case "09"

            '        Case "10"

            '        Case "11"

            '        Case "12"

            '        Case "13"


            '    End Select

            '    Application.DoEvents()

            'End With
            'all subs/functions should have an error trap
        Catch ex As Exception
            'appEventLog_Write("error takeMessage: " & sinstr & " : ", ex)
            appEventLog_Write("error takeMessage: " & ex.ToString())
        End Try

    End Sub

    Function FindPlayorById(ByVal playorList() As Playor, ByVal Id As String) As Playor

        For index As Integer = 0 To playorList.Length - 1
            If Not playorList(index) Is Nothing AndAlso playorList(index).ID = Id Then
                Return playorList(index)
            End If
        Next

        Return Nothing
    End Function

   
    Public Sub loadParameters()
        Try
            'load parameters from server.ini

            numberOfPlayers = getINI(sfile, "gameSettings", "numberOfPlayers")
            numberOfRound = getINI(sfile, "gameSettings", "numberOfRound")
            initScoreOfPlayor = getINI(sfile, "gameSettings", "iniScore")
            portNumber = getINI(sfile, "gameSettings", "port")
            Dim lsStr As String = getINI(sfile, "gameSettings", "ls")
            If (lsStr <> "?") Then
                ls = Decimal.Parse(lsStr)
                If ls < 0 OrElse ls > 1 Then
                    Throw New Exception("Game parameter error,ls(" + ls.ToString() + ") should between 0 and 1")
                End If
            End If

            '
            If playerList Is Nothing Then
                playerList = New LC.Playor(numberOfPlayers - 1) {} 'kyle
            Else
                Array.Resize(playerList, numberOfPlayers)
            End If
            If groupList Is Nothing Then
                groupList = New LC.Group(((numberOfPlayers) / 2) - 1) {}
            Else
                Array.Resize(groupList, (numberOfPlayers) / 2)
            End If
            'read all meaning
            Dim meaningStr As String = getINI(sfile, "meanings", "all")
            If meaningStr = "?" Then
                Throw New Exception("meanings not found in INI file")
            End If
            modMain.meanings = meaningStr.TrimEnd(","c).Split(",")

            'initial vocabulary
            Dim numberOfWordStr As String = getINI(sfile, "gameSettings", "ininumberofwords")
            If numberOfWordStr = "?" Then
                Throw New Exception("ininumberofwords not found in INI file")
            End If
            modMain.initialNumberofWords = Integer.Parse(numberOfWordStr)

            allSymbols = Vocabulary.ReadSymbolFromFile(Application.StartupPath + "\\symbols.txt")
            allVocabulary = Vocabulary.GenerateVocabulary(numberOfPlayers, allSymbols, ls, initialNumberofWords, meanings)

            'output the initial vobalary
            Vocabulary.WriteToCsv(allVocabulary, File.Create(Application.StartupPath + "\\iniVocabulary.csv", 10000))

            'initial score matrix
            modMain.cooperateMatrix = New ScoreMatrix()
            cooperateMatrix.ReadFromFile(sfile, modMain.meanings, "cooperatematrix")

            modMain.competeMatrix = New LC.ScoreMatrix()
            competeMatrix.ReadFromFile(sfile, modMain.meanings, "competematrix")
            frmScoreMatrix.cooperateMatrix = cooperateMatrix
            frmScoreMatrix.competeMatrix = competeMatrix

            frmScoreMatrix.meanings = meanings
            'frmScoreMatrix.ShowDialog()
        Catch ex As Exception
            appEventLog_Write("error loadParameters:", ex)
        End Try
    End Sub

    Public Sub writeSummaryData()
        Try
            'write data to output file
            Dim outstr As String = ""

            summaryDf.WriteLine(outstr)
        Catch ex As Exception
            appEventLog_Write("error write summary data:", ex)
        End Try
    End Sub

    Public Sub updateInstructionDisplay(ByVal sinstr As String, ByVal index As Integer)
        Try
            With frmServer
                Dim msgtokens() As String = sinstr.Split(";")
                Dim nextToken As Integer = 0

                .DataGridView1.Rows(index - 1).Cells(2).Value = "Page " & msgtokens(nextToken)
                nextToken += 1
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    
End Module
