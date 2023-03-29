using HRIS.DatabaseModels.CompanyInformation;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISgenericInterfaces;

namespace HRIS.Interfaces.CompanyInterfaces
{
    public interface ILocation: IGetInterfaces<Location>, IInsertInterfaces<Location>, IUpdateInterfaces<Location>, IDeleteInterfaces<Location>
    {
    }
}
