using Infra.Core.HealthCheck;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using ProductsApi.HealthCheck;

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

app.MapGet("/products/{id}", (string id) =>
    {
        var products = new List<Product>
        {
            new("1", "Apple"),
            new("2", "Banana"),
        };
        return products.Find(product => product.Id == id);
    })
    .WithName("GetProduct")
    .WithOpenApi();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = HealthCheckHelper.CreateResponse
});

app.Run();

internal record Product(string Id, string Name);
