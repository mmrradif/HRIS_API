using HRIS.DatabaseModels.CompanyInformation;
using HRIS.Interfaces;
using HRISdatabaseModels.DatabaseModels.CommonTables;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.CompanyInterfaces
{
    public interface ICDistrict: IGetInterfaces<CDistrict>, IInsertInterfaces<CDistrict>, IUpdateInterfaces<CDistrict>, IDeleteInterfaces<CDistrict>
    {
    }
}
