using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Apuntes.Migrations.SqlServer.Migrations {
    public partial class Migration_SqlServerRemote : Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false),
                    FechaHoy = table.Column<DateTime>(nullable: false),
                    Direccion = table.Column<string>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Usuario", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new {
                    ID = table.Column<int>(nullable: false),
                    IDMaterial = table.Column<int>(nullable: false),
                    Material = table.Column<string>(nullable: true),
                    TipoMaterial = table.Column<int>(nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Material", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Material_Usuario_ID",
                        column: x => x.ID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
