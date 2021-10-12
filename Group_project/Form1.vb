'******************************************************************************
'
Option Explicit On
Option Strict On
Option Infer Off

Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Public Class frmCharity
    Private train As Training
    Private num As Integer
    'For training
    Private count As Integer
    Private fs As FileStream
    Private bf As BinaryFormatter

    'for donation
    Private donate() As DonationClass
    Private Const fileConstr As String = "Construction.imf"
    Private Const fileItem As String = "Items.imf"
    Private CountI As Integer
    'for fundRaising
    Private Const filefund As String = "fundRaising.imf"
    Private numf As Integer
    Private fundR() As Fundraising
    Private checker As Boolean = False

    Private Sub frmCharity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReDim donate(10)
        loadConstruction()
        loadEvents()
        train = New Training()
    End Sub



    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        count = count + 1
        Dim name As String
        Dim surname As String
        Dim ID As String
        Dim qualification As String
        Dim schoolName As String
        Dim schoolID As String
        ReDim Preserve train.applicantsPro(count)

        train.applicantsPro(count) = New ApplicantsAccepted
        name = InputBox("Enter your name : ", "Name ")
        surname = InputBox("Enter your surname : ", "Surname")
        ID = InputBox("Enter your ID", "ID")
        qualification = InputBox("Enter your qualification (Eg. Mathematics teacher  , physics teacher) ", "Qualification")
        schoolName = InputBox("Enter your School Name : ", "School Name")
        schoolID = InputBox("Enter the school ID : ", "School ID")



        'checking for accpetance 

        If Not (train.findSchool(schoolName, schoolID) Is Nothing) Then

            train.applicantsPro(count).name = name
            train.applicantsPro(count).surname = surname
            train.applicantsPro(count).ID = ID
            train.applicantsPro(count).qualification = qualification
            train.applicantsPro(count).schoolName = schoolName
            train.applicantsPro(count).schoolID = schoolID

            train.saveApplicants(train.applicantsPro(count))

            MessageBox.Show("Your application has been sent to the Training institution . Results will be sent to you in two weeks time")
        Else
            MessageBox.Show("we are sorry to inform you that your application is not sent . The school you have entered is not in our database please  ")
        End If


    End Sub



    'This can be used in data display
    Private Sub listApplicants()

        Dim applicant As ApplicantsAccepted
        fs = New FileStream(train.fileApplicantsName, FileMode.Open, FileAccess.Read)
        bf = New BinaryFormatter()

        While fs.Position < fs.Length
            applicant = DirectCast(bf.Deserialize(fs), ApplicantsAccepted)
            txtDisplay.Text &= applicant.display & Environment.NewLine
        End While
    End Sub


    'Donation 

    Public Sub loadConstruction()



        fs = New FileStream(fileConstr, FileMode.Create, FileAccess.Write)
        bf = New BinaryFormatter()
        'if you change the number of donations here you should also change the loop count at item for donation
        donate(1) = New Construction("Sasekani Primary School", "4xlB3", "Limpopo , Giyani", "ClassRoom")
        donate(1).amountNeeded = 200000

        donate(2) = New Construction("Lusaka Primary School", "5xlB4", "Malawi , Mzuzu ", "Sports ground")
        donate(2).amountNeeded = 200000

        donate(3) = New Construction("St George Promary School", "6xlB5", "Congo , Kasai", "Lab Room")
        donate(3).amountNeeded = 300000

        donate(4) = New Construction("Achieve Primary School ", "7xlB6", "Nigeria , Kabba", "ClassRoom")
        donate(4).amountNeeded = 110000

        donate(5) = New Construction("Masvingo Primary school", "8xlB7", "Zimbabwe , Masvingo", "Build new School")
        donate(5).amountNeeded = 500000

        For x As Integer = 1 To 5
            bf.Serialize(fs, donate(x))

        Next

        fs.Close()
    End Sub
    Private Sub btnDonate_Click(sender As Object, e As EventArgs) Handles btnDonate.Click
        Dim choice As Integer
        num += 1
        Dim don As Construction

        fs = New FileStream(fileConstr, FileMode.Open, FileAccess.Read)
        bf = New BinaryFormatter()

        If Not (num Mod 2 = 0) Then
            choice = CInt(InputBox("Choose what you want to donate to :" & Environment.NewLine & " 1 - Construction " & Environment.NewLine & "2-Donate clothes/Food(or money for us to buy clothes and food for the children)"))
        End If


        If (choice = 2) Then

            ItemsActivated()

        Else

            txtDisplay.Text = " "
            For x As Integer = 1 To 5
                don = DirectCast(bf.Deserialize(fs), Construction)
                txtDisplay.Text &= "Project Number : " & x & Environment.NewLine & don.Display & Environment.NewLine
                txtDisplay.Text &= "*************************************************" & Environment.NewLine
            Next

            fs.Close()

            If Not (num Mod 2 = 0) Then
                MessageBox.Show("Press again to enter details")
            End If

            If (num Mod 2 = 0) Then
                Dim chooseP As Integer
                Dim paymentMethod As Integer
                Dim amount As Double
                Dim pin As String
                chooseP = CInt(InputBox("Which project do you wish to donate to (Enter the project number): ", "Project choice"))
                paymentMethod = CInt(InputBox("Choose paying Method : " & Environment.NewLine & "1- Bank Account details " & Environment.NewLine & "2- PayPalEasy"))
                amount = CInt(InputBox("Enter the amount you want to donate "))
                txtDisplay.Text = " "
                If (chooseP = 1) Then

                    If (paymentMethod = 1) Then
                        txtDisplay.Text = donate(1).BankAccDetails(amount) & Environment.NewLine
                        MessageBox.Show(" Thank you for helping we appreciate your effort")
                    Else
                        pin = InputBox("Enter paypalEasy Pin")
                        donate(1).PaypalEasy(amount)
                        MessageBox.Show(" Thank you for helping we appreciate your effort")
                    End If


                ElseIf (chooseP = 2) Then

                    If (paymentMethod = 1) Then
                        txtDisplay.Text &= donate(2).BankAccDetails(amount) & Environment.NewLine
                        MessageBox.Show(" Thank you for helping we appreciate your effort")
                    Else
                        pin = InputBox("Enter paypalEasy Pin")
                        donate(2).PaypalEasy(amount)
                        MessageBox.Show(" Thank you for helping we appreciate your effort")
                    End If


                ElseIf (chooseP = 3) Then
                    If (paymentMethod = 1) Then
                        txtDisplay.Text &= donate(3).BankAccDetails(amount) & Environment.NewLine
                        MessageBox.Show(" Thank you for helping we appreciate your effort")
                    Else
                        pin = InputBox("Enter paypalEasy Pin")
                        donate(3).PaypalEasy(amount)
                        MessageBox.Show(" Thank you for helping we appreciate your effort")
                    End If
                ElseIf (chooseP = 4) Then
                    If (paymentMethod = 1) Then
                        txtDisplay.Text &= donate(4).BankAccDetails(amount) & Environment.NewLine
                        MessageBox.Show(" Thank you for helping we appreciate your effort")
                    Else
                        pin = InputBox("Enter paypalEasy Pin")
                        donate(4).PaypalEasy(amount)
                        MessageBox.Show(" Thank you for helping we appreciate your effort")
                    End If


                ElseIf (chooseP = 5) Then
                    If (paymentMethod = 1) Then
                        txtDisplay.Text &= donate(5).BankAccDetails(amount) & Environment.NewLine
                        MessageBox.Show(" Thank you for helping we appreciate your effort")
                    Else
                        pin = InputBox("Enter paypalEasy Pin")
                        donate(5).PaypalEasy(amount)
                        MessageBox.Show(" Thank you for helping we appreciate your effort")
                    End If
                End If

                loadConstruction()
            End If
        End If
    End Sub

    'Items

    Public Sub ItemsActivated()
        Dim Ilevel1 As Integer
        Dim Ilevel2 As Integer
        Dim nameOfFood As String
        Dim num As Integer
        Dim loopNum As Integer
        Dim diffItems As Integer
        Dim typeCl As String

        Dim now As Integer
        Dim typeGd As String
        Dim gadgetName As String
        Dim payment As Integer
        fs = New FileStream(fileItem, FileMode.Create, FileAccess.Write)
        bf = New BinaryFormatter()

        diffItems = CInt(InputBox("How many different types/categories Of Items do you want to donate amongst clothes , food , gadgets , money [e.g answer = 2 (being clothes , gadgets),YOU CANNOT EXCEED 4 *] "))

        For c As Integer = 1 To diffItems

            Ilevel1 = CInt(InputBox("choose the type of Item you want to donate (You can donate money for us to buy the Items for the children) : " & Environment.NewLine & "1-Food , 2-Clothes , 3-Gadgets , 4-donate money"))

            'Food
            If (Ilevel1 = 1) Then
                loopNum = CInt(InputBox("How many different foods do you want to donate"))

                'countI prevents repetition of indexes
                ReDim Preserve donate(6 + loopNum + CountI)

                For x As Integer = (6 + CountI) To (6 + loopNum + CountI) - 1

                    nameOfFood = InputBox("What is the name of the food you want to donate : ", " Food " & (x - 5 - CountI))
                    num = CInt(InputBox("How many " & nameOfFood))


                    donate(x) = New Items("Food", nameOfFood, num)
                    'Payment Method

                    bf.Serialize(fs, donate(x))

                Next x
                CountI += loopNum

            End If
            'clothes
            If (Ilevel1 = 2) Then
                loopNum = CInt(InputBox("How many different types clothes do you want to donate"))
                ReDim Preserve donate(6 + loopNum + CountI)
                For x As Integer = (6 + CountI) To (6 + loopNum + CountI) - 1


                    Ilevel2 = CInt(InputBox("Enter the type of Item you want to donate (1-Shirts , 2-Shoes , 3-Trousers)", "Item type " & (x - 5 - CountI)))

                    If (Ilevel2 = 1) Then
                        typeCl = "Shirts"
                    ElseIf (Ilevel2 = 2) Then
                        typeCl = "Shoes"
                    Else
                        typeCl = "Trousers"
                    End If

                    num = CInt(InputBox("How many " & typeCl))

                    donate(x) = New Items("Clothes", typeCl, num)

                    bf.Serialize(fs, donate(x))


                Next x


                CountI += loopNum


            End If

            'Gadgets
            If (Ilevel1 = 3) Then

                loopNum = CInt(InputBox("How many different  types of of Gadgets you want to donate"))
                ReDim Preserve donate(6 + loopNum + CountI)
                For x As Integer = 6 + CountI To (6 + loopNum + CountI) - 1

                    Ilevel2 = CInt(InputBox("Enter the type of Gadget/s you want to donate(1-Phone , 2-Tablet , 3-Computer/laptop ", "Gadget " & (x - 5 - CountI)))
                    gadgetName = InputBox("Enter the name of the Gadget")

                    If (Ilevel2 = 1) Then
                        typeGd = "Phone"

                    ElseIf (Ilevel2 = 2) Then
                        typeGd = "Tablet"
                    Else
                        typeGd = "Computer/Laptop"
                    End If
                    Dim converter As Items
                    num = CInt(InputBox("How many " & typeGd))

                    donate(x) = New Items("Gadgets", typeGd, num)

                    converter = TryCast(donate(x), Items)

                    For i As Integer = 1 To num
                        converter.gadgetsPro(i).nameOfGadget = gadgetName
                    Next i

                    bf.Serialize(fs, converter)
                Next x

                CountI += loopNum
            End If

            Dim amount As Double
            Dim pin As String

            If (Ilevel1 = 4) Then
                ReDim Preserve donate(6 + CountI + 1)

                payment = CInt(InputBox("Choose paying Method : " & Environment.NewLine & "1- Bank Account details " & Environment.NewLine & "2- PayPalEasy"))
                amount = CInt(InputBox("Enter the amount you want to donate "))
                donate(6 + CountI + 1) = New Items("Money")
                If (payment = 1) Then

                    txtDisplay.Text &= donate(6 + CountI + 1).BankAccDetails(amount) & Environment.NewLine


                Else

                    pin = InputBox("Enter paypalEasy Pin")
                    donate(6 + CountI + 1).PaypalEasy(amount)


                End If

                bf.Serialize(fs, donate(6 + CountI + 1))
                CountI += 1
            End If
        Next c
        MessageBox.Show(" Thank you for helping we appreciate your effort")
    End Sub

    'FundRaising 
    'LOadEvents
    Private Sub loadEvents()
        ReDim fundR(3)
        fs = New FileStream(filefund, FileMode.Create, FileAccess.Write)
        bf = New BinaryFormatter()



        fundR(1) = New Fundraising("Runners", 20000, "South Africa , Gauteng", "A1", 20)
        fundR(1).FundsAimed = 2000000
        fundR(1).aimPro = "buid a School in khigali "

        fundR(2) = New Fundraising("Runners", 22000, "America , New York", "A2", 20)
        fundR(2).FundsAimed = 1000000
        fundR(2).aimPro() = "For food parcels that will be destributed across Africa"

        fundR(3) = New Fundraising("Runners", 10000, "Nigeria , Abuja", "A3", 20)
        fundR(3).FundsAimed = 2500000
        fundR(3).aimPro() = "For clothes that will be distributed across Africa"
        For x As Integer = 1 To 3

            bf.Serialize(fs, fundR(x))
        Next

        fs.Close()

    End Sub

    Private Sub btnEvents_Click(sender As Object, e As EventArgs) Handles btnEvents.Click
        Dim chooseE As Integer
        Dim paymentMethodE As Integer
        Dim pinE As String
        Dim email As String
        numf += 1
        Dim fund As Fundraising

        fs = New FileStream(filefund, FileMode.Open, FileAccess.Read)
        bf = New BinaryFormatter()

        txtDisplay.Text = " "
        For x As Integer = 1 To 3
            fund = DirectCast(bf.Deserialize(fs), Fundraising)
            txtDisplay.Text &= "Event number: " & x & Environment.NewLine & fund.Display & Environment.NewLine
            txtDisplay.Text &= "*************************************************" & Environment.NewLine
        Next

        fs.Close()

        If Not (numf Mod 2 = 0) Then
            MessageBox.Show("Press again to enter details")
        End If

        If (numf Mod 2 = 0) Then

            chooseE = CInt(InputBox("Which event do you wish to attend (Enter event number ): "))
            email = InputBox("Enter your email ", "Email")
            paymentMethodE = CInt(InputBox("Choose paying Method : " & Environment.NewLine & "1- Bank Account details " & Environment.NewLine & "2- PayPalEasy"))

            If (chooseE = 1) Then

                If (paymentMethodE = 1) Then

                    txtDisplay.Text = fundR(1).BankAccDetails() & Environment.NewLine
                    MessageBox.Show(" Thank you for helping we appreciate your effort. Ticket details will be sent to your email")
                Else
                    pinE = InputBox("Enter paypalEasy Pin")

                    fundR(1).PaypalEasy()
                    MessageBox.Show(" Thank you for helping we appreciate your effort.Ticket details will be sent to your email")
                End If
            End If
            If (chooseE = 2) Then

                If (paymentMethodE = 1) Then

                    txtDisplay.Text = fundR(2).BankAccDetails() & Environment.NewLine
                    MessageBox.Show(" Thank you for helping we appreciate your effort. Ticket details will sent to your email")
                Else
                    pinE = InputBox("Enter paypalEasy Pin")

                    fundR(2).PaypalEasy()
                    MessageBox.Show(" Thank you for helping we appreciate your effort.Ticket details will be sent to your email")
                End If

            End If

            If (chooseE = 3) Then

                If (paymentMethodE = 1) Then

                    txtDisplay.Text = fundR(3).BankAccDetails() & Environment.NewLine
                    MessageBox.Show(" Thank you for helping we appreciate your effort. Ticket details will sent to your email")
                Else
                    pinE = InputBox("Enter paypalEasy Pin")

                    fundR(3).PaypalEasy()
                    MessageBox.Show(" Thank you for helping we appreciate your effort.Ticket details will be sent to your email")
                End If

            End If
        End If



        loadEvents()
    End Sub
End Class
