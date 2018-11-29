using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EnrollStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {

        Student AcceptedStudent = new Student();
        AcceptedStudent.StudentId = StudentIdTextBox.Text;
        AcceptedStudent.FirstName = FirstNameTextBox.Text;
        AcceptedStudent.LastName = LastNameTextBox.Text;
        AcceptedStudent.Email = EmailTextBox.Text;
        string ProgramCode = ProgramTextBox.Text;

        bool Confirmation;
        try
        {
            BCS RequestDirector = new BCS();
            Confirmation = RequestDirector.EnrollStudent(AcceptedStudent, ProgramCode);

            if (Confirmation)
            {
                MessagesLabel.Visible = true;
                MessagesLabel.ForeColor = System.Drawing.Color.Green;
                MessagesLabel.Text = ("Add student was successful");

                StudentIdTextBox.Text = "";
                FirstNameTextBox.Text = "";
                LastNameTextBox.Text = "";
                EmailTextBox.Text = "";
                ProgramTextBox.Text = "";
            }
            else
            {
                MessagesLabel.ForeColor = System.Drawing.Color.Red;
                MessagesLabel.Visible = true;
                MessagesLabel.Text = ("Add student was not successful");
            }
        }
        catch (Exception ex)
        {
            MessagesLabel.Visible = true;
            //MessagesLabel.Text = ex.Message + "<br />"; this line looks ugly when the message is too long, look into this later
            MessagesLabel.Text = ("Add student was not successful");
            MessagesLabel.ForeColor = System.Drawing.Color.DarkRed;
        }
        
            
    }
}