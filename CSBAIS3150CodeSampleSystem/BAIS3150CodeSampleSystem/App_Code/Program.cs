using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Program
/// </summary>
public class Program
{
    private string mProgramCode;

    public string ProgramCode
    {
        get { return mProgramCode; }
        set { mProgramCode = value; }
    }

    private string mDescription;

    public string Description
    {
        get { return mDescription; }
        set { mDescription = value; }
    }
    private List<Student> mEnrolledStudents = new List<Student>();

    public List<Student> EnrolledStudents
    {
        get { return mEnrolledStudents; }
    }

    public Program()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}