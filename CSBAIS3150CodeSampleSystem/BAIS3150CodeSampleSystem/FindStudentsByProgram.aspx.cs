using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FindStudentsByProgram : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {

        BCS requestDirector = new BCS();
        Program program = requestDirector.FindProgram(FindStudentsByProgramTextBox.Text);

        TableHeaderRow HeaderRow = new TableHeaderRow();


        TableHeaderCell StudentIDHeaderCell = new TableHeaderCell();
        StudentIDHeaderCell.Text = "Student ID";
        HeaderRow.Cells.Add(StudentIDHeaderCell);

        TableHeaderCell FirstNameHeaderCell = new TableHeaderCell();
        FirstNameHeaderCell.Text = "First Name";
        HeaderRow.Cells.Add(FirstNameHeaderCell);

        TableHeaderCell LastNameHeaderCell = new TableHeaderCell();
        LastNameHeaderCell.Text = "Last Name";
        HeaderRow.Cells.Add(LastNameHeaderCell);

        TableHeaderCell EmailHeaderCell = new TableHeaderCell();
        EmailHeaderCell.Text = "Email Address";
        HeaderRow.Cells.Add(EmailHeaderCell);

        StudentTable.Rows.Add(HeaderRow);

        foreach (Student student in program.EnrolledStudents)
        {
            // Create a TableRow for each student
            TableRow StudentTableRow = new TableRow();
            // Create a TableCell for each property of a Student
            // and add the TableCell to the TableRow
            TableCell StudentIDCell = new TableCell();
            // StudentIDCell.BorderStyle = BorderStyle.Inset
            StudentIDCell.Text = student.StudentId;
            StudentTableRow.Cells.Add(StudentIDCell);
            TableCell FirstNameCell = new TableCell();
            FirstNameCell.Text = student.FirstName;
            StudentTableRow.Cells.Add(FirstNameCell);
            TableCell LastNameCell = new TableCell();
            LastNameCell.Text = student.LastName;
            StudentTableRow.Cells.Add(LastNameCell);
            TableCell EmailCell = new TableCell();
            EmailCell.Text = student.Email;
            StudentTableRow.Cells.Add(EmailCell);
            // Add the TableRow to the Table
            StudentTable.Rows.Add(StudentTableRow);

        }

    }
}