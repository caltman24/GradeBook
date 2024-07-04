using System.Data;
using System.Reflection;
using Dapper;
using FluentMigrator.Runner;
using GradeBook;
using GradeBook.Extensions;
using GradeBook.Models;
using GradeBook.Repositories;
using GradeBook.Routes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

DefaultTypeMap.MatchNamesWithUnderscores = true;

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services
    .AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddPostgres()
        .WithGlobalConnectionString(builder.Configuration.GetConnectionString("postgres"))
        .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
        .AddLogging(lb => lb.ClearProviders().AddFluentMigratorConsole());


var app = builder.Build();

app.MapStudentRoute();

app.MapGet("/error", () => TypedResults.Problem());

app.UseExceptionHandler("/error");

app.UpdateDatabase();

app.Run();

