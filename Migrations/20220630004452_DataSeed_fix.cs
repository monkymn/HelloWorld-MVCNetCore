using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyectoAspCore.Migrations
{
    public partial class DataSeed_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("70c5d507-97c8-4a27-ba63-6f6b64de0371"), null, "Pendientes", 40 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("bbe85b12-cd36-4e4f-91fe-12c9dc9d9e8d"), null, "En Progreso", 60 });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[] { new Guid("e02f60b9-bc30-47e2-b4a2-7f85745b42c6"), null, "No Iniciada", 10 });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("3c2428ff-5631-417e-8b10-8f2a309acefd"), new Guid("e02f60b9-bc30-47e2-b4a2-7f85745b42c6"), null, new DateTime(2022, 6, 29, 19, 44, 52, 307, DateTimeKind.Local).AddTicks(5501), 0, "Cocinar" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("90559269-84fb-4c26-a93b-311787b0f522"), new Guid("70c5d507-97c8-4a27-ba63-6f6b64de0371"), null, new DateTime(2022, 6, 29, 19, 44, 52, 307, DateTimeKind.Local).AddTicks(5459), 1, "Tender cama" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "Titulo" },
                values: new object[] { new Guid("9892d8af-9648-4fe9-8433-7fd2a2b36055"), new Guid("bbe85b12-cd36-4e4f-91fe-12c9dc9d9e8d"), null, new DateTime(2022, 6, 29, 19, 44, 52, 307, DateTimeKind.Local).AddTicks(5498), 2, "Clases Programación" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("3c2428ff-5631-417e-8b10-8f2a309acefd"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("90559269-84fb-4c26-a93b-311787b0f522"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("9892d8af-9648-4fe9-8433-7fd2a2b36055"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("70c5d507-97c8-4a27-ba63-6f6b64de0371"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("bbe85b12-cd36-4e4f-91fe-12c9dc9d9e8d"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("e02f60b9-bc30-47e2-b4a2-7f85745b42c6"));
        }
    }
}
