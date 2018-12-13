using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
    public int CustomerID { get; set; }
    public string CustomerName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Province { get; set; }

    public Customer(int custID, string name, string address, string city, string postalCode, string province)
    {
        CustomerID = custID;
        CustomerName = name;
        Address = address;
        City = city;
        PostalCode = postalCode;
        Province = province;
    }
    public Customer()
    {

    }
}