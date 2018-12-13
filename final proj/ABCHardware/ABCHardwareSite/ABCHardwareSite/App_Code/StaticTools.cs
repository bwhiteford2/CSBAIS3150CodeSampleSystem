using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
    public static void ClearFields(ControlCollection pageControls)
    {
        foreach (Control contl in pageControls)
        {
            string strCntName = (contl.GetType()).Name;

            switch (strCntName)
            {
                case "TextBox":
                    TextBox tbSource = (TextBox)contl;
                    tbSource.Text = string.Empty;
                    break;
                case "RadioButtonList":
                    RadioButtonList rblSource = (RadioButtonList)contl;
                    rblSource.SelectedIndex = -1;
                    break;
                case "DropDownList":
                    DropDownList ddlSource = (DropDownList)contl;
                    ddlSource.SelectedIndex = -1;
                    break;
                case "ListBox":
                    ListBox lbsource = (ListBox)contl;
                    lbsource.SelectedIndex = -1;
                    break;
            }
            ClearFields(contl.Controls);
        }
    }
}
