using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace contas.Migrations
{
    /// <inheritdoc />
    public partial class FloatToStringMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Contas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Agencias",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Agencias",
                keyColumn: "AgenciaId",
                keyValue: 1,
                column: "Numero",
                value: "1010");

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "ContaId",
                keyValue: 1,
                column: "Numero",
                value: "123456789");

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "ContaId",
                keyValue: 2,
                column: "Numero",
                value: "987654321");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Numero",
                table: "Contas",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Agencias",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Agencias",
                keyColumn: "AgenciaId",
                keyValue: 1,
                column: "Numero",
                value: 1010);

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "ContaId",
                keyValue: 1,
                column: "Numero",
                value: 123456790f);

            migrationBuilder.UpdateData(
                table: "Contas",
                keyColumn: "ContaId",
                keyValue: 2,
                column: "Numero",
                value: 987654340f);
        }
    }
}
