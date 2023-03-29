using HRISdatabaseModels.DatabaseModels.EmployeeInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.EmployeeInformationInterfaces
{
    public interface IEmployeeType: IGetInterfaces<EmployeeType>,IInsertInterfaces<EmployeeType>,IUpdateInterfaces<EmployeeType>,IDeleteInterfaces<EmployeeType>
    {
    }
}
