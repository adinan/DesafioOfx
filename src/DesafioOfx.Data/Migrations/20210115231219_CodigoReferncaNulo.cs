using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioOfx.Data.Migrations
{
    public partial class CodigoReferncaNulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CodigoReferencia",
                table: "Transacoes",
                type: "varchar(22)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(22)");

            migrationBuilder.AlterColumn<int>(
                name: "AgenciaId",
                table: "Contas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CodigoReferencia",
                table: "Transacoes",
                type: "varchar(22)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(22)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgenciaId",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
