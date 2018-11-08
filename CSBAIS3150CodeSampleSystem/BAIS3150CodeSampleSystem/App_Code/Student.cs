using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Student
/// </summary>
public class Student
{
    private string mStudentId;
    public string StudentId
    {
        get { return mStudentId; }
        set { mStudentId = value; }
    }

    private string mFirstName;
    public string FirstName
    {
        get { return mFirstName; }
        set { mFirstName = value; }
    }

    private string mLastName;
    public string LastName
    {
        get { return mLastName; }
        set { mLastName = value; }
    }

    private string mEmail;
    public string Email
    {
        get { return mEmail; }
        set { mEmail = value; }
    }


    public Student()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}