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

builder.Services.AddCors(); 

var app = builder.Build();

app.UseCors(config => config.
    AllowAnyOrigin().
    AllowAnyMethod().
    AllowAnyHeader().
    SetIsOriginAllowed(x => true));


// Root endpoint
// Root endpoint
app.MapGet("/", ([FromServices]MyDbContext dbContext) =>
{
    var response = new
    {
        Description = "My Library API",
        Title = "My Library API",
        Id = Guid.NewGuid().ToString(),
        Books = dbContext.Books.ToList()
    };

    return Results.Json(response);
});


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
