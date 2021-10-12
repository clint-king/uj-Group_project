<Serializable> Public Class Food
    Private name As String
    Private num As Integer

    Public Sub New(nameOfFood As String, howMany As Integer)
        name = nameOfFood
        num = howMany
    End Sub


    Public ReadOnly Property namePro() As String
        Get
            Return name
        End Get
    End Property

    Public ReadOnly Property howMany() As Integer
        Get
            Return num
        End Get
    End Property
End Class
