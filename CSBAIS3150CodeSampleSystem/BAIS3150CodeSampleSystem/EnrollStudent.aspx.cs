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
        string ProgramCode = ProgramDropDownList.SelectedValue;

        bool Confirmation;

        BCS RequestDirector = new BCS();
        Confirmation = RequestDirector.EnrollStudent(AcceptedStudent, ProgramCode);

        if (Confirmation)
        {
            MessagesLabel.Visible = true;
            MessagesLabel.Text = ("Add student was successful");
        }            
        else
        {
            MessagesLabel.Visible = true;
            MessagesLabel.Text = ("Add student was not successful");
        }
            
    }
}