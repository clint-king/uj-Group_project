Option Strict On
Option Explicit On
Option Infer Off


<Serializable> Public Class Items
    Inherits DonationClass

    Private food() As Food
    Private gadgets() As Gadgets
    Private clothes() As Clothes
    Private Shared numberOfItems As Integer
    Private itemChosen As String
    Private itemType As String
    Public Sub New(nameOfItem As String, type As String, numberOfItem As Integer)
        MyBase.New(nameOfItem)
        itemChosen = nameOfItem
        itemType = type
        If (nameOfItem = "Food") Then

            ReDim food(numberOfItem)
            For x As Integer = 1 To numberOfItem
                food(x) = New Food(type, numberOfItem)
            Next

        ElseIf (nameOfItem = "Gadgets") Then
            ReDim gadgets(numberOfItem)

            For x As Integer = 1 To numberOfItem
                gadgets(x) = New Gadgets(type, numberOfItem)

            Next

        ElseIf (nameOfItem = "Clothes") Then
            ReDim clothes(numberOfItem)

            For x As Integer = 1 To numberOfItem
                clothes(x) = New Clothes(type, numberOfItems)
            Next
        End If

        numberOfItems += 1
    End Sub

    Public Sub New(money As String)
        MyBase.New(money)

        itemChosen = money
    End Sub
    Public Property gadgetsPro() As Gadgets()
        Get
            Return gadgets
        End Get
        Set(value As Gadgets())
            gadgets = value
        End Set
    End Property

    Public Function ShippingDetails() As String
        Dim info As String
        info &= "ADRESS" & Environment.NewLine
        info &= "EducateAfrica Charity" & Environment.NewLine
        info &= "Ellis park st 128, Doorfontein" & Environment.NewLine
        info &= "johannesburg ,2094 " & Environment.NewLine
        info &= "South Africa " & Environment.NewLine

        Return info
    End Function


    Public Overrides Sub paypalEasy(amount As Double)
        amountNeeded += (amount * 2)

        MyBase.PaypalEasy(amount)

    End Sub
    Public Overrides Function BankAccDetails(amount As Double) As String
        Dim info As String
        info &= "Bank Name : Standard Bank" & Environment.NewLine
        info &= "Account Name : EducateAfrica Charity " & Environment.NewLine
        info &= "Account Number : 00005309368" & Environment.NewLine
        info &= "Reference : OXt342Ct" & Environment.NewLine

        amountNeeded += amount
        Return info
    End Function





End Class
