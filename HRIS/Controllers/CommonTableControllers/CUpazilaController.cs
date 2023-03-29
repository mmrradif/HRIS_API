using HRIS.Interfaces;
using HRISdatabaseModels.DatabaseModels.CommonTables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HRIS.Controllers.CompanyControllers
{
    
    [Route("/[controller]/[action]")]
    [ApiController]

    public class CUpazilaController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CUpazilaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var cDistricts = await unitOfWork.cUpazilaRepository.GetAll();
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
                var data = await unitOfWork.cUpazilaRepository.GetById(id);
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
        public async Task<IActionResult> Insert(CUpazila cUpazila)
        {
            try
            {
                await unitOfWork.cUpazilaRepository.Insert(cUpazila);
                await unitOfWork.CompleteAsync();
                return Ok(cUpazila);
            }
            catch (Exception)
            {
                throw;
            }

        }



        // ------------------------------- Insert Range
        [HttpPost]
        public async Task<IActionResult> InsertRange(CUpazila[] cUpazilas)
        {
            try
            {
                await unitOfWork.cUpazilaRepository.InsertRange(cUpazilas);
                await unitOfWork.CompleteAsync();
                return Ok(cUpazilas);
            }
            catch (Exception)
            {

                throw;
            }

        }


        // ----------------------------- UPDATE
        [HttpPut]
        public async Task<IActionResult> Update(CUpazila cUpazila)
        {
            try
            {
                var result = await unitOfWork.cUpazilaRepository.Update(cUpazila);
                if (result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok(cUpazila);
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
                var data = await unitOfWork.cUpazilaRepository.GetById(id);
                if (data == null)
                {
                    return NotFound($"ID: {id} Not Exists");
                }
                await unitOfWork.cUpazilaRepository.Delete(id);
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
