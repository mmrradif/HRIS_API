using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using HRIS.Interfaces;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using Microsoft.AspNetCore.Authorization;
using HRIS.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using HRISgenericInterfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using HRISdatabaseModels.DatabaseModels.EmployeeInformation;

namespace HRIS.Controllers.CompanyControllers
{
    [Route("/[controller]/[action]")]
    [ApiController]

    public class CompanyController : GenericController<Company>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly HRISdbContext hRISdbContext;

        public CompanyController(IAllInterfaces<Company> allController, IUnitOfWork unitOfWork, HRISdbContext hRISdbContext) : base(allController)
        {
            this.unitOfWork = unitOfWork;
            this.hRISdbContext = hRISdbContext;
        }


        [HttpGet]
        public ActionResult CompanyWithGrades()
        {
            try
            {
                var compnayAndGrades = unitOfWork.companyRepository.GetCompanyWithGrade();
                return Ok(compnayAndGrades);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
