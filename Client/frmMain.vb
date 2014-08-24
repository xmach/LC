Public Class frmMain
    'Public WithEvents mobjSocketClient As TCPConnection
    Delegate Sub SetTextCallback(ByVal [text] As String)
    Delegate Sub SetTextCallback2()

    Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try

            'if ALT+K are pressed kill the client
            'if ALT+Q are pressed bring up connection box
            If e.Alt = True Then
                If CInt(e.KeyValue) = CInt(Keys.K) Then
                    If MessageBox.Show("Close Program?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                    modMain.closing = True
                    Me.Close()
                ElseIf CInt(e.KeyValue) = CInt(Keys.Q) Then
                    frmConnect.Show()
                End If
            End If
        Catch ex As Exception
            appEventLog_Write("error frmChat_KeyDown:", ex)
        End Try
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            sfile = System.Windows.Forms.Application.StartupPath & "\client.ini"

            'take IP from command line
            Dim commandLine As String = Command()

            If commandLine <> "" Then
                writeINI(sfile, "Settings", "ip", commandLine)
            End If

            'connect
            myIPAddress = getINI(sfile, "Settings", "ip")
            myPortNumber = getINI(sfile, "Settings", "port")
            localPort = getINI(sfile, "Settings", "localport")
            connect()

            BindData()
        Catch ex As Exception
            appEventLog_Write("errorfrmChat_Load :", ex)
        End Try

    End Sub
    Private Sub BindData()
        BindRowData(New String() {"10,10", "0,0", "3,3"})
        BindRowData(New String() {"2,2", "20,20", "0,0"})
        BindRowData(New String() {"5,5", "3,3", "20,20"})
    End Sub
    Private Sub BindRowData(ByVal rowData As String())
        Dim index As Integer = Me.DataGridView1.Rows.Add()
        Dim newRow As DataGridViewRow = Me.DataGridView1.Rows(index)
        For i As Integer = 0 To rowData.Length - 1
            newRow.Cells(i).Value = rowData(i)
        Next

        'Me.DataGridView1.Rows.Add(New DataGridViewRow())
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try

        Catch ex As Exception
            appEventLog_Write("error Timer1_Tick:", ex)
        End Try
    End Sub



    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try

        Catch ex As Exception
            appEventLog_Write("error Timer2_Tick client:", ex)
        End Try
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If Not modMain.closing Then e.Cancel = True
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class
