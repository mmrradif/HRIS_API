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
    public interface ICUpazila: IGetInterfaces<CUpazila>, IInsertInterfaces<CUpazila>, IUpdateInterfaces<CUpazila>, IDeleteInterfaces<CUpazila>
    {
    }
}
