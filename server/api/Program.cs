using api;
using api.Services;
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

builder.Services.AddControllers(); //registers the controllers in the application with (DI)
builder.Services.AddOpenApiDocument();
builder.Services.AddCors(); 
builder.Services.AddExceptionHandler<GlobalExeptionHendler>();
builder.Services.AddProblemDetails();
builder.Services.AddScoped<IBookService ,BookService>();

var app = builder.Build();

app.UseCors(config => config.
    AllowAnyOrigin().
    AllowAnyMethod().
    AllowAnyHeader().
    SetIsOriginAllowed(x => true));

app.MapControllers();

app.UseOpenApi();
app.UseSwaggerUi();
app.UseExceptionHandler();

app.Run();
