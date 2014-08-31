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

    'Public instructionX As Integer            'start up locations of windows
    'Public instructionY As Integer
    'Public windowX As Integer
    'Public windowY As Integer

    'kyle
    Private m_status As ClientStatusBase = New StatusNotConnected()
    Public m_meanings As String()
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
                takeMessage(msgtokens(i - 1))
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
        ModuleEventLog.fileNamePrefix = "ClientLog"
        AppEventLog_Init()
        appEventLog_Write("Begin")

        ToggleScreenSaverActive(False)

        Application.EnableVisualStyles()
        Application.Run(frmMain)

        ToggleScreenSaverActive(True)

        appEventLog_Write("End")
        AppEventLog_Close()
    End Sub

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

    'Public Function timeConversion(ByVal sec As Integer) As String
    '    Try
    '        'appEventLog_Write("time conversion :" & sec)
    '        timeConversion = Format((sec \ 60), "00") & ":" & Format((sec Mod 60), "00")
    '    Catch ex As Exception
    '        appEventLog_Write("error timeConversion:", ex)
    '        timeConversion = ""
    '    End Try
    'End Function

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


    Public Sub sendIPAddress(ByVal sinstr As String)
        Try
            'appEventLog_Write("send ip :" & sinstr)

            With frmMain
                'Dim outstr As String

                inumber = sinstr

                appEventLog_Write("Client# = " & inumber)

                'outstr = SystemInformation.ComputerName
                '.wskClient.Send("03", outstr)
            End With
        Catch ex As Exception
            appEventLog_Write("error sendIPAddress:", ex)
        End Try
    End Sub

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

    Private Sub takeMessage(ByVal sinstr As String)
        Try
            'take message from server
            'msgtokens(0) has type of message sent, having different types of messages allows you to send different formats for different actions.
            'msgtokens(1) has the semicolon delimited data that is to be parsed and acted upon.  

            'Dim msgtokens() As String
            'msgtokens = sinstr.Split("|")
            Dim mTypeStr As String = sinstr 'msgtokens(0)
            Dim msgbag As LC.MessageBag = LC.XmlHelper.XmlDeserialize(Of LC.MessageBag)(sinstr, Encoding.UTF8)
            'Dim mType As LC.MsgType = System.Enum.Parse(GetType(LC.MsgType), mTypeStr)
            GameStatus.ReceiveMsg(msgbag)
            'Select Case msgtokens(0) 'case statement to handle each of the different types of messages

            'End Select
        Catch ex As Exception
            appEventLog_Write("error takeMessage:", ex)
        End Try

    End Sub



    Public Sub begin(ByVal sinstr As String)
        With frmMain
            Try
                'server has signaled client to start experiment

                'parse incoming data string
                'Dim msgtokens() As String = sinstr.Split(";")

                'If showInstructions Then
                '    'frmInstructions.Show()
                '    frmInstructions.Location = New System.Drawing.Point(instructionX, instructionY)
                'End If

                '.Location = New System.Drawing.Point(windowX, windowY)
            Catch ex As Exception
                appEventLog_Write("error begin:", ex)
            End Try

        End With
    End Sub

    Public Sub endGame(ByVal sinstr As String)
        Try
            'end the experiment
            With frmMain

            End With
        Catch ex As Exception
            appEventLog_Write("error endGame:", ex)
        End Try
    End Sub

    Public Sub endEarly(ByVal sinstr As String)
        Try
            'end experiment early
            Dim msgtokens() As String
            msgtokens = sinstr.Split(";")

            numberOfPeriods = msgtokens(0)
        Catch ex As Exception
            appEventLog_Write("error endEarly:", ex)
        End Try
    End Sub

    Public Sub periodResults(ByVal sinstr As String)
        Try
            'show the results at end of period
            With frmMain

                Dim msgtokens() As String = Split(sinstr, ";")
                Dim nextToken As Integer = 0

            End With
        Catch ex As Exception
            appEventLog_Write("error periodResults:", ex)
        End Try
    End Sub

    Public Sub finishedInstructions()
        Try
            With frmMain
                'close the instructions and start experiment

                frmInstructions.Close()
                showInstructions = False
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Module