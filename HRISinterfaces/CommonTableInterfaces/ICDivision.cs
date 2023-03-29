using HRIS.Interfaces;
using HRISdatabaseModels.DatabaseModels.CommonTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.CompanyInterfaces
{
    public interface ICDivision: IGetInterfaces<CDivision>, IInsertInterfaces<CDivision>, IUpdateInterfaces<CDivision>, IDeleteInterfaces<CDivision>
    {
    }
}
