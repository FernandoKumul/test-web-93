using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi93.Migrations
{
    public partial class example : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    PkRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.PkRol);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    PkUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FkRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.PkUsuario);
                    table.ForeignKey(
                        name: "FK_usuarios_roles_FkRol",
                        column: x => x.FkRol,
                        principalTable: "roles",
                        principalColumn: "PkRol");
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "PkRol", "Nombre" },
                values: new object[] { 1, "sa" });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "PkUsuario", "FkRol", "Name", "Password", "User" },
                values: new object[] { 1, 1, "Fernando", "1234", "Usuario" });

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_FkRol",
                table: "usuarios",
                column: "FkRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
