using Infrastructure.Postgres.Scaffolding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add instanse of MyDbContext 
builder.Services.AddDbContext<MyDbContext>(conf =>
{
    var conn = builder.Configuration["AppOptions:ConnectionString"];
    conf.UseNpgsql(conn);
    // conf.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_URL"));
});

var app = builder.Build();

// Root endpoint
app.MapGet("/", () => " API is running. Try /authors, /books, /genres or /swagger");

// Endpoints
app.MapGet("/authors", ([FromServices]MyDbContext dbContext) =>
    dbContext.Authors.ToList()
    );
app.MapGet("/books", ([FromServices]MyDbContext dbContext) =>
    dbContext.Books.ToList()
);
app.MapGet("/genres", ([FromServices]MyDbContext dbContext) =>
    dbContext.Genres.ToList()
);

app.Run();
