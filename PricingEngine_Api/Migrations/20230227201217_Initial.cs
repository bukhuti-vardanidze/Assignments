using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PricingEngine_Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataBaseInputs",
                columns: table => new
                {
                    DataBaseInputId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintenanceRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrepaymentRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreditRiskAllocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapitalRiskRateWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataBaseInputs", x => x.DataBaseInputId);
                });

            migrationBuilder.CreateTable(
                name: "UserInputs",
                columns: table => new
                {
                    UserInputId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InterestType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalTermInMonths = table.Column<int>(type: "int", nullable: false),
                    CommitmentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MonthlyFeeIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InterestSpread = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TeaserPeriod = table.Column<int>(type: "int", nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TeaserSpread = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AvgMonthlyFeeIncome = table.Column<int>(type: "int", nullable: false),
                    DiaxountFromStandardFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInputs", x => x.UserInputId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataBaseInputs");

            migrationBuilder.DropTable(
                name: "UserInputs");
        }
    }
}
