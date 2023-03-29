using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRISdatabaseModels.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAttendanceMonthEnd",
                columns: table => new
                {
                    AttendanceMonthEndId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    RosterId = table.Column<int>(type: "int", nullable: false),
                    AttendanceMonth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DaysOfMonth = table.Column<int>(type: "int", nullable: true),
                    AbsentDays = table.Column<int>(type: "int", nullable: true),
                    LeaveDays = table.Column<int>(type: "int", nullable: true),
                    Holiday = table.Column<int>(type: "int", nullable: true),
                    LateDeduction = table.Column<int>(type: "int", nullable: true),
                    FinalDeductionDays = table.Column<int>(type: "int", nullable: true),
                    AcumulatedDays = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: true),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAttendanceMonthEnd", x => x.AttendanceMonthEndId);
                });

            migrationBuilder.CreateTable(
                name: "tblCandidate",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppliedDate = table.Column<DateTime>(type: "date", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SpouseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PassportNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DateofBirth = table.Column<DateTime>(type: "date", nullable: false),
                    PresentAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Upazila = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PermanentAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PermanentAddressDistrict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentAddressThana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentAddressUpazila = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthCertificateNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Signature = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Sscinstitute = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sscboard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SscpassingYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sscsection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SscrollNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SscregNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Hscinstitute = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Hscboard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HscpassingYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hscsection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HscrollNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HscregNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HonoursInstitute = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HonoursBoard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HonoursPassingYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HonoursDepartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HonoursRollNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    HonoursRegNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MastersInstitute = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MastersBoard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MastersPassingYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MastersSection = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MastersRollNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MastersRegNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    JobExperienceType1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JobExperienceCompany1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JobExperienceDetails1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JobExperienceType2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JobExperienceCompany2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JobExperienceDetails2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JobExperienceType3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JobExperienceCompany3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JobExperienceDetails3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCandidate", x => x.CandidateId);
                });

            migrationBuilder.CreateTable(
                name: "tblCDivision",
                columns: table => new
                {
                    CDivisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCDivision", x => x.CDivisionId);
                });

            migrationBuilder.CreateTable(
                name: "tblCompany",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyAlias = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyRegisterNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCompany", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "tblDailyAttendance",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    RosterId = table.Column<int>(type: "int", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "date", nullable: false),
                    InTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalWorkingHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OverTimeHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDailyAttendance", x => x.AttendanceId);
                });

            migrationBuilder.CreateTable(
                name: "tblEmployeeType",
                columns: table => new
                {
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeTypeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EmployeeTypeCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NoticePeriod = table.Column<int>(type: "int", nullable: true),
                    IsOverTimeAllowed = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployeeType", x => x.EmployeeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "tblHolidayInformation",
                columns: table => new
                {
                    HolidayInformationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HolidayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblHolidayInformation", x => x.HolidayInformationId);
                });

            migrationBuilder.CreateTable(
                name: "tblJobCircular",
                columns: table => new
                {
                    JobCircularId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublishDate = table.Column<DateTime>(type: "date", nullable: false),
                    LiveTime = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblJobCircular", x => x.JobCircularId);
                });

            migrationBuilder.CreateTable(
                name: "tblLeaveApply",
                columns: table => new
                {
                    EmployeeLeaveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    LeaveAppliedDate = table.Column<DateTime>(type: "date", nullable: true),
                    FromDate = table.Column<DateTime>(type: "date", nullable: false),
                    ToDate = table.Column<DateTime>(type: "date", nullable: false),
                    LeaveDaysAppliedFor = table.Column<int>(type: "int", nullable: true),
                    LeaveReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveApprovedBy = table.Column<int>(type: "int", nullable: true),
                    LeaveApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LeaveApprovedFromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LeaveApprovedToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedLeaveDays = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLeaveApply", x => x.EmployeeLeaveId);
                });

            migrationBuilder.CreateTable(
                name: "tblLeaveBalance",
                columns: table => new
                {
                    LeaveBalanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    YearlyLeaveTypeBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LeaveEnjoyed = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    YearlyClosingBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLeaveBalance", x => x.LeaveBalanceId);
                });

            migrationBuilder.CreateTable(
                name: "tblLeaveDetails",
                columns: table => new
                {
                    LeaveDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: true),
                    LeaveDates = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLeaveDetails", x => x.LeaveDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "tblLeaveType",
                columns: table => new
                {
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaveTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeaveYear = table.Column<int>(type: "int", nullable: true),
                    TotalAvailableLeave = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLeaveType", x => x.LeaveTypeId);
                });

            migrationBuilder.CreateTable(
                name: "tblPayGradeScale",
                columns: table => new
                {
                    PayGradeScaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    SalaryComponentId = table.Column<int>(type: "int", nullable: false),
                    SalaryComponentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPayGradeScale", x => x.PayGradeScaleId);
                });

            migrationBuilder.CreateTable(
                name: "tblSalary",
                columns: table => new
                {
                    SalaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    SalaryMonth = table.Column<DateTime>(type: "date", nullable: false),
                    TotalSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DaysOfMonth = table.Column<int>(type: "int", nullable: false),
                    AcumulatedDays = table.Column<int>(type: "int", nullable: false),
                    GrossPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoanScheduleId = table.Column<int>(type: "int", nullable: false),
                    Arear = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetPayout = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    ApproverId = table.Column<int>(type: "int", nullable: true),
                    ApproveDate = table.Column<DateTime>(type: "date", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: false),
                    BankAccountNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaryRemarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentBy = table.Column<int>(type: "int", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: true),
                    IsBankPayment = table.Column<int>(type: "int", nullable: true),
                    BankPaymentBy = table.Column<int>(type: "int", nullable: true),
                    BankPaymentDate = table.Column<DateTime>(type: "date", nullable: true),
                    IsCashPayment = table.Column<int>(type: "int", nullable: true),
                    CashPaymentBy = table.Column<int>(type: "int", nullable: true),
                    CashPaymentDate = table.Column<DateTime>(type: "date", nullable: true),
                    PaymentConfirmationDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSalary", x => x.SalaryId);
                });

            migrationBuilder.CreateTable(
                name: "tblSalaryComponent",
                columns: table => new
                {
                    SalaryComponentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryComponentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaryComponentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaryComponentType = table.Column<int>(type: "int", nullable: false),
                    IsBonus = table.Column<int>(type: "int", nullable: true),
                    BonusEligibility = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSalaryComponent", x => x.SalaryComponentId);
                });

            migrationBuilder.CreateTable(
                name: "tblSalaryDetails",
                columns: table => new
                {
                    SalaryDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryId = table.Column<int>(type: "int", nullable: false),
                    SalaryComponentId = table.Column<int>(type: "int", nullable: false),
                    SalaryComponentValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SalaryComponentType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSalaryDetails", x => x.SalaryDetailsId);
                });

            migrationBuilder.CreateTable(
                name: "tblCDistrict",
                columns: table => new
                {
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CDivisionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCDistrict", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_tblCDistrict_tblCDivision_CDivisionId",
                        column: x => x.CDivisionId,
                        principalTable: "tblCDivision",
                        principalColumn: "CDivisionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblDivision",
                columns: table => new
                {
                    DivisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DivisionCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDivision", x => x.DivisionId);
                    table.ForeignKey(
                        name: "FK_tblDivision_tblCompany_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "tblCompany",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblGrade",
                columns: table => new
                {
                    GradeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblGrade", x => x.GradeId);
                    table.ForeignKey(
                        name: "FK_tblGrade_tblCompany_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "tblCompany",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblEmployee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FatherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MotherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SpouseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PassportNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateofBirth = table.Column<DateTime>(type: "date", nullable: false),
                    PresentAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Upazila = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PermanentAddressDistrict = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentAddressThana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentAddressUpazila = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    ProfilePicture = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthCertificateNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Signature = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Sscinstitute = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sscboard = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SscpassingYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sscsection = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    SscrollNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SscregNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Hscinstitute = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Hscboard = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    HscpassingYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hscsection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HscrollNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HscregNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HonoursInstitute = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HonoursBoard = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    HonoursPassingYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HonoursDepartment = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    HonoursRollNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    HonoursRegNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MastersInstitute = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MastersBoard = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MastersPassingYear = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MastersSection = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MastersRollNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    MastersRegNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    JobExperienceType1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JobExperienceCompany1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JobExperienceDetails1 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JobExperienceType2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JobExperienceCompany2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JobExperienceDetails2 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JobExperienceType3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JobExperienceCompany3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JobExperienceDetails3 = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "date", nullable: true),
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_tblEmployee_tblEmployeeType_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "tblEmployeeType",
                        principalColumn: "EmployeeTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblCUpazila",
                columns: table => new
                {
                    CUpazilaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpazilaName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CDistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCUpazila", x => x.CUpazilaId);
                    table.ForeignKey(
                        name: "FK_tblCUpazila_tblCDistrict_CDistrictId",
                        column: x => x.CDistrictId,
                        principalTable: "tblCDistrict",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblDepartment",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDepartment", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_tblDepartment_tblDivision_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "tblDivision",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblDesignation",
                columns: table => new
                {
                    DesignationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DesignationCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDesignation", x => x.DesignationId);
                    table.ForeignKey(
                        name: "FK_tblDesignation_tblGrade_GradeId",
                        column: x => x.GradeId,
                        principalTable: "tblGrade",
                        principalColumn: "GradeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblEmployeePosting",
                columns: table => new
                {
                    EmployeePostingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    RosterId = table.Column<int>(type: "int", nullable: false),
                    BankAccountNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelephoneExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OfficialEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    TinNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreateBy = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "date", nullable: true),
                    UpdateBy = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployeePosting", x => x.EmployeePostingId);
                    table.ForeignKey(
                        name: "FK_tblEmployeePosting_tblEmployee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "tblEmployee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblLocation",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LocationAddress = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLocation", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_tblLocation_tblDepartment_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "tblDepartment",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblRoster",
                columns: table => new
                {
                    RosterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RosterMonth = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    RosterInTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RosterOutTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalWorkingHours = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    CreateBy = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateBy = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblRoster", x => x.RosterId);
                    table.ForeignKey(
                        name: "FK_tblRoster_tblLocation_LocationId",
                        column: x => x.LocationId,
                        principalTable: "tblLocation",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCDistrict_CDivisionId",
                table: "tblCDistrict",
                column: "CDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCUpazila_CDistrictId",
                table: "tblCUpazila",
                column: "CDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDepartment_DivisionId",
                table: "tblDepartment",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDesignation_GradeId",
                table: "tblDesignation",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblDivision_CompanyId",
                table: "tblDivision",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployee_EmployeeTypeId",
                table: "tblEmployee",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployeePosting_EmployeeId",
                table: "tblEmployeePosting",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_tblGrade_CompanyId",
                table: "tblGrade",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_tblLocation_DepartmentId",
                table: "tblLocation",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tblRoster_LocationId",
                table: "tblRoster",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAttendanceMonthEnd");

            migrationBuilder.DropTable(
                name: "tblCandidate");

            migrationBuilder.DropTable(
                name: "tblCUpazila");

            migrationBuilder.DropTable(
                name: "tblDailyAttendance");

            migrationBuilder.DropTable(
                name: "tblDesignation");

            migrationBuilder.DropTable(
                name: "tblEmployeePosting");

            migrationBuilder.DropTable(
                name: "tblHolidayInformation");

            migrationBuilder.DropTable(
                name: "tblJobCircular");

            migrationBuilder.DropTable(
                name: "tblLeaveApply");

            migrationBuilder.DropTable(
                name: "tblLeaveBalance");

            migrationBuilder.DropTable(
                name: "tblLeaveDetails");

            migrationBuilder.DropTable(
                name: "tblLeaveType");

            migrationBuilder.DropTable(
                name: "tblPayGradeScale");

            migrationBuilder.DropTable(
                name: "tblRoster");

            migrationBuilder.DropTable(
                name: "tblSalary");

            migrationBuilder.DropTable(
                name: "tblSalaryComponent");

            migrationBuilder.DropTable(
                name: "tblSalaryDetails");

            migrationBuilder.DropTable(
                name: "tblCDistrict");

            migrationBuilder.DropTable(
                name: "tblGrade");

            migrationBuilder.DropTable(
                name: "tblEmployee");

            migrationBuilder.DropTable(
                name: "tblLocation");

            migrationBuilder.DropTable(
                name: "tblCDivision");

            migrationBuilder.DropTable(
                name: "tblEmployeeType");

            migrationBuilder.DropTable(
                name: "tblDepartment");

            migrationBuilder.DropTable(
                name: "tblDivision");

            migrationBuilder.DropTable(
                name: "tblCompany");
        }
    }
}
