Imports Microsoft.VisualBasic

Public Class BCS

    Public Function CreateProgram(ProgramCode As String, Description As String) As Boolean
        Dim ProgramManager As Programs = New Programs()
        Dim Confirmation As Boolean = ProgramManager.AddProgram(ProgramCode, Description)

        Return Confirmation
    End Function

    Public Function EnrollStudent(AcceptedStudent As Student, ProgramCode As String) As Boolean
        Dim StudentManager As Students = New Students()
        Dim Confirmation As Boolean = StudentManager.AddStudent(AcceptedStudent, ProgramCode)

        Return Confirmation
    End Function

    Public Function FindStudent(StudentID As String) As Student
        Dim StudentManager As Students = New Students()
        Dim EnrolledStudent As Student = StudentManager.GetStudent(StudentID)

        Return EnrolledStudent
    End Function

    Public Function ModifyStudent(EnrolledStudent As Student) As Integer
        Dim StudentManager As Students = New Students()
        Dim Success = StudentManager.UpdateStudent(EnrolledStudent)

        Return Success
    End Function

    Public Function RemoveStudent(StudentID As String) As Boolean
        Dim StudentManager As Students = New Students()
        Dim Success = StudentManager.DeleteStudent(StudentID)

        Return Success
    End Function

    Public Function FindProgram(ProgramCode As String) As Program
        Dim ProgramManager As Programs = New Programs()
        Dim ActiveProgram = ProgramManager.GetProgram(ProgramCode)
        Return ActiveProgram
    End Function
End Class
