using HRISdatabaseModels.DatabaseModels.EmployeeTaxInformation;
using HRISdatabaseModels.DatabaseModels.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.EmployeeTaxInformationInterfaces
{
    public interface IEmployeeTaxInformation: IGetInterfaces<EmployeeTaxInfo>, IInsertInterfaces<EmployeeTaxInfo>, IUpdateInterfaces<EmployeeTaxInfo>, IDeleteInterfaces<EmployeeTaxInfo>
    {
        Task<bool> InsertEmployeeTaxInformation(EmployeeTaxInfo data);
        Task<bool> UpdateEmployeeTaxInformation(EmployeeTaxInfo data);
        Task<bool> DeleteEmployeeTaxInformation(int id);
    }
}
