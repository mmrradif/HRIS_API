using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces
{
    public interface IAllInterfaces <T>: IGetInterfaces<T>, IInsertInterfaces<T>, IUpdateInterfaces<T>, IDeleteInterfaces<T>,ISaveChanges where T:class
    {
        // -- If You Want to More Methods 
        // -- Write Methods Signature


        //IEnumerable<Company> GetCompanyWithGrade();
    
    }
}
