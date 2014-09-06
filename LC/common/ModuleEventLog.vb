
Imports System.IO
Imports System.Windows.Forms


Public Module ModuleEventLog
    Public eventLog As StreamWriter
    Dim int As String
    Private m_fileNamePrefix As String
    Public Property fileNamePrefix() As String
        Get
            Return m_fileNamePrefix
        End Get
        Set(ByVal value As String)
            m_fileNamePrefix = value
        End Set
    End Property
    Public Sub AppEventLog_Init()
        Try
            Dim filename As String

            Dim tempTime As String = DateTime.Now.Month & "-" & DateTime.Now.Day & "-" & DateTime.Now.Year & "_" & DateTime.Now.Hour & _
                    "_" & DateTime.Now.Minute & "_" & DateTime.Now.Second

            filename = m_fileNamePrefix + "_" & tempTime & ".txt"

            Dim folder As DirectoryInfo = New DirectoryInfo(System.Windows.Forms.Application.StartupPath & "\Logs")
            If Not folder.Exists Then
                folder.Create()
            End If

            filename = System.Windows.Forms.Application.StartupPath & "\Logs\" & filename

            eventLog = File.CreateText(filename)

            int = "int"
            eventLog.AutoFlush = True
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub appEventLog_Write(ByVal text As String)
        Try
            If int = Nothing Then AppEventLog_Init()

            eventLog.WriteLine(text & " (" & Now & ")")

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub appEventLog_Write(ByVal text As String, ByVal err As Exception)
        Try
            If int = Nothing Then AppEventLog_Init()

            Dim outstr As String

            eventLog.WriteLine(text & " (" & Now & ")")

            outstr = err.Message & vbCrLf
            outstr &= err.StackTrace & vbCrLf

            eventLog.WriteLine(outstr)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AppEventLog_Close()
        Try
            If eventLog IsNot Nothing Then eventLog.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub WriteLCMessage(ByVal msgs As LC.MessageBag())
        'TODO 
        'write log async 
    End Sub
End Module
