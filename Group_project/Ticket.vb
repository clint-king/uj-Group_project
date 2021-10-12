<Serializable> Public Class Ticket
    Private Shared _ID As Integer
    Private _Tag As String
    Private _Price As Integer

    Public Sub New(Tag As String, Price As Integer)
        _Tag = Tag
        _Price = Price
        _ID += 1
    End Sub
    Public Property Tag() As String
        Get
            Return _Tag
        End Get
        Set(value As String)
            _Tag = value
        End Set
    End Property

    Public Property Price() As Integer
        Get
            Return _Price
        End Get
        Set(value As Integer)
            _Price = value
        End Set
    End Property

    Public ReadOnly Property ID() As Integer
        Get
            Return _ID
        End Get
    End Property

    Public Function Display() As String
        Return "Title" & _Tag & vbCrLf & "R " & _Price & vbCrLf & "Ticket No. " & _ID
    End Function

End Class
