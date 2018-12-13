using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Items
/// </summary>
public class Items
{
    public bool AddItem(Item item)
    {
        bool success = false;
        
            using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString))
            {
                dbConn.Open();
                SqlCommand dbCmd = new SqlCommand();
                dbCmd.CommandText = "uspAddItem";
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Connection = dbConn;

                dbCmd.Parameters.AddWithValue("@ItemCode", item.ItemCode);
                dbCmd.Parameters.AddWithValue("@Description", item.Description);
                dbCmd.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                dbCmd.Parameters.AddWithValue("@QuantityOnHand", item.QuantityOnHand);
                dbCmd.Parameters.AddWithValue("@Active", item.Active);

                SqlParameter statusParam = new SqlParameter();
                statusParam.Direction = ParameterDirection.ReturnValue;
                statusParam.ParameterName = "@Status";
                
                dbCmd.Parameters.Add(statusParam);
               
                dbCmd.ExecuteNonQuery();
                int returnStatus = (int)statusParam.Value;
                success = (returnStatus == 1) ? true : false;
            }                        
        return success;
    }

    internal bool DeleteItem(string itemCode)
    {
        bool success = false;

        using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString))
        {
            dbConn.Open();
            SqlCommand dbCmd = new SqlCommand();
            dbCmd.CommandText = "uspDeleteItem";
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Connection = dbConn;

            dbCmd.Parameters.AddWithValue("@ItemCode", itemCode);
            
            SqlParameter statusParam = new SqlParameter();
            statusParam.Direction = ParameterDirection.ReturnValue;
            statusParam.ParameterName = "@Status";

            dbCmd.Parameters.Add(statusParam);

            dbCmd.ExecuteNonQuery();
            int returnStatus = (int)statusParam.Value;
            success = (returnStatus == 1) ? true : false;
        }
        return success;
    }

    public bool UpdateItem(Item item)
    {
        bool success = false;

        using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString))
        {
            dbConn.Open();
            SqlCommand dbCmd = new SqlCommand();
            dbCmd.CommandText = "uspUpdateItem";
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Connection = dbConn;

            dbCmd.Parameters.AddWithValue("@ItemCode", item.ItemCode);
            dbCmd.Parameters.AddWithValue("@Description", item.Description);
            dbCmd.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
            dbCmd.Parameters.AddWithValue("@QuantityOnHand", item.QuantityOnHand);
            dbCmd.Parameters.AddWithValue("@Active", item.Active);

            SqlParameter statusParam = new SqlParameter();
            statusParam.Direction = ParameterDirection.ReturnValue;
            statusParam.ParameterName = "@Status";

            dbCmd.Parameters.Add(statusParam);

            dbCmd.ExecuteNonQuery();
            int returnStatus = (int)statusParam.Value;
            success = (returnStatus == 1) ? true : false;
        }
        return success;
    }

    public Item LookupItem(string itemCode)
    {
        Item item = new Item();

        using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString))
        {
            dbConn.Open();
            SqlCommand dbCmd = new SqlCommand();
            dbCmd.CommandText = "uspLookupItem";
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Connection = dbConn;

            dbCmd.Parameters.AddWithValue("@ItemCode", itemCode);


            SqlParameter statusParam = new SqlParameter();
            statusParam.Direction = ParameterDirection.ReturnValue;
            statusParam.ParameterName = "@Status";

            dbCmd.Parameters.Add(statusParam);


            SqlDataReader reader = dbCmd.ExecuteReader();
            
            //int returnStatus = (int)statusParam.Value; return parameter not coming back? 
            if (reader.HasRows)
            {
                item.ItemCode = itemCode;
                while (reader.Read())
                {
                    item.Description = reader.GetString(0);
                    item.UnitPrice = reader.GetDecimal(1);
                    item.QuantityOnHand = reader.GetInt32(2);
                    item.Active = reader.GetBoolean(3);
                }
            }
        }
        return item;
    }

}