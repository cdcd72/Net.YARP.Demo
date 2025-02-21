var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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

app.UseHttpsRedirection();

app.Run();

internal record User(string Id, string Name);