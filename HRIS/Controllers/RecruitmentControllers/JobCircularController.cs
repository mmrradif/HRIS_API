using HRISdatabaseModels.DatabaseModels.Recruitement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Controllers.RecruitmentControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobCircularController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public JobCircularController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var jobcircular = await unitOfWork.jobCircularRepository.GetAll();
                return Ok(jobcircular);
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
                var data = await unitOfWork.jobCircularRepository.GetById(id);
                if (data == null)
                {
                    return NotFound($"Sorry!!! Job Circular ID: {id} Not Exists");
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
        //        var data = await unitOfWork.jobCircularRepository.GetByName(name);
        //        if (data == null)
        //        {
        //            return NotFound($"Sorry!!! Job: {name} Not Exists");
        //        }
        //        return Ok(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        [HttpPost]
        public async Task<IActionResult> Insert([FromForm] JobCircular jobCircular)
        {
            try
            {
                await unitOfWork.jobCircularRepository.Insert(jobCircular);
                await unitOfWork.CompleteAsync();
                return Ok(jobCircular);
            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpPost]
        public async Task<IActionResult> InsertRange(JobCircular[] jobCirculars)
        {
            try
            {
                await unitOfWork.jobCircularRepository.InsertRange(jobCirculars);
                await unitOfWork.CompleteAsync();
                return Ok(jobCirculars);
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPut]
        public async Task<IActionResult> Update([FromForm] JobCircular jobCircular)
        {
            try
            {
                var result = await unitOfWork.jobCircularRepository.Update(jobCircular);
                if (result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok(jobCircular);
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
                var data = await unitOfWork.jobCircularRepository.GetById(id);
                if (data == null)
                {
                    return NotFound($"Job Circular ID: {id} Not Exists");
                }
                await unitOfWork.jobCircularRepository.Delete(id);
                await unitOfWork.CompleteAsync();
                return Ok($"Job Circular {id} Deleted Successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
