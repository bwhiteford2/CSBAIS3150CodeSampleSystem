Imports System.Data.SqlClient
Imports System.Data ' For DataSet, DataTable, DataColumn, DataRow
Partial Class DisplayProgramAndStudents
    Inherits System.Web.UI.Page

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        ' Step 1: Create an SqlConnection instance and configure it
        Const dbConnectionString As String = "Server=(localdb)\MSSQLLocalDB;Database=BAIS3150BCS;Integrated Security=true"
        Dim dbConnection As SqlConnection = New SqlConnection()
        dbConnection.ConnectionString = dbConnectionString
        ' Step 2: Create an SqlCommand instance and configure it
        Dim getProgramCommand As SqlCommand = New SqlCommand()
        getProgramCommand.CommandType = CommandType.StoredProcedure
        getProgramCommand.CommandText = "uspGetProgram"

        Dim getProgramStudentsCommand As SqlCommand = New SqlCommand()
        getProgramStudentsCommand.CommandType = CommandType.StoredProcedure
        getProgramStudentsCommand.CommandText = "uspGetProgramStudents"

        Dim programCodeParameter As SqlParameter = New SqlParameter()
        programCodeParameter.Value = "BAIST"
        programCodeParameter.SqlDbType = SqlDbType.VarChar
        programCodeParameter.Size = 10

        getProgramCommand.Parameters.Add(programCodeParameter)
        getProgramStudentsCommand.Parameters.Add(programCodeParameter)

        ' Step 3: Create an SqlDataAdapter and configure it
        Dim getProgramDA As SqlDataAdapter = New SqlDataAdapter()
        getProgramDA.SelectCommand = getProgramCommand
        Dim getProgramStudentsDA As SqlDataAdapter = New SqlDataAdapter()
        getProgramStudentsDA.SelectCommand = getProgramStudentsCommand

        ' Step 4: Create a DataSet instance and use the SqlDataAdapter instance fill the tables in it 
        Dim bcsDataSet As DataSet = New DataSet("BCSDataSet")
        getProgramDA.Fill(bcsDataSet, "Program")
        getProgramStudentsDA.Fill(bcsDataSet, "Students")

        ' Step 5: Iterate through the DataTables in the DataSet and process the data

        For Each programRow In bcsDataSet.Tables("Program").Rows
            Response.Write(programRow("ProgramCode") & ", " & programRow("Description") & "<br />")
        Next

        For Each studentRow In bcsDataSet.Tables("Studens").Rows
            Response.Write(studentRow("FirstName") & " " & studentRow("LastName") & "<br />")
        Next
        ' programmatically get all column names (homework)
    End Sub
End Class
