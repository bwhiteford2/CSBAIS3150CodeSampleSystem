
Partial Class ModifyStudent
    Inherits System.Web.UI.Page

    'Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
    '    Dim RequestDirector As New BCS()

    '    ' TEST DATA
    '    Dim EnrolledStudent As Student = RequestDirector.FindStudent(StudentIdTextBox.Text)

    '    'ask how he wants to validate found student
    '    If EnrolledStudent.StudentID IsNot Nothing Then
    '        ' Modify Student     

    '        EnrolledStudent.FirstName = "first test"
    '        EnrolledStudent.LastName = "still first test"

    '        Dim confirmation As Boolean = RequestDirector.ModifyStudent(EnrolledStudent)

    '        If confirmation Then
    '            Response.Write("Changed Successfully")
    '        Else
    '            Response.Write("Change unsuccessful")
    '        End If

    '    Else 'else to enrolled student is not nothing
    '        Response.Write("Student not found")
    '    End If

    'End Sub
    Protected Sub FindStudentButton_Click(sender As Object, e As EventArgs)
        Dim RequestDirector As New BCS()

        Dim EnrolledStudent As Student = RequestDirector.FindStudent(StudentIdTextBox.Text)
        FirstNameTextBox.Text = EnrolledStudent.FirstName
        LastNameTextBox.Text = EnrolledStudent.LastName
        EmailTextBox.Text = EnrolledStudent.Email
        Panel1.Visible = True

    End Sub
    Protected Sub ModifyStudentButton_Click(sender As Object, e As EventArgs)
        Dim RequestDirector As New BCS()

        Dim EnrolledStudent As New Student()
        EnrolledStudent.StudentID = StudentIdTextBox.Text
        EnrolledStudent.FirstName = FirstNameTextBox.Text
        EnrolledStudent.LastName = LastNameTextBox.Text
        EnrolledStudent.Email = EmailTextBox.Text

        Dim confirmation As Boolean = RequestDirector.ModifyStudent(EnrolledStudent)

        If confirmation Then
            MessageLabel.Text = ("Changed Successfully")
        Else
            MessageLabel.Text = ("Change unsuccessful")
        End If

    End Sub
End Class
