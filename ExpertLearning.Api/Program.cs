using ExpertLearning.Application.LearningContext.UseCases.CreateSubject;
using ExpertLearning.Domain.LearningContext.Entities;
using ExpertLearning.Infrastructure.Configuration;
using IuriDev26.Mediator.Abstractions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";
builder.Services.AddDatabaseConfiguration(connectionString);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapPost("/subject", (IMediator mediator, [FromBody] Command command) =>
{
    Task<Subject> response = mediator.SendAsync(command);
    return Results.Ok(response);
});

app.UseHttpsRedirection();
app.Run();
