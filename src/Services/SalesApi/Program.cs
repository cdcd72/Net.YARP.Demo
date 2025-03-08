using Infra.Core.HealthCheck;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using SalesApi.HealthCheck;

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

app.MapGet("/sales/{id}", (string id) =>
    {
        var sales = new List<Sale>
        {
            new("1", "Ame"),
            new("2", "Flora"),
        };
        return sales.Find(sale => sale.Id == id);
    })
    .WithName("GetSale")
    .WithOpenApi();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = HealthCheckHelper.CreateResponse
});

app.Run();

internal record Sale(string Id, string Name);