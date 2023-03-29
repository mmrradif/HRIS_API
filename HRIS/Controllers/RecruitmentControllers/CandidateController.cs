using HRISdatabaseModels.DatabaseModels.EmployeeInformation;
using HRISdatabaseModels.DatabaseModels.Recruitement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Controllers.RecruitmentControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {

        private readonly IUnitOfWork unitOfWork;

        public CandidateController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var candidate = await unitOfWork.candidateRepository.GetAll();
                return Ok(candidate);
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
                var data = await unitOfWork.candidateRepository.GetById(id);
                if (data == null)
                {
                    return NotFound($"Sorry!!! Candidate ID: {id} Not Exists");
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
                var data = await unitOfWork.candidateRepository.GetByName(name);
                if (data == null)
                {
                    return NotFound($"Sorry!!! Candidate: {name} Not Exists");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Insert([FromForm] Candidate candidate)
        {
            try
            {
                await unitOfWork.candidateRepository.Insert(candidate);
                await unitOfWork.CompleteAsync();
                return Ok(candidate);
            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpPost]
        public async Task<IActionResult> InsertRange(Candidate[] candidates)
        {
            try
            {
                await unitOfWork.candidateRepository.InsertRange(candidates);
                await unitOfWork.CompleteAsync();
                return Ok(candidates);
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPut]
        public async Task<IActionResult> Update([FromForm] Candidate candidate)
        {
            try
            {
                var result = await unitOfWork.candidateRepository.Update(candidate);
                if (result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok(candidate);
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
                var data = await unitOfWork.candidateRepository.GetById(id);
                if (data == null)
                {
                    return NotFound($"Candidate ID: {id} Not Exists");
                }
                await unitOfWork.candidateRepository.Delete(id);
                await unitOfWork.CompleteAsync();
                return Ok($"Candidate {id} Deleted Successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}
