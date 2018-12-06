using System;
using System.Collections.Generic;
using System.Data.SqlClient; // SqlConnection, SqlCommand, SqlParameter, SqlDataReader 
using System.Data;
using System.Configuration;

public class Programs
{
    public bool AddProgram(string ProgramCode, string Description)
    {
        bool Success;
        // Step 1: Create an SqlConnection instance and open the database connection
        string dbConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString; 
        SqlConnection dbConnection = new SqlConnection();
        dbConnection.ConnectionString = dbConnectionString;
        dbConnection.Open();
        // Step 2: Create an SqlCommand instance and specify the stored procedure name that you want to execute 
        SqlCommand addProgramCommand = new SqlCommand();
        addProgramCommand.Connection = dbConnection;
        addProgramCommand.CommandType = CommandType.StoredProcedure;
        addProgramCommand.CommandText = "uspAddProgram";
        // Step 2b: If the stored procedure requires parameters then create SqlParameter a corresponding SqlParameter and add the SqlParameter instance to the SqlCommand instance
        SqlParameter programCodeParameter = new SqlParameter();
        programCodeParameter.ParameterName = "@ProgramCode";
        programCodeParameter.SqlDbType = SqlDbType.VarChar;
        programCodeParameter.Size = 10;
        programCodeParameter.SqlValue = ProgramCode;
        programCodeParameter.Direction = ParameterDirection.Input;
        addProgramCommand.Parameters.Add(programCodeParameter);

        SqlParameter programCodeParameterDesc = new SqlParameter();
        programCodeParameterDesc.ParameterName = "@Description";
        programCodeParameterDesc.SqlDbType = SqlDbType.VarChar;
        programCodeParameterDesc.Size = 60;
        programCodeParameterDesc.SqlValue = Description;
        programCodeParameterDesc.Direction = ParameterDirection.Input;
        addProgramCommand.Parameters.Add(programCodeParameterDesc);

        SqlParameter statusParameter = new SqlParameter();
        statusParameter.ParameterName = "@return_status";
        statusParameter.SqlDbType = SqlDbType.Int;
        statusParameter.Direction = ParameterDirection.ReturnValue;
        addProgramCommand.Parameters.Add(statusParameter);

        // Step 3: Execute the SqlCommand and process data being returned
        // - Use ExecuteNonQuery() method if stored procedure does not return data (Insert, Update, Delete)
        // - Use ExecuteReader() method if stored procedure returns data
        // - Use ExecuteScalar() method if stored procedure returns a single value
        addProgramCommand.ExecuteNonQuery();
        int returnStatus = (int)statusParameter.Value;

        Success = (returnStatus == 0) ? true : false;
        // Step 3b: Use SqlDataReader to process query results. Close SqlDataReader when you are finished processing the query results
        // Step 4: Close the database connection 
        dbConnection.Close();
        return Success;
    }

    public Program GetProgram(string ProgramCode)
    {
        Program ActiveProgram = new Program();

        // send in the programcode, get the description

        string dbConnectionString = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString; 
        SqlConnection dbConnection = new SqlConnection();
        dbConnection.ConnectionString = dbConnectionString;
        dbConnection.Open();

        SqlCommand dbCmd = new SqlCommand();
        dbCmd.Connection = dbConnection;
        dbCmd.CommandText = "uspFindProgram";
        dbCmd.CommandType = CommandType.StoredProcedure;

        SqlParameter returnStatus = new SqlParameter();
        returnStatus.Direction = ParameterDirection.ReturnValue;
        returnStatus.SqlDbType = SqlDbType.Int;
        returnStatus.ParameterName = "@Status";
        dbCmd.Parameters.Add(returnStatus);
        dbCmd.Parameters.AddWithValue("@ProgramCode", ProgramCode);

        SqlDataReader reader = dbCmd.ExecuteReader();
        reader.Read();
        ActiveProgram.ProgramCode = ProgramCode;
        ActiveProgram.Description = reader.GetString(1);

        dbConnection.Close();


        Students StudentManager = new Students();
        ActiveProgram.EnrolledStudents.AddRange(StudentManager.GetStudents(ProgramCode));

        return ActiveProgram;
    }

    public Programs()
    {
    }
}
