using HRIS.DatabaseModels.CompanyInformation;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISgenericInterfaces;

namespace HRIS.Interfaces.CompanyInterfaces
{
    public interface IDepartment: IGetInterfaces<Department>, IInsertInterfaces<Department>, IUpdateInterfaces<Department>, IDeleteInterfaces<Department>
    {
    }
}
