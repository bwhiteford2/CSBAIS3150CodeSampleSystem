using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FindStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        BCS RequestDirector = new BCS();

        try
        {
            Student enrolledStudent = RequestDirector.FindStudent(FindStudentTextBox.Text);

            if (!string.IsNullOrEmpty(enrolledStudent.FirstName))
            {
                MessageLabel.Text = "";
                Panel1.Visible = true;                
                FirstName.Text = enrolledStudent.FirstName;
                LastName.Text = enrolledStudent.LastName;
                Email.Text = enrolledStudent.Email;
                FindStudentTextBox.Text = "";
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
}