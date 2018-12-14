using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ItemMaintenance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void LookupBtn_Click(object sender, EventArgs e)
    {
        ABCController controller = new ABCController();
        bool found = false;
        FormTools ft = new FormTools();
        if (IsValid)
        {            
            try
            {
                Item item = controller.LookupItem(ItemCodeLookupTextBox.Text);
                if (!string.IsNullOrEmpty(item.ItemCode))
                {
                    found = true;
                    Panel1.Visible = true;
                    ItemCodeTB.Text = item.ItemCode;
                    DescriptionTextBox.Text = item.Description;
                    UnitPriceTextBox.Text = item.UnitPrice + "";
                    QoHTextBox.Text = item.QuantityOnHand + "";
                    ActiveCB.Checked = item.Active;
                    MessageBox.Text = "";
                }
                else
                {
                    Panel1.Visible = false;
                    ft.MessageBox(MessageBox, "Item not found", false);
                }
            }
            catch (Exception)
            {
                ft.MessageBox(MessageBox, "Item lookup unsuccessful", false);
            }
        }
        if (!found)
        {
            ft.MessageBox(MessageBox, "Item lookup unsuccessful", false);
        }
    }
    protected void Modify_Click(object sender, EventArgs e)
    {
        ABCController controller = new ABCController();
        FormTools ft = new FormTools();
        Item item = new Item(ItemCodeTB.Text, DescriptionTextBox.Text, decimal.Parse(UnitPriceTextBox.Text), int.Parse(QoHTextBox.Text), ActiveCB.Checked);
        try
        {
            controller.UpdateItem(item);
            ft.MessageBox(MessageBox, "Item update successful", true);
            ft.ClearFields(Form.Controls);
            Panel1.Visible = false;
        }
        catch (Exception)
        {
            ft.MessageBox(MessageBox, "Item update unsuccessful", false);
        }

    }
    protected void Delete_Click(object sender, EventArgs e)
    {
        ABCController controller = new ABCController();
        FormTools ft = new FormTools();
        try
        {
            controller.DeleteItem(ItemCodeTB.Text);
            ft.MessageBox(MessageBox, "Item delete successful", true);
            ft.ClearFields(Form.Controls);
            Panel1.Visible = false;
        }
        catch (Exception)
        {
            ft.MessageBox(MessageBox, "Item delete unsuccessful", false);
        }
    }
}