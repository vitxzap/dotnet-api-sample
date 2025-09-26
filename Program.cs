using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserDb>(opt => opt.UseInMemoryDatabase("AllUsers"));
var app = builder.Build();

app.MapGet("/users", async (UserDb db) => await db.Users.ToListAsync());

app.MapGet("/users/{id}", async (int id, UserDb db) =>
    await db.Users.FindAsync(id)
        is User user
        ? Results.Ok(user)
        : Results.NotFound());

app.MapPost("/users", async (User UserData, UserDb db) =>
{
    db.Users.Add(UserData);
    await db.SaveChangesAsync();
    return Results.Created($"/users/{UserData.Id}", UserData);
});

app.Run();
