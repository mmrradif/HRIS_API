using HRIS.Repositories;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISdatabaseModels.DatabaseModels.Loan;
using HRISgenericInterfaces;
using HRISgenericRepositories.LoanRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HRIS.Controllers.LoanControllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class LoanInformationController : GenericController<LoanInformation>
    {
        private readonly IUnitOfWork unitOfWork;
        
        public LoanInformationController(IAllInterfaces<LoanInformation> allController, IUnitOfWork unitOfWork) : base(allController)
        {
            this.unitOfWork = unitOfWork;
            
        }


        // Apply For Loan

        [HttpPost]
        public async Task<IActionResult> ApplyForLoan(LoanInformation data)
        {
            try
            {
                var result = await unitOfWork.loanInformationRepository.ApplyForLoan(data);
                if (result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok($"A loan for {data.LoanAmount} tk is applied by  Employee Id: {data.EmployeeId}");
                }
                return BadRequest("Loan Application Failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Approve Loan

        [HttpPut]
        public async Task<IActionResult> ApproveLoan(LoanInformation data)
        {
            try
            {
                var result = await unitOfWork.loanInformationRepository.ApproveLoan(data);
                if(result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok($"{data.LoanAmount} taka loan is approved for Employee Id: {data.EmployeeId}");
                }
                else
                {
                    return BadRequest("Failed to Approve Loan");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Reject Loan

        [HttpPut]
        public async Task<IActionResult> RejectLoan(LoanInformation data)
        {
            try
            {
                var result = await unitOfWork.loanInformationRepository.RejectLoan(data);
                if (result)
                {
                    await unitOfWork.CompleteAsync();

                    return Ok($"Loan Application By Employee Id: {data.EmployeeId} for {data.LoanAmount} taka was Rejected");
                }
                else
                {
                    return BadRequest($"Failed to reject loan for loan information id: {data.LoanInformationId}");
                }

                
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE

        [HttpDelete]
        public async Task<IActionResult> DeleteLoanData(int id)
        {
            try
            {
                var loanInfoToDelete = await unitOfWork.loanInformationRepository.DeleteLoan(id);
                if (loanInfoToDelete)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok($"Loan with Info Id {id} deleted successfully");
                }
                else
                {
                    return Ok("Failed to delete loan data");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
