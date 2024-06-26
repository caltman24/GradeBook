namespace GradeBook.Models;

public class Student
{
    public Guid StudentId { get; }
    public string FirstName { get; }

    public Student(Guid studentId, string firstName)
    {
        StudentId = studentId;
        FirstName = firstName;
    }
}
