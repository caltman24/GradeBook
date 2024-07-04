using FluentMigrator;

namespace GradeBook.Migrations;

[Migration(4)]
public class AddEnrollmentTable : Migration
{
    private const string TABLE_NAME = "enrollment";

    public override void Up()
    {
        Create.Table(TABLE_NAME)
            .WithColumn("id").AsGuid().PrimaryKey().Indexed()
            .WithColumn("course_id").AsGuid().ForeignKey("course", "id")
            .WithColumn("teacher_id").AsGuid().ForeignKey("teacher", "id")
            .WithColumn("student_id").AsGuid().ForeignKey("student", "id")
            .WithColumn("start_date").AsDateTime()
            .WithColumn("end_date").AsDateTime();
    }
    public override void Down()
    {
        Delete.Table(TABLE_NAME);
    }
}