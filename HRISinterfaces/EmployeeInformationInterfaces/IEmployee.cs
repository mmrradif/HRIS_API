using HRISdatabaseModels.DatabaseModels.EmployeeInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.EmployeeInformationInterfaces
{
    public interface IEmployee: IGetInterfaces<Employee>,IInsertInterfaces<Employee>,IUpdateInterfaces<Employee>,IDeleteInterfaces<Employee>
    {
    }
}
