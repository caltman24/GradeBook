namespace GradeBook.Models;

public class Classroom
{
    public Guid Id { get; init; }
    public Guid SchoolId { get; init; }
    public Guid TeacherId { get; init; }
    public int ClassroomNumber { get; init; }

}
