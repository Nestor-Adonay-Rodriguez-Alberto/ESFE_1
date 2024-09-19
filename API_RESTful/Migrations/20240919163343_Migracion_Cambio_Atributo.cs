using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_RESTful.Migrations
{
    public partial class Migracion_Cambio_Atributo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salaraio",
                table: "Empleados",
                newName: "Salario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salario",
                table: "Empleados",
                newName: "Salaraio");
        }
    }
}
