namespace GradeBook.Models;

public class School
{
    public Guid Id { get; init; }
    public string Name { get; init; } = "";
    public List<SchoolYear> SchoolYears { get; init; } = new();
    public SchoolYear CurrentSchoolYear { get; private set; }
    public List<Admin> Admins { get; init; } = new();

    public void SetCurrentSchoolYear(int year)
    {
        CurrentSchoolYear = SchoolYears.Find(sy => sy.Year == year)
                             ?? throw new InvalidOperationException($"School year {year} not found.");
    }
}
