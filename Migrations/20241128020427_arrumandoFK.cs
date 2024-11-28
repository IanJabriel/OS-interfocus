using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCrud.Migrations
{
    /// <inheritdoc />
    public partial class arrumandoFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OcorrenciasOS_OcorrenciasOS_IdOrdemServico",
                table: "OcorrenciasOS");

            migrationBuilder.DropForeignKey(
                name: "FK_OcorrenciasOS_Ocorrencias_OcorrenciaId",
                table: "OcorrenciasOS");

            migrationBuilder.DropForeignKey(
                name: "FK_OcorrenciasOS_OrdensServico_OrdemServicoId",
                table: "OcorrenciasOS");

            migrationBuilder.DropIndex(
                name: "IX_OcorrenciasOS_OcorrenciaId",
                table: "OcorrenciasOS");

            migrationBuilder.DropIndex(
                name: "IX_OcorrenciasOS_OrdemServicoId",
                table: "OcorrenciasOS");

            migrationBuilder.DropColumn(
                name: "OcorrenciaId",
                table: "OcorrenciasOS");

            migrationBuilder.DropColumn(
                name: "OrdemServicoId",
                table: "OcorrenciasOS");

            migrationBuilder.AddForeignKey(
                name: "FK_OcorrenciasOS_OrdensServico_IdOrdemServico",
                table: "OcorrenciasOS",
                column: "IdOrdemServico",
                principalTable: "OrdensServico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OcorrenciasOS_OrdensServico_IdOrdemServico",
                table: "OcorrenciasOS");

            migrationBuilder.AddColumn<int>(
                name: "OcorrenciaId",
                table: "OcorrenciasOS",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrdemServicoId",
                table: "OcorrenciasOS",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OcorrenciasOS_OcorrenciaId",
                table: "OcorrenciasOS",
                column: "OcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_OcorrenciasOS_OrdemServicoId",
                table: "OcorrenciasOS",
                column: "OrdemServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_OcorrenciasOS_OcorrenciasOS_IdOrdemServico",
                table: "OcorrenciasOS",
                column: "IdOrdemServico",
                principalTable: "OcorrenciasOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OcorrenciasOS_Ocorrencias_OcorrenciaId",
                table: "OcorrenciasOS",
                column: "OcorrenciaId",
                principalTable: "Ocorrencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OcorrenciasOS_OrdensServico_OrdemServicoId",
                table: "OcorrenciasOS",
                column: "OrdemServicoId",
                principalTable: "OrdensServico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
