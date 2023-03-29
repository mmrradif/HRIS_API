using HRIS_Models.DatabaseModels.SalaryFinalize;
using HRISdatabaseModels.DatabaseModels.SalaryAndBonusInformation;
using HRISgenericInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Controllers.SalaryFinalizeController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SalaryDetailsController : GenericController<SalaryDetails>
    {
        public SalaryDetailsController(IAllInterfaces<SalaryDetails> allController) : base(allController)
        {
        }
    }
}
