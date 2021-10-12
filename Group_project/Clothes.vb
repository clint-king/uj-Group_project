<Serializable> Public Class Clothes
    Private Const shirts As String = "Shirts"
    Private Const trousers As String = "Trousers"
    Private Const shoes As String = "Shoes"

    Private Shared nShirts As Integer
    Private Shared nShoes As Integer
    Private Shared nTrousers As Integer


    Public Sub New(type As String, numberOfTypes As Integer)


        If (type = "Shirts") Then
            nShirts += numberOfTypes
        ElseIf (type = "Trousers") Then

            nTrousers += numberOfTypes

        ElseIf (type = "Shoes") Then
            nShoes += numberOfTypes
        End If

    End Sub


    Public ReadOnly Property NumberOfShirts() As Integer
        Get
            Return nShirts
        End Get
    End Property

    Public ReadOnly Property NumberOfTrousers() As Integer
        Get
            Return nTrousers
        End Get
    End Property


End Class
