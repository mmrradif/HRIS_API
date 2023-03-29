using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISdatabaseModels.DatabaseModels.SalaryAndBonusInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.SalaryFinalizeInterfaces
{
    public interface ISalary: IGetInterfaces<Salary>, IInsertInterfaces<Salary>, IUpdateInterfaces<Salary>, IDeleteInterfaces<Salary>
    {
        Task<bool> InsertSalary(Salary data);
        Task<bool> ApproveSalary(Salary data);
        Task<bool> SalaryPayment(Salary data);
        Task<bool> DeleteSalary(int id);
    }
}
