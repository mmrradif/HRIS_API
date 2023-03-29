using HRIS.DatabaseModels.CompanyInformation;
using HRIS.Interfaces;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISgenericInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HRIS.Controllers.CompanyControllers
{
    [Route("/[controller]/[action]")]
    [ApiController]

    public class DepartmentsController : GenericController<Department>
    {
        public DepartmentsController(IAllInterfaces<Department> allController) : base(allController)
        {
        }
    }
}
