using Microsoft.EntityFrameworkCore;
using MovieAPI.Data.Contexts;
using MovieAPI.Data.Models;

var builder = WebApplication.CreateBuilder(args);

foreach (var item in args)
{
    Console.WriteLine(item);
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MovieDbContext>(ops => ops.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/Rating", async (MovieDbContext db) =>
{
    var movies = await db.Movies.ToListAsync();
    return Results.Ok(movies);
})
.WithOpenApi()
.WithName("GetRating")
.WithDescription("Get movies rating from database");


app.MapGet("/Search/{title}", async (MovieDbContext db, string title) =>
{
    var movie = await db.Movies.FindAsync(title);
    return movie is not null ? Results.Ok(movie) : Results.NotFound();
})
.WithOpenApi()
.WithName("Search")
.WithDescription("Get movie from database by title");


app.MapPost("/AddMovie", async (MovieDbContext db, Movie movie) =>
{
    await db.Movies.AddAsync(movie);
    await db.SaveChangesAsync();
    return Results.Created($"/getcar/{movie.Title}", movie);
})
.WithOpenApi()
.WithName("AddMovie")
.WithDescription("Add a new movie to database");



app.MapPost("/AddCategory", async (MovieDbContext db, Category category) =>
{
    await db.Categories.AddAsync(category);
    await db.SaveChangesAsync();
    return Results.Created($"/getcar/{category.CategoryId}", category);
})
.WithOpenApi()
.WithName("AddCategory")
.WithDescription("Add a new category to database");

app.Run();
