using HRIS.Interfaces;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISdatabaseModels.DatabaseModels.SalaryStructure;
using HRISgenericInterfaces;
using HRISgenericRepositories.SalaryStructureRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Controllers.SalaryStructure
{
    [Route("/[controller]/[action]")]
    [ApiController]

    public class PayGradeScaleController : GenericController<PayGradeScale>
    {
        private readonly IUnitOfWork unitOfWork;

        public PayGradeScaleController(IAllInterfaces<PayGradeScale> allController, IUnitOfWork unitOfWork) : base(allController)
        {
            this.unitOfWork = unitOfWork;
        }

        // INSERT

        [HttpPost]
        public async Task<IActionResult> InsertPayGradeScale(PayGradeScale data)
        {
            try
            {
                var insertScale = await unitOfWork.payGradeScaleRepository.CreatePayGradeScale(data);

                if (insertScale)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok("New Pay Grade Scale Inserted Successfully");
                }
                else
                {
                    return BadRequest("Failed to insert new pay grade scale !!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        //UPDATE

        [HttpPut]
        public async Task<IActionResult> UpdatePayGradeScale(PayGradeScale data)
        {
            try
            {
                var updateScale = await unitOfWork.payGradeScaleRepository.UpdatePayGradeScale(data);

                if (updateScale)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok($"Pay Grade Scale data with id {data.PayGradeScaleId} Successfully");
                }
                else
                {
                    return BadRequest($"Failed to update pay grade scale data of id {data.PayGradeScaleId} !!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE

        [HttpDelete]
        public async Task<IActionResult> DeletePayGradeScaleData(int id)
        {
            try
            {
                var dataToDelete = await unitOfWork.payGradeScaleRepository.DeletePayGradeScale(id);
                if (dataToDelete)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok($"Pay grade scale with Id {id} deleted successfully");
                }
                else
                {
                    return Ok("Failed to delete Pay grade scale data");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
