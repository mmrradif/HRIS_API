using HRISdatabaseModels.DatabaseModels.AttendenceInformation;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISdatabaseModels.DatabaseModels.Recruitement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Controllers.AttendanceInfomationControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DailyAttendanceController : ControllerBase
    {

        private readonly IUnitOfWork unitOfWork;

        public DailyAttendanceController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var attendanceData = await unitOfWork.dailyAttendanceRepository.GetAll();
                return Ok(attendanceData);
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
                var data = await unitOfWork.dailyAttendanceRepository.GetById(id);
                if (data == null)
                {
                    return NotFound($"Sorry!!! Attendance ID: {id} Not Exists");
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        //[HttpGet]
        //public async Task<IActionResult> GetEmployeeWiseAttendance(int empId)
        //{
        //    try
        //    {
        //        if (empId != null)
        //        {
        //            List<DailyAttendence> attnList = new List<DailyAttendence>();
        //            attnList = await unitOfWork.dailyAttendanceRepository.GetListById(empId);
        //            return Ok(attnList);
        //        }
        //        else
        //        {
        //            return BadRequest($"Employee ID not found");
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        //[HttpGet]
        //public async Task<IActionResult> GetByName(string name)
        //{
        //    try
        //    {
        //        var data = await unitOfWork.candidateRepository.GetByName(name);
        //        if (data == null)
        //        {
        //            return NotFound($"Sorry!!! Candidate: {name} Not Exists");
        //        }
        //        return Ok(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        [HttpPost]
        public async Task<IActionResult> Insert(DailyAttendence attendance)
        {
            try
            {
                await unitOfWork.dailyAttendanceRepository.Insert(attendance);
                await unitOfWork.CompleteAsync();
                return Ok(attendance);
            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpPost]
        public async Task<IActionResult> InsertRange(DailyAttendence[] attendances)
        {
            try
            {
                await unitOfWork.dailyAttendanceRepository.InsertRange(attendances);
                await unitOfWork.CompleteAsync();
                return Ok(attendances);
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPut]
        public async Task<IActionResult> Update(DailyAttendence attendance)
        {
            try
            {
                var result = await unitOfWork.dailyAttendanceRepository.Update(attendance);
                if (result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok(attendance);
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
                var data = await unitOfWork.dailyAttendanceRepository.GetById(id);
                if (data == null)
                {
                    return NotFound($"Attendance ID: {id} Not Exists");
                }
                await unitOfWork.dailyAttendanceRepository.Delete(id);
                await unitOfWork.CompleteAsync();
                return Ok($"Attendance ID {id} Deleted Successfully");
            }
            catch (Exception)
            {

                throw;
            }
        }




        [HttpPost]
        public async Task<IActionResult> GetReport(int id, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var result = await unitOfWork.dailyAttendanceRepository.AttendaceReport(id, fromDate, toDate);
                if (result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok(result);
                }
                return BadRequest("Report Created Failed...");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // INSERT

        [HttpPost]
        public async Task<IActionResult> InsertAttendanceWithSP(DailyAttendence data)
        {
            try
            {
                var result = await unitOfWork.dailyAttendanceRepository.InsertAttnWithSP(data);

                if (result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok($"Attendance inserted successfully. Employee ID: {data.EmployeeId} , Attendance Date: {data.AttendanceDate}");
                }
                else
                {
                    return BadRequest($"Failed to insert attendance data");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // UPDATE 

        [HttpPut]
        public async Task<IActionResult> UpdateAttendanceWithSP(DailyAttendence data)
        {
            try
            {
                var result = await unitOfWork.dailyAttendanceRepository.UpdateAttnWithSP(data);

                if (result)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok($"Attendance data of Attendance Date: {data.AttendanceDate} and Employee ID: {data.EmployeeId}  updated successfully.");
                }
                else
                {
                    return BadRequest($"Failed to update attendance data");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE

        [HttpDelete]
        public async Task<IActionResult> DeleteDailyAttnDataWithSP(int id)
        {
            try
            {
                var deleteAttnData = await unitOfWork.dailyAttendanceRepository.DeleteAttnWithSP(id);

                if (deleteAttnData)
                {
                    await unitOfWork.CompleteAsync();
                    return Ok($"Attendance data deleted successfully");
                }
                else
                {
                    return Ok("Failed to delete attendance data");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}
