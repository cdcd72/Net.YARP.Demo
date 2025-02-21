var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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

app.UseHttpsRedirection();

app.Run();

internal record Product(string Id, string Name);
