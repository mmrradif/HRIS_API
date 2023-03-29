using HRIS.DatabaseContext;
using HRIS.Interfaces;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISdatabaseModels.DatabaseModels.Loan;
using HRISgenericInterfaces;
using HRISgenericInterfaces.LoanInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HRISgenericRepositories.LoanRepositories
{
    public class LoanInformationRepo : GenericRepo<LoanInformation>, ILoanInformation, IAllInterfaces<LoanInformation>
    {
        public LoanInformationRepo(HRISdbContext dbContext) : base(dbContext)
        {
            
        }

        

        // ----------------------- CREATE
        //public override async Task<bool> CreateWithSP(LoanInformation data)
        //{
            
        //}

       

        // Apply for loan
        public async Task<bool> ApplyForLoan(LoanInformation data)
        {
            try
            {
                if(data.LoanInformationId == 0)
                {
                    await hrisDbContext.Database.ExecuteSqlAsync($"EXEC  sp_Insert_tblLoanInformation_tblLoanSchedule @EmployeeId = {data.EmployeeId}, @LoanAmount = {data.LoanAmount}, @Recomendation = {data.Recomendation}, @Reason = {data.Reason}");

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        // Approve loan
        public async Task<bool> ApproveLoan(LoanInformation data)
        {
            try
            {
                var loanToApprove = await hrisDbContext.tblLoanInformation.FirstOrDefaultAsync(x => x.LoanInformationId == data.LoanInformationId);

                if (loanToApprove!=null)
                {
                    var loanInfoToApprove = await hrisDbContext.Database.ExecuteSqlAsync($"EXEC sp_Insert_tblLoanInformation_tblLoanSchedule        @LoanInformationId = {data.LoanInformationId}, @EmployeeId = {data.EmployeeId}, @LoanAmount = {data.LoanAmount}, @ApproveBy={data.ApproveBy}, @LoanStartDate = {data.LoanStartDate}, @InstalmentAmount = {data.InstalmentAmount}");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Reject loan
        public async Task<bool> RejectLoan(LoanInformation data)
        {
            try
            {
                var loanToReject = await hrisDbContext.tblLoanInformation.FirstOrDefaultAsync(x => x.LoanInformationId == data.LoanInformationId);

                if(loanToReject != null)
                {
                    await hrisDbContext.Database.ExecuteSqlAsync($"EXEC sp_Insert_tblLoanInformation_tblLoanSchedule @LoanInformationId = {data.LoanInformationId}, @EmployeeId = {data.EmployeeId}, @LoanAmount = {data.LoanAmount}, @RejectedBy = {data.RejectedBy}");

                    return true;
                }
                else
                {
                    return false;
                }   
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Delete loan data
        public async Task<bool> DeleteLoan(int id)
        {
            try
            {
                var loanToDelete = await hrisDbContext.tblLoanInformation.FirstOrDefaultAsync(x=>x.LoanInformationId == id);

                if (loanToDelete != null)
                {
                    await hrisDbContext.Database.ExecuteSqlAsync($"EXEC spGenericDeleteData @tableName = 'tblLoanInformation', @dataId = {id}");
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }
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
