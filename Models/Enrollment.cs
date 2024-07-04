namespace GradeBook.Models;

public class Enrollment
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public Guid TeacherId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

}