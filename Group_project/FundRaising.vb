<Serializable> Public Class Fundraising

    Private _Name As String 'Fundraiser Name
    Private _aim As String
    Private _NumTickets As Integer
    Private _Tickets() As Ticket 'Has-A
    ' Private Shared _ID As Integer 'ID 
    Private _location As String 'Where Fundraising is taking place
    Private _Amount As Double
    Private _FundsAimed As Double ' Funds Aimed 
    Private _price As Double
    ' Private _BankAcc As Integer 'Account Number
    ' Private _BankBalance As Double 'Balance


    Public Sub New(Name As String, NumTickets As Integer, Location As String, TicketTitle As String, Price As Integer)

        _Name = Name
        _NumTickets = NumTickets
        ReDim _Tickets(NumTickets)
        For c As Integer = 1 To NumTickets
            _Tickets(c) = New Ticket(TicketTitle, Price)
        Next
        _location = Location
        _price = Price


    End Sub


    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(value As String)
            _Name = value
        End Set
    End Property

    Public Property aimPro() As String
        Get
            Return _aim
        End Get
        Set(value As String)
            _aim = value
        End Set
    End Property

    Public Property amountPro() As Double
        Get
            Return _Amount
        End Get
        Set(value As Double)
            _Amount = value
        End Set
    End Property
    Public Property Tickets() As Ticket()
        Get
            Return _Tickets
        End Get
        Set(value As Ticket())
            _Tickets = value
        End Set
    End Property

    Public Property School() As String
        Get
            Return _location
        End Get
        Set(value As String)
            _location = value
        End Set
    End Property

    Public Property FundsAimed() As Double
        Get
            Return _FundsAimed
        End Get
        Set(value As Double)
            _FundsAimed = value
        End Set
    End Property

    Public Property NumTickets() As Integer
        Get
            Return _NumTickets
        End Get
        Set(value As Integer)
            _NumTickets = value
        End Set
    End Property
    ' I have not used this function
    Public Function AfterSell(count As Integer) As String
        Dim show As String
        show &= "Ticket No. : " & _Tickets(count).ID & Environment.NewLine
        show &= "Tag : " & _Tickets(count).Tag & Environment.NewLine
        show &= "Price :" & _Tickets(count).Price & Environment.NewLine

        Return show
    End Function

    Public Function BankAccDetails() As String
        Dim info As String

        _NumTickets -= 1
        _Amount += _price
        info &= "Bank Name : FNB" & Environment.NewLine
        info &= "Account Name : EducateAfrica Charity " & Environment.NewLine
        info &= "Account Number : 11165309368" & Environment.NewLine
        info &= "Reference : ZXt342Ct" & Environment.NewLine

        ReDim Preserve _Tickets(_NumTickets)

        Return info
    End Function

    Public Sub PaypalEasy()


        _NumTickets -= 1
        _Amount += _price
        ReDim Preserve _Tickets(_NumTickets)

    End Sub

    'display

    Public Function Display() As String
        Dim show As String


        show &= "Name of Fundraiser : " & Name & Environment.NewLine
        show &= "Aim : " & _aim & Environment.NewLine
        show &= "AmountAimed : $" & FundsAimed & Environment.NewLine
        show &= "N0. Tickets Available : " & _NumTickets & Environment.NewLine
        show &= "Price : " & _price & Environment.NewLine

        Return show
    End Function



End Class
