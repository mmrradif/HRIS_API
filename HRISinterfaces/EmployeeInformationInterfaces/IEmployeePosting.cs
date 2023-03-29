using HRISdatabaseModels.DatabaseModels.EmployeeInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.EmployeeInformationInterfaces
{
    public interface IEmployeePosting: IGetInterfaces<EmployeePosting>,IInsertInterfaces<EmployeePosting>,IUpdateInterfaces<EmployeePosting>,IDeleteInterfaces<EmployeePosting>
    {
    }
}
