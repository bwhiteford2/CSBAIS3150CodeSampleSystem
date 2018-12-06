
Partial Class DeleteStudent
    Inherits System.Web.UI.Page

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load

    End Sub
    Protected Sub SubmitButton_Click(sender As Object, e As EventArgs)
        Dim RequestDirector As New BCS()

        ' TEST DATA
        Dim EnrolledStudent As Student = RequestDirector.FindStudent(DeleteStudentTextBox.Text)

        'ask how he wants to validate found student
        If EnrolledStudent.StudentID IsNot Nothing Then
            ' Modify Student     


            Dim confirmation As Boolean = RequestDirector.RemoveStudent(DeleteStudentTextBox.Text)

            If confirmation Then
                MessageLabel.Text = ("Remove student successful")
            Else
                MessageLabel.Text = ("Remove student unsuccessful")
            End If

        Else 'else to enrolled student is not nothing
            MessageLabel.Text = ("Student not found")
        End If
    End Sub
End Class
