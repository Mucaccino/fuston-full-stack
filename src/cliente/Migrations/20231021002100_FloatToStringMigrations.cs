using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cliente.Migrations
{
    /// <inheritdoc />
    public partial class FloatToStringMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Documento",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 1,
                columns: new[] { "Documento", "Password" },
                values: new object[] { "01421586584", "$2a$11$Na7BCqtllJJC.Wz.pCBbGu9ekLI99UfjjK3fRQ/pRCQ9Csl66t.Tq" });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 2,
                columns: new[] { "Documento", "Password" },
                values: new object[] { "58666889640", "$2a$11$Na7BCqtllJJC.Wz.pCBbGu9ekLI99UfjjK3fRQ/pRCQ9Csl66t.Tq" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Documento",
                table: "Clientes",
                type: "real",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 1,
                columns: new[] { "Documento", "Password" },
                values: new object[] { 1.4215866E+09f, "Gt9Yc4AiIvmsC1QQbe2RZsCIqvoYlst2xbz0Fs8aHnw=" });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 2,
                columns: new[] { "Documento", "Password" },
                values: new object[] { 5.866689E+10f, "Gt9Yc4AiIvmsC1QQbe2RZsCIqvoYlst2xbz0Fs8aHnw=" });
        }
    }
}
