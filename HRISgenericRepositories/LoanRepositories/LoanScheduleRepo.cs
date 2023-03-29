using HRIS.DatabaseContext;
using HRISdatabaseModels.DatabaseModels.Loan;
using HRISgenericInterfaces;
using HRISgenericInterfaces.LoanInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericRepositories.LoanRepositories
{
    public class LoanScheduleRepo : GenericRepo<LoanSchedule>, ILoanSchedule, IAllInterfaces<LoanSchedule>
    {
        public LoanScheduleRepo(HRISdbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> DeleteLoanSchedule(int id)
        {
            try
            {

                var scheduleToDelete = await hrisDbContext.tblLoanSchedule.FirstOrDefaultAsync(x=>x.LoanScheduleId == id);

                if(scheduleToDelete != null)
                {
                    await hrisDbContext.Database.ExecuteSqlAsync($"EXEC spGenericDeleteData @tableName = 'tblLoanSchedule', @dataId = {id}");
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


        // INSERT
        public async Task<bool> InsertLoanSchedule(LoanSchedule data)
        {
            try
            {
                if(data.LoanScheduleId == 0)
                {
                    await hrisDbContext.Database.ExecuteSqlAsync($"EXEC spFor_tblLoanSchedule @loanInfoId={data.LoanInformationId}, @emiDate={data.EmiDate}, @emiAmount={data.EmiAmount}, @paidDate={data.PaidDate}, @isPaid={data.IsPaid}, @createBy={data.CreateBy}");

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


        // UPDATE
        public async Task<bool> UpdateLoanSchedule(LoanSchedule data)
        {
            try
            {
                var scheduleToUpdate = await hrisDbContext.tblLoanSchedule.FirstOrDefaultAsync(x=>x.LoanScheduleId == data.LoanScheduleId);

                if(scheduleToUpdate != null )
                {
                    await hrisDbContext.Database.ExecuteSqlAsync($"EXEC spFor_tblLoanSchedule @loanScheduleId={data.LoanScheduleId}, @loanInfoId={data.LoanInformationId}, @emiDate={data.EmiDate}, @emiAmount={data.EmiAmount}, @updateBy={data.UpdateBy}");

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
