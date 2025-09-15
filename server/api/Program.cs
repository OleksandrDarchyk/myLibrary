using api;
using Infrastructure.Postgres.Scaffolding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Register AppOptions from appsettings.json into the DI container
var appOptions = builder.Services.AddAppOptions(builder.Configuration);

// Add instanse of MyDbContext 
builder.Services.AddDbContext<MyDbContext>(conf =>
{
    conf.UseNpgsql(appOptions.DbConnectionString);
});

var app = builder.Build();

// Root endpoint
app.MapGet("/", () => " API is running. Try /authors, /books, /genres or /swagger");

// Endpoints
app.MapGet("/authors", (
        [FromServices]IOptionsMonitor<AppOptions> optionMonitor,
        [FromServices]MyDbContext dbContext) =>
 
    dbContext.Authors.ToList()
    );
app.MapGet("/books", ([FromServices]MyDbContext dbContext) =>
    dbContext.Books.ToList()
);
app.MapGet("/genres", ([FromServices]MyDbContext dbContext) =>
    dbContext.Genres.ToList()
);

app.Run();
