using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddCustomer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        ABCController controller = new ABCController();
        
        if(IsValid)
        {
            FormTools ft = new FormTools();
            try
            {
                Customer cust = new Customer(int.Parse(CustomerIDTextBox.Text), CustomerNameTextBox.Text, AddressTextBox.Text, CityTextBox.Text, PostalCodeTextBox.Text, ProvinceTextBox.Text);
                controller.AddCustomer(cust);                
                ft.MessageBox(MessageBox, "Customer add successful", true);
                ft.ClearFields(Form.Controls);
            }
            catch (Exception)
            {
                ft.MessageBox(MessageBox, "Customer add unsuccessful", false);
            }            
        }
    }
}