using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YCompanyThirdPartyAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coverage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoverageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverageGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPolicyCoverage = table.Column<bool>(type: "bit", nullable: false),
                    IsVehicleCoverage = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coverage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolicyNumber = table.Column<int>(type: "int", nullable: false),
                    PolicyEffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolicyExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentOption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    AdditionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseIssuedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LicenseIssuedState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LicenseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrimaryPolicyHolder = table.Column<bool>(type: "bit", nullable: false),
                    RelationWithPrimaryPolicyHolder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Driver_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Policy_Coverage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    CoverageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy_Coverage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Policy_Coverage_Coverage_CoverageId",
                        column: x => x.CoverageId,
                        principalTable: "Coverage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Policy_Coverage_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleYear = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleNumberPlate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle_Coverage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    CoverageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle_Coverage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Coverage_Coverage_CoverageId",
                        column: x => x.CoverageId,
                        principalTable: "Coverage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicle_Coverage_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vehicle_Driver",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriveForBusiness = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPrimaryDriver = table.Column<bool>(type: "bit", nullable: false),
                    EverydayMileage = table.Column<float>(type: "real", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle_Driver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Driver_Driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicle_Driver_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Driver_PolicyId",
                table: "Driver",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_Coverage_CoverageId",
                table: "Policy_Coverage",
                column: "CoverageId");

            migrationBuilder.CreateIndex(
                name: "IX_Policy_Coverage_PolicyId",
                table: "Policy_Coverage",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Coverage_CoverageId",
                table: "Vehicle_Coverage",
                column: "CoverageId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Coverage_VehicleId",
                table: "Vehicle_Coverage",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Driver_DriverId",
                table: "Vehicle_Driver",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_Driver_VehicleId",
                table: "Vehicle_Driver",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_PolicyId",
                table: "Vehicles",
                column: "PolicyId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policy_Coverage");

            migrationBuilder.DropTable(
                name: "Vehicle_Coverage");

            migrationBuilder.DropTable(
                name: "Vehicle_Driver");

            migrationBuilder.DropTable(
                name: "Coverage");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Policies");
        }
    }
}
