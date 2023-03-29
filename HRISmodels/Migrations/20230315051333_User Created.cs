using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRISdatabaseModels.Migrations
{
    /// <inheritdoc />
    public partial class UserCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SalaryComponentAmount",
                table: "tblPayGradeScale",
                type: "decimal(7,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "PayScaleGrade",
                table: "tblPayGradeScale",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "tblEmployeeTaxInfo",
                columns: table => new
                {
                    EmployeeTaxInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployeeTaxInfo", x => x.EmployeeTaxInfoId);
                });

            migrationBuilder.CreateTable(
                name: "tblLoanInformation",
                columns: table => new
                {
                    LoanInformationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    LoanAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Recomendation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RejectedBy = table.Column<int>(type: "int", nullable: true),
                    RejectDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApproveBy = table.Column<int>(type: "int", nullable: true),
                    ApproveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoanStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InstalmentAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    TotalPaid = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    DueAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    DownpaymentAmount = table.Column<decimal>(type: "decimal(12,2)", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLoanInformation", x => x.LoanInformationId);
                });

            migrationBuilder.CreateTable(
                name: "tblLoanType",
                columns: table => new
                {
                    LoanTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanTypeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaximumLoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TermsAndCondition = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    JobLength = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLoanType", x => x.LoanTypeId);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblLoanSchedule",
                columns: table => new
                {
                    LoanScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoanInformationId = table.Column<int>(type: "int", nullable: false),
                    EmiDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmiAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPaid = table.Column<int>(type: "int", nullable: true),
                    CreateBy = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", maxLength: 100, nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLoanSchedule", x => x.LoanScheduleId);
                    table.ForeignKey(
                        name: "FK_tblLoanSchedule_tblLoanInformation_LoanInformationId",
                        column: x => x.LoanInformationId,
                        principalTable: "tblLoanInformation",
                        principalColumn: "LoanInformationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblLoanSchedule_LoanInformationId",
                table: "tblLoanSchedule",
                column: "LoanInformationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEmployeeTaxInfo");

            migrationBuilder.DropTable(
                name: "tblLoanSchedule");

            migrationBuilder.DropTable(
                name: "tblLoanType");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblLoanInformation");

            migrationBuilder.DropColumn(
                name: "PayScaleGrade",
                table: "tblPayGradeScale");

            migrationBuilder.AlterColumn<decimal>(
                name: "SalaryComponentAmount",
                table: "tblPayGradeScale",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)");
        }
    }
}
