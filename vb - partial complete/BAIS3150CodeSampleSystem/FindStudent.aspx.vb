
Partial Class FindStudent
    Inherits System.Web.UI.Page

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load


    End Sub
    Protected Sub Submit_Click(sender As Object, e As EventArgs)
        Dim RequestDirector As New BCS()

        Dim enrolledStudent = RequestDirector.FindStudent(FindStudentTextBox.Text)

        If Not String.IsNullOrEmpty(enrolledStudent.FirstName) Then
            MessageLabel.Text = (enrolledStudent.FirstName & " " & enrolledStudent.LastName & " <br />" & enrolledStudent.Email)
        Else
            MessageLabel.Text = ("Student not found")
        End If
    End Sub
End Class
