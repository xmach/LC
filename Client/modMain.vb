'Programmed by Jeffrey Kirchner and Your Name Here
'kirchner@chapman.edu/jkirchner@gmail.com
'Economic Science Institute, Chapman University 2008-2010 ?

Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Text
Imports LC
Module modMain
    Public sfile As String
    Public WithEvents wskClient As Winsock

    Public inumber As Integer                  'client ID number
    Public numberOfPlayers As Integer          'number of total players in experiment
    Public currentPeriod As Integer            'current period of experiment
    Public serverIPAddress As String               'IP address of server 
    Public serverPortNumber As String              'port number of server 
    Public localPortNumber As String 'local port
    Public exchangeRate As Integer             'client's exchange rate
    'Public currentInstruction As Integer       'current instruction
    Public numberOfPeriods As Integer          'number of periods  
    Public showInstructions As Boolean         'wether to show instructions to subject


    Public closing As Boolean = False

    'kyle
    Public m_meanings As String()
    Public ReadOnly mainForm As New frmMain()
    Private m_status As ClientStatusBase = New StatusNotConnected()

    Public Property GameStatus() As ClientStatusBase
        Get
            Return m_status
        End Get
        Set(ByVal value As ClientStatusBase)
            m_status = value
        End Set
    End Property
#Region " Winsock Code "
    Private Sub wskClient_DataArrival(ByVal sender As Object, ByVal e As WinsockDataArrivalEventArgs) Handles wskClient.DataArrival
        Try
            Dim buf As String = Nothing
            CType(sender, Winsock).Get(buf)

            Dim msgtokens() As String = buf.Split("#")
            Dim i As Integer

            appEventLog_Write("data arrival: " & buf)

            For i = 1 To msgtokens.Length - 1
                If String.IsNullOrEmpty(msgtokens(i - 1)) Then
                    Continue For
                End If
                'takeMessage(msgtokens(i - 1))
                Dim msgbag As LC.MessageBag = LC.XmlHelper.XmlDeserialize(Of LC.MessageBag)(msgtokens(i - 1), Encoding.UTF8)

                GameStatus.ReceiveMsg(msgbag)
            Next

        Catch ex As Exception
            appEventLog_Write("error wskClient_DataArrival:", ex)
        End Try
    End Sub

   


    Private Sub wskClient_ErrorReceived(ByVal sender As System.Object, ByVal e As WinsockErrorEventArgs) Handles wskClient.ErrorReceived
        ' Log("Error: " & e.Message)
    End Sub

    Private Sub wskClient_StateChanged(ByVal sender As Object, ByVal e As WinsockStateChangingEventArgs) Handles wskClient.StateChanged
        Try
            'appEventLog_Write("state changed")

            If e.New_State = WinsockStates.Closed Then
                frmConnect.Show()
            End If
        Catch ex As Exception
            appEventLog_Write("error wskClient_StateChanged:", ex)
        End Try

    End Sub

    Public Sub connect()
        Try

            wskClient = New Winsock
            wskClient.BufferSize = 8192
            wskClient.LegacySupport = False
            wskClient.LocalPort = 8080
            wskClient.MaxPendingConnections = 1
            wskClient.Protocol = WinsockProtocols.Tcp
            wskClient.RemotePort = serverPortNumber
            wskClient.RemoteServer = serverIPAddress
            wskClient.SynchronizingObject = frmMain

            wskClient.Connect()
            GameStatus = New StatusConnected()
        Catch e As Exception
            'frmMain.Hide()
            MessageBox.Show(e.Message)
            frmConnect.Show()
            GameStatus = New StatusNotConnected()
        End Try
    End Sub

#End Region

