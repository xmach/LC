Public Class Tuple(Of T1, T2)
    Private m_item1 As T1
    Private m_item2 As T2
    Public Sub New()

    End Sub
    Public Sub New(ByVal val1 As T1, ByVal val2 As T2)
        Me.m_item1 = val1
        Me.m_item2 = val2
    End Sub

    Public Property Item1() As T1
        Get
            Return Me.m_item1
        End Get
        Set(ByVal value As T1)
            Me.m_item1 = value
        End Set
    End Property

    Public Property Item2() As T2
        Get
            Return Me.m_item2
        End Get
        Set(ByVal value As T2)
            Me.m_item2 = value
        End Set
    End Property



End Class
