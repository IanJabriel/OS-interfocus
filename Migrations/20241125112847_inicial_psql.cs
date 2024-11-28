using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiCrud.Migrations
{
    /// <inheritdoc />
    public partial class inicial_psql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IdContrato = table.Column<int>(type: "integer", nullable: false),
                    CpfCnpj = table.Column<string>(type: "text", nullable: false),
                    IdCidade = table.Column<int>(type: "integer", nullable: true),
                    IdEstado = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ocorrencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    Anexo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocorrencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdensServico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdTipoServico = table.Column<int>(type: "integer", nullable: false),
                    DataAgendamento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdContrato = table.Column<int>(type: "integer", nullable: false),
                    IdCliente = table.Column<int>(type: "integer", nullable: false),
                    IdFuncionarioAbriu = table.Column<int>(type: "integer", nullable: false),
                    IdFuncionarioFechou = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdensServico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPlano",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPlano", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposServico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StatusCt = table.Column<int>(type: "integer", nullable: false),
                    MudancaContrato = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposServico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCliente = table.Column<int>(type: "integer", nullable: false),
                    IdEndereco = table.Column<int>(type: "integer", nullable: false),
                    IdEquipamento = table.Column<int>(type: "integer", nullable: false),
                    StatusContrato = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contrato_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OcorrenciasOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdOrdemServico = table.Column<int>(type: "integer", nullable: false),
                    IdOcorrencia = table.Column<int>(type: "integer", nullable: false),
                    OrdemServicoId = table.Column<int>(type: "integer", nullable: false),
                    OcorrenciaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcorrenciasOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OcorrenciasOS_OcorrenciasOS_IdOrdemServico",
                        column: x => x.IdOrdemServico,
                        principalTable: "OcorrenciasOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OcorrenciasOS_Ocorrencias_IdOcorrencia",
                        column: x => x.IdOcorrencia,
                        principalTable: "Ocorrencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OcorrenciasOS_Ocorrencias_OcorrenciaId",
                        column: x => x.OcorrenciaId,
                        principalTable: "Ocorrencias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OcorrenciasOS_OrdensServico_OrdemServicoId",
                        column: x => x.OrdemServicoId,
                        principalTable: "OrdensServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plano",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    IdTipo = table.Column<int>(type: "integer", nullable: false),
                    Combo = table.Column<bool>(type: "boolean", nullable: false),
                    Tier = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plano", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plano_TipoPlano_IdTipo",
                        column: x => x.IdTipo,
                        principalTable: "TipoPlano",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_IdCliente",
                table: "Contrato",
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
                name: "IX_OcorrenciasOS_OcorrenciaId",
                table: "OcorrenciasOS",
                column: "OcorrenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_OcorrenciasOS_OrdemServicoId",
                table: "OcorrenciasOS",
                column: "OrdemServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Plano_IdTipo",
                table: "Plano",
                column: "IdTipo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "OcorrenciasOS");

            migrationBuilder.DropTable(
                name: "Plano");

            migrationBuilder.DropTable(
                name: "StatusOS");

            migrationBuilder.DropTable(
                name: "TiposServico");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Ocorrencias");

            migrationBuilder.DropTable(
                name: "OrdensServico");

            migrationBuilder.DropTable(
                name: "TipoPlano");
        }
    }
}
