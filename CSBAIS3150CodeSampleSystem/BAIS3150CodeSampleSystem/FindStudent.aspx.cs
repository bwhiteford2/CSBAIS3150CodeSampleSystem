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

        Student enrolledStudent = RequestDirector.FindStudent(FindStudentTextBox.Text);

        if (!string.IsNullOrEmpty(enrolledStudent.FirstName))
            MessageLabel.Text = (enrolledStudent.FirstName + " " + enrolledStudent.LastName + " <br />" + enrolledStudent.Email);
        else
            MessageLabel.Text = ("Student not found");
    }
}