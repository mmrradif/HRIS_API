using HRIS.DatabaseModels.CompanyInformation;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISgenericInterfaces;

namespace HRIS.Interfaces.CompanyInterfaces
{
    public interface IDesignation: IGetInterfaces<Designation>, IInsertInterfaces<Designation>, IUpdateInterfaces<Designation>, IDeleteInterfaces<Designation>
    {
    }
}
