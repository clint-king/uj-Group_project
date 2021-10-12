Option Strict On
Option Explicit On
Option Infer Off


<Serializable> Public MustInherit Class DonationClass
    Private _Name As String
    Private _ID As String
    Private _Location As String
    Private _amountNeeded As Double

    Public Sub New(name As String)
        _Name = name
    End Sub
    Public Sub New(name As String, ID As String, location As String)
        _Name = name
        _ID = ID
        _Location = location
    End Sub


    Public ReadOnly Property Name As String
        Get
            Return _Name
        End Get
    End Property

    Public ReadOnly Property ID As String
        Get
            Return _ID
        End Get
    End Property

    Public ReadOnly Property Location As String
        Get
            Return _Location
        End Get
    End Property

    Public Property amountNeeded() As Double
        Get
            Return _amountNeeded
        End Get
        Set(value As Double)
            _amountNeeded = value
        End Set
    End Property


    Public Overridable Sub PaypalEasy(amountSent As Double)

        _amountNeeded -= amountSent

    End Sub

    Public MustOverride Function BankAccDetails(amount As Double) As String





End Class
