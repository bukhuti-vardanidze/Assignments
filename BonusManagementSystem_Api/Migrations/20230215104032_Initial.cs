using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BonusManagementSystemApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrivateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    RecomedatorId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bonuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    recomendtorId = table.Column<int>(type: "int", nullable: false),
                    BonusQuantity = table.Column<double>(type: "float", nullable: false),
                    BonusIssueTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bonuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bonuses_employees_Id",
                        column: x => x.Id,
                        principalTable: "employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bonuses");

            migrationBuilder.DropTable(
                name: "employees");
        }
    }
}
