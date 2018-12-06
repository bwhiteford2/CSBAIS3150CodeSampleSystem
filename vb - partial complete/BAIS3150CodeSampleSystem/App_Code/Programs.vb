Imports Microsoft.VisualBasic
Imports System.Data.SqlClient 'SqlConnection, SqlCommand, SqlParameter, SqlDataReader 
Imports System.Data

Public Class Programs
    Public Function AddProgram(ProgramCode As String, Description As String) As Boolean
        Dim Success As Boolean
        ' Step 1: Create an SqlConnection instance and open the database connection
        Const dbConnectionString As String = "Server=(localdb)\MSSQLLocalDB;database=BCS-db;Integrated Security=true"
        Dim dbConnection As SqlConnection = New SqlConnection()
        dbConnection.ConnectionString = dbConnectionString
        dbConnection.Open()
        ' Step 2: Create an SqlCommand instance and specify the stored procedure name that you want to execute 
        Dim addProgramCommand As SqlCommand = New SqlCommand()
        addProgramCommand.Connection = dbConnection
        addProgramCommand.CommandType = CommandType.StoredProcedure
        addProgramCommand.CommandText = "uspAddProgram"
        ' Step 2b: If the stored procedure requires parameters then create SqlParameter a corresponding SqlParameter and add the SqlParameter instance to the SqlCommand instance
        Dim programCodeParameter As SqlParameter = New SqlParameter()
        programCodeParameter.ParameterName = "@ProgramCode"
        programCodeParameter.SqlDbType = SqlDbType.VarChar
        programCodeParameter.Size = 10
        programCodeParameter.SqlValue = ProgramCode
        programCodeParameter.Direction = ParameterDirection.Input
        addProgramCommand.Parameters.Add(programCodeParameter)

        Dim programCodeParameterDesc As SqlParameter = New SqlParameter()
        programCodeParameterDesc.ParameterName = "@Description"
        programCodeParameterDesc.SqlDbType = SqlDbType.VarChar
        programCodeParameterDesc.Size = 60
        programCodeParameterDesc.SqlValue = Description
        programCodeParameterDesc.Direction = ParameterDirection.Input
        addProgramCommand.Parameters.Add(programCodeParameterDesc)

        Dim statusParameter As SqlParameter = New SqlParameter()
        statusParameter.ParameterName = "@return_status"
        statusParameter.SqlDbType = SqlDbType.Int
        statusParameter.Direction = ParameterDirection.ReturnValue
        addProgramCommand.Parameters.Add(statusParameter)

        ' Step 3: Execute the SqlCommand and process data being returned
        '  - Use ExecuteNonQuery() method if stored procedure does not return data (Insert, Update, Delete)
        '  - Use ExecuteReader() method if stored procedure returns data
        '  - Use ExecuteScalar() method if stored procedure returns a single value
        addProgramCommand.ExecuteNonQuery()
        Dim returnStatus As Integer = CType(statusParameter.Value, Integer)
        If returnStatus = 0 Then
            Success = True
        Else
            Success = False
        End If
        ' Step 3b: Use SqlDataReader to process query results. Close SqlDataReader when you are finished processing the query results
        ' Step 4: Close the database connection 
        dbConnection.Close()
        Return Success
    End Function

    Public Function GetProgram(ProgramCode As String) As Program
        Dim ActiveProgram As New Program()

        ' send in the programcode, get the description

        Const dbConnectionString As String = "Server=(localdb)\MSSQLLocalDB;database=BCS-db;Integrated Security=true"
        Dim dbConnection As SqlConnection = New SqlConnection()
        dbConnection.ConnectionString = dbConnectionString
        dbConnection.Open()

        Dim dbCmd As New SqlCommand()
        dbCmd.Connection = dbConnection
        dbCmd.CommandText = "uspFindProgram"
        dbCmd.CommandType = CommandType.StoredProcedure

        Dim returnStatus As New SqlParameter()
        returnStatus.Direction = ParameterDirection.ReturnValue
        returnStatus.SqlDbType = SqlDbType.Int
        returnStatus.ParameterName = "@Status"
        dbCmd.Parameters.Add(returnStatus)
        dbCmd.Parameters.AddWithValue("@ProgramCode", ProgramCode)

        Dim reader As SqlDataReader = dbCmd.ExecuteReader()
        reader.Read()
        ActiveProgram.ProgramCode = ProgramCode
        ActiveProgram.Description = reader.GetString(1)

        dbConnection.Close()


        Dim StudentManager As New Students()
        ActiveProgram.EnrolledStudents.AddRange(StudentManager.GetStudents(ProgramCode))

        Return ActiveProgram
    End Function

    Public Sub New()

    End Sub
End Class
