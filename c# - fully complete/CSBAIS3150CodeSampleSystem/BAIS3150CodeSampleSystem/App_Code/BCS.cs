public class BCS
{
    public bool CreateProgram(string ProgramCode, string Description)
    {
        Programs ProgramManager = new Programs();
        bool Confirmation = ProgramManager.AddProgram(ProgramCode, Description);

        return Confirmation;
    }

    public bool EnrollStudent(Student AcceptedStudent, string ProgramCode)
    {
        Students StudentManager = new Students();
        bool Confirmation = StudentManager.AddStudent(AcceptedStudent, ProgramCode);

        return Confirmation;
    }

    public Student FindStudent(string StudentID)
    {
        Students StudentManager = new Students();
        Student EnrolledStudent = StudentManager.GetStudent(StudentID);

        return EnrolledStudent;
    }

    public bool ModifyStudent(Student EnrolledStudent)
    {
        Students StudentManager = new Students();
        bool Success = StudentManager.UpdateStudent(EnrolledStudent);

        return Success;
    }

    public bool RemoveStudent(string StudentID)
    {
        Students StudentManager = new Students();
        bool Success = StudentManager.DeleteStudent(StudentID);

        return Success;
    }

    public Program FindProgram(string ProgramCode)
    {
        Programs ProgramManager = new Programs();
        Program ActiveProgram = ProgramManager.GetProgram(ProgramCode);
        return ActiveProgram;
    }
}
