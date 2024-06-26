namespace GradeBook;

public class Teacher
{
    public Guid TeacherId { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }

    public Teacher(
        Guid teacherId,
        string firstName,
        string lastName,
        string email)
    {
        TeacherId = teacherId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

}
