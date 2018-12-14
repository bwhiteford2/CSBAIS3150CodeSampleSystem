using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ABCController
/// </summary>
public class ABCController
{
    public bool AddItem(Item item)
    {
        Items ItemsManager = new Items();
        bool confirmation = ItemsManager.AddItem(item);

        return confirmation;
    }
    public Item LookupItem(string itemCode)
    {
        Items itemsManager = new Items();
        Item lookupItem = itemsManager.LookupItem(itemCode);

        return lookupItem;
    }
    public bool UpdateItem(Item item)
    {
        Items itemsManager = new Items();
        bool confirmation = itemsManager.UpdateItem(item);

        return confirmation;
    }

    public Customer LookupCustomer(int custID)
    {
        Customers customersManager = new Customers();
        Customer cust = customersManager.LookupCustomer(custID);
        return cust;
    }

    public bool AddCustomer(Customer cust)
    {
        Customers customersManager = new Customers();
        bool confirmation = customersManager.AddCustomer(cust);

        return confirmation;
    }

    public bool DeleteItem(string itemCode)
    {
        Items ItemsManager = new Items();
        bool confirmation = ItemsManager.DeleteItem(itemCode);

        return confirmation;
    }

    public bool UpdateCustomer(Customer cust)
    {
        Customers customersManager = new Customers();
        bool confirmation = customersManager.UpdateCustomer(cust);

        return confirmation;
    }

    public bool DeleteCustomer(int custID)
    {
        Customers customersManager = new Customers();
        bool confirmation = customersManager.DeleteCustomer(custID);

        return confirmation;
    }
}