namespace GradeBook.Models;

public class SchoolYear
{
    public Guid Id { get; init; }
    public int Year { get; init; } = new DateOnly().Year;
    public List<Semester> Semesters { get; init; } = new();
}
