using HRISdatabaseModels.DatabaseModels.Recruitement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.RecruitmentInterfaces
{
    public interface ICandidate: IGetInterfaces<Candidate>,IInsertInterfaces<Candidate>,IUpdateInterfaces<Candidate>,IDeleteInterfaces<Candidate>
    {
    }
}
