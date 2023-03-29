using HRIS.DatabaseContext;
using HRISdatabaseModels.DatabaseModels.Loan;
using HRISgenericInterfaces;
using HRISgenericInterfaces.LoanInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericRepositories.LoanRepositories
{
    public class LoanTypeRepo : GenericRepo<LoanType>, ILoanType, IAllInterfaces<LoanType>
    {
        public LoanTypeRepo(HRISdbContext dbContext) : base(dbContext)
        {
        }

        public async Task CompleteAsync()
        {
            await hrisDbContext.SaveChangesAsync();
            Dispose();
        }

        public void Dispose()
        {
            hrisDbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
