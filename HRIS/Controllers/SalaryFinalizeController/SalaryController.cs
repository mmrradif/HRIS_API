using HRISdatabaseModels.DatabaseModels.Recruitement;
using HRISdatabaseModels.DatabaseModels.SalaryAndBonusInformation;
using HRISgenericInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Controllers.SalaryFinalizeController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SalaryController : GenericController<Salary> 
    {
        private readonly IUnitOfWork unitOfWork;

        public SalaryController(IAllInterfaces<Salary> allController, IUnitOfWork unitOfWork) : base(allController)
        {
            this.unitOfWork = unitOfWork;
        }

        // Insert Salary

        [HttpPost]
        public async Task<IActionResult> InsertSalary(Salary data)
        {
            try
            {
                var result = await unitOfWork.salaryRepository.InsertSalary(data);
                if (result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok($"Salary Inserted Successfully for Employee Id: {data.EmployeeId}. Waiting for approval");
                }
                else
                {
                    return BadRequest("Failed to Insert Salary !!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Approve Salary

        [HttpPut]
        public async Task<IActionResult> ApproveSalary(Salary data)
        {
            try
            {
                var result = await unitOfWork.salaryRepository.ApproveSalary(data);
                if(result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok($"Salary For Employee ID: {data.EmployeeId} Approved by {data.ApproverId}. Waiting for payment confirmation.");
                }
                else
                {
                    return BadRequest("Failed to approve salary !!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Salary Payment

        [HttpPut]
        public async Task<IActionResult> PaymentConfirm(Salary data)
        {
            try
            {
                var result = await unitOfWork.salaryRepository.SalaryPayment(data);
                if (result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok($"Salary Payment Confirmed By Id: {data.PaymentBy}");
                }
                else
                {
                    return BadRequest("Salary Payment Failed !!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE

        [HttpDelete]
        public async Task<IActionResult> DeleteSalaryData(int id)
        {
            try
            {
                var salaryDataToDelete = await unitOfWork.salaryRepository.DeleteSalary(id);
                if (salaryDataToDelete)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok($"Salary with Salary Id {id} deleted successfully");
                }
                else
                {
                    return Ok("Failed to delete Salary data");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
