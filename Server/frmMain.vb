Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Drawing
Imports LC

Public Class frmMain
#Region " Winsock Code "
    Public WithEvents wsk_Col As New WinsockCollection
    'Private _users As New UserCollection
    Public WithEvents wskListener As Winsock

    Private Sub wskListener_ConnectionRequest(ByVal sender As Object, ByVal e As WinsockClientReceivedEventArgs) Handles wskListener.ConnectionRequest
        Try
            'Log("Connection received from: " & e.ClientIP)
            'Dim y As New clsUser
            Dim i As Integer
            Dim ID As String = Game.GetNewPlayorId() ' playerCount + 1

            Dim x As New Winsock(Me)
            wsk_Col.Add(x, ID)
            x.Accept(e.Client)

            If cmdBegin.Enabled = False Then
                For i = 0 To playerList.Length - 1
                    If playerList(i).myIPAddress = e.ClientIP Then
                        playerList(i).socketKey = ID 'wsk_Col.Count - 1
                        Exit For
                    End If
                Next
                Exit Sub
            End If

            RegisterPlayor(playerList, ID, e.ClientIP)
            'playerList(playerCount) = New Playor
            'playerList(playerCount).ID = ID
            'playerList(playerCount).socketKey = ID 'wsk_Col.Count - 1
            'playerList(playerCount).myIPAddress = e.ClientIP

            ''playerList(playerCount).requsetIP(wsk_Col)
            'playerCount += 1

            lblConnections.Text = wsk_Col.Count.ToString()
            RefreshPlayorDisplay()

            'appEventLog_Write("connection request: " & e.ClientIP)
        Catch ex As Exception
            appEventLog_Write("error wskListener_ConnectionRequest:", ex)
        End Try
    End Sub

    Private Sub wskListener_ErrorReceived(ByVal sender As System.Object, ByVal e As WinsockErrorEventArgs) Handles wskListener.ErrorReceived
        Try
            appEventLog_Write("winsock error: " & e.Message)
        Catch ex As Exception
            appEventLog_Write("error wskListener_ErrorReceived:", ex)
        End Try
    End Sub

    Private Sub wskListener_StateChanged(ByVal sender As Object, ByVal e As WinsockStateChangingEventArgs) Handles wskListener.StateChanged
        'Log("Listener state changed from " & e.Old_State.ToString & " to " & e.New_State.ToString)
        'lblListenState.Text = "State: " & e.New_State.ToString
        'cmdListen.Enabled = False
        'cmdClose.Enabled = False
        'Select Case e.New_State
        '    Case WinsockStates.Closed
        '        cmdListen.Enabled = True
        '    Case WinsockStates.Listening
        '        cmdClose.Enabled = True
        'End Select
    End Sub

    'Private Sub Log(ByVal val As String)
    '    lstLog.SelectedIndex = lstLog.Items.Add(val)
    '    lstLog.SelectedIndex = -1
    'End Sub


    Private Sub Wsk_DataArrival(ByVal sender As Object, ByVal e As WinsockDataArrivalEventArgs) Handles wsk_Col.DataArrival
        Try
            Dim sender_key As String = wsk_Col.GetKey(sender)
            Dim buf As String = Nothing
            CType(sender, Winsock).Get(buf)

            Dim msgtokens() As String = buf.Split("#")
            Dim i As Integer

            'appEventLog_Write("data arrival: " & buf)

            For i = 0 To msgtokens.Length - 1
                Dim message As LC.MessageBag = LC.XmlHelper.XmlDeserialize(Of LC.MessageBag)(msgtokens(i), System.Text.Encoding.UTF8)
                message.clientID = sender_key
                Game.takeMessage(message)
            Next
            Me.RefreshPlayorDisplay()
        Catch ex As Exception
            appEventLog_Write("error Wsk_DataArrival:", ex)
        End Try
    End Sub

    Private Sub Wsk_Disconnected(ByVal sender As Object, ByVal e As System.EventArgs) Handles wsk_Col.Disconnected
        Try
            wsk_Col.Remove(sender)
            Dim sender_key As String = wsk_Col.GetKey(sender)
            Dim playorDisconnect As Playor = FindPlayorById(Game.playerList, (sender_key))
            Dim idx As Integer = Array.IndexOf(Game.playerList, playorDisconnect)
            If (idx > -1) Then Game.playerList(idx) = Nothing
            'If cmdBegin.Enabled Then Exit Sub
            MsgBox("A client has been disconnected.", MsgBoxStyle.Critical)
            appEventLog_Write("client disconnected")
            Me.RefreshPlayorDisplay()
            'playerCount -= 1
        Catch ex As Exception
            appEventLog_Write("error Wsk_Disconnected:", ex)
        End Try
    End Sub
    Private Sub Wsk_Connected(ByVal sender As Object, ByVal e As System.EventArgs) Handles wsk_Col.Connected
        lblConnections.Text = wsk_Col.Count.ToString()
        'lblConnections
    End Sub

    Private Sub ShutDownServer()
        Try
            GC.Collect()
        Catch ex As Exception
            appEventLog_Write("error ShutDownServer:", ex)
        End Try

    End Sub
