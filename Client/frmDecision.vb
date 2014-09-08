Imports LC
Imports System.Windows.Forms
Public Class frmDecision
    Private m_ScoreMatrix As LC.ScoreMatrix
    Private m_Phase1Decision As String
    Private m_Phase2Decision As String
    Private m_Meanings As String()
    Private m_IsPhase2 As Boolean

    Public Property ScoreMatrix() As LC.ScoreMatrix
        Get
            Return m_ScoreMatrix
        End Get
        Set(ByVal value As LC.ScoreMatrix)
            m_ScoreMatrix = value
        End Set
    End Property


    Public Property Phase1Decision() As String
        Get
            Return m_Phase1Decision
        End Get
        Set(ByVal value As String)
            m_Phase1Decision = value
        End Set
    End Property

    Public Property Phase2Decision() As String
        Get
            Return m_Phase2Decision
        End Get
        Set(ByVal value As String)
            m_Phase2Decision = value
        End Set
    End Property
    Public Property Meanings() As String()
        Get
            Return m_Meanings
        End Get
        Set(ByVal value As String())
            m_Meanings = value
        End Set
    End Property

    Public Property IsPhase2() As Boolean
        Get
            Return m_IsPhase2
        End Get
        Set(ByVal value As Boolean)
            m_IsPhase2 = value
        End Set
    End Property

    Private Sub frmPhase2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.pnlPhase2.Visible = IsPhase2
        Me.Text = CStr(IIf(IsPhase2, "Please reconfirm your choice", "Please choose"))
        Binddata()
    End Sub


    Private Sub cmdSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubmit.Click
        If Me.cboMeanings.SelectedItem Is Nothing Then
            MsgBox("Please input your decision")
            Me.cboMeanings.Focus()
            Return
        End If
        If Me.IsPhase2 Then
            Me.Phase2Decision = Me.cboMeanings.SelectedItem.ToString()
        Else
            Me.Phase1Decision = Me.cboMeanings.SelectedItem.ToString()
        End If
        Me.Close()
    End Sub

    Private Sub Binddata()

        If IsPhase2 Then
            Me.lblCounterPartPhase1.Text = Me.Phase1Decision
        End If

        Me.cboMeanings.Items.Clear()
        For index As Integer = 0 To Me.Meanings.Length - 1
            Me.cboMeanings.Items.Add(Me.Meanings(index))
        Next

        For index As Integer = 0 To Meanings.Length - 1
            Me.grdmatrix.Columns.Add("col" + Meanings(index), Meanings(index))
        Next
        Me.grdmatrix.Rows.Add(Meanings.Length)
        For rowIndex As Integer = 0 To Meanings.Length - 1
            Me.grdmatrix.Rows(rowIndex).HeaderCell.Value = Meanings(rowIndex)
            For colIndex As Integer = 0 To Meanings.Length - 1
                Dim scoreTuple As Tuple(Of Integer, Integer) = Me.ScoreMatrix.GetScore(Meanings(rowIndex), Meanings(colIndex))
                Me.grdmatrix.Rows(rowIndex).Cells(colIndex).Value = scoreTuple.Item1.ToString() + "," + scoreTuple.Item2.ToString()

            Next
        Next
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class