using HRIS.DatabaseModels.CompanyInformation;
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

    public class CDistrictController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CDistrictController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cDistricts = await unitOfWork.cDistrictRepository.GetAll();
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
                var data = await unitOfWork.cDistrictRepository.GetById(id);
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
        public async Task<IActionResult> Insert(CDistrict district)
        {
            try
            {
                await unitOfWork.cDistrictRepository.Insert(district);
                await unitOfWork.CompleteAsync();
                return Ok(district);
            }
            catch (Exception)
            {
                throw;
            }

        }



        // ------------------------------- Insert Range
        [HttpPost]
        public async Task<IActionResult> InsertRange(CDistrict[] cdistricts)
        {
            try
            {
                await unitOfWork.cDistrictRepository.InsertRange(cdistricts);
                await unitOfWork.CompleteAsync();
                return Ok(cdistricts);
            }
            catch (Exception)
            {

                throw;
            }

        }


        // ----------------------------- UPDATE
        [HttpPut]
        public async Task<IActionResult> Update(CDistrict cDistrict)
        {
            try
            {
                var result = await unitOfWork.cDistrictRepository.Update(cDistrict);
                if (result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok(cDistrict);
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
                var data = await unitOfWork.cDistrictRepository.GetById(id);
                if (data == null)
                {
                    return NotFound($"ID: {id} Not Exists");
                }
                await unitOfWork.gradeRepository.Delete(id);
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
