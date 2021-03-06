Imports System.Windows.Forms
Imports LC
Public Class frmConnect

    Public ReadOnly Property ServerIP As String
        Get
            Return Me.txtIP.Text
        End Get
    End Property

    Public ReadOnly Property serverPortNumber As String
        Get
            Return Me.txtPort.Text
        End Get
    End Property

    Private Sub frmConnect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'load in last ip/port
            txtIP.Text = getINI(sfile, "Settings", "ip")
            txtPort.Text = getINI(sfile, "Settings", "port")
        Catch ex As Exception
            appEventLog_Write("error frmConnect_Load:", ex)
        End Try
    End Sub

    Private Sub cmdConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConnect.Click
        Try
            'try to connect to server
            'Me.Hide()
            'serverIPAddress = Me.txtIP.Text
            'serverPortNumber = txtPort.Text
            'connect()
            'frmMain.Show()
            'modMain.GameStatus = New StatusConnected
            'writeINI(sfile, "Settings", "ip", serverIPAddress)
            'writeINI(sfile, "Settings", "port", txtPort.Text)
            Me.Close()
        Catch ex As Exception
            appEventLog_Write("error cmdConnect_Click:", ex)
            modMain.GameStatus = New StatusNotConnected
        End Try
    End Sub

    Private Sub frmConnect_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            'close program on alt+k
            If e.Alt = True Then
                If CInt(e.KeyValue) = CInt(Keys.K) Then
                    If MessageBox.Show("Close Program?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
                    modMain.closing = True
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            appEventLog_Write("error frmConnect_KeyDown:", ex)
        End Try
    End Sub
End Class
