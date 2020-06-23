using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.Data
{
    public partial class TeachersStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dni = table.Column<int>(nullable: false),
                    names = table.Column<string>(maxLength: 50, nullable: false),
                    surnames = table.Column<string>(maxLength: 50, nullable: false),
                    address = table.Column<string>(maxLength: 100, nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<int>(nullable: false),
                    deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dni = table.Column<int>(nullable: false),
                    names = table.Column<string>(maxLength: 50, nullable: false),
                    surnames = table.Column<string>(maxLength: 50, nullable: false),
                    address = table.Column<string>(maxLength: 100, nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<int>(nullable: false),
                    deleted = table.Column<bool>(nullable: false),
                    TeachersIdentityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                    table.ForeignKey(
                        name: "FK_Students_Teachers_TeachersIdentityId",
                        column: x => x.TeachersIdentityId,
                        principalTable: "Teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_TeachersIdentityId",
                table: "Students",
                column: "TeachersIdentityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
