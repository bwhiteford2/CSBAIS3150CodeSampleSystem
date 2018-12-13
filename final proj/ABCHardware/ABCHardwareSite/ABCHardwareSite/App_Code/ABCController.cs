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
        Items ItemsManager = new Items();
        bool confirmation = ItemsManager.UpdateItem(item);

        return confirmation;
    }

    public bool DeleteItem(string itemCode)
    {
        Items ItemsManager = new Items();
        bool confirmation = ItemsManager.DeleteItem(itemCode);

        return confirmation;
    }
}