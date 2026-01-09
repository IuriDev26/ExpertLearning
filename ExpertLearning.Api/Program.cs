using ExpertLearning.Api.Configuration;
using ExpertLearning.Application.Configuration;
using ExpertLearning.Application.LearningContext.UseCases.CreateSubject;
using ExpertLearning.Application.SharedContext.Abstractions;
using ExpertLearning.Domain.LearningContext.Entities;
using ExpertLearning.Infrastructure.Configuration;
using IuriDev26.Mediator.Abstractions;
using Microsoft.AspNetCore.Mvc;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";
builder.Services.AddDatabaseConfiguration(connectionString);

builder.Services.AddMediator();
builder.Services.AddLearningContext();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapPost("/subject", async ([FromServices]IMediator mediator, [FromBody] Command command) =>
{
    Result<Subject> response = await mediator.SendAsync(command);
    return Results.Ok(response);
});

app.UseHttpsRedirection();
app.Run();
