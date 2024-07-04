using FluentMigrator;

namespace GradeBook.Migrations;

[Migration(3)]
public class AddTeacherTable : Migration
{
    private const string TABLE_NAME = "teacher";

    public override void Up()
    {
        Create.Table(TABLE_NAME)
            .WithColumn("id").AsGuid().PrimaryKey().Indexed()
            .WithColumn("first_name").AsString()
            .WithColumn("last_name").AsString()
            .WithColumn("email").AsString();

    }
    public override void Down()
    {
        Delete.Table(TABLE_NAME);
    }
}