using HRIS_Models.DatabaseModels.SalaryFinalize;
using HRISdatabaseModels.DatabaseModels.SalaryAndBonusInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.SalaryFinalizeInterfaces
{
    public interface ISalaryDetails : IGetInterfaces<SalaryDetails>, IInsertInterfaces<SalaryDetails>, IUpdateInterfaces<SalaryDetails>, IDeleteInterfaces<SalaryDetails>
    {
    }
}
