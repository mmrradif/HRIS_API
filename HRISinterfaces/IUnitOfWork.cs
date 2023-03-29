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
using Microsoft.EntityFrameworkCore.Storage;
using System.Transactions;

namespace HRIS.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {

        //companyInformation
        ICompany companyRepository { get; }
        IGrade gradeRepository { get; }
        IDesignation designationRepository { get; }
        IDivision divisionRepository { get; }
        IDepartment departmentRepository { get; }
        ILocation locationRepository { get; }
        IRoster rosterRepository { get; }



        //recruitment
        ICandidate candidateRepository { get; }
        IJobCircular jobCircularRepository { get; }


        //employeeinformation
        IEmployee employeeRepository { get; }
        IEmployeeType employeeTypeRepository { get; }
        IEmployeePosting employeePostingRepository { get; }


        //attendanceinformation
        IDailyAttendance dailyAttendanceRepository { get; }



        //// Salary Structure
        //ISalaryComponent salaryComponentRepository { get; }
        //IPayGradeScale payGradeScaleRepository { get; }


        ////salaryFinalize
        //ISalary salaryRepository { get; }
        //ISalaryDetails salaryDetailsRepository { get; }


        // Common Tables
        ICDivision cDivisionRepository { get; }
        ICDistrict cDistrictRepository { get; }
        ICUpazila cUpazilaRepository { get; }


        // Tax
        IEmployeeTaxInformation employeeTaxInformationRepository { get; }


        // Loan
        ILoanInformation loanInformationRepository { get; }
        ILoanType loanTypeRepository { get; }
        ILoanSchedule loanScheduleRepository { get; }




        // Salary Structure
        ISalaryComponent salaryComponentRepository { get; }
        IPayGradeScale payGradeScaleRepository { get; }


        //salaryFinalize
        ISalary salaryRepository { get; }
        ISalaryDetails salaryDetailsRepository { get; }


        // Authentication & Authorization
        IUserInterface userRepository { get; }


        Task CompleteAsync();      
    }
}
