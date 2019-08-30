using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SchoolOccurrences.School.Infa.Migrations
{
    public partial class AlterTableStudentCascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OcrOcorrencia_EstEstudante_StudentId",
                table: "OcrOcorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_ResResponsavel_EstEstudante_StudentId",
                table: "ResResponsavel");

            migrationBuilder.AddForeignKey(
                name: "FK_OcrOcorrencia_EstEstudante_StudentId",
                table: "OcrOcorrencia",
                column: "StudentId",
                principalTable: "EstEstudante",
                principalColumn: "EstId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ResResponsavel_EstEstudante_StudentId",
                table: "ResResponsavel",
                column: "StudentId",
                principalTable: "EstEstudante",
                principalColumn: "EstId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OcrOcorrencia_EstEstudante_StudentId",
                table: "OcrOcorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_ResResponsavel_EstEstudante_StudentId",
                table: "ResResponsavel");

            migrationBuilder.AddForeignKey(
                name: "FK_OcrOcorrencia_EstEstudante_StudentId",
                table: "OcrOcorrencia",
                column: "StudentId",
                principalTable: "EstEstudante",
                principalColumn: "EstId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ResResponsavel_EstEstudante_StudentId",
                table: "ResResponsavel",
                column: "StudentId",
                principalTable: "EstEstudante",
                principalColumn: "EstId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
