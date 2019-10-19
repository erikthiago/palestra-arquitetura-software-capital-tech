using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SchoolOccurrences.School.Infa.Migrations
{
    public partial class ChangeSchoolAddressNumberColName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EscTEnderecoNumero",
                table: "EscEscola",
                newName: "EscEnderecoNumero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EscEnderecoNumero",
                table: "EscEscola",
                newName: "EscTEnderecoNumero");
        }
    }
}
