Option Explicit On
Option Strict On
Option Infer Off
<Serializable> Public Class School
    Private _name As String
    Private _schoolID As String
    Private _SchoolpassWord As String

    Public Sub New(name As String, schoolID As String)
        Me._name = name
        Me._schoolID = schoolID
    End Sub

    Public Property name() As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property schoolId() As String
        Get
            Return _schoolID
        End Get
        Set(value As String)
            _schoolID = value
        End Set
    End Property

    Public Property schoolpassWord() As String
        Get
            Return _SchoolpassWord
        End Get
        Set(value As String)
            _SchoolpassWord = value
        End Set
    End Property

    Public Function display() As String
        Dim tempStr As String
        tempStr &= "Name : " & _name & Environment.NewLine
        tempStr &= "SchoolId : " & _schoolID & Environment.NewLine


        Return tempStr
    End Function
End Class
