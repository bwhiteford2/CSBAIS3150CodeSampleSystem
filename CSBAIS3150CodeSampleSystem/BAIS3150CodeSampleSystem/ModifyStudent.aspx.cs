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

        try
        {
            Student enrolledStudent = RequestDirector.FindStudent(StudentIdTextBox.Text);

            if (!string.IsNullOrEmpty(enrolledStudent.FirstName))
            {
                MessageLabel.Text = "";
                Panel1.Visible = true;

                StudentIdTB.Text = enrolledStudent.StudentId;
                FirstNameTextBox.Text = enrolledStudent.FirstName;
                LastNameTextBox.Text = enrolledStudent.LastName;
                EmailTextBox.Text = enrolledStudent.Email;
                StudentIdTextBox.Text = "";
            }
            else
            {
                Panel1.Visible = false;
                MessageLabel.Text = ("Student not found");
            }
        }
        catch (Exception)
        {
            Panel1.Visible = false;
            MessageLabel.Text = ("Find student was not successful");

            MessageLabel.ForeColor = System.Drawing.Color.DarkRed;
        }
    }

    protected void ModifyStudentButton_Click(object sender, EventArgs e)
    {
        BCS RequestDirector = new BCS();

        Student EnrolledStudent = new Student();
        EnrolledStudent.StudentId = StudentIdTB.Text;
        EnrolledStudent.FirstName = FirstNameTextBox.Text;
        EnrolledStudent.LastName = LastNameTextBox.Text;
        EnrolledStudent.Email = EmailTextBox.Text;

        try
        {
            bool confirmation = RequestDirector.ModifyStudent(EnrolledStudent);
            if (confirmation)
            {
                MessageLabel.Text = ("Changed Successfully");
                Panel1.Visible = false;
            }                
            else
            {
                MessageLabel.Text = ("Change unsuccessful");
            }                
        }
        catch (Exception ex)
        {
            MessageLabel.Text = "Change unsuccessful";
            
        }             
    }
}