#Region " General Functions "
    Public Sub main()
        testDesionScreen()
        
        ModuleEventLog.fileNamePrefix = "ClientLog"
        AppEventLog_Init()
        appEventLog_Write("Begin")

        ToggleScreenSaverActive(False)

        Application.EnableVisualStyles()
        Application.Run(mainForm)

        ToggleScreenSaverActive(True)

        appEventLog_Write("End")
        AppEventLog_Close()
    End Sub
    Private Sub testDesionScreen()
        Dim f As New frmDecision
        f.IsPhase2 = False
        f.ScoreMatrix = New ScoreMatrix()
        Dim meanings As String() = New String() {"A", "B", "C"}
        f.ScoreMatrix.ReadFromFile("D:\Project\LC\Server\bin\Debug\server.ini", meanings, "cooperatematrix")
        f.Meanings = meanings
        f.ShowDialog()
    End Sub
    'test frmLangChange
    Private Sub testLangeScreen()
        Dim vo As New Vocabulary()
        vo.Meanings = New List(Of String)(New String() {"A", "B", "C"})
        vo.AddCommonList("A", "*")
        vo.AddPrivateList("B", "()")
        vo.AddCommonList("C", "$")
        Dim f As New frmLangChange()
        f.Vocabulary = vo
        f.Meaning = vo.Meanings.ToArray()
        f.Symbols = New String() {"*", "()", "$"}
        f.ShowDialog()
    End Sub


    Public Sub setID(ByVal sinstr As String)
        Try
            'appEventLog_Write("set id :" & sinstr)

            Dim msgtokens() As String

            msgtokens = sinstr.Split(";")

            inumber = msgtokens(0)

            appEventLog_Write("Client# = " & inumber)

        Catch ex As Exception
            appEventLog_Write("error setID:", ex)
        End Try
    End Sub


    'Public Sub sendIPAddress(ByVal sinstr As String)
    '    Try
    '        'appEventLog_Write("send ip :" & sinstr)

    '        With frmMain
    '            'Dim outstr As String

    '            inumber = sinstr

    '            appEventLog_Write("Client# = " & inumber)

    '            'outstr = SystemInformation.ComputerName
    '            '.wskClient.Send("03", outstr)
    '        End With
    '    Catch ex As Exception
    '        appEventLog_Write("error sendIPAddress:", ex)
    '    End Try
    'End Sub

    'Public Function numberSuffix(ByVal sinstr As Integer) As String
    '    numberSuffix = sinstr
    '    Try
    '        Select Case sinstr
    '            Case 1
    '                numberSuffix = sinstr & "st"
    '            Case 2
    '                numberSuffix = sinstr & "nd"
    '            Case 3
    '                numberSuffix = sinstr & "rd"
    '            Case Is >= 4
    '                numberSuffix = sinstr & "th"
    '        End Select
    '    Catch ex As Exception
    '        appEventLog_Write("error numberSuffix:", ex)
    '    End Try
    'End Function
#End Region

    'Private Sub takeMessage(ByVal sinstr As String)
    '    Try
    '        'take message from server
    '        'msgtokens(0) has type of message sent, having different types of messages allows you to send different formats for different actions.
    '        'msgtokens(1) has the semicolon delimited data that is to be parsed and acted upon.  

    '        'Dim msgtokens() As String
    '        'msgtokens = sinstr.Split("|")
    '        Dim mTypeStr As String = sinstr 'msgtokens(0)
    '        Dim msgbag As LC.MessageBag = LC.XmlHelper.XmlDeserialize(Of LC.MessageBag)(sinstr, Encoding.UTF8)
    '        'Dim mType As LC.MsgType = System.Enum.Parse(GetType(LC.MsgType), mTypeStr)
    '        GameStatus.ReceiveMsg(msgbag)
    '        'Select Case msgtokens(0) 'case statement to handle each of the different types of messages

    '        'End Select
    '    Catch ex As Exception
    '        appEventLog_Write("error takeMessage:", ex)
    '    End Try

    'End Sub



    'Public Sub begin(ByVal sinstr As String)
    '    With frmMain
    '        Try
    '            'server has signaled client to start experiment

    '            'parse incoming data string
    '            'Dim msgtokens() As String = sinstr.Split(";")

    '            'If showInstructions Then
    '            '    'frmInstructions.Show()
    '            '    frmInstructions.Location = New System.Drawing.Point(instructionX, instructionY)
    '            'End If

    '            '.Location = New System.Drawing.Point(windowX, windowY)
    '        Catch ex As Exception
    '            appEventLog_Write("error begin:", ex)
    '        End Try

    '    End With
    'End Sub

    'Public Sub endGame(ByVal sinstr As String)
    '    Try
    '        'end the experiment
    '        With frmMain

    '        End With
    '    Catch ex As Exception
    '        appEventLog_Write("error endGame:", ex)
    '    End Try
    'End Sub

    'Public Sub endEarly(ByVal sinstr As String)
    '    Try
    '        'end experiment early
    '        Dim msgtokens() As String
    '        msgtokens = sinstr.Split(";")

    '        numberOfPeriods = msgtokens(0)
    '    Catch ex As Exception
    '        appEventLog_Write("error endEarly:", ex)
    '    End Try
    'End Sub

    'Public Sub periodResults(ByVal sinstr As String)
    '    Try
    '        'show the results at end of period
    '        With frmMain

    '            Dim msgtokens() As String = Split(sinstr, ";")
    '            Dim nextToken As Integer = 0

    '        End With
    '    Catch ex As Exception
    '        appEventLog_Write("error periodResults:", ex)
    '    End Try
    'End Sub

    'Public Sub finishedInstructions()
    '    Try
    '        With frmMain
    '            'close the instructions and start experiment

    '            frmInstructions.Close()
    '            showInstructions = False
    '        End With
    '    Catch ex As Exception
    '        appEventLog_Write("error :", ex)
    '    End Try
    'End Sub
End Module
