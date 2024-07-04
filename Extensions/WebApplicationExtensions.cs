using FluentMigrator.Runner;

namespace GradeBook.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UpdateDatabase(this WebApplication app)
    {
        if (app.Configuration.GetSection("FluentMigrator") == null) return app;

        app.Lifetime.ApplicationStarted.Register(() =>
        {

            using var scope = app.Services.CreateScope();
            var runner = scope.ServiceProvider
                .GetRequiredService<IMigrationRunner>();

            var migrationVersion = app.Configuration
                .GetValue<int>("FluentMigrator:MigrationVersion");
            var operation = app.Configuration
                .GetValue<string>("FluentMigrator:Operation");

            if (operation == "up")
            {
                runner.MigrateUp(migrationVersion);
            }
            else if (operation == "down")
            {
                runner.MigrateDown(migrationVersion);
            }
        });

        return app;
    }

}