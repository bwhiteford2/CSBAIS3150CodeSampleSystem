using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Item
/// </summary>
public class Item
{
    public string ItemCode { get; set; }
    public string Description { get; set; }
    public decimal UnitPrice { get; set; }
    public int QuantityOnHand { get; set; }
    public bool Active { get; set; }

    public Item(string itemCode, string description, decimal unitPrice, int quantityOnHand, bool active) 
    {
        ItemCode = itemCode;
        Description = description;
        UnitPrice = unitPrice;
        QuantityOnHand = quantityOnHand;
        Active = active;
    }
    public Item() 
    {

    }

}