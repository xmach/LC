Imports LC
Imports System.IO

Public Class frmInstructions
    'Dim tempS As Boolean
    Dim startPressed As Boolean
    Dim currentInstruction As Integer
    Dim MaxPages As Integer
    Public Sub nextInstruction(ByVal pageNumber As Integer)
        Try
            'load the next page of instructions

            RichTextBox1.LoadFile(System.Windows.Forms.Application.StartupPath & _
                 "\instructions\page" & pageNumber.ToString() & ".rtf")

            'variables()

            RichTextBox1.SelectionStart = 1
            RichTextBox1.ScrollToCaret()

            'If Not startPressed Then
            '    Dim cmdStr As String = "01" & currentInstruction & ";"
            '    wskClient.Send(cmdStr)
            'End If

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub variables()
        Try
            'load variables into instructions

            Dim tempN As Integer = 0
            Dim outstr As String = ""
            Select Case currentInstruction
                Case 1
                    'Use the following command to insert varibles into the instructions.
                    'Call RepRTBfield("playerCount-1", numberOfPlayers - 1)
                Case 2

                Case 3

                Case 4

                Case 5

                Case 6

                Case 7

                Case 8


            End Select

            Me.Text = "Instructions " & currentInstruction & "/8"
        Catch ex As Exception
            appEventLog_Write("error variables:", ex)
        End Try
    End Sub

    Public Sub RepRTBfield(ByVal sField As String, ByVal sValue As String)
        Try
            'when the instructions are loaded into the rich text box control this function will
            'replace the variable place holders with variables.

            RichTextBox1.Find("#" & sField & "#")
            RichTextBox1.SelectedText = sValue
        Catch ex As Exception
            appEventLog_Write("error RepRTBfield:", ex)
        End Try
    End Sub

    Private Sub frmInstructions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            MaxPages = checkNumberOfPages()
            startPressed = False
            currentInstruction = 1
            nextInstruction(currentInstruction)
            'tempS = False

        Catch ex As Exception
            appEventLog_Write("error frmInstructions_Load:", ex)
        End Try
    End Sub

    Private Function checkNumberOfPages() As Integer
        Dim di As DirectoryInfo = New DirectoryInfo(System.Windows.Forms.Application.StartupPath & _
                         "\instructions")
        Dim pageFiles As FileInfo() = di.GetFiles("page*.rtf")
        Return pageFiles.Length
    End Function

    Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        'Try
        '    'client done with instructions
        '    Dim cmdStr As String = "02" & ""
        '    wskClient.Send(cmdStr)
        '    cmdStart.Visible = False
        '    startPressed = True
        'Catch ex As Exception
        '    appEventLog_Write("error instructinos start:", ex)
        'End Try

        'Kyle
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        Try
            'load next page of instructions
            currentInstruction += 1
            nextInstruction(currentInstruction)
            If currentInstruction > 1 Then
                Me.cmdBack.Enabled = True
            End If

            If currentInstruction = Me.MaxPages AndAlso Me.cmdStart.Visible = False Then
                cmdStart.Visible = True
            End If
            If currentInstruction = Me.MaxPages Then
                Me.cmdNext.Enabled = False
            End If
        Catch ex As Exception
            appEventLog_Write("error cmdNext_Click:", ex)
        End Try
    End Sub

    Private Sub cmdBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBack.Click
        Try
            'previous page of instructions
            currentInstruction -= 1
            nextInstruction(currentInstruction)

            If currentInstruction < Me.MaxPages Then
                Me.cmdNext.Enabled = True
            End If
            If currentInstruction = 1 Then
                Me.cmdBack.Enabled = False
                'Return
            End If

        Catch ex As Exception
            appEventLog_Write("error cmdBack_Click :", ex)
        End Try
    End Sub
End Class