#End Region    'communication code

#Region " Extra Functions "
    'Public Function convertY(ByVal p As Integer, ByVal graphMin As Integer, ByVal graphMax As Integer, _
    '                             ByVal panelHeight As Integer, ByVal bottomOffset As Integer, ByVal topOffset As Integer) As Double
    '    Try
    '        Dim tempD As Double

    '        tempD = p - graphMin

    '        tempD = (tempD * (panelHeight - bottomOffset - topOffset)) / (graphMax - graphMin)
    '        tempD = panelHeight - (bottomOffset + topOffset) - tempD

    '        convertY = tempD + topOffset
    '    Catch ex As Exception
    '        Return 0
    '        appEventLog_Write("error convertY:", ex)
    '    End Try
    'End Function

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Try
            Dim i As Integer
            Dim f As New Font("Arial", 8, FontStyle.Bold)
            Dim tempN As Integer

            e.Graphics.DrawString(filename2, f, Brushes.Black, 10, 10)

            f = New Font("Arial", 15, FontStyle.Bold)

            e.Graphics.DrawString("Name", f, Brushes.Black, 10, 30)
            e.Graphics.DrawString("Earnings", f, Brushes.Black, 400, 30)

            f = New Font("Arial", 12, FontStyle.Bold)

            tempN = 55

            For i = 1 To DataGridView1.RowCount
                If i Mod 2 = 0 Then
                    e.Graphics.FillRectangle(Brushes.Aqua, 0, tempN, 500, 19)
                End If
                e.Graphics.DrawString(DataGridView1.Rows(i - 1).Cells(1).Value, f, Brushes.Black, 10, tempN)
                e.Graphics.DrawString(DataGridView1.Rows(i - 1).Cells(3).Value, f, Brushes.Black, 400, tempN)

                tempN += 20
            Next

        Catch ex As Exception
            appEventLog_Write("error PrintDocument1_PrintPage:", ex)
        End Try

    End Sub
