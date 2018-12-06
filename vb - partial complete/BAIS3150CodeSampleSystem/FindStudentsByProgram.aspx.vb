
Partial Class FindStudentsByProgram
    Inherits System.Web.UI.Page

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load

    End Sub


    Protected Sub Submit_Click(sender As Object, e As EventArgs)
        Dim requestDirector As New BCS()
        Dim program As Program = requestDirector.FindProgram(FindStudentsByProgramTextBox.Text)

        Response.Write(program.ProgramCode & "<br />")
        Response.Write(program.Description & "<br />")

        Dim HeaderRow As TableHeaderRow = New TableHeaderRow()

        Dim StudentIDHeaderCell As TableHeaderCell = New TableHeaderCell()
        StudentIDHeaderCell.Text = "Student ID"
        HeaderRow.Cells.Add(StudentIDHeaderCell)

        Dim FirstNameHeaderCell As TableHeaderCell = New TableHeaderCell()
        FirstNameHeaderCell.Text = "First Name"
        HeaderRow.Cells.Add(FirstNameHeaderCell)

        Dim LastNameHeaderCell As TableHeaderCell = New TableHeaderCell()
        LastNameHeaderCell.Text = "Last Name"
        HeaderRow.Cells.Add(LastNameHeaderCell)

        Dim EmailHeaderCell As TableHeaderCell = New TableHeaderCell()
        EmailHeaderCell.Text = "Email Address"
        HeaderRow.Cells.Add(EmailHeaderCell)

        StudentTable.Rows.Add(HeaderRow)

        For Each student In program.EnrolledStudents
            ' Create a TableRow for each student
            Dim StudentTableRow As TableRow = New TableRow()
            ' Create a TableCell for each property of a Student
            ' and add the TableCell to the TableRow
            Dim StudentIDCell As TableCell = New TableCell()
            'StudentIDCell.BorderStyle = BorderStyle.Inset
            StudentIDCell.Text = student.StudentID
            StudentTableRow.Cells.Add(StudentIDCell)
            Dim FirstNameCell As TableCell = New TableCell()
            FirstNameCell.Text = student.FirstName
            StudentTableRow.Cells.Add(FirstNameCell)
            Dim LastNameCell As TableCell = New TableCell()
            LastNameCell.Text = student.LastName
            StudentTableRow.Cells.Add(LastNameCell)
            Dim EmailCell As TableCell = New TableCell()
            EmailCell.Text = student.Email
            StudentTableRow.Cells.Add(EmailCell)
            ' Add the TableRow to the Table
            StudentTable.Rows.Add(StudentTableRow)
        Next
    End Sub
End Class
