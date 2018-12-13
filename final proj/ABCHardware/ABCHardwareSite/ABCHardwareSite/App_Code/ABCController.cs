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
}