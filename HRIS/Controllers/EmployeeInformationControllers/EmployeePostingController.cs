using HRISdatabaseModels.DatabaseModels.EmployeeInformation;
using HRISdatabaseModels.DatabaseModels.Recruitement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Controllers.EmployeeInformationControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeePostingController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeePostingController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var postingData = await unitOfWork.employeePostingRepository.GetAll();
                return Ok(postingData);
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
                var data = await unitOfWork.employeePostingRepository.GetById(id);
                if (data == null)
                {
                    return NotFound($"Sorry!!! Employee Posting ID: {id} Not Exists");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //[HttpGet]
        //public async Task<IActionResult> GetByName(string name)
        //{
        //    try
        //    {
        //        var data = await unitOfWork.candidateRepository.GetByName(name);
        //        if (data == null)
        //        {
        //            return NotFound($"Sorry!!! Candidate: {name} Not Exists");
        //        }
        //        return Ok(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        [HttpPost]
        public async Task<IActionResult> Insert([FromForm] EmployeePosting postingdata)
        {
            try
            {
                await unitOfWork.employeePostingRepository.Insert(postingdata);
                await unitOfWork.CompleteAsync();
                return Ok(postingdata);
            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpPost]
        public async Task<IActionResult> InsertRange(EmployeePosting[] postings)
        {
            try
            {
                await unitOfWork.employeePostingRepository.InsertRange(postings);
                await unitOfWork.CompleteAsync();
                return Ok(postings);
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPut]
        public async Task<IActionResult> Update([FromForm] EmployeePosting postingData)
        {
            try
            {
                var result = await unitOfWork.employeePostingRepository.Update(postingData);
                if (result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok(postingData);
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
                var data = await unitOfWork.employeePostingRepository.GetById(id);
                if (data == null)
                {
                    return NotFound($"Employee Posting ID: {id} Not Exists");
                }
                await unitOfWork.employeePostingRepository.Delete(id);
                await unitOfWork.CompleteAsync();
                return Ok($"Employee Posting {id} Deleted Successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
