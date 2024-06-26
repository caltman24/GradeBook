namespace GradeBook.Models;

public class Semester
{
    public Guid Id { get; init; }
    public string Name { get; init; } = ""; // Fall or Spring
    public List<Quarter> Quarters { get; init; } = new();
}
