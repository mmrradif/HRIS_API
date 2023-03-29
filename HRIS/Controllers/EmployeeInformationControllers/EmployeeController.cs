using HRISdatabaseModels.DatabaseModels.EmployeeInformation;
using HRISdatabaseModels.DatabaseModels.Recruitement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Controllers.EmployeeInformationControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var emp = await unitOfWork.employeeRepository.GetAll();
                return Ok(emp);
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
                var data = await unitOfWork.employeeRepository.GetById(id);
                if (data == null)
                {
                    return NotFound($"Sorry!!! Employee ID: {id} Not Exists");
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
                var data = await unitOfWork.employeeRepository.GetByName(name);
                if (data == null)
                {
                    return NotFound($"Sorry!!! Employee {name} Not Exists");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Insert(Employee employee)
        {
            try
            {
                await unitOfWork.employeeRepository.Insert(employee);
                await unitOfWork.CompleteAsync();
                return Ok(employee);
            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpPost]
        public async Task<IActionResult> InsertRange(Employee[] employees)
        {
            try
            {
                await unitOfWork.employeeRepository.InsertRange(employees);
                await unitOfWork.CompleteAsync();
                return Ok(employees);
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPut]
        public async Task<IActionResult> Update([FromForm] Employee employee)
        {
            try
            {
                var result = await unitOfWork.employeeRepository.Update(employee);
                if (result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok(employee);
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
                var data = await unitOfWork.employeeRepository.GetById(id);
                if (data == null)
                {
                    return NotFound($"Employee ID: {id} Not Exists");
                }
                await unitOfWork.employeeRepository.Delete(id);
                await unitOfWork.CompleteAsync();
                return Ok($"Employee {id} Deleted Successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
