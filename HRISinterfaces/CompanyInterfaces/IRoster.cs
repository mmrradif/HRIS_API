using HRIS.Interfaces;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.CompanyInterfaces
{
    public interface IRoster : IGetInterfaces<Roster>, IInsertInterfaces<Roster>, IUpdateInterfaces<Roster>, IDeleteInterfaces<Roster>
    {
        //void BeginTransaction();
        //void CommitTransaction();
        //void RollbackTransaction();
    }
}
