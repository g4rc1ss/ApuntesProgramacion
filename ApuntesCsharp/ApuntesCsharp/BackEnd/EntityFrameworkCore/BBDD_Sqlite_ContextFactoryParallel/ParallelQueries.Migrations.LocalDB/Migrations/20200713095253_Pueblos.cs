using Microsoft.EntityFrameworkCore.Migrations;

namespace Apuntes.Migrations.LocalDB.Migrations {
    public partial class Pueblos :Migration {
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "Pueblos",
                columns: table => new {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Pueblos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "Pueblos");
        }
    }
}
