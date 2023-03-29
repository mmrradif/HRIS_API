using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISdatabaseModels.DatabaseModels.EmployeeInformation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Controllers.EmployeeInformationControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {

        private readonly IUnitOfWork unitOfWork;

        public EmployeeTypeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var emptype = await unitOfWork.employeeTypeRepository.GetAll();
                return Ok(emptype);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await unitOfWork.employeeTypeRepository.GetById(id);
                if (data == null)
                {
                    return NotFound($"Sorry!!! Employee Type ID: {id} Not Exists");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var data = await unitOfWork.employeeTypeRepository.GetByName(name);
                if (data == null)
                {
                    return NotFound($"Sorry!!! Employee Type: {name} Not Exists");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Insert([FromForm] EmployeeType emptype)
        {
            try
            {
                await unitOfWork.employeeTypeRepository.Insert(emptype);
                await unitOfWork.CompleteAsync();
                return Ok(emptype);
            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpPost]
        public async Task<IActionResult> InsertRange(EmployeeType[] emptypes)
        {
            try
            {
                await unitOfWork.employeeTypeRepository.InsertRange(emptypes);
                await unitOfWork.CompleteAsync();
                return Ok(emptypes);
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPut]
        public async Task<IActionResult> Update([FromForm] EmployeeType emptype)
        {
            try
            {
                var result = await unitOfWork.employeeTypeRepository.Update(emptype);
                if (result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok(emptype);
                }
                return NotFound("Id Not Found");
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var data = await unitOfWork.employeeTypeRepository.GetById(id);
                if (data == null)
                {
                    return NotFound($"employeeTypeRepository ID: {id} Not Exists");
                }
                await unitOfWork.employeeTypeRepository.Delete(id);
                await unitOfWork.CompleteAsync();
                return Ok($"Employee Type {id} Deleted Successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
