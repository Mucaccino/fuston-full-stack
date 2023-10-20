using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace transacao.Migrations
{
    /// <inheritdoc />
    public partial class AddedContaId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContaId",
                table: "Transacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_ContaId",
                table: "Transacoes",
                column: "ContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Contas_ContaId",
                table: "Transacoes",
                column: "ContaId",
                principalTable: "Contas",
                principalColumn: "ContaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Contas_ContaId",
                table: "Transacoes");

            migrationBuilder.DropIndex(
                name: "IX_Transacoes_ContaId",
                table: "Transacoes");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "Transacoes");
        }
    }
}
