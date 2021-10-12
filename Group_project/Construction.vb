Option Explicit On
Option Strict On
Option Infer Off

<Serializable> Public Class Construction
    Inherits DonationClass

    Private _Project As String 'Examples: Building Classrooms, building sports grounds etc



    Public Sub New(schoolName As String, schoolID As String, location As String, project As String)
        MyBase.New(schoolName, schoolID, location)

        _Project = project
        amountNeeded = 2000000
    End Sub

    Public Property Project As String
        Get
            Return _Project
        End Get
        Set(value As String)
            _Project = value
        End Set
    End Property


    Public Overrides Function BankAccDetails(amount As Double) As String
        Dim info As String
        info &= "Bank Name : Standard Bank" & Environment.NewLine
        info &= "Account Name : EducateAfrica Charity " & Environment.NewLine
        info &= "Account Number : 38465309368" & Environment.NewLine
        info &= "Reference : BXt342Ct" & Environment.NewLine

        amountNeeded -= amount
        Return info
    End Function



    Public Function Display() As String
        Dim res As String

        res &= "School name : " & Name & Environment.NewLine
        res &= "School location : " & Location & Environment.NewLine
        res &= "School ID : " & ID & Environment.NewLine
        res &= "Project : " & _Project & Environment.NewLine
        res &= "MoneyNeeded : $" & amountNeeded & Environment.NewLine

        Return res
    End Function




End Class
