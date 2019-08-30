using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SchoolOccurrences.School.Infa.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EscEscola",
                columns: table => new
                {
                    EscId = table.Column<Guid>(nullable: false),
                    EscNome = table.Column<string>(type: "varchar(50)", nullable: false),
                    EscTelefone = table.Column<string>(type: "varchar(10)", nullable: false),
                    EscSiglaUf = table.Column<int>(type: "int", nullable: false),
                    EscCidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    EscPais = table.Column<string>(type: "varchar(50)", nullable: false),
                    EscBairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    EscTEnderecoNumero = table.Column<int>(type: "int", nullable: false),
                    EscUf = table.Column<string>(type: "varchar(50)", nullable: false),
                    EscRua = table.Column<string>(type: "varchar(50)", nullable: false),
                    EscCep = table.Column<string>(type: "varchar(8)", nullable: false),
                    EscNumeroDocumento = table.Column<string>(type: "varchar(14)", nullable: false),
                    EscTipoDocumento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscEscola", x => x.EscId);
                });

            migrationBuilder.CreateTable(
                name: "EstEstudante",
                columns: table => new
                {
                    EstId = table.Column<Guid>(nullable: false),
                    EstAnoLetivo = table.Column<DateTime>(type: "datetime", nullable: false),
                    EstDataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstNumeroChamada = table.Column<int>(type: "int", nullable: false),
                    EstTipoEnsino = table.Column<int>(type: "int", nullable: false),
                    EstTurma = table.Column<string>(type: "varchar(1)", nullable: false),
                    EstObservacao = table.Column<string>(type: "varchar(255)", nullable: false),
                    SchoolId = table.Column<Guid>(nullable: true),
                    EstSerie = table.Column<int>(type: "int", nullable: false),
                    Shifts = table.Column<int>(nullable: false),
                    EstSiglaUf = table.Column<int>(type: "int", nullable: false),
                    EstCidade = table.Column<string>(type: "varchar(50)", nullable: false),
                    EstPais = table.Column<string>(type: "varchar(50)", nullable: false),
                    EstBairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    EstTEnderecoNumero = table.Column<int>(type: "int", nullable: false),
                    EstUf = table.Column<string>(type: "varchar(50)", nullable: false),
                    EstRua = table.Column<string>(type: "varchar(50)", nullable: false),
                    EstCep = table.Column<string>(type: "varchar(8)", nullable: false),
                    EstNome = table.Column<string>(type: "varchar(60)", nullable: false),
                    EstSobreNome = table.Column<string>(type: "varchar(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstEstudante", x => x.EstId);
                    table.ForeignKey(
                        name: "FK_EstEstudante_EscEscola_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "EscEscola",
                        principalColumn: "EscId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OcrOcorrencia",
                columns: table => new
                {
                    OcrId = table.Column<Guid>(nullable: false),
                    OcrCausa = table.Column<string>(type: "varchar(255)", nullable: false),
                    OcrData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OcrDescricao = table.Column<string>(type: "varchar(255)", nullable: false),
                    OcrSituacao = table.Column<int>(type: "int", nullable: false),
                    OcrTipo = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcrOcorrencia", x => x.OcrId);
                    table.ForeignKey(
                        name: "FK_OcrOcorrencia_EstEstudante_StudentId",
                        column: x => x.StudentId,
                        principalTable: "EstEstudante",
                        principalColumn: "EstId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResResponsavel",
                columns: table => new
                {
                    ResId = table.Column<Guid>(nullable: false),
                    ResTelefoneAlternativo = table.Column<string>(type: "varchar(10)", nullable: true),
                    ResTelefoneContato = table.Column<string>(type: "varchar(10)", nullable: true),
                    ResFamiliaridade = table.Column<int>(type: "int", nullable: false),
                    ResNome = table.Column<string>(type: "varchar(100)", nullable: false),
                    StudentId = table.Column<Guid>(nullable: true),
                    ResTelefonePrincipal = table.Column<string>(type: "varchar(10)", nullable: false),
                    ResNumeroDocumento = table.Column<string>(type: "varchar(14)", nullable: false),
                    ResTipoDocumento = table.Column<int>(type: "int", nullable: false),
                    ResEmail = table.Column<string>(type: "varchar(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResResponsavel", x => x.ResId);
                    table.ForeignKey(
                        name: "FK_ResResponsavel_EstEstudante_StudentId",
                        column: x => x.StudentId,
                        principalTable: "EstEstudante",
                        principalColumn: "EstId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstEstudante_SchoolId",
                table: "EstEstudante",
                column: "SchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_OcrOcorrencia_StudentId",
                table: "OcrOcorrencia",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ResResponsavel_StudentId",
                table: "ResResponsavel",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OcrOcorrencia");

            migrationBuilder.DropTable(
                name: "ResResponsavel");

            migrationBuilder.DropTable(
                name: "EstEstudante");

            migrationBuilder.DropTable(
                name: "EscEscola");
        }
    }
}
