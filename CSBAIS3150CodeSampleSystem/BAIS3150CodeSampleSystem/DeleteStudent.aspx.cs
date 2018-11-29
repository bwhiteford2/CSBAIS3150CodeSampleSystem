using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        BCS RequestDirector = new BCS();
        

        try
        {
            Student enrolledStudent = RequestDirector.FindStudent(DeleteStudentTextBox.Text);

            if (!string.IsNullOrEmpty(enrolledStudent.FirstName))
            {
                MessageLabel.Text = "";
                Panel1.Visible = true;
                StudentId.Text = enrolledStudent.StudentId;
                FirstName.Text = enrolledStudent.FirstName;
                LastName.Text = enrolledStudent.LastName;
                Email.Text = enrolledStudent.Email;
                DeleteStudentTextBox.Text = "";
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


    protected void DeleteBtn_Click(object sender, EventArgs e)
    {
        BCS RequestDirector = new BCS();

        // this way is prone to user changing html and sending in wrong value, but saves a trip finding from db to verify again
        try
        {
            bool confirmation = RequestDirector.RemoveStudent(StudentId.Text);

            if (confirmation)
            {
                MessageLabel.Text = ("Remove student successful");
                Panel1.Visible = false;
            }
            else
            {
                MessageLabel.Text = ("Remove student unsuccessful");
                MessageLabel.ForeColor = System.Drawing.Color.DarkRed;
            }
           
        }
        catch (Exception ex)
        {
            MessageLabel.Text = ("Find student was not successful");

            MessageLabel.ForeColor = System.Drawing.Color.DarkRed;
        }

    }
}