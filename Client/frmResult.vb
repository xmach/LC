Public Class frmResult
    Private m_displayMsg As String
    Public Property DisplayMsg() As String
        Get
            Return m_displayMsg
        End Get
        Set(ByVal value As String)
            m_displayMsg = value
        End Set
    End Property
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frmResult_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Label1.Text = Me.m_displayMsg
    End Sub
End Class
