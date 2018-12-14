using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomerMaintenance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LookupBtn_Click(object sender, EventArgs e)
    {
        ABCController controller = new ABCController();
        bool found = false;
        FormTools ft = new FormTools();
        if(IsValid)
        {
            try
            {
                Customer cust = controller.LookupCustomer(int.Parse(CustomerIDTextBox.Text));
                if(!string.IsNullOrEmpty(cust.CustomerName))
                {
                    found = true;
                    Panel1.Visible = true;
                    CustIDTB.Text = cust.CustomerID + "";
                    CustomerNameTextBox.Text = cust.CustomerName;
                    AddressTextBox.Text = cust.Address;
                    CityTextBox.Text = cust.City;
                    PostalCodeTextBox.Text = cust.PostalCode;
                    ProvinceTextBox.Text = cust.Province;
                    MessageBox.Text = "";
                }
                else
                {
                    Panel1.Visible = false;
                    ft.MessageBox(MessageBox, "Customer not found", false);
                }
            }
            catch (Exception)
            {
                ft.MessageBox(MessageBox, "Customer lookup unsuccessful", false);
            }
        }
        if(!found)
        {
            ft.MessageBox(MessageBox, "Customer lookup unsuccessful", false);
        }
    }
    protected void Modify_Click(object sender, EventArgs e)
    {
        ABCController controller = new ABCController();
        FormTools ft = new FormTools();
        Customer cust = new Customer(int.Parse(CustIDTB.Text), CustomerNameTextBox.Text, AddressTextBox.Text, CityTextBox.Text, PostalCodeTextBox.Text, ProvinceTextBox.Text);
        //try
        {
            controller.UpdateCustomer(cust);
            ft.MessageBox(MessageBox, "Customer update successful", true);
            ft.ClearFields(Form.Controls);
            Panel1.Visible = false;
        }
        //catch (Exception)
        {
            //ft.MessageBox(MessageBox, "Customer update unsuccessful", false);
        }
    }

    protected void Delete_Click(object sender, EventArgs e)
    {
        ABCController controller = new ABCController();
        FormTools ft = new FormTools();
        try
        {
            controller.DeleteCustomer(int.Parse(CustIDTB.Text));
            ft.MessageBox(MessageBox, "Customer delete successful", true);
            ft.ClearFields(Form.Controls);
            Panel1.Visible = false;
        }
        catch (Exception)
        {
            ft.MessageBox(MessageBox, "Customer delete unsuccessful", false);
        }
    }
}