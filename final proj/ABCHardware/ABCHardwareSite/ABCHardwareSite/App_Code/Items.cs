using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Items
/// </summary>
public class Items
{
    public bool AddItem(Item item)
    {
        bool success = false;
        try
        {
            using (SqlConnection dbConn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString))
            {
                dbConn.Open();
                SqlCommand dbCmd = new SqlCommand();
                dbCmd.CommandText = "uspAddItem";
                dbCmd.CommandType = CommandType.StoredProcedure;

                dbCmd.Parameters.AddWithValue("@ItemCode", item.ItemCode);
                dbCmd.Parameters.AddWithValue("@Description", item.Description);
                dbCmd.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                dbCmd.Parameters.AddWithValue("@QuantityOnHand", item.QuantityOnHand);
                dbCmd.Parameters.AddWithValue("@Active", item.Active);

                SqlParameter statusParam = new SqlParameter();
                statusParam.Direction = ParameterDirection.ReturnValue;
                statusParam.ParameterName = "@Status";
                int returnStatus = (int)statusParam.Value;

                success = (returnStatus == 0) ? true : false;
            }
        }
        catch (Exception)
        {

        }
        
        return success;
    }
}