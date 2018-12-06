Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class Students
    Public Function AddStudent(AcceptedStudent As Student, ProgramCode As String) As Boolean
        Dim Success As Boolean

        Dim dbConn As New SqlConnection()
        dbConn.ConnectionString = "Server=(localdb)\MSSQLLocalDB;Database=BCS-db;Integrated Security=true"
        dbConn.Open()

        Dim dbCmd As New SqlCommand()
        With dbCmd
            dbCmd.Connection = dbConn
            dbCmd.CommandType = CommandType.StoredProcedure
            dbCmd.CommandText = "uspAddStudent"
            dbCmd.Parameters.AddWithValue("@StudentId", AcceptedStudent.StudentID)
            dbCmd.Parameters.AddWithValue("@FirstName", AcceptedStudent.FirstName)
            dbCmd.Parameters.AddWithValue("@LastName", AcceptedStudent.LastName)
            dbCmd.Parameters.AddWithValue("@Email", AcceptedStudent.Email)
            dbCmd.Parameters.AddWithValue("@ProgramCode", ProgramCode)
        End With

        Dim statusParam As New SqlParameter()
        With statusParam
            statusParam.ParameterName = "@Status"
            statusParam.Direction = ParameterDirection.ReturnValue
        End With
        dbCmd.Parameters.Add(statusParam)

        dbCmd.ExecuteNonQuery()

        If CType(statusParam.Value, Integer) = 0 Then
            Success = True
        Else
            Success = False
        End If
        dbConn.Close()

        Return Success
    End Function

    Public Function GetStudent(StudentID As String) As Student
        Dim EnrolledStudent As New Student()

        Dim dbConn As New SqlConnection()
        dbConn.ConnectionString = "Server=(localdb)\MSSQLLocalDB;Database=BCS-db;Integrated Security=True"
        dbConn.Open()
        Dim dbCmd As New SqlCommand()
        dbCmd.Connection = dbConn
        dbCmd.CommandType = CommandType.StoredProcedure
        dbCmd.CommandText = "uspFindStudent"
        dbCmd.Parameters.AddWithValue("@StudentId", StudentID)

        Dim returnStatus As New SqlParameter()
        returnStatus.Direction = ParameterDirection.ReturnValue
        returnStatus.SqlDbType = SqlDbType.Int
        returnStatus.ParameterName = "@Status"

        dbCmd.Parameters.Add(returnStatus)

        Dim reader As SqlDataReader = dbCmd.ExecuteReader()



        While reader.Read
            EnrolledStudent.StudentID = reader.GetValue(0)
            EnrolledStudent.FirstName = reader.GetValue(1)
            EnrolledStudent.LastName = reader.GetValue(2)
            EnrolledStudent.Email = reader.GetValue(3)
        End While

        dbConn.Close()
        Return EnrolledStudent
    End Function

    Public Function UpdateStudent(EnrolledStudent As Student) As Boolean
        Dim Success As Boolean = False

        Dim dbConn As New SqlConnection()
        dbConn.ConnectionString = "Server=(localdb)\MSSQLLocalDB;Database=BCS-db;Integrated Security=True"
        dbConn.Open()

        Dim dbCmd As New SqlCommand()
        With dbCmd
            .Connection = dbConn
            .CommandText = "uspModifyStudent"
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@StudentId", EnrolledStudent.StudentID)
            .Parameters.AddWithValue("@FirstName", EnrolledStudent.FirstName)
            .Parameters.AddWithValue("@LastName", EnrolledStudent.LastName)
            .Parameters.AddWithValue("@Email", EnrolledStudent.Email)
            '.Parameters.AddWithValue("@ProgramCode", EnrolledStudent)
        End With

        Dim status As New SqlParameter()
        With status
            .SqlDbType = SqlDbType.Int
            .Direction = ParameterDirection.ReturnValue
            .ParameterName = "@Status"
        End With

        dbCmd.Parameters.Add(status)

        dbCmd.ExecuteNonQuery()

        If CType(status.Value = 0, Integer) Then
            Success = True
        End If

        Return Success
    End Function

    Public Function DeleteStudent(StudentID As String) As Boolean
        Dim Success As Boolean = False

        Dim dbConn As New SqlConnection()
        dbConn.ConnectionString = "Server=(localdb)\MSSQLLocalDB;Database=BCS-db;Integrated Security=True"
        dbConn.Open()

        Dim dbCmd As New SqlCommand()
        With dbCmd
            .Connection = dbConn
            .CommandText = "uspDeleteStudent"
            .CommandType = CommandType.StoredProcedure
            .Parameters.AddWithValue("@StudentId", StudentID)
            '.Parameters.AddWithValue("@ProgramCode", EnrolledStudent)
        End With

        Dim status As New SqlParameter()
        With status
            .SqlDbType = SqlDbType.Int
            .Direction = ParameterDirection.ReturnValue
            .ParameterName = "@Status"
        End With

        dbCmd.Parameters.Add(status)

        dbCmd.ExecuteNonQuery()

        If CType(status.Value = 0, Integer) Then
            Success = True
        End If

        Return Success
    End Function

    Public Function GetStudents(ProgramCode As String) As List(Of Student)
        Dim EnrolledStudents = New List(Of Student)

        Dim studentDS As New DataSet("Student")
        Dim dbConn As New SqlConnection()
        dbConn.ConnectionString = "Server=(localdb)\MSSQLLocalDB;Database=BCS-db;Integrated Security=true"

        Dim dbCmd As New SqlCommand()
        dbCmd.Connection = dbConn
        dbCmd.CommandText = "uspGetStudentsByProgram"
        dbCmd.CommandType = CommandType.StoredProcedure
        dbCmd.Parameters.AddWithValue("@ProgramCode", ProgramCode)

        Dim getStudentDA As New SqlDataAdapter()
        getStudentDA.SelectCommand = dbCmd
        getStudentDA.Fill(studentDS, "Student")

        Dim studentTable As DataTable = studentDS.Tables("Student")

        For Each studentRow In studentTable.Rows
            Dim newStudent As New Student()
            newStudent.StudentID = studentRow("StudentId")
            newStudent.FirstName = studentRow("FirstName")
            newStudent.LastName = studentRow("LastName")
            newStudent.Email = studentRow("Email")
            EnrolledStudents.Add(newStudent)
        Next

        Return EnrolledStudents
    End Function
End Class
