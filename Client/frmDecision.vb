Imports LC
Public Class frmDecision
    Public Property ScoreMatrix As LC.ScoreMatrix

    Public Property Phase1Decision As String

    Public Property Phase2Decision As String
    Public Property Meanings As String()

    Public Property IsPhase2 As Boolean
    Private Sub frmPhase2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.pnlPhase2.Visible = IsPhase2
        Binddata()
    End Sub


    Private Sub cmdSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSubmit.Click
        If Me.IsPhase2 Then
            Me.Phase2Decision = Me.cboMeanings.SelectedText
        Else
            Me.Phase1Decision = Me.cboMeanings.SelectedText
        End If
        Me.Close()
    End Sub

    Private Sub Binddata()
        For index As Integer = 0 To meanings.Length - 1
            Me.grdmatrix.Columns.Add("col" + meanings(index), meanings(index))
        Next
        Me.grdmatrix.Rows.Add(meanings.Length)
        For rowIndex As Integer = 0 To meanings.Length - 1
            Me.grdmatrix.Rows(rowIndex).HeaderCell.Value = meanings(rowIndex)
            For colIndex As Integer = 0 To meanings.Length - 1
                Dim scoreTuple As Tuple(Of Integer, Integer) = Me.ScoreMatrix.GetScore(Meanings(rowIndex), Meanings(colIndex))
                Me.grdmatrix.Rows(rowIndex).Cells(colIndex).Value = scoreTuple.Item1.ToString() + "," + scoreTuple.Item2.ToString()

            Next
        Next
    End Sub

End Class