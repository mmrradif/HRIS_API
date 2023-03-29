using HRIS.DatabaseModels.CompanyInformation;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISgenericInterfaces;

namespace HRIS.Interfaces.CompanyInterfaces
{
    public interface IDivision: IGetInterfaces<Division>, IInsertInterfaces<Division>, IUpdateInterfaces<Division>, IDeleteInterfaces<Division>
    {
    }
}
