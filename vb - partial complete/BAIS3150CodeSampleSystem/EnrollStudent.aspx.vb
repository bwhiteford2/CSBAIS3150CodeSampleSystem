
Partial Class EnrollStudent
    Inherits System.Web.UI.Page

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load



    End Sub
    Protected Sub Submit_Click(sender As Object, e As EventArgs)


        Dim AcceptedStudent As New Student()
        AcceptedStudent.StudentID = StudentIdTextBox.Text
        AcceptedStudent.FirstName = FirstNameTextBox.Text
        AcceptedStudent.LastName = LastNameTextBox.Text
        AcceptedStudent.Email = EmailTextBox.Text
        Dim ProgramCode As String = ProgramDropDownList.SelectedValue

        Dim Confirmation As Boolean

        Dim RequestDirector As New BCS()
        Confirmation = RequestDirector.EnrollStudent(AcceptedStudent, ProgramCode)

        If Confirmation Then
            MessagesLabel.Text = ("Add student was successful")
        Else
            MessagesLabel.Text = ("Add student was not successful")
        End If

    End Sub
End Class
