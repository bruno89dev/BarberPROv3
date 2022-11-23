using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberPROv3.Migrations
{
    /// <inheritdoc />
    public partial class NewModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtendimentoItens_Atendimentos_AtendimentoId",
                table: "AtendimentoItens");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Caixas_CaixaDestinoId",
                table: "Atendimentos");

            migrationBuilder.DropIndex(
                name: "IX_Atendimentos_CaixaDestinoId",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "CaixaDestinoId",
                table: "Atendimentos");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalGeral",
                table: "Atendimentos",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "CaixaId",
                table: "Atendimentos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "AtendimentoId",
                table: "AtendimentoItens",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_CaixaId",
                table: "Atendimentos",
                column: "CaixaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtendimentoItens_Atendimentos_AtendimentoId",
                table: "AtendimentoItens",
                column: "AtendimentoId",
                principalTable: "Atendimentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Caixas_CaixaId",
                table: "Atendimentos",
                column: "CaixaId",
                principalTable: "Caixas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtendimentoItens_Atendimentos_AtendimentoId",
                table: "AtendimentoItens");

            migrationBuilder.DropForeignKey(
                name: "FK_Atendimentos_Caixas_CaixaId",
                table: "Atendimentos");

            migrationBuilder.DropIndex(
                name: "IX_Atendimentos_CaixaId",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "CaixaId",
                table: "Atendimentos");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalGeral",
                table: "Atendimentos",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.AddColumn<int>(
                name: "CaixaDestinoId",
                table: "Atendimentos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AtendimentoId",
                table: "AtendimentoItens",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_CaixaDestinoId",
                table: "Atendimentos",
                column: "CaixaDestinoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtendimentoItens_Atendimentos_AtendimentoId",
                table: "AtendimentoItens",
                column: "AtendimentoId",
                principalTable: "Atendimentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atendimentos_Caixas_CaixaDestinoId",
                table: "Atendimentos",
                column: "CaixaDestinoId",
                principalTable: "Caixas",
                principalColumn: "Id");
        }
    }
}
