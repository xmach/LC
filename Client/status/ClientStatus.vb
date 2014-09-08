Imports LC
Public MustInherit Class ClientStatusBase
    Public MustOverride Sub ReceiveMsg(ByVal m As LC.MessageBag)

    'Protected m_form As frmMain
    'Friend Property MainForm() As frmMain
    '    Get
    '        Return Me.m_form
    '    End Get
    '    Set(ByVal value As frmMain)
    '        Me.m_form = value
    '    End Set
    'End Property

    'Protected m_game As modMain

End Class

Public Class StatusCommunicationDicision
    Inherits ClientStatusBase


    Public Overrides Sub ReceiveMsg(ByVal m As LC.MessageBag)
        If m.MsgType = LC.MsgType.Server_feedbackPhase1Decision Then
            modMain.GameStatus = New StatusPhase2Decision
            frmMain.DisplayPhase2Decision(m)
        ElseIf m.MsgType = LC.MsgType.Server_feedbackResult Then
            modMain.GameStatus = New StatusNewRound
            frmMain.DisplayResult(m)
        End If
    End Sub
End Class

Public Class StatusConnected
    Inherits ClientStatusBase


    Public Overrides Sub ReceiveMsg(ByVal m As LC.MessageBag)
        If m.MsgType = LC.MsgType.Server_readInstruction Then
            modMain.GameStatus = New StatusReadInstruction
            
            frmMain.DisplayInstructions(m)
        End If
    End Sub
End Class

Public Class StatusLanguageDicision
    Inherits ClientStatusBase

    Public Overrides Sub ReceiveMsg(ByVal m As LC.MessageBag)
        If m.MsgType = LC.MsgType.Server_feedbackScoreMatrix Then
            modMain.GameStatus = New StatusCommunicationDicision
            
            frmMain.DisplayPhase1Decision(m)

        End If
    End Sub
End Class

Public Class StatusNewRound
    Inherits ClientStatusBase


    Public Overrides Sub ReceiveMsg(ByVal m As LC.MessageBag)
        If m.MsgType = LC.MsgType.Server_languageDecision Then
            frmMain.DisplayLanguageDecision(m)
            modMain.GameStatus = New StatusLanguageDicision
        End If
    End Sub
End Class

Public Class StatusNotConnected
    Inherits ClientStatusBase


    Public Overrides Sub ReceiveMsg(ByVal m As LC.MessageBag)

    End Sub
End Class

Public Class StatusPhase2Decision
    Inherits ClientStatusBase

    Public Overrides Sub ReceiveMsg(ByVal m As LC.MessageBag)
        If m.MsgType = LC.MsgType.Server_feedbackResult Then
            modMain.GameStatus = New StatusReadInstruction
            frmMain.DisplayResult(m)
        End If
    End Sub
End Class

Public Class StatusReadInstruction
    Inherits ClientStatusBase


    Public Overrides Sub ReceiveMsg(ByVal m As LC.MessageBag)
        If m.MsgType = LC.MsgType.Server_languageDecision Then
            frmMain.DisplayLanguageDecision(m)
            modMain.GameStatus = New StatusLanguageDicision
        End If
    End Sub
End Class
