using HRIS.Interfaces;
using HRISdatabaseModels.DatabaseModels.SalaryStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.SalaryStructureInterfaces
{
   public interface  IPayGradeScale: IGetInterfaces<PayGradeScale>, IInsertInterfaces<PayGradeScale>, IUpdateInterfaces<PayGradeScale>, IDeleteInterfaces<PayGradeScale>
    {
        Task<bool> CreatePayGradeScale(PayGradeScale data);
        Task<bool> UpdatePayGradeScale(PayGradeScale data);
        Task<bool> DeletePayGradeScale(int id);
    }
}
