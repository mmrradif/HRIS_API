using HRIS.Interfaces;
using HRISdatabaseModels.DatabaseModels.SalaryStructure;
using HRISgenericInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Controllers.SalaryStructure
{
    [Route("/[controller]/[action]")]
    [ApiController]

    public class SalaryComponentController : GenericController<SalaryComponent>
    {
        private readonly IUnitOfWork unitOfWork;

        public SalaryComponentController(IAllInterfaces<SalaryComponent> allController, IUnitOfWork unitOfWork) : base(allController)
        {
            this.unitOfWork = unitOfWork;
        }


        // INSERT

        [HttpPost]
        public async Task<IActionResult> InsertSalaryComponent(SalaryComponent data)
        {
            try
            {
                var result = await unitOfWork.salaryComponentRepository.CreateSalaryComponent(data);
                if (result)
                {
                    return Ok("New Salary Component Inserted Successfully");
                }
                else
                {
                    return BadRequest("Failed to Insert New Salary Component !!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        // UPDATE

        [HttpPut]
        public async Task<IActionResult> UpdateSalaryComponent(SalaryComponent data)
        {
            try
            {
                var result = await unitOfWork.salaryComponentRepository.UpdateSalaryComponent(data);
                if (result)
                {
                    return Ok($"Salary Component Data with Id {data.SalaryComponentId} Updated Successfully");
                }
                else
                {
                    return BadRequest("Failed to Update Salary Component !!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE

        [HttpDelete]
        public async Task<IActionResult> DeleteSalaryComponentData(int id)
        {
            try
            {
                var salaryComponentToDelete = await unitOfWork.salaryComponentRepository.DeleteSalaryComponent(id);
                if (salaryComponentToDelete)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok($"Salary Component with Info Id {id} deleted successfully");
                }
                else
                {
                    return Ok("Failed to delete Salary Component data");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
