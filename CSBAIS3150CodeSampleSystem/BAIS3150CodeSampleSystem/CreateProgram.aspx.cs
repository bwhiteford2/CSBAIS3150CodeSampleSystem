using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class CreateProgram : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        string programCode = ProgramCodeTextBox.Text;
        string description = DescriptionTextBox.Text;

        try
        {
            BCS RequestDirector = new BCS();
            bool Confirmation = RequestDirector.CreateProgram(programCode, description);

            if (Confirmation)
            {
                MessagesLabel.Text = "Create program was successful";
                MessagesLabel.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                MessagesLabel.Text = "Create program was not successful";
                MessagesLabel.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            MessagesLabel.Text = ex.Message + "<br />";
            MessagesLabel.ForeColor = System.Drawing.Color.DarkRed;
        }
    }

}