using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MigrationsSqlServer.Migrations;

public partial class CrearDatabase : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Pueblos",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
            },
            constraints: table => table.PrimaryKey("PK_Pueblos", x => x.Id));

        migrationBuilder.CreateTable(
            name: "Usuarios",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                PuebloId = table.Column<int>(type: "int", nullable: false),
                Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Edad = table.Column<int>(type: "int", nullable: false),
                FechaHoy = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Usuarios", x => x.Id);
                table.ForeignKey(
                    name: "FK_Usuarios_Pueblos_PuebloId",
                    column: x => x.PuebloId,
                    principalTable: "Pueblos",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Usuarios_PuebloId",
            table: "Usuarios",
            column: "PuebloId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Usuarios");

        migrationBuilder.DropTable(
            name: "Pueblos");
    }
}
