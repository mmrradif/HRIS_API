using HRIS.Interfaces;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISgenericInterfaces;
using HRISgenericRepositories.CompanyRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace HRIS.Controllers.CompanyControllers
{


    [Route("/[controller]/[action]")]
    [ApiController]

    public class RostersController : GenericController<Roster>
    {
        public RostersController(IAllInterfaces<Roster> allController) : base(allController)
        {
        }
    }
}
