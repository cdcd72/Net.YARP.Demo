var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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

app.UseHttpsRedirection();

app.Run();

internal record Sale(string Id, string Name);