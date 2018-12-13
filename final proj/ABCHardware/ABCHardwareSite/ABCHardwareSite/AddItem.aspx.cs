using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        ABCController controller = new ABCController();

        if (IsValid) 
        {
            Item item = new Item(ItemCodeTextBox.Text, DescriptionTextBox.Text, decimal.Parse(UnitPriceTextBox.Text), int.Parse(QoHTextBox.Text), ActiveCB.Checked);
           try
            {
                controller.AddItem(item);
                StaticTools.MessageBox(MessageBox, "Item add successful", true);
                StaticTools.ClearFields(Form.Controls);
                // QoH is df to 0
                QoHTextBox.Text = "0";
                MessageBox.Text = "";
            }
            catch (Exception)
            {
                StaticTools.MessageBox(MessageBox, "Item add unsuccessful", false);
            }            
        }
    }
}