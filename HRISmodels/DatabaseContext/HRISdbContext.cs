using HRIS.DatabaseModels.CompanyInformation;
using HRIS_Models.DatabaseModels.AttendenceInformation;
using HRIS_Models.DatabaseModels.SalaryFinalize;
using HRISdatabaseModels.DatabaseModels.AttendenceInformation;
using HRISdatabaseModels.DatabaseModels.AuthenticationAuthorization;
using HRISdatabaseModels.DatabaseModels.CommonTables;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISdatabaseModels.DatabaseModels.EmployeeInformation;
using HRISdatabaseModels.DatabaseModels.EmployeeTaxInformation;
using HRISdatabaseModels.DatabaseModels.Leave;
using HRISdatabaseModels.DatabaseModels.Loan;
using HRISdatabaseModels.DatabaseModels.Recruitement;
using HRISdatabaseModels.DatabaseModels.SalaryAndBonusInformation;
using HRISdatabaseModels.DatabaseModels.SalaryStructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Xml;

namespace HRIS.DatabaseContext
{
    public class HRISdbContext:DbContext
    {
        public HRISdbContext(DbContextOptions<HRISdbContext> options):base(options)
        {

        }

        public HRISdbContext()
        {
        }

        //ComapanyInformation
        public DbSet<Company> tblCompany => Set<Company>();
        public DbSet<Grade> tblGrade => Set<Grade>();
        public DbSet<Designation> tblDesignation => Set<Designation>();
        public DbSet<Division> tblDivision => Set<Division>();
        public DbSet<Department> tblDepartment => Set<Department>();
        public DbSet<Location> tblLocation => Set<Location>();
        public DbSet<Roster> tblRoster => Set<Roster>();


        //Recruitment
        public DbSet<Candidate> tblCandidate => Set<Candidate>();
        public DbSet<JobCircular> tblJobCircular => Set<JobCircular>();



        //EmployeeInformation
        public DbSet<Employee> tblEmployee => Set<Employee>();
        public DbSet<EmployeePosting> tblEmployeePosting => Set<EmployeePosting>();
        public DbSet<EmployeeType> tblEmployeeType => Set<EmployeeType>();

       

        ////AttendanceInformation
        public DbSet<AttendenceMonthEnd> tblAttendanceMonthEnd => Set<AttendenceMonthEnd>();
        public DbSet<DailyAttendence> tblDailyAttendance => Set<DailyAttendence>();
        public DbSet<HolidayInformation> tblHolidayInformation => Set<HolidayInformation>();


        public DbSet<LeaveType> tblLeaveType => Set<LeaveType>();
        public DbSet<LeaveApply> tblLeaveApply => Set<LeaveApply>();
        public DbSet<LeaveBalance> tblLeaveBalance => Set<LeaveBalance>();


        public DbSet<LeaveDetails> tblLeaveDetails => Set<LeaveDetails>();




        // --- SalaryComponent
        public DbSet<SalaryComponent> tblSalaryComponent => Set<SalaryComponent>();
        public DbSet<PayGradeScale> tblPayGradeScale => Set<PayGradeScale>();



        //SalaryFinalize
        public DbSet<Salary> tblSalary => Set<Salary>();
        public DbSet<SalaryDetails> tblSalaryDetails => Set<SalaryDetails>();


        // --- CommonTables
        public DbSet<CDivision> tblCDivision => Set<CDivision>();
        public DbSet<CDistrict> tblCDistrict => Set<CDistrict>();
        public DbSet<CUpazila> tblCUpazila => Set<CUpazila>();

        // Loan 
        public DbSet<LoanInformation> tblLoanInformation => Set<LoanInformation>();
        public DbSet<LoanSchedule> tblLoanSchedule => Set<LoanSchedule>();
        public DbSet<LoanType> tblLoanType => Set<LoanType>();


        // Employee Tax Information
        public DbSet<EmployeeTaxInfo> tblEmployeeTaxInfo => Set<EmployeeTaxInfo>();


        // Authetication Authorization
        public DbSet<User> tblUser => Set<User>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .ToTable(tb => tb.HasTrigger("[trg_tblCompany]"));

            modelBuilder.Entity<Grade>()
                .ToTable(tb => tb.HasTrigger("[trg_tblGrade]"));

            modelBuilder.Entity<Department>()
                .ToTable(tb => tb.HasTrigger("[trg_tblDepartment]"));
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=HumanResourceInformationSystemsAPIData;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
