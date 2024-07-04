using FluentMigrator;

namespace GradeBook.Migrations;

[Migration(1)]
public class AddStudentTable : Migration
{
    private const string TABLE_NAME = "student";

    public override void Up()
    {
        Create.Table(TABLE_NAME)
            .WithColumn("id").AsGuid().PrimaryKey().Indexed()
            .WithColumn("first_name").AsString()
            .WithColumn("last_name").AsString();
    }
    public override void Down()
    {
        Delete.Table(TABLE_NAME);
    }
}