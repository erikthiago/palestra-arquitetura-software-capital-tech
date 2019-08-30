using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SchoolOccurrences.School.Infa.Migrations
{
    public partial class AlterNameColStudentAddressNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstTEnderecoNumero",
                table: "EstEstudante",
                newName: "EstEnderecoNumero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstEnderecoNumero",
                table: "EstEstudante",
                newName: "EstTEnderecoNumero");
        }
    }
}
