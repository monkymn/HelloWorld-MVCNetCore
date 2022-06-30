using Microsoft.EntityFrameworkCore;
using proyectoef.Models;

namespace proyectoef;

public class TareasContext: DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get; set;}

    public TareasContext(DbContextOptions<TareasContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder){

        // Datos Semilla
        List<Categoria> categoriaSeed = new List<Categoria>();
        categoriaSeed.Add(new Categoria() {CategoriaId = Guid.Parse("70c5d507-97c8-4a27-ba63-6f6b64de0371"), Nombre = "Pendientes", Peso = 40});
        categoriaSeed.Add(new Categoria() {CategoriaId = Guid.Parse("bbe85b12-cd36-4e4f-91fe-12c9dc9d9e8d"), Nombre = "En Progreso", Peso = 60});
        categoriaSeed.Add(new Categoria() {CategoriaId = Guid.Parse("e02f60b9-bc30-47e2-b4a2-7f85745b42c6"), Nombre = "No Iniciada", Peso = 10});

        List<Tarea> tareaSeed = new List<Tarea>();
        tareaSeed.Add(new Tarea() {TareaId = Guid.Parse("90559269-84fb-4c26-a93b-311787b0f522"), CategoriaId = Guid.Parse("70c5d507-97c8-4a27-ba63-6f6b64de0371"), Titulo = "Tender cama", PrioridadTarea = Prioridad.Media, FechaCreacion = DateTime.Now});
        tareaSeed.Add(new Tarea() {TareaId = Guid.Parse("9892d8af-9648-4fe9-8433-7fd2a2b36055"), CategoriaId = Guid.Parse("bbe85b12-cd36-4e4f-91fe-12c9dc9d9e8d"), Titulo = "Clases Programación", PrioridadTarea = Prioridad.Alta, FechaCreacion = DateTime.Now });
        tareaSeed.Add(new Tarea() {TareaId = Guid.Parse("3c2428ff-5631-417e-8b10-8f2a309acefd"), CategoriaId = Guid.Parse("e02f60b9-bc30-47e2-b4a2-7f85745b42c6"), Titulo = "Cocinar", PrioridadTarea = Prioridad.Baja, FechaCreacion = DateTime.Now });

        // Definición de Modelo con Fluent API
        modelBuilder.Entity<Categoria>(categoria => {
            categoria.ToTable("Categoria");
            categoria.HasKey("CategoriaId");
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Descripcion).IsRequired(false); 
            categoria.Property(p => p.Peso);
            categoria.HasData(categoriaSeed);
        });

        modelBuilder.Entity<Tarea>(tarea => {
            tarea.ToTable("Tarea");
            tarea.HasKey(t => t.TareaId);
            tarea.HasOne(c => c.Categoria).WithMany(t => t.Tareas).HasForeignKey(t => t.CategoriaId);
            tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(150);
            tarea.Property(t => t.Descripcion).IsRequired(false);
            tarea.Property(t => t.PrioridadTarea);
            tarea.Property(t => t.FechaCreacion);
            tarea.HasData(tareaSeed);
        });
    }
}