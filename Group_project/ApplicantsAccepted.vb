Option Explicit On
Option Strict On
Option Infer Off

<Serializable> Public Class ApplicantsAccepted
    Private _name As String
    Private _surname As String
    Private _ID As String
    Private _qualification As String
    Private _schoolName As String
    Private _schoolID As String



    Public Property name() As String
        Get
            Return _name
        End Get
        Set(value As String)
            _name = value
        End Set
    End Property

    Public Property surname() As String
        Get
            Return _surname
        End Get
        Set(value As String)
            _surname = value
        End Set
    End Property

    Public Property ID() As String
        Get
            Return _ID
        End Get
        Set(value As String)
            _ID = value
        End Set
    End Property

    Public Property qualification() As String
        Get
            Return _qualification
        End Get
        Set(value As String)
            _qualification = value

        End Set
    End Property

    Public Property schoolName() As String
        Get
            Return _schoolName
        End Get
        Set(value As String)
            _schoolName = value
        End Set
    End Property

    Public Property schoolID() As String
        Get
            Return _schoolID
        End Get
        Set(value As String)
            _schoolID = value
        End Set
    End Property

    Public Function display() As String
        Dim tempStr As String
        tempStr &= "Name : " & _name & Environment.NewLine
        tempStr &= "Surname : " & _surname & Environment.NewLine
        tempStr &= "ID : " & _ID & Environment.NewLine
        tempStr &= "Qualification : " & _qualification & Environment.NewLine
        tempStr &= "School : " & _schoolName & Environment.NewLine

        Return tempStr
    End Function
End Class
