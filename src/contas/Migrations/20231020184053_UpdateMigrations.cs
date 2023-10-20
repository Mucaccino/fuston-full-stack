using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace contas.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencias",
                columns: table => new
                {
                    AgenciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencias", x => x.AgenciaId);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    ContaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgenciaId = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<float>(type: "real", nullable: false),
                    Saldo = table.Column<float>(type: "real", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.ContaId);
                    table.ForeignKey(
                        name: "FK_Contas_Agencias_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "Agencias",
                        principalColumn: "AgenciaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Agencias",
                columns: new[] { "AgenciaId", "Numero" },
                values: new object[] { 1, 1010f });

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "ContaId", "AgenciaId", "ClienteId", "Numero", "Saldo" },
                values: new object[,]
                {
                    { 1, 1, 1, 123456790f, 1100f },
                    { 2, 1, 2, 987654340f, 2200f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contas_AgenciaId",
                table: "Contas",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_ClienteId",
                table: "Contas",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Agencias");
        }
    }
}
