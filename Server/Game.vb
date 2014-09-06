'锘?Programmed by Jeffrey Kirchner and Your Name Here
'kirchner@chapman.edu/jkirchner@gmail.com
'Economic Science Institute, Chapman University 2008-2010 漏

Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports LC

Module Game
#Region " General Variables "
    Public playerList() As Playor                  'array of players
    'Public playerCount As Integer                    'number of players connected
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
    Public groupList() As Group 'each group contains 2 playors
    Public ls As Decimal           'language similarity
    Public cooperateMatrix As LC.ScoreMatrix 'the score matrix for cooperate game
    Public competeMatrix As LC.ScoreMatrix 'the score matrix for compete game
    Public meanings() As String ' 
    Public initialNumberofWords As Integer 'initial number of words in vocabulary
    Public numberOfRound As Integer
    Public initScoreOfPlayor As Integer

    Public allSymbols As List(Of String)
    Public allVocabulary As List(Of Vocabulary)
    Private playorIDSeed As Integer = 1
    Private syncObj As Object = String.Empty
    Private currentRound As Integer
#End Region

    Public ReadOnly Property ReadyForNewRound() As Boolean
        Get
            Dim allGroupFinishedARound = True
            For index As Integer = 0 To groupList.Length - 1
                If Not TypeOf groupList(index).Status Is StatusPhase2DecisionMade Then
                    allGroupFinishedARound = False
                    Exit For
                End If
            Next
            Return allGroupFinishedARound
        End Get
    End Property

    Public ReadOnly Property CurrentRoundNumber() As Integer
        Get
            Return currentRound
        End Get
    End Property

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
    Public Function GetNewPlayorId() As String
        SyncLock syncObj
            Dim newID As String = playorIDSeed.ToString()
            playorIDSeed += 1
            Return newID
        End SyncLock
    End Function


#End Region
    ''' <summary>
    ''' scramble and reassign the vocabulary for new round 
    ''' </summary>
    Public Sub NextRound()
        'TODO 
        currentRound += 1
        If currentRound > 1 Then
            're assign the vocabulary 
            'group(i) 's vocabulary assign to group(i-1) 
            Dim tempVocalist As Tuple(Of Vocabulary, Vocabulary)()
            tempVocalist = New Tuple(Of Vocabulary, Vocabulary)(groupList.Length - 1) {}
            For index As Integer = 0 To groupList.Length - 1
                Dim tempIdx As Integer = CInt(IIf(index - 1 < 0, groupList.Length - 1, index - 1))

                tempVocalist(tempIdx) = New Tuple(Of Vocabulary, Vocabulary)(groupList(index).Playors(0).Vocabulary, groupList(index).Playors(1).Vocabulary)

            Next
            ScrambleVocabulary(tempVocalist)
        End If
        For index As Integer = 0 To groupList.Length - 1
            groupList(index).Status = New StatusNewRound(groupList(index))
            groupList(index).NewRound()
        Next
    End Sub

    Private Sub ScrambleVocabulary(ByVal vocalist As Tuple(Of Vocabulary, Vocabulary)())
        'TODO
    End Sub

    Public Sub RegisterPlayor(ByVal playerList As Playor(), ByVal ID As String, ByVal ClientIP As String)

        For index As Integer = 0 To playerList.Length
            If playerList(index) Is Nothing Then
                playerList(index) = New Playor()
                playerList(index).ID = ID
                playerList(index).myIPAddress = ClientIP
                Return
            End If
        Next
    End Sub


    Public Sub takeMessage(ByVal msg As MessageBag)
        Try
            Dim playor As Playor = FindPlayorById(Game.playerList, (msg.clientID))
            If (playor Is Nothing) Then Return

            playor.Group.ProcessMsg(msg, playor)

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

            numberOfPlayers = Convert.ToInt32(getINI(sfile, "gameSettings", "numberOfPlayers"))
            numberOfRound = Convert.ToInt32(getINI(sfile, "gameSettings", "numberOfRound"))
            initScoreOfPlayor = Convert.ToInt32(getINI(sfile, "gameSettings", "iniScore"))
            portNumber = Convert.ToInt32(getINI(sfile, "gameSettings", "port"))
            Dim lsStr As String = getINI(sfile, "gameSettings", "ls")
            If (lsStr <> "?") Then
                ls = Decimal.Parse(lsStr)
                If ls < 0 OrElse ls > 1 Then
                    Throw New Exception("Game parameter error,ls(" + ls.ToString() + ") should between 0 and 1")
                End If
            End If

            '
            If playerList Is Nothing Then
                playerList = New Playor(numberOfPlayers - 1) {} 'kyle
            Else
                Array.Resize(playerList, numberOfPlayers)
            End If
            If groupList Is Nothing Then
                groupList = New Group(Convert.ToInt32((numberOfPlayers) / 2) - 1) {}
            Else
                Array.Resize(groupList, Convert.ToInt32((numberOfPlayers) / 2))
            End If
            'read all meaning
            Dim meaningStr As String = getINI(sfile, "meanings", "all")
            If meaningStr = "?" Then
                Throw New Exception("meanings not found in INI file")
            End If
            Game.meanings = meaningStr.TrimEnd(","c).Split(","c)

            'initial vocabulary
            Dim numberOfWordStr As String = getINI(sfile, "gameSettings", "ininumberofwords")
            If numberOfWordStr = "?" Then
                Throw New Exception("ininumberofwords not found in INI file")
            End If
            Game.initialNumberofWords = Integer.Parse(numberOfWordStr)

            allSymbols = Vocabulary.ReadSymbolFromFile(Application.StartupPath + "\\symbols.txt")
            allVocabulary = Vocabulary.GenerateVocabulary(numberOfPlayers, allSymbols, ls, initialNumberofWords, meanings)
            
            'output the initial vobalary
            Vocabulary.WriteToCsv(allVocabulary, File.Create(Application.StartupPath + "\\iniVocabulary.csv", 10000))

            'initial score matrix
            Game.cooperateMatrix = New ScoreMatrix()
            cooperateMatrix.ReadFromFile(sfile, Game.meanings, "cooperatematrix")

            Game.competeMatrix = New LC.ScoreMatrix()
            competeMatrix.ReadFromFile(sfile, Game.meanings, "competematrix")
            frmScoreMatrix.cooperateMatrix = cooperateMatrix
            frmScoreMatrix.competeMatrix = competeMatrix

            frmScoreMatrix.meanings = meanings
            currentRound = 1
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

    'Public Sub updateInstructionDisplay(ByVal sinstr As String, ByVal index As Integer)
    '    Try
    '        With frmServer
    '            Dim msgtokens() As String = sinstr.Split(";"c)
    '            Dim nextToken As Integer = 0

    '            .DataGridView1.Rows(index - 1).Cells(2).Value = "Page " & msgtokens(nextToken)
    '            nextToken += 1
    '        End With
    '    Catch ex As Exception
    '        appEventLog_Write("error :", ex)
    '    End Try
    'End Sub


End Module
