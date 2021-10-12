Option Explicit On
Option Strict On
Option Infer Off
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary


<Serializable> Public Class Training


    Private Shared applicants() As ApplicantsAccepted
    Private schoolList() As School
    Private fs As FileStream
    Private bf As BinaryFormatter
    Private Const fileNamesch As String = "Schools.imf"
    Private Const fileNameAppl As String = "applicants.ifm"

    Public Sub New()

        loadSchools()
    End Sub



    Public ReadOnly Property fileApplicantsName() As String
        Get
            Return fileNameAppl
        End Get
    End Property

    Public ReadOnly Property fileSchoolName() As String
        Get
            Return fileNamesch
        End Get
    End Property

    Public Property applicantsPro() As ApplicantsAccepted()
            Get
                Return applicants
            End Get
            Set(value As ApplicantsAccepted())
                applicants = value
            End Set
        End Property

        Public Property schoolListPro() As School()
            Get
                Return schoolList
            End Get
            Set(value As School())
                schoolList = value
            End Set
        End Property

        Private Sub loadSchools()
            ReDim schoolList(5)

            fs = New FileStream(fileNamesch, FileMode.Create, FileAccess.Write)
            bf = New BinaryFormatter()


            'Schools info

            schoolList(1) = New School("Letaba", "3461clAB")
            schoolList(2) = New School("Excellent", "3471srZT")
            schoolList(3) = New School("Bright", "3481pjCR")
            schoolList(4) = New School("The Ridge", "3491kyQL")
            schoolList(5) = New School("St George", "3511wdEF")

            For x As Integer = 1 To 5
                bf.Serialize(fs, schoolList(x))
            Next

            fs.Close()
        End Sub

        Public Function findSchool(Schoolname As String, ID As String) As School
            Dim sch As School
            fs = New FileStream(fileNamesch, FileMode.Open, FileAccess.Read)
            bf = New BinaryFormatter()

            While fs.Position < fs.Length
                sch = DirectCast(bf.Deserialize(fs), School)

            If (sch.name.Equals(Schoolname)) Then

                If (sch.schoolId.Equals(ID)) Then
                    fs.Close()

                    Return sch
                End If


            End If
            End While

            Return Nothing
        End Function


        Public Function saveApplicants(applicant As ApplicantsAccepted) As Boolean
            fs = New FileStream(fileNameAppl, FileMode.Create, FileAccess.Write)
            bf = New BinaryFormatter()

            bf.Serialize(fs, applicant)
            fs.Close()
            Return True
        End Function

        Public Sub listApplicants()
            Dim applicant As ApplicantsAccepted
            fs = New FileStream(fileNameAppl, FileMode.Open, FileAccess.Read)
            bf = New BinaryFormatter()

            While fs.Position < fs.Length
                applicant = DirectCast(bf.Deserialize(fs), ApplicantsAccepted)
            End While

        End Sub
    End Class
