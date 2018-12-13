using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for StaticTools
/// </summary>
public class StaticTools
{
    /// <summary>
    /// Send in messagebox, the message, and the bool. Will deal with handling color 
    /// </summary>
    /// <param name="lbl"></param>
    /// <param name="msg"></param>
    /// <param name="success"></param>
    public static void MessageBox(Label lbl, string msg, bool success)
    {
        lbl.Text = msg;
        if (success)
        {
            lbl.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
            lbl.ForeColor = System.Drawing.Color.Red;
        }        
    }
}
