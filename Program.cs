using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef;
using proyectoef.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("dbTareas"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("dbTareas"));

var app = builder.Build();

app.MapGet("/", () => "Pagina OK");

app.MapGet("/conexionDB", async ([FromServices] TareasContext dbContext) => {
    dbContext.Database.EnsureCreated();
    
    return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
    
});

//Obtener todas las tareas
app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) => {
    
    return Results.Ok(dbContext.Tareas.Include(t => t.Categoria));
    
});

//Agregar nueva tarea
app.MapPost("/api/tarea", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) => {
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;

    await dbContext.AddAsync(tarea);

    await dbContext.SaveChangesAsync();

    return Results.Ok();
}); 

//Actualizar tarea
app.MapPut("/api/tarea/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) => {
    var tareaActual = dbContext.Tareas.Find(id);

    if(tareaActual != null){
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.Descripcion = tarea.Descripcion;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();    

});

//Eliminar tarea
app.MapDelete("/api/tarea/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) => {
    var tareaActual = dbContext.Tareas.Find(id);

    if(tareaActual != null) {

        dbContext.Remove(tareaActual);
        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();
});

app.Run();