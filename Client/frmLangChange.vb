Imports LC
Imports System.Collections.Generic
Imports System.Windows.Forms
Public Class frmLangChange

    Private m_meanings As String()
    Private m_vocabulary As Vocabulary
    Private m_symbols As String()

    Public ReadOnly Property LearnNum() As Integer
        Get
            Return Convert.ToInt16(Me.numLearn.Value)
        End Get
    End Property

    Public ReadOnly Property Invent() As Tuple(Of String, String)()
        Get
            Dim lst As New List(Of Tuple(Of String, String))
            If Not String.IsNullOrEmpty(Me.txtNewWord1.Text) AndAlso Not String.IsNullOrEmpty(Me.cboMeaning1.SelectedText) Then
                Dim t As New Tuple(Of String, String)(Me.txtNewWord1.Text, Me.cboMeaning1.SelectedItem.ToString())
                lst.Add(t)
            End If
            If Not String.IsNullOrEmpty(Me.txtNewWord2.Text) AndAlso Not String.IsNullOrEmpty(Me.cboMeaning2.SelectedText) Then
                Dim t As New Tuple(Of String, String)(Me.txtNewWord2.Text, Me.cboMeaning2.SelectedItem.ToString())
                lst.Add(t)
            End If
            If Not String.IsNullOrEmpty(Me.txtNewWord3.Text) AndAlso Not String.IsNullOrEmpty(Me.cboMeaning3.SelectedText) Then
                Dim t As New Tuple(Of String, String)(Me.txtNewWord3.Text, Me.cboMeaning3.SelectedItem.ToString())
                lst.Add(t)
            End If
            Return lst.ToArray()
        End Get
    End Property

    Public Property Meaning() As String()
        Get
            Return Me.m_meanings
        End Get
        Set(ByVal value As String())
            m_meanings = value
        End Set
    End Property

    Public Property Vocabulary() As Vocabulary
        Get
            Return m_vocabulary
        End Get
        Set(ByVal value As Vocabulary)
            m_vocabulary = value
        End Set
    End Property
    Public Property Symbols() As String()
        Get
            Return m_symbols
        End Get
        Set(ByVal value As String())
            m_symbols = value
        End Set
    End Property
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not ValidateInput() Then Return

        Me.Close()
    End Sub

    Private Sub frmLangChange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        binddata()
    End Sub

    Private Function ValidateInput() As Boolean
        If Me.numInvent.Value >= 1 Then
            If String.IsNullOrEmpty(Me.txtNewWord1.Text) OrElse Me.cboMeaning1.SelectedItem Is Nothing Then
                MessageBox.Show("Please input for new word 1")
                Return False
            End If
        End If
        If Me.numInvent.Value >= 2 Then
            If String.IsNullOrEmpty(Me.txtNewWord2.Text) OrElse Me.cboMeaning2.SelectedItem Is Nothing Then
                MessageBox.Show("Please input for new word 2")
                Return False
            End If
        End If
        If Me.numInvent.Value >= 3 Then
            If String.IsNullOrEmpty(Me.txtNewWord3.Text) OrElse Me.cboMeaning3.SelectedItem Is Nothing Then
                MessageBox.Show("Please input for new word 3")
                Return False
            End If
        End If
        If (Me.txtNewWord1.Text = Me.txtNewWord2.Text AndAlso Not String.IsNullOrEmpty(txtNewWord2.Text)) OrElse _
           (Me.txtNewWord1.Text = Me.txtNewWord3.Text AndAlso Not String.IsNullOrEmpty(txtNewWord3.Text)) OrElse _
            (Me.txtNewWord2.Text = Me.txtNewWord3.Text AndAlso Not String.IsNullOrEmpty(txtNewWord2.Text) AndAlso Not String.IsNullOrEmpty(txtNewWord3.Text)) Then
            MessageBox.Show("The new words should be unique ,please re-input")
            Return False
        End If
        Return True
    End Function

    Private Sub BindData()
        Me.lstComm.View = View.LargeIcon
        Me.lstPrivate.View = View.LargeIcon
        Me.lstComm.GridLines = True
        'Me.lstComm.Groups.Clear()
        'Me.lstComm.Items.Clear()
        'Me.lstPrivate.Groups.Clear()
        'Me.lstPrivate.Items.Clear()

        BindMeaning(Me.lstComm, Me.Meaning)
        BindMeaning(Me.lstPrivate, Me.Meaning)
        BindSymbol(Me.lstComm, Me.lstPrivate, Me.Vocabulary)
        Me.lstComm.ShowGroups = True
        Me.lstPrivate.ShowGroups = True

        Dim columnHeader0 As ColumnHeader = New ColumnHeader()
        columnHeader0.Text = "Title"
        columnHeader0.Width = 200
        Me.lstComm.Columns.Add(columnHeader0)

        Me.numLearn.Maximum = Me.Meaning.Length
        Me.numInvent.Maximum = Me.Meaning.Length

        bindCombo(Me.Meaning, Me.cboMeaning1)
        bindCombo(Me.Meaning, Me.cboMeaning2)
        bindCombo(Me.Meaning, Me.cboMeaning3)
        Me.cboMeaning1.SelectedIndex = 0
        Me.cboMeaning1.SelectedIndex = 1
        Me.cboMeaning1.SelectedIndex = 2
    End Sub

    Private Sub bindCombo(ByVal meaning As String(), ByVal combo As ComboBox)
        combo.Items.Clear()

        For index As Integer = 0 To meaning.Length - 1
            combo.Items.Add(meaning(index))
        Next

    End Sub
    Private Sub BindMeaning(ByVal lv As ListView, ByVal meanings As String())

        For index As Integer = 0 To meanings.Length - 1
            Dim grp As New ListViewGroup(meanings(index), meanings(index))
            grp.Header = meanings(index)

            lv.Groups.Add(grp)
        Next

    End Sub

    Private Sub BindSymbol(ByVal lvCommon As ListView, ByVal lvPrivate As ListView, ByVal voca As Vocabulary)

        For index As Integer = 0 To lvCommon.Groups.Count - 1
            Dim grp As ListViewGroup = lvCommon.Groups(index)
            Dim symbollist As ICollection(Of String) = voca.GetCommonList(grp.Name)
            If symbollist Is Nothing Then
                Continue For
            End If
            For Each sym As String In symbollist
                Dim item As New ListViewItem(sym, 0, grp)
                'item.Group = grp
                'grp.Items.Add(item)
                lvCommon.Items.Add(item)
            Next
        Next
        For index As Integer = 0 To lvPrivate.Groups.Count - 1
            Dim grp As ListViewGroup = lvPrivate.Groups(index)
            Dim symbollist As ICollection(Of String) = voca.GetPrivateList(grp.Name)
            If symbollist Is Nothing Then
                Continue For
            End If
            For Each sym As String In symbollist
                Dim item As New ListViewItem(sym, 0, grp)
                'item.Group = grp
                'grp.Items.Add(item)
                lvPrivate.Items.Add(item)
            Next
        Next
    End Sub

    Private Sub numLearn_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numLearn.ValueChanged
        Me.lblLearnCost.Text = Me.numLearn.Value.ToString()
    End Sub

    Private Sub numInvent_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numInvent.ValueChanged
        Me.lblInventCost.Text = (0.5 * Me.numInvent.Value * (1 + Me.numInvent.Value)).ToString()

        If Me.numInvent.Value >= 1 Then
            Me.txtNewWord1.Enabled = True
            Me.cboMeaning1.Enabled = True
        Else
            Me.txtNewWord1.Enabled = False
            Me.cboMeaning1.Enabled = False
        End If

        If Me.numInvent.Value >= 2 Then
            Me.txtNewWord2.Enabled = True
            Me.cboMeaning2.Enabled = True
        Else
            Me.txtNewWord2.Enabled = False
            Me.cboMeaning2.Enabled = False
        End If

        If Me.numInvent.Value >= 3 Then
            Me.txtNewWord3.Enabled = True
            Me.cboMeaning3.Enabled = True
        Else
            Me.txtNewWord3.Enabled = False
            Me.cboMeaning3.Enabled = False
        End If
    End Sub

    Private Sub txtNewWord1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNewWord1.TextChanged, txtNewWord2.TextChanged, txtNewWord3.TextChanged
        Dim txt As TextBox = CType(sender, TextBox)
        txt.Text = txt.Text.Trim()
        If String.IsNullOrEmpty(txt.Text) Then Return

        If Me.Vocabulary.ContainsSymbol(txt.Text) Then
            MessageBox.Show("This symbol:" & txt.Text & " already exists in vocabulary,please use another one")
        End If
    End Sub

End Class
