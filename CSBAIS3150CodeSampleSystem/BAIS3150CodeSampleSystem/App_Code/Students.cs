using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

public class Students
{
    public bool AddStudent(Student AcceptedStudent, string ProgramCode)
    {
        bool Success;

        SqlConnection dbConn = new SqlConnection();
        dbConn.ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=BCS-db;Integrated Security=true";
        dbConn.Open();

        SqlCommand dbCmd = new SqlCommand();
        {
            dbCmd.Connection = dbConn;
            dbCmd.CommandType = CommandType.StoredProcedure;
            dbCmd.CommandText = "uspAddStudent";
            dbCmd.Parameters.AddWithValue("@StudentId", AcceptedStudent.StudentId);
            dbCmd.Parameters.AddWithValue("@FirstName", AcceptedStudent.FirstName);
            dbCmd.Parameters.AddWithValue("@LastName", AcceptedStudent.LastName);
            dbCmd.Parameters.AddWithValue("@Email", AcceptedStudent.Email);
            dbCmd.Parameters.AddWithValue("@ProgramCode", ProgramCode);
        }

        SqlParameter statusParam = new SqlParameter();

        statusParam.ParameterName = "@Status";
        statusParam.Direction = ParameterDirection.ReturnValue;

        dbCmd.Parameters.Add(statusParam);

        dbCmd.ExecuteNonQuery();

        if (System.Convert.ToInt32(statusParam.Value) == 0)
            Success = true;
        else
            Success = false;
        dbConn.Close();

        return Success;
    }

    public Student GetStudent(string StudentID)
    {
        Student EnrolledStudent = new Student();

        SqlConnection dbConn = new SqlConnection();
        dbConn.ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=BCS-db;Integrated Security=True";
        dbConn.Open();
        SqlCommand dbCmd = new SqlCommand();
        dbCmd.Connection = dbConn;
        dbCmd.CommandType = CommandType.StoredProcedure;
        dbCmd.CommandText = "uspFindStudent";
        dbCmd.Parameters.AddWithValue("@StudentId", StudentID);

        SqlParameter returnStatus = new SqlParameter();
        returnStatus.Direction = ParameterDirection.ReturnValue;
        returnStatus.SqlDbType = SqlDbType.Int;
        returnStatus.ParameterName = "@Status";

        dbCmd.Parameters.Add(returnStatus);

        SqlDataReader reader = dbCmd.ExecuteReader();



        while (reader.Read())
        {
            EnrolledStudent.StudentId = reader.GetValue(0).ToString();
            EnrolledStudent.FirstName = reader.GetValue(1).ToString();
            EnrolledStudent.LastName = reader.GetValue(2).ToString();
            EnrolledStudent.Email = reader.GetValue(3).ToString();
        }

        dbConn.Close();
        return EnrolledStudent;
    }

    public bool UpdateStudent(Student EnrolledStudent)
    {
        bool Success = false;

        SqlConnection dbConn = new SqlConnection();
        dbConn.ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=BCS-db;Integrated Security=True";
        dbConn.Open();

        SqlCommand dbCmd = new SqlCommand();

        dbCmd.Connection = dbConn;
        dbCmd.CommandText = "uspModifyStudent";
        dbCmd.CommandType = CommandType.StoredProcedure;
        dbCmd.Parameters.AddWithValue("@StudentId", EnrolledStudent.StudentId);
        dbCmd.Parameters.AddWithValue("@FirstName", EnrolledStudent.FirstName);
        dbCmd.Parameters.AddWithValue("@LastName", EnrolledStudent.LastName);
        dbCmd.Parameters.AddWithValue("@Email", EnrolledStudent.Email);


        SqlParameter status = new SqlParameter();

        status.SqlDbType = SqlDbType.Int;
        status.Direction = ParameterDirection.ReturnValue;
        status.ParameterName = "@Status";

        dbCmd.Parameters.Add(status);

        dbCmd.ExecuteNonQuery();

        if ((int)status.Value == 0)
            Success = true;

        return Success;
    }

    public bool DeleteStudent(string StudentID)
    {
        bool Success = false;

        SqlConnection dbConn = new SqlConnection();
        dbConn.ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=BCS-db;Integrated Security=True";
        dbConn.Open();

        SqlCommand dbCmd = new SqlCommand();
        dbCmd.Connection = dbConn;
        dbCmd.CommandText = "uspDeleteStudent";
        dbCmd.CommandType = CommandType.StoredProcedure;
        dbCmd.Parameters.AddWithValue("@StudentId", StudentID);


        SqlParameter status = new SqlParameter();

        status.SqlDbType = SqlDbType.Int;
        status.Direction = ParameterDirection.ReturnValue;
        status.ParameterName = "@Status";

        dbCmd.Parameters.Add(status);

        dbCmd.ExecuteNonQuery();

        if ((int)status.Value == 0)
            Success = true;

        return Success;
    }

    public List<Student> GetStudents(string ProgramCode)
    {
        List<Student> EnrolledStudents = new List<Student>();

        DataSet studentDS = new DataSet("Student");
        SqlConnection dbConn = new SqlConnection();
        dbConn.ConnectionString = @"Server=(localdb)\MSSQLLocalDB;Database=BCS-db;Integrated Security=true";

        SqlCommand dbCmd = new SqlCommand();
        dbCmd.Connection = dbConn;
        dbCmd.CommandText = "uspGetStudentsByProgram";
        dbCmd.CommandType = CommandType.StoredProcedure;
        dbCmd.Parameters.AddWithValue("@ProgramCode", ProgramCode);

        SqlDataAdapter getStudentDA = new SqlDataAdapter();
        getStudentDA.SelectCommand = dbCmd;
        getStudentDA.Fill(studentDS, "Student");

        DataTable studentTable = studentDS.Tables["Student"];

  

        foreach (DataRow studentRow in studentTable.Rows)
        {
            Student newStudent = new Student();
            newStudent.StudentId =  (string)studentRow["StudentId"];
            newStudent.FirstName = (string)studentRow["FirstName"];
            newStudent.LastName = (string)studentRow["LastName"];
            newStudent.Email = (string)studentRow["Email"];
            EnrolledStudents.Add(newStudent);
        }


        return EnrolledStudents;
    }
}
