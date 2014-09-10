'锘?Programmed by Jeffrey Kirchner and Your Name Here
'kirchner@chapman.edu/jkirchner@gmail.com
'Economic Science Institute, Chapman University 2008-2010 漏

Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports LC

Module Game
#Region " General Variables "
    Public playerList() As Player                  'array of players
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
    'Public numberofGroups As Integer         'number of groups = number of Players / 2
    Public groupList() As Group 'each group contains 2 Players
    Public ls As Decimal           'language similarity
    Public cooperateMatrix As LC.ScoreMatrix 'the score matrix for cooperate game
    Public competeMatrix As LC.ScoreMatrix 'the score matrix for compete game
    Public meanings() As String ' 
    Public initialNumberofWords As Integer 'initial number of words in vocabulary
    Public numberOfRound As Integer
    Public initScoreOfPlayer As Integer

    Public allSymbols As List(Of String)
    Public allVocabulary As List(Of Vocabulary)
    Private PlayerIDSeed As Integer = 1
    Private syncObj As Object = String.Empty
    Private currentRound As Integer
    Private Matrixes As ScoreMatrix()
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

    Public ReadOnly Property CurrentMatrix() As ScoreMatrix
        Get
            Return Game.Matrixes(Game.CurrentRoundNumber - 1)
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
    Public Function GetNewPlayerId() As String
        SyncLock syncObj
            Dim newID As String = PlayerIDSeed.ToString()
            PlayerIDSeed += 1
            Return newID
        End SyncLock
    End Function


