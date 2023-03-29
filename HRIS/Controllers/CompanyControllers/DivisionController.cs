using HRIS.DatabaseModels.CompanyInformation;
using HRIS.Interfaces;
using HRISgenericInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HRIS.Controllers.CompanyControllers
{

    [Route("/[controller]/[action]")]
    [ApiController]

    public class DivisionController : GenericController<Division>
    {
        public DivisionController(IAllInterfaces<Division> allController) : base(allController)
        {
        }
    }
}
