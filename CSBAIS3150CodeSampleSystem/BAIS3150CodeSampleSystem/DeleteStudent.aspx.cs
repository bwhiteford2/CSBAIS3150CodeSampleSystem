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

        
        Student EnrolledStudent = RequestDirector.FindStudent(DeleteStudentTextBox.Text);

        if (EnrolledStudent.StudentId != null)
        {
            // Modify Student     


            bool confirmation = RequestDirector.RemoveStudent(DeleteStudentTextBox.Text);

            if (confirmation)
                MessageLabel.Text = ("Remove student successful");
            else
                MessageLabel.Text = ("Remove student unsuccessful");
        }
        else
            MessageLabel.Text = ("Student not found");
    }
}