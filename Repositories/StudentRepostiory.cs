using Dapper;
using GradeBook.Models;
using Npgsql;

namespace GradeBook.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly string _connectionString;

    public StudentRepository(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("postgres")!;
    }

    public async Task<BasicStudent?> GetStudentById(Guid studentId)
    {
        using var conn = new NpgsqlConnection(_connectionString);
        const string sql = @"
            SELECT s.* FROM student s
            WHERE s.id = @Id;
        ";

        return await conn.QueryFirstOrDefaultAsync<BasicStudent>(sql, new
        {
            Id = studentId
        });
    }

    public async Task<List<BasicStudent>> GetStudentsAsync()
    {
        using var conn = new NpgsqlConnection(_connectionString);
        const string sql = @"
            SELECT * FROM student;
        ";

        return (await conn.QueryAsync<BasicStudent>(sql)).AsList();
    }

    public async Task InsertStudentAsync(BasicStudent student)
    {
        using var conn = new NpgsqlConnection(_connectionString);
        const string sql = @"
            INSERT INTO student (id, first_name, last_name)
            VALUES (@Id, @FirstName, @LastName);
        ";

        await conn.ExecuteAsync(sql, new
        {
            student.Id,
            student.FirstName,
            student.LastName
        });
    }

}

public interface IStudentRepository
{
    Task<List<BasicStudent>> GetStudentsAsync();
    Task<BasicStudent?> GetStudentById(Guid studentId);
    Task InsertStudentAsync(BasicStudent student);
}