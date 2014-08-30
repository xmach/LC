Imports System.Windows.Forms
Imports LC
Public Class frmScoreMatrix
    Private m_cooperateMatrix As LC.ScoreMatrix
    Private m_competeMatrix As LC.ScoreMatrix
    Private m_meanings As String()

    Friend Property cooperateMatrix() As LC.ScoreMatrix
        Get
            Return Me.m_cooperateMatrix
        End Get
        Set(ByVal value As LC.ScoreMatrix)
            Me.m_cooperateMatrix = value
        End Set
    End Property

    Friend Property competeMatrix() As LC.ScoreMatrix
        Get
            Return Me.m_competeMatrix
        End Get
        Set(ByVal value As LC.ScoreMatrix)
            Me.m_competeMatrix = value
        End Set
    End Property

    Friend Property Meanings() As String()
        Get
            Return Me.m_meanings
        End Get
        Set(ByVal value As String())
            Me.m_meanings = value
        End Set
    End Property

    Private Sub frmScoreMatrix_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BindData()
    End Sub

    Private Sub BindData()

        For index As Integer = 0 To m_meanings.Length - 1
            Me.grdCooperate.Columns.Add("col" + m_meanings(index), m_meanings(index))
            Me.grdCompete.Columns.Add("col" + m_meanings(index), m_meanings(index))
        Next
        Me.grdCooperate.Rows.Add(m_meanings.Length)
        Me.grdCompete.Rows.Add(m_meanings.Length)
        For rowIndex As Integer = 0 To m_meanings.Length - 1
            Me.grdCooperate.Rows(rowIndex).HeaderCell.Value = m_meanings(rowIndex)
            Me.grdCompete.Rows(rowIndex).HeaderCell.Value = m_meanings(rowIndex)
            For colIndex As Integer = 0 To m_meanings.Length - 1
                Dim scoreTuple As Tuple(Of Integer, Integer) = Me.m_cooperateMatrix.GetScore(m_meanings(rowIndex), m_meanings(colIndex))
                Me.grdCooperate.Rows(rowIndex).Cells(colIndex).Value = scoreTuple.Item1.ToString() + "," + scoreTuple.Item2.ToString()

                scoreTuple = Me.m_competeMatrix.GetScore(m_meanings(rowIndex), m_meanings(colIndex))
                Me.grdCompete.Rows(rowIndex).Cells(colIndex).Value = scoreTuple.Item1.ToString() + "," + scoreTuple.Item2.ToString()
            Next
        Next
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        SameGridViewToTable(Me.grdCooperate, Me.m_cooperateMatrix)
        SameGridViewToTable(Me.grdCompete, Me.m_competeMatrix)

        Me.Close()
    End Sub

    Private Sub SameGridViewToTable(ByVal grid As Windows.Forms.DataGridView, ByVal scoreMatrix As LC.ScoreMatrix)

        For rowIndex As Integer = 0 To grid.Rows.Count - 1

            For colindex As Integer = 0 To grid.Columns.Count - 1
                Dim meaning1 As String = m_meanings(rowIndex)
                Dim meaning2 As String = m_meanings(colindex)
                Dim cellValues As String() = grid.Rows(rowIndex).Cells(colindex).Value.ToString().Trim(","c).Split(","c)
                Dim score1 As Integer = Integer.Parse(cellValues(0))
                Dim score2 As Integer = Integer.Parse(cellValues(1))
                scoreMatrix.UpdateScore(meaning1, meaning2, score1, score2)
            Next
        Next

    End Sub
End Class
