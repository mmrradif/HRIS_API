using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.CompanyInterfaces
{
    public interface ICompany: IGetInterfaces<Company>,IInsertInterfaces<Company>,IUpdateInterfaces<Company>,IDeleteInterfaces<Company>
    {
        // -- If You Want to More Methods 
        // -- Write Methods Signature


        IEnumerable<Company> GetCompanyWithGrade();

    }
}
