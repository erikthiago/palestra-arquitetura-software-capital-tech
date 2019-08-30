using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SchoolOccurrences.School.Infa.Migrations
{
    public partial class AddColShiftStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Shifts",
                table: "EstEstudante",
                newName: "EstTurno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstTurno",
                table: "EstEstudante",
                newName: "Shifts");
        }
    }
}
