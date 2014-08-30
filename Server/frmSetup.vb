﻿Imports LC
Public Class frmSetup

    Private Sub frmSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'load paremeters into text boxes from server.ini
            txtPlayers.Text = getINI(sfile, "gameSettings", "numberOfPlayers")
            chkShowInstructions.Checked = getINI(sfile, "gameSettings", "showInstructions")
            txtPort.Text = getINI(sfile, "gameSettings", "port")
            txtRounds.Text = getINI(sfile, "gameSettings", "numberOfPeriods")

            'txtInstructionX.Text = getINI(sfile, "gameSettings", "instructionX")
            'txtInstructionY.Text = getINI(sfile, "gameSettings", "instructionY")
            'txtWindowX.Text = getINI(sfile, "gameSettings", "windowX")
            'txtWindowY.Text = getINI(sfile, "gameSettings", "windowY")

        Catch ex As Exception
            appEventLog_Write("error frmSetup_Load:", ex)
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Try
            'write parameter from text boxes into server.ini
            writeINI(sfile, "gameSettings", "numberOfPlayers", txtPlayers.Text)
            writeINI(sfile, "gameSettings", "showInstructions", chkShowInstructions.Checked)
            writeINI(sfile, "gameSettings", "port", txtPort.Text)
            writeINI(sfile, "gameSettings", "numberOfPeriods", txtRounds.Text)

            'writeINI(sfile, "gameSettings", "instructionX", txtInstructionX.Text)
            'writeINI(sfile, "gameSettings", "instructionY", txtInstructionY.Text)
            'writeINI(sfile, "gameSettings", "windowX", txtWindowX.Text)
            'writeINI(sfile, "gameSettings", "windowY", txtWindowY.Text)

            loadParameters()

            Me.Close()
        Catch ex As Exception
            appEventLog_Write("error cmdSave_Click:", ex)
        End Try
    End Sub

    Private Sub Label20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label20.Click

    End Sub
End Class
