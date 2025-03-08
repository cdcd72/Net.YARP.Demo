using Infra.Core.HealthCheck;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using UsersApi.HealthCheck;

var builder = WebApplication.CreateBuilder(args);

#region Config App

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddHealthChecks()
    .AddCheck<TaskHealthCheck>("Task", tags: ["api"]);

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.MapGet("/users/{id}", (string id) =>
    {
        var users = new List<User>
        {
            new("1", "Ben"),
            new("2", "May"),
        };
        return users.Find(user => user.Id == id);
    })
    .WithName("GetUser")
    .WithOpenApi();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = HealthCheckHelper.CreateResponse
});

app.Run();

internal record User(string Id, string Name);