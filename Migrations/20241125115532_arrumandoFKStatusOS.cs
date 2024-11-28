using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCrud.Migrations
{
    /// <inheritdoc />
    public partial class arrumandoFKStatusOS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdStatusOS",
                table: "OrdensServico",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrdensServico_IdStatusOS",
                table: "OrdensServico",
                column: "IdStatusOS");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdensServico_StatusOS_IdStatusOS",
                table: "OrdensServico",
                column: "IdStatusOS",
                principalTable: "StatusOS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdensServico_StatusOS_IdStatusOS",
                table: "OrdensServico");

            migrationBuilder.DropIndex(
                name: "IX_OrdensServico_IdStatusOS",
                table: "OrdensServico");

            migrationBuilder.DropColumn(
                name: "IdStatusOS",
                table: "OrdensServico");
        }
    }
}
