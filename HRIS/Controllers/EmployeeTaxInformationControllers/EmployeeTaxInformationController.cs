using HRISdatabaseModels.DatabaseModels.EmployeeTaxInformation;
using HRISdatabaseModels.DatabaseModels.Loan;
using HRISgenericInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Controllers.EmployeeTaxInformationControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeTaxInformationController : GenericController <EmployeeTaxInfo>
    {
        private readonly IUnitOfWork unitOfWork;

        public EmployeeTaxInformationController(IAllInterfaces<EmployeeTaxInfo> allController, IUnitOfWork unitOfWork) : base(allController)
        {
            this.unitOfWork = unitOfWork;
        }


        // INSERT

        [HttpPost]
        public async Task<IActionResult> InsertTaxInfo(EmployeeTaxInfo data)
        {
            try
            {
                var result = await unitOfWork.employeeTaxInformationRepository.InsertEmployeeTaxInformation(data);
                if (result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok($"Tax Amount {data.TaxAmount} has been effective for employee with id:{data.EmployeeId}");
                }
                return BadRequest("Failed to insert new tax info !!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // UPDATE

        [HttpPut]
        public async Task<IActionResult> UpdateTaxInfo(EmployeeTaxInfo data)
        {
            try
            {
                var result = await unitOfWork.employeeTaxInformationRepository.UpdateEmployeeTaxInformation(data);
                if (result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok($"Tax Information Updated Successfully.");
                }
                return BadRequest("Failed to update tax info !!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // DELETE

        [HttpDelete]
        public async Task<IActionResult> DeleteTaxInfo(int id)
        {
            try
            {
                var taxInfoToDelete = await unitOfWork.employeeTaxInformationRepository.DeleteEmployeeTaxInformation(id);

                if (taxInfoToDelete)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok($"Tax info with Info Id {id} deleted successfully");
                }
                else
                {
                    return Ok("Failed to delete tax data");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
