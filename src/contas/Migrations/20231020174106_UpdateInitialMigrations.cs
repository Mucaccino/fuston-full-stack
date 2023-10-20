using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace contas.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencia",
                columns: table => new
                {
                    AgenciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencia", x => x.AgenciaId);
                });

            migrationBuilder.CreateTable(
                name: "Conta",
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
                    table.PrimaryKey("PK_Conta", x => x.ContaId);
                    table.ForeignKey(
                        name: "FK_Conta_Agencia_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "Agencia",
                        principalColumn: "AgenciaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conta_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Agencia",
                columns: new[] { "AgenciaId", "Numero" },
                values: new object[] { 1, 1010f });

            migrationBuilder.InsertData(
                table: "Conta",
                columns: new[] { "ContaId", "AgenciaId", "ClienteId", "Numero", "Saldo" },
                values: new object[,]
                {
                    { 1, 1, 1, 123456790f, 1100f },
                    { 2, 1, 2, 987654340f, 2200f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conta_AgenciaId",
                table: "Conta",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Conta_ClienteId",
                table: "Conta",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "Agencia");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
