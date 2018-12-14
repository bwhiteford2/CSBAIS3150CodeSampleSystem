using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customers
/// </summary>
public class Customers
{  
    public bool AddCustomer(Customer cust)
    {
        bool success = false;

        using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString))
        {
            dbConn.Open();
            SqlCommand dbCmd = new SqlCommand();
            dbCmd.Connection = dbConn;

            dbCmd.CommandText = "uspAddCustomer";
            dbCmd.CommandType = CommandType.StoredProcedure;

            dbCmd.Parameters.AddWithValue("@CustomerID", cust.CustomerID);
            dbCmd.Parameters.AddWithValue("@CustomerName", cust.CustomerName);
            dbCmd.Parameters.AddWithValue("@Address", cust.Address);
            dbCmd.Parameters.AddWithValue("@City", cust.City);
            dbCmd.Parameters.AddWithValue("@PostalCode", cust.PostalCode);
            dbCmd.Parameters.AddWithValue("@Province", cust.Province);

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

    public bool UpdateCustomer(Customer cust)
    {
        bool success = false;

        using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString))
        {
            dbConn.Open();
            SqlCommand dbCmd = new SqlCommand();
            dbCmd.CommandText = "uspUpdateCustomer";
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Connection = dbConn;

            dbCmd.Parameters.AddWithValue("@CustomerID", cust.CustomerID);
            dbCmd.Parameters.AddWithValue("@CustomerName", cust.CustomerName);
            dbCmd.Parameters.AddWithValue("@Address", cust.Address);
            dbCmd.Parameters.AddWithValue("@City", cust.City);
            dbCmd.Parameters.AddWithValue("@PostalCode", cust.PostalCode);
            dbCmd.Parameters.AddWithValue("@Province", cust.Province);

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

    public bool DeleteCustomer(int custID)
    {
        bool success = false;

        using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString))
        {
            dbConn.Open();
            SqlCommand dbCmd = new SqlCommand();
            dbCmd.CommandText = "uspDeleteCustomer";
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.Connection = dbConn;

            dbCmd.Parameters.AddWithValue("@CustomerID", custID);

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

    public Customer LookupCustomer(int custID)
    {
        Customer cust = new Customer();

        using (SqlConnection dbConn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString))
        {
            dbConn.Open();
            SqlCommand dbCmd = new SqlCommand();
            dbCmd.Connection = dbConn;

            dbCmd.CommandText = "uspLookupCustomer";
            dbCmd.CommandType = CommandType.StoredProcedure;

            dbCmd.Parameters.AddWithValue("@CustomerID", custID);

            SqlParameter statusParam = new SqlParameter();
            statusParam.Direction = ParameterDirection.ReturnValue;
            statusParam.ParameterName = "@Status";

            dbCmd.Parameters.Add(statusParam);

            SqlDataReader reader = dbCmd.ExecuteReader();

            //int returnStatus = (int)statusParam.Value; return parameter not coming back? 
            if (reader.HasRows)
            {
                cust.CustomerID = custID;
                while (reader.Read())
                {
                    cust.CustomerName = reader.GetString(0);
                    cust.Address = reader.GetString(1);
                    cust.City = reader.GetString(2);
                    cust.PostalCode = reader.GetString(3);
                    cust.Province = reader.GetString(4);
                }
            }
        }
        return cust;
    }
}