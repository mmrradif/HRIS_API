using HRISdatabaseModels.DatabaseModels.Loan;
using HRISgenericInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Controllers.LoanControllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class LoanTypeController : GenericController<LoanType>
    {
        public LoanTypeController(IAllInterfaces<LoanType> allController) : base(allController)
        {
        }
    }
}
