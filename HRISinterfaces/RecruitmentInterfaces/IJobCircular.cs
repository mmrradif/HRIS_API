using HRISdatabaseModels.DatabaseModels.Recruitement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.RecruitmentInterfaces
{
    public interface IJobCircular: IGetInterfaces<JobCircular>,IInsertInterfaces<JobCircular>,IUpdateInterfaces<JobCircular>,IDeleteInterfaces<JobCircular>
    {
    }
}
