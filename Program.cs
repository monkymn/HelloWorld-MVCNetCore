using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("dbTareas"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("dbTareas"));

var app = builder.Build();

app.MapGet("/", () => "Pagina OK");

app.MapGet("/conexionDB", async ([FromServices] TareasContext dbContext) => {
    dbContext.Database.EnsureCreated();
    
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
    
});

app.Run();