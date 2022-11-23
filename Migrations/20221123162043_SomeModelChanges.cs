using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberPROv3.Migrations
{
    /// <inheritdoc />
    public partial class SomeModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Caixas_CaixaDestinoId",
                table: "Atendimentos");

            migrationBuilder.AlterColumn<int>(
                name: "CaixaDestinoId",
                table: "Atendimentos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalGeral",
                table: "Atendimentos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Caixas_CaixaDestinoId",
                table: "Atendimentos",
                column: "CaixaDestinoId",
                principalTable: "Caixas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Caixas_CaixaDestinoId",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "TotalGeral",
                table: "Atendimentos");

            migrationBuilder.AlterColumn<int>(
                name: "CaixaDestinoId",
                table: "Atendimentos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Caixas_CaixaDestinoId",
                table: "Atendimentos",
                column: "CaixaDestinoId",
                principalTable: "Caixas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
