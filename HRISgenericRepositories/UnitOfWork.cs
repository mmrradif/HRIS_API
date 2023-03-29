using HRIS.DatabaseContext;
using HRIS.Interfaces;
using HRIS.Interfaces.CompanyInterfaces;
using HRISgenericInterfaces.AttendanceInformationInterfaces;
using HRISgenericInterfaces.AuthInterfaces;
using HRISgenericInterfaces.CompanyInterfaces;
using HRISgenericInterfaces.EmployeeInformationInterfaces;
using HRISgenericInterfaces.EmployeeTaxInformationInterfaces;
using HRISgenericInterfaces.LoanInterfaces;
using HRISgenericInterfaces.RecruitmentInterfaces;
using HRISgenericInterfaces.SalaryFinalizeInterfaces;
using HRISgenericInterfaces.SalaryStructureInterfaces;
using HRISgenericRepositories.AttendanceInformationRepositories;
using HRISgenericRepositories.CompanyRepositories;
using HRISgenericRepositories.EmployeeInformationRepositories;
using HRISgenericRepositories.EmployeeTaxInformationRepositories;
using HRISgenericRepositories.LoanRepositories;
using HRISgenericRepositories.RecruitmentRepositories;
using HRISgenericRepositories.SalaryFinalizeRepositories;
using HRISgenericRepositories.SalaryStructureRepositories;
using HRISgenericRepositories.UserAuthRepositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace HRIS.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        // Loan
        public ILoanInformation loanInformationRepository { get; private set; }
        public ILoanType loanTypeRepository { get; private set; }
        public ILoanSchedule loanScheduleRepository { get; private set; }

        //companyInformation
        public ICompany companyRepository { get; private set; }
        public IGrade gradeRepository { get; private set; }
        public IDesignation designationRepository { get; private set; }
        public IDivision divisionRepository { get; private set; }
        public IDepartment departmentRepository { get; private set; }
        public ILocation locationRepository { get; private set; }
        public IRoster rosterRepository { get; private set; }




        //recruitment
        public ICandidate candidateRepository { get; private set; }
        public IJobCircular jobCircularRepository { get; private set; }


        //employeeinformation
        public IEmployee employeeRepository { get; private set; }
        public IEmployeeType employeeTypeRepository { get; private set; }
        public IEmployeePosting employeePostingRepository { get; private set; }


        //attendanceinformation
        public IDailyAttendance dailyAttendanceRepository { get; private set; }



        // Salary Structure
        public ISalaryComponent salaryComponentRepository { get; private set; }
        public IPayGradeScale payGradeScaleRepository { get; private set; }


        //salaryfinalize
        public ISalary salaryRepository { get; private set; }
        public ISalaryDetails salaryDetailsRepository { get; private set; }

  

        // Common Tables
        public ICDivision cDivisionRepository { get; private set; }
        public ICDistrict cDistrictRepository { get; private set; }
        public ICUpazila cUpazilaRepository { get; private set; }


        // Tax
        public IEmployeeTaxInformation employeeTaxInformationRepository { get; private set; }


        // Authentication & Authorization
        public IUserInterface userRepository { get; private set; }




        private readonly HRISdbContext hrisDbContext;

        public UnitOfWork(HRISdbContext DbContext)
        {
            this.hrisDbContext = DbContext;

            //company
            companyRepository = new CompanyRepo(hrisDbContext);          
            //gradeRepository = new GradeRepo(hrisDbContext);

            //employeeinformation
            employeeRepository = new EmployeeRepo(hrisDbContext);
            employeeTypeRepository = new EmployeeTypeRepo(hrisDbContext);
            employeePostingRepository = new EmployeePostingRepo(hrisDbContext);



            //recruitment
            candidateRepository = new CandidateRepo(hrisDbContext);
            jobCircularRepository= new JobCircularRepo(hrisDbContext);


            //attendanceinformation
            dailyAttendanceRepository = new DailyAttendanceRepo(hrisDbContext);


            // Salary Structure
            salaryComponentRepository = new SalaryComponenetRepo(hrisDbContext);
            payGradeScaleRepository = new PayGradeScaleRepo(hrisDbContext);


            //salaryfinalize
            salaryRepository = new SalaryRepo(hrisDbContext);
            salaryDetailsRepository = new SalaryDetailsRepo(hrisDbContext);


            // Common Tables
            cDivisionRepository = new CDivisionRepo(hrisDbContext);
            cDistrictRepository = new CDistrictRepo(hrisDbContext);
            cDivisionRepository = new CDivisionRepo(hrisDbContext);



            // Tax
            employeeTaxInformationRepository = new EmployeeTaxInformationRepo(hrisDbContext);


            // loan
            loanInformationRepository = new LoanInformationRepo(hrisDbContext);
            loanTypeRepository = new LoanTypeRepo(hrisDbContext);
            loanScheduleRepository = new LoanScheduleRepo(hrisDbContext);


            // Authentication & Authorization
            userRepository = new UserAuthRepo(hrisDbContext);
        }



        public async Task CompleteAsync()
        {
            await hrisDbContext.SaveChangesAsync();
            Dispose();
        }

        public void Dispose()
        {
            hrisDbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
