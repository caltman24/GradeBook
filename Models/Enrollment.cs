namespace GradeBook.Models;

class Enrollment
{
    public Guid EnrollmentId { get; }
    public string Name { get; }

    public Enrollment(Guid enrollmentId, string name)
    {
        EnrollmentId = enrollmentId;
        Name = name;
    }
}