namespace GradeBook.Models;

public class Course
{
    public Guid CourseId { get; }
    public string Name { get; }

    public Course(Guid courseId, string name)
    {
        CourseId = courseId;
        Name = name;
    }

}
