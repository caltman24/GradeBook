namespace GradeBook.Models;

public class Student
{
    public Guid StudentId { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public List<Enrollment> Enrollments { get; set; } = new();
}