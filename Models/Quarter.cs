namespace GradeBook.Models;

public class Quarter
{
    public Guid Id { get; init; }
    public int Number { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public List<Classroom> Classrooms { get; init; } = new();
}
