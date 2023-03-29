using HRISdatabaseModels.DatabaseModels.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.LoanInterfaces
{
    public interface ILoanType: IGetInterfaces<LoanType>, IInsertInterfaces<LoanType>, IUpdateInterfaces<LoanType>, IDeleteInterfaces<LoanType>
    {

    }
}
