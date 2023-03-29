using HRISdatabaseModels.DatabaseModels.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.LoanInterfaces
{
    public interface ILoanInformation:IGetInterfaces<LoanInformation>,IInsertInterfaces<LoanInformation>, IUpdateInterfaces<LoanInformation>, IDeleteInterfaces<LoanInformation>
    {
        Task<bool> ApplyForLoan(LoanInformation data);
        Task<bool> ApproveLoan(LoanInformation data);
        Task<bool> RejectLoan(LoanInformation data);
        Task<bool> DeleteLoan(int id);
    }
}
