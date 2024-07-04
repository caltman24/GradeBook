using GradeBook.Models;
using GradeBook.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GradeBook.Routes;

public static class StudentRoute
{
    public static IEndpointRouteBuilder MapStudentRoute(this IEndpointRouteBuilder app)
    {

        var studentGroup = app.MapGroup("/student");

        studentGroup.MapGet("/", async (IStudentRepository studentRepository) =>
        {
            var students = await studentRepository.GetStudentsAsync();

            return TypedResults.Ok(students);
        });

        studentGroup.MapGet("/{studentId:Guid}",
        async Task<Results<Ok<BasicStudent>, NotFound>> (
            [FromRoute] Guid studentId,
            IStudentRepository studentRepository) =>
        {
            var student = await studentRepository.GetStudentById(studentId);

            if (student == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(student);
        }).WithName("GetStudentById");

        studentGroup.MapPost("/", async (
            [FromBody] NewStudentRequest student,
            IStudentRepository studentRepository) =>
        {
            var newStudent = new BasicStudent
            {
                Id = Guid.NewGuid(),
                FirstName = student.FirstName,
                LastName = student.LastName
            };

            await studentRepository.InsertStudentAsync(newStudent);

            return TypedResults.CreatedAtRoute(newStudent, "GetStudentById", new
            {
                studentId = newStudent.Id
            });
        });

        return app;
    }
    public record NewStudentRequest(string FirstName, string LastName);
}