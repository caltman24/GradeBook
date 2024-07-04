using FluentMigrator;

namespace GradeBook.Migrations;

[Migration(2)]
public class AddCourseTable : Migration
{
    private const string TABLE_NAME = "course";

    public override void Up()
    {
        Create.Table(TABLE_NAME)
            .WithColumn("id").AsGuid().PrimaryKey().Indexed()
            .WithColumn("name").AsString();
    }
    public override void Down()
    {
        Delete.Table(TABLE_NAME);
    }
}