#End Region

    Public tempTime As String 'time stamp at start of experiment

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            sfile = System.Windows.Forms.Application.StartupPath & "\server.ini"
            loadParameters()

            Dim i As Integer           ', j As Integer

            For i = 1 To 4
                DataGridView1.Columns(i - 1).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            'setup communication on load
            wskListener = New Winsock
            wskListener.BufferSize = 8192
            wskListener.LegacySupport = False
            wskListener.LocalPort = portNumber
            wskListener.MaxPendingConnections = 1
            wskListener.Protocol = WinsockProtocols.Tcp
            wskListener.RemotePort = 8080
            'wskListener.RemoteServer = "localhost"
            wskListener.SynchronizingObject = Me

            wskListener.Listen()

            'playerCount = 0

            lblIP.Text = wskListener.LocalIP
            lblLocalHost.Text = SystemInformation.ComputerName

            'kyle

        Catch ex As Exception
            appEventLog_Write("error frmSvr_Load:", ex)
        End Try

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            'Dim b As New System.Windows.Media.BrushConverter
            'b=
            'DisplayMain1.Canvas1.Background = 
        Catch ex As Exception
            appEventLog_Write("error Timer1_Tick:", ex)
        End Try
    End Sub



    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click
        Try
            'when reset is pressed bring server back to state to start another experiment

            'disable timers
            Timer1.Enabled = False
            Timer2.Enabled = False
            Timer3.Enabled = False

            'close data files
            'If summaryDf IsNot Nothing Then summaryDf.Close()

            'shut down clients
            Dim i As Integer
            For i = 1 To CInt(lblConnections.Text)
                'TODO playerList(i).resetClient()
            Next

            'enable/disable buttons
            cmdLoad.Enabled = True
            cmdGameSetup.Enabled = True
            cmdBegin.Enabled = True
            cmdExit.Enabled = True
            cmdEnd.Enabled = False
            cmdExchange.Enabled = True
            cmdSetup2.Enabled = True
            cmdExchange.Enabled = True

            lblConnections.Text = 0
            ' playerCount = 0

            DataGridView1.RowCount = 0

            'TODO frmInstructions.Close()

        Catch ex As Exception
            appEventLog_Write("error cmdReset_Click:", ex)
        End Try
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Try
            'exit program

            Timer1.Enabled = False
            ShutDownServer()

            Me.Close()
        Catch ex As Exception
            appEventLog_Write("error cmdExit_Click:", ex)
        End Try
    End Sub

    Private Sub cmdGameSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGameSetup.Click
        Try
            frmSetup.Show()
        Catch ex As Exception
            appEventLog_Write("error cmdGameSetup_Click:", ex)
        End Try
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try

        Catch ex As Exception
            appEventLog_Write("error Timer2_Tick:", ex)
        End Try
    End Sub

    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        Try

            Dim tempS As String
            Dim sinstr As String

            'dispaly open file dialog to select file
            OpenFileDialog1.FileName = ""
            OpenFileDialog1.Filter = "Parameter Files (*.txt)|*.txt"
            OpenFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath

            OpenFileDialog1.ShowDialog()

            'if filename is not empty then continue with load
            If OpenFileDialog1.FileName = "" Then
                Exit Sub
            End If

            tempS = OpenFileDialog1.FileName

            sinstr = getINI(tempS, "gameSettings", "gameName")

            'check that this is correct type of file to load
            If sinstr <> "programName" Then
                MsgBox("Invalid file", vbExclamation)
                Exit Sub
            End If

            'copy file to be loaded into server.ini
            FileCopy(OpenFileDialog1.FileName, sfile)

            'load new parameters into server
            loadParameters()
        Catch ex As Exception
            appEventLog_Write("error cmdLoad_Click:", ex)
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Try
            'save current parameters to a text file so they can be loaded at a later time

            SaveFileDialog1.FileName = ""
            SaveFileDialog1.Filter = "Parameter Files (*.txt)|*.txt"
            SaveFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath
            SaveFileDialog1.ShowDialog()

            If SaveFileDialog1.FileName = "" Then
                Exit Sub
            End If

            FileCopy(sfile, SaveFileDialog1.FileName)

        Catch ex As Exception
            appEventLog_Write("error cmdSave_Click:", ex)
        End Try
    End Sub



    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        Try
            'end experiment early

            Dim i As Integer
            cmdEnd.Enabled = False

            'numberOfPeriods = currentPeriod

            For i = 1 To numberOfPlayers
                'TODO playerList(i).endEarly()
            Next
        Catch ex As Exception
            appEventLog_Write("error cmdEnd_Click:", ex)
        End Try
    End Sub

    Private Sub txtExchange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExchange.Click
        Interaction.Shell("notepad.exe " + Application.StartupPath + "\\symbols.txt")
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Try

        Catch ex As Exception
            appEventLog_Write("error timer3 tick:", ex)
        End Try
    End Sub

    Private Sub cmdSetup2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetup2.Click
        Try
            frmScoreMatrix.ShowDialog()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub llESI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llESI.LinkClicked
        Try
            System.Diagnostics.Process.Start("http://www.chapman.edu/esi/")
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Try
            Dim r As DialogResult = PrintDialog1.ShowDialog()
            If r = Windows.Forms.DialogResult.OK Then
                PrintDocument1.Print()
            End If

        Catch ex As Exception
            appEventLog_Write("error cmdPrint_Click:", ex)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not playerList(0) Is Nothing Then
            playerList(0).DisplayInstruction(Me.wsk_Col)
        End If
    End Sub

    Private Sub RefreshPlayorDisplay()
        lblConnections.Text = wsk_Col.Count.ToString()

        DataGridView1.RowCount = playerList.Length

        For i As Integer = 0 To playerList.Length - 1
            If playerList(i) Is Nothing Then
                DataGridView1.Rows(i).Cells(0).Value = String.Empty
                DataGridView1.Rows(i).Cells(1).Value = String.Empty
                DataGridView1.Rows(i).Cells(2).Value = String.Empty
                DataGridView1.Rows(i).Cells(3).Value = String.Empty
                DataGridView1.Rows(i).Cells(4).Value = String.Empty
            Else
                DataGridView1.Rows(i).Cells(0).Value = playerList(i).ID
                DataGridView1.Rows(i).Cells(1).Value = playerList(i).Name
                DataGridView1.Rows(i).Cells(2).Value = playerList(i).myIPAddress
                If playerList(i).Group Is Nothing Then
                    DataGridView1.Rows(i).Cells(3).Value = "Connected"
                Else
                    DataGridView1.Rows(i).Cells(3).Value = playerList(i).Group.Status.ToString()
                End If
                DataGridView1.Rows(i).Cells(4).Value = playerList(i).Score.ToString()
            End If
        Next


    End Sub
    Private Sub cmdBegin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBegin.Click
        Try

            'when a button is pressed it's click event is fired

            loadParameters()

            Dim nextToken As Integer = 0
            'Dim str As String

            If CInt(lblConnections.Text) <> numberOfPlayers Then
                MsgBox("Incorrect number of connections.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            'define timestamp for recording data
            tempTime = DateTime.Now.Month & "-" & DateTime.Now.Day & "-" & DateTime.Now.Year & "_" & DateTime.Now.Hour & _
                     "_" & DateTime.Now.Minute & "_" & DateTime.Now.Second

            'create unique file name for storing data, CSVs are excel readable, Comma Separted Value files.
            filename = "summary_data_" & tempTime & ".csv"
            Dim di As New DirectoryInfo(Application.StartupPath & "\datafiles")
            If Not di.Exists Then di.Create()
            filename = di.FullName & "\" & filename

            'summaryDf = File.CreateText(filename)
            'str = "Period,data1,data2,data3"
            'summaryDf.WriteLine(str)

            ' currentPeriod = 1
            'txtPeriod.Text = currentPeriod
            checkin = 0

            'disable/enable buttons needed when the experiment starts
            cmdLoad.Enabled = False
            cmdGameSetup.Enabled = False
            cmdExchange.Enabled = False
            cmdSetup2.Enabled = False
            cmdExit.Enabled = False
            cmdBegin.Enabled = False
            cmdEnd.Enabled = True
            cmdExchange.Enabled = False

            'filename2 = filename

            'showInstructions = getINI(sfile, "gameSettings", "showInstructions")


            'signal clients to begin
            'every group contains 2 playors
            'playorlist 0,1 make a group , and 2,3 make a group and so on...
            Group.MakeGroups(Game.playerList, Game.groupList, _
                            Game.allVocabulary, Game.initScoreOfPlayor, _
                            Game.cooperateMatrix, Game.competeMatrix, _
                            Me.wsk_Col)

            For i As Integer = 0 To Game.groupList.Length - 1
                groupList(i).Begin()
            Next

            checkin = 0
            RefreshPlayorDisplay()
        Catch ex As Exception
            appEventLog_Write("error cmdBegin_Click:", ex)
        End Try
    End Sub
End Class
