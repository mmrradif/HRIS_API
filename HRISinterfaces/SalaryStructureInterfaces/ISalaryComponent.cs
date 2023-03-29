using HRIS.Interfaces;
using HRISdatabaseModels.DatabaseModels.SalaryStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.SalaryStructureInterfaces
{
    public interface ISalaryComponent: IGetInterfaces<SalaryComponent>, IInsertInterfaces<SalaryComponent>, IUpdateInterfaces<SalaryComponent>, IDeleteInterfaces<SalaryComponent>
    {
        Task<bool> CreateSalaryComponent(SalaryComponent data);
        Task<bool> UpdateSalaryComponent(SalaryComponent data);
        Task<bool> DeleteSalaryComponent(int id);
    }
}
