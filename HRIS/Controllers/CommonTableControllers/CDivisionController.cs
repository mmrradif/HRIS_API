using HRIS.Interfaces;
using HRISdatabaseModels.DatabaseModels.CommonTables;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HRIS.Controllers.CompanyControllers
{
   
    [Route("/[controller]/[action]")]
    [ApiController]

    public class CDivisionController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CDivisionController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cDistricts = await unitOfWork.cDivisionRepository.GetAll();
                return Ok(cDistricts);
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
                var data = await unitOfWork.cDivisionRepository.GetById(id);
                if (data == null)
                {
                    return NotFound($"Sorry!!! ID: {id} Not Exists");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }





        // ------------------------------- Insert 
        [HttpPost]
        public async Task<IActionResult> Insert(CDivision division)
        {
            try
            {
                await unitOfWork.cDivisionRepository.Insert(division);
                await unitOfWork.CompleteAsync();
                return Ok(division);
            }
            catch (Exception)
            {
                throw;
            }

        }



        // ------------------------------- Insert Range
        [HttpPost]
        public async Task<IActionResult> InsertRange(CDivision[] cDivisions)
        {
            try
            {
                await unitOfWork.cDivisionRepository.InsertRange(cDivisions);
                await unitOfWork.CompleteAsync();
                return Ok(cDivisions);
            }
            catch (Exception)
            {
                throw;
            }

        }


        // ----------------------------- UPDATE
        [HttpPut]
        public async Task<IActionResult> Update(CDivision cDivision)
        {
            try
            {
                var result = await unitOfWork.cDivisionRepository.Update(cDivision);
                if (result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok(cDivision);
                }
                return NotFound("Id Not Found");
            }
            catch (Exception)
            {

                throw;
            }

        }



        // --------------------------- Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var data = await unitOfWork.cDivisionRepository.GetById(id);
                if (data == null)
                {
                    return NotFound($"ID: {id} Not Exists");
                }
                await unitOfWork.cDivisionRepository.Delete(id);
                await unitOfWork.CompleteAsync();
                return Ok($"ID: {id} Deleted Successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
