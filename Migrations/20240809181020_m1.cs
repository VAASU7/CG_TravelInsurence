using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Travel_Insurance.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentID = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    Department = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Agents__9AC3BFD12309DED6", x => x.AgentID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__A4AE64B824C23CDC", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    PolicyID = table.Column<int>(type: "integer", nullable: false),
                    CustomerID = table.Column<int>(type: "integer", nullable: true),
                    PolicyNumber = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CoverageDetails = table.Column<string>(type: "text", nullable: true),
                    PremiumAmount = table.Column<decimal>(type: "numeric(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Policies__2E13394459265849", x => x.PolicyID);
                    table.ForeignKey(
                        name: "FK__Policies__Custom__267ABA7A",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    ClaimID = table.Column<int>(type: "integer", nullable: false),
                    PolicyID = table.Column<int>(type: "integer", nullable: true),
                    DateSubmitted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ClaimStatus = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    ClaimAmount = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    ClaimDetails = table.Column<string>(type: "text", nullable: true),
                    DateProcessed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ProcessorComments = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Claims__EF2E13BB86A1F247", x => x.ClaimID);
                    table.ForeignKey(
                        name: "FK__Claims__PolicyID__29572725",
                        column: x => x.PolicyID,
                        principalTable: "Policies",
                        principalColumn: "PolicyID");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "integer", nullable: false),
                    ClaimID = table.Column<int>(type: "integer", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AmountPaid = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    PaymentMethod = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true),
                    TransactionID = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payments__9B556A58497FBAEF", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK__Payments__ClaimI__2C3393D0",
                        column: x => x.ClaimID,
                        principalTable: "Claims",
                        principalColumn: "ClaimID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Claims_PolicyID",
                table: "Claims",
                column: "PolicyID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ClaimID",
                table: "Payments",
                column: "ClaimID");

            migrationBuilder.CreateIndex(
                name: "IX_Policies_CustomerID",
                table: "Policies",
                column: "CustomerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
