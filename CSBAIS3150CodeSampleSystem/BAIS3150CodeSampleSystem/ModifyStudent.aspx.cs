using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModifyStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void FindStudentButton_Click(object sender, EventArgs e)
    {
        BCS RequestDirector = new BCS();

        Student EnrolledStudent = RequestDirector.FindStudent(StudentIdTextBox.Text);
        FirstNameTextBox.Text = EnrolledStudent.FirstName;
        LastNameTextBox.Text = EnrolledStudent.LastName;
        EmailTextBox.Text = EnrolledStudent.Email;
        Panel1.Visible = true;
    }

    protected void ModifyStudentButton_Click(object sender, EventArgs e)
    {
        BCS RequestDirector = new BCS();

        Student EnrolledStudent = new Student();
        EnrolledStudent.StudentId = StudentIdTextBox.Text;
        EnrolledStudent.FirstName = FirstNameTextBox.Text;
        EnrolledStudent.LastName = LastNameTextBox.Text;
        EnrolledStudent.Email = EmailTextBox.Text;

        bool confirmation = RequestDirector.ModifyStudent(EnrolledStudent);

        if (confirmation)
            MessageLabel.Text = ("Changed Successfully");
        else
            MessageLabel.Text = ("Change unsuccessful");
    }

}