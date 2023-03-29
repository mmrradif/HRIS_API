using HRISdatabaseModels.DatabaseModels.Loan;
using HRISgenericInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Controllers.LoanControllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class LoanScheduleController : GenericController<LoanSchedule>
    {
        private readonly IUnitOfWork unitOfWork;

        public LoanScheduleController(IAllInterfaces<LoanSchedule> allController, IUnitOfWork unitOfWork) : base(allController)
        {
            this.unitOfWork = unitOfWork;
        }

        // INSERT LOAN SCHEDULE

        [HttpPost]
        public async Task<IActionResult> InsertSchedule(LoanSchedule data)
        {
            try
            {
                var result = await unitOfWork.loanScheduleRepository.InsertLoanSchedule(data);
                if (result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok($"New Loan Schedule Inserted Successfully");
                }
                return BadRequest("Failed to insert loan schedule");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // PAYMENT LOAN SCHEDULE

        [HttpPut]
        public async Task<IActionResult> PaymentSchedule(LoanSchedule data)
        {
            try
            {
                var result = await unitOfWork.loanScheduleRepository.UpdateLoanSchedule(data);
                if (result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok($"Loan Schedule Updated Successfully");
                }
                return BadRequest("Failed to update loan schedule");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE

        [HttpDelete]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            try
            {
                var deleteSchedule = await unitOfWork.loanScheduleRepository.DeleteLoanSchedule(id);
                if (deleteSchedule)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok($"Loan Schedule with id:{id} deleted successfully");
                }
                else
                {
                    return Ok("Failed to delete schedule");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
