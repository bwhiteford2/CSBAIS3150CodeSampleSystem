using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProcessSale : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TableHeaderRow thr = new TableHeaderRow();

        TableHeaderCell thc1 = new TableHeaderCell();
        thc1.Text = "Item Code";
        TableHeaderCell thc2 = new TableHeaderCell();
        thc2.Text = "Quantity in cart";

        thr.Cells.Add(thc1);
        thr.Cells.Add(thc2);

        Table1.Rows.Add(thr);
        ReloadTable();
    }

    private void ReloadTable()
    {
        Dictionary<string, int> values = (Dictionary<string, int>)Session["cart"];
        if (values != null)
        {
            
            foreach (KeyValuePair<string, int> item in values)
            {
                TableRow tr = new TableRow();
                TableCell tc1 = new TableCell();
                tc1.Text = item.Key;

                tr.Cells.Add(tc1);

                TableCell tc2 = new TableCell();
                tc2.Text = item.Value + "";

                tr.Cells.Add(tc2);
                Table1.Rows.Add(tr);
            }
        }
    }

    protected void AddToCart_Click(object sender, EventArgs e)
    {
        // if item exists, add qty to cart
        ABCController controller = new ABCController();
        bool found = false;
        FormTools ft = new FormTools();
        if (IsValid)
        {
            try
            {
                Item item = controller.LookupItem(ItemCodeTextBox.Text);
                if (!string.IsNullOrEmpty(item.ItemCode))
                {
                    found = true;
                    Dictionary<string, int> values = (Dictionary<string, int>)Session["cart"];
                    if (values != null)
                    {
                        int qty;
                        if (values.TryGetValue(item.ItemCode, out qty))
                        {
                            values[item.ItemCode] += int.Parse(QtyTextbox.Text);
                        }
                        else
                        {
                            values[item.ItemCode] = int.Parse(QtyTextbox.Text);
                        }
                    }
                    else
                    {
                        values = new Dictionary<string, int>();
                        values[item.ItemCode] = int.Parse(QtyTextbox.Text);
                        Session["cart"] = values;                        
                    }
                    ReloadTable();
                }
                else
                {                    
                    ft.MessageBox(MessageBox, "Item not found", false);
                }
            }
            catch (Exception)
            {
                ft.MessageBox(MessageBox, "Item lookup unsuccessful, not added to cart", false);
            }
        }
        if (!found)
        {
            ft.MessageBox(MessageBox, "Item lookup unsuccessful, not added to cart", false);
        }
    }
}