#End Region

    ''' <summary>
    ''' every 2 Player into 1 group(game) 
    ''' </summary>
    ''' <param name="playerList"></param>
    ''' <param name="grouplist"></param>
    ''' <param name="vocabularyList"></param>
    ''' <param name="iniScore"></param>
    ''' <remarks></remarks>
    Public Sub MakeGroups(ByVal sockCol As WinsockCollection)
        Dim groupIndex As Integer = 0

        For index As Integer = 0 To Game.playerList.Length - 1
            If (index Mod 2 = 0) Then
                Dim p() As Player = New Player(1) {playerList(index), playerList(index + 1)}
                groupList(groupIndex) = New Group(p)
                groupList(groupIndex).ScoreMatrix = Game.CurrentMatrix
                groupList(groupIndex).WinsockCollection = sockCol
                groupIndex += 1
            End If
            playerList(index).Group = groupList(groupIndex - 1)
            playerList(index).Score = Game.initScoreOfPlayer
            playerList(index).Vocabulary = Game.allVocabulary(index)
        Next

    End Sub

    ''' <summary>
    ''' signal both Player to begin
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Begin()
        For i As Integer = 0 To Game.groupList.Length - 1
            If TypeOf Game.groupList(i).Status Is StatusConnected Then
                'Game.groupList(i).currentRound = 1
                For index As Integer = 0 To Game.groupList(i).Players.Length - 1
                    Game.groupList(i).Players(index).DisplayInstruction(Game.groupList(i).WinsockCollection)
                Next
            Else
                Throw New Exception("Game already started")
            End If
        Next
    End Sub

    ''' <summary>
    ''' scramble and reassign the vocabulary for new round 
    ''' </summary>
    Public Sub NextRound()
        'TODO 
        'backup message
        Game.BackupMessage()
        currentRound += 1
        If currentRound > 1 Then
            're-assign the vocabulary 
            'group(i) 's vocabulary assign to group(i-1) 
            Dim tempVocalist As Tuple(Of Vocabulary, Vocabulary)()
            tempVocalist = New Tuple(Of Vocabulary, Vocabulary)(groupList.Length - 1) {}
            For index As Integer = 0 To groupList.Length - 1
                Dim tempIdx As Integer = CInt(IIf(index - 1 < 0, groupList.Length - 1, index - 1))
                tempVocalist(tempIdx) = New Tuple(Of Vocabulary, Vocabulary)(groupList(index).Players(0).Vocabulary, groupList(index).Players(1).Vocabulary)
            Next
            ScrambleVocabulary(tempVocalist)
            're assign the scrambled vocabulary to players

        End If
        For index As Integer = 0 To groupList.Length - 1
            groupList(index).ScoreMatrix = Game.Matrixes(currentRound - 1)
            groupList(index).Status = New StatusNewRound(groupList(index))
            groupList(index).NewRound()
        Next
    End Sub

    Private Sub ScrambleVocabulary(ByVal vocalist As Tuple(Of Vocabulary, Vocabulary)())
        'TODO
    End Sub

    Public Sub RegisterPlayer(ByVal playerList As Player(), ByVal ID As String, ByVal ClientIP As String)

        For index As Integer = 0 To playerList.Length
            If playerList(index) Is Nothing Then
                playerList(index) = New Player()
                playerList(index).ID = ID
                playerList(index).myIPAddress = ClientIP
                Return
            End If
        Next
    End Sub


    Public Sub takeMessage(ByVal msg As MessageBag)
        Try
            Dim Player As Player = FindPlayerById(Game.playerList, (msg.clientID))
            If (Player Is Nothing) Then Return

            Player.Group.ProcessMsg(msg, Player)

        Catch ex As Exception
            'appEventLog_Write("error takeMessage: " & sinstr & " : ", ex)
            appEventLog_Write("error takeMessage: " & ex.ToString())
        End Try

    End Sub

    Function FindPlayerById(ByVal playerList() As Player, ByVal Id As String) As Player

        For index As Integer = 0 To playerList.Length - 1
            If Not playerList(index) Is Nothing AndAlso playerList(index).ID = Id Then
                Return playerList(index)
            End If
        Next

        Return Nothing
    End Function


    Public Sub loadParameters()
        Try
            'load parameters from server.ini

            numberOfPlayers = Convert.ToInt32(getINI(sfile, "gameSettings", "numberOfPlayers"))
            numberOfRound = Convert.ToInt32(getINI(sfile, "gameSettings", "numberOfRound"))
            initScoreOfPlayer = Convert.ToInt32(getINI(sfile, "gameSettings", "iniScore"))
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
                playerList = New Player(numberOfPlayers - 1) {} 'kyle
            Else
                Array.Resize(playerList, numberOfPlayers)
            End If
            If groupList Is Nothing Then
                groupList = New Group(Convert.ToInt32((numberOfPlayers) / 2) - 1) {}
            Else
                Array.Resize(groupList, Convert.ToInt32((numberOfPlayers) / 2))
            End If
            'read all meaning
            Dim meaningStr As String = getINI(sfile, "gameSettings", "meanings")
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
            Game.Matrixes = ScoreMatrix.ReadFromFile(Application.StartupPath + "\\scorematrix.csv", numberOfRound, Game.meanings)
            
            currentRound = 1

            'Dim gametypeStr As String = getINI(sfile, "gameSettings", "gametype")
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

   

    Private Sub BackupMessage()
        'TODO Throw New NotImplementedException
        Dim writer As New StreamWriter(IO.File.OpenWrite("output.csv"), System.Text.Encoding.UTF8)
        If Game.CurrentRoundNumber = 1 Then
            writer.BaseStream.SetLength(0)
            'Write header
            writer.Write("Round,GroupID,GameType,LS(initial),LS(after),PlayerID,NumOfLean,NumOfInvent,cost,Phase1Decisoin,Phase2Decision,score")
        End If
        For gIndex As Integer = 0 To Game.groupList.Length - 1
            Dim g As Group = Game.groupList(gIndex)
            Dim gId As String = gIndex.ToString()
            For pindex As Integer = 0 To g.MsgFromAllPlayers.Length - 1
                Dim msgs As LC.MessageBag() = g.MsgFromAllPlayers(pindex).ToArray()
                g.MsgFromAllPlayers(pindex).Clear()
                Dim p As Player = g.Players(pindex)
                'Dim p1d1 As String = g.Players(0).Phase1_decision
                'Write To Message File
                ' LC.ModuleEventLog.WriteLCMessage(msgs)
                writer.Write(Game.CurrentRoundNumber.ToString() & "," & _
                     gId.ToString() & "," & _
                     g.ScoreMatrix.GameType & "," & _
                     p.InitialLS.ToString() & "," & _
                p.Vocabulary.LS.ToString() & "," & _
p.ID & "," & _
p.Num_of_learn.ToString() & "," & _
p.Num_of_invent.ToString() & "," & _
p.Cost & "," & _
p.Phase1_decision & "," & _
p.Phase2_decision & "," & _
p.Score.ToString())
            Next
        Next

    End Sub



End Module
