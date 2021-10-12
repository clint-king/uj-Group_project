<Serializable> Public Class Gadgets

    Private name As String
    Private numOfGadgets As Integer
    Private Const gurantee As String = "6 moths "

    Private Const phone As String = "Phone"
    Private Const tablet As String = "Tablet"
    Private Const pc As String = "Compter/Laptop"

    Private Shared nPhones As Integer
    Private Shared nTablets As Integer
    Private Shared nPcs As Integer

    Public Sub New(typeOfGadgets As String, numOfGadgets As Integer)

        Me.numOfGadgets = numOfGadgets

        If (typeOfGadgets = phone) Then
            nPhones += numberOfGadgets
        ElseIf (typeOfGadgets = tablet) Then

            nTablets += numOfGadgets

        ElseIf (typeOfGadgets = pc) Then

            nPcs += numOfGadgets
        End If
    End Sub


    Public Property nameOfGadget() As String
        Get
            Return name
        End Get
        Set(value As String)
            name = value
        End Set
    End Property

    Public ReadOnly Property numberOfGadgets() As Integer
        Get
            Return Me.numOfGadgets
        End Get
    End Property

    Public ReadOnly Property guranteePro() As String
        Get
            Return gurantee
        End Get
    End Property

    Public ReadOnly Property NumberOfPhones() As Integer
        Get
            Return nPhones
        End Get
    End Property

    Public ReadOnly Property NumberOfTablets() As Integer
        Get
            Return nTablets
        End Get
    End Property

    Public ReadOnly Property NumberOfPc() As Integer
        Get
            Return nPcs
        End Get
    End Property
End Class
