using HRISdatabaseModels.DatabaseModels.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.LoanInterfaces
{
    public interface ILoanSchedule: IGetInterfaces<LoanSchedule>, IInsertInterfaces<LoanSchedule>, IUpdateInterfaces<LoanSchedule>, IDeleteInterfaces<LoanSchedule>
    {
        Task<bool> InsertLoanSchedule(LoanSchedule data);
        Task<bool> UpdateLoanSchedule(LoanSchedule data);
        Task<bool> DeleteLoanSchedule(int id);
    }

    
}
