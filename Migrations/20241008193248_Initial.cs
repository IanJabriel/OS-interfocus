using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCrud.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IdContrato = table.Column<int>(type: "INTEGER", nullable: false),
                    CpfCnpj = table.Column<string>(type: "TEXT", nullable: false),
                    IdCidade = table.Column<int>(type: "INTEGER", nullable: true),
                    IdEstado = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ocorrencias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    Anexo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposPlano",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPlano", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdCliente = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdEndereco = table.Column<int>(type: "INTEGER", nullable: false),
                    IdEquipamento = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusContrato = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Planos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    IdTipo = table.Column<Guid>(type: "TEXT", nullable: false),
                    Combo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Tier = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Planos_TiposPlano_IdTipo",
                        column: x => x.IdTipo,
                        principalTable: "TiposPlano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade); 
                });

            migrationBuilder.CreateTable(
                name: "TiposServico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IdContrato = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposServico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposServico_Contratos_IdContrato",
                        column: x => x.IdContrato,
                        principalTable: "Contratos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OcorrenciasOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdOrdemServico = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdOcorrencia = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcorrenciasOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OcorrenciasOS_Ocorrencias_IdOcorrencia",
                        column: x => x.IdOcorrencia,
                        principalTable: "Ocorrencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdensServico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdTipoServico = table.Column<Guid>(type: "TEXT", nullable: false),
                    DataAgendamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdContrato = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdCliente = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdStatusOS = table.Column<Guid>(type: "TEXT", nullable: false),
                    FuncionarioAbriu = table.Column<Guid>(type: "TEXT", nullable: false),
                    IdFuncionarioFechou = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdensServico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    OrdemServicoId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusOS_OrdensServico_OrdemServicoId",
                        column: x => x.OrdemServicoId,
                        principalTable: "OrdensServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_IdCliente",
                table: "Contratos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_OcorrenciasOS_IdOcorrencia",
                table: "OcorrenciasOS",
                column: "IdOcorrencia");

            migrationBuilder.CreateIndex(
                name: "IX_OcorrenciasOS_IdOrdemServico",
                table: "OcorrenciasOS",
                column: "IdOrdemServico");

            migrationBuilder.CreateIndex(
                name: "IX_OrdensServico_IdStatusOS",
                table: "OrdensServico",
                column: "IdStatusOS");

            migrationBuilder.CreateIndex(
                name: "IX_Planos_IdTipo",
                table: "Planos",
                column: "IdTipo");

            migrationBuilder.CreateIndex(
                name: "IX_StatusOS_OrdemServicoId",
                table: "StatusOS",
                column: "OrdemServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposServico_IdContrato",
                table: "TiposServico",
                column: "IdContrato");

            migrationBuilder.AddForeignKey(
                name: "FK_OcorrenciasOS_OrdensServico_IdOrdemServico",
                table: "OcorrenciasOS",
                column: "IdOrdemServico",
                principalTable: "OrdensServico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_StatusOS_OrdensServico_OrdemServicoId",
                table: "StatusOS");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "OcorrenciasOS");

            migrationBuilder.DropTable(
                name: "Planos");

            migrationBuilder.DropTable(
                name: "TiposServico");

            migrationBuilder.DropTable(
                name: "Ocorrencias");

            migrationBuilder.DropTable(
                name: "TiposPlano");

            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "OrdensServico");

            migrationBuilder.DropTable(
                name: "StatusOS");
        }
    }
}
