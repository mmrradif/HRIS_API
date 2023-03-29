using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.CompanyInterfaces
{
    public interface IGrade: IGetInterfaces<Grade>, IInsertInterfaces<Grade>, IUpdateInterfaces<Grade>, IDeleteInterfaces<Grade>
    {
        // -- If You Want to More Methods 
        // -- Write Methods Signature
    }
}
