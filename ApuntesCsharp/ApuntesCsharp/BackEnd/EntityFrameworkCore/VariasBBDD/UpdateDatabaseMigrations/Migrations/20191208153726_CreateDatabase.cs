using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace UpdateDatabaseMigrations.Migrations {
    public partial class CreateDatabase :Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                    IDMaterial = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID = table.Column<int>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    TipoMaterial = table.Column<int>(nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Material", x => x.IDMaterial);
                    table.ForeignKey(
                        name: "FK_Material_Usuario_ID",
                        column: x => x.ID,
                        principalTable: "Usuario",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Material_ID",
                table: "Material",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
