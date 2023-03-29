using HRIS.DatabaseContext;
using HRISdatabaseModels.DatabaseModels.AttendenceInformation;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISdatabaseModels.DatabaseModels.Recruitement;
using HRISgenericInterfaces.AttendanceInformationInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericRepositories.AttendanceInformationRepositories
{
    public class DailyAttendanceRepo : GenericRepo<DailyAttendence>, IDailyAttendance
    {
        public DailyAttendanceRepo(HRISdbContext dbContext) : base(dbContext)
        {
        }

        //get all

        public override Task<List<DailyAttendence>> GetAll()
        {
            try
            {
                return base.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //get by id

        public override async Task<DailyAttendence> GetById(int id)
        {
            try
            {
                var attendanceData = await dbSet.FirstOrDefaultAsync(item => item.AttendanceId == id);
                return attendanceData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //get attendance data by Employee ID
        //public override async Task<List<DailyAttendence>> GetListById(int empId)
        //{
        //    try
        //    {
        //        List<DailyAttendence> empAttn = new List<DailyAttendence>();
        //        empAttn = await hrisDbContext.tblDailyAttendance.FromSqlRaw($"sp_GetAttendanceDataByEmployeeId {empId}").ToListAsync();
        //        return empAttn;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

      

        //insert
        public override async Task Insert(DailyAttendence entity)
        {
            await dbSet.AddAsync(entity);
        }


        //update
        public override async Task<bool> Update(DailyAttendence entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.AttendanceId == entity.AttendanceId);

                if (existdata != null)
                {
                    existdata.AttendanceId= entity.AttendanceId;
                    existdata.EmployeeId= entity.EmployeeId;
                    existdata.EmployeeTypeId= entity.EmployeeTypeId;
                    existdata.CompanyId= entity.CompanyId;
                    existdata.GradeId= entity.GradeId;
                    existdata.DivisionId= entity.DivisionId;
                    existdata.DesignationId= entity.DesignationId;
                    existdata.DepartmentId= entity.DepartmentId;
                    existdata.LocationId= entity.LocationId;
                    existdata.RosterId= entity.RosterId;
                    existdata.AttendanceDate= entity.AttendanceDate;
                    existdata.InTime= entity.InTime;
                    existdata.OutTime= entity.OutTime;
                    existdata.TotalWorkingHours= entity.TotalWorkingHours;
                    existdata.OverTimeHours= entity.OverTimeHours;
                    existdata.Status = entity.Status;
                    existdata.CreateBy= entity.CreateBy;
                    existdata.CreateDate= entity.CreateDate;
                    existdata.UpdateBy = entity.UpdateBy;
                    existdata.UpdateDate = entity.UpdateDate;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        //delete
        public override async Task<bool> Delete(int id)
        {
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.AttendanceId == id);
            if (existdata != null)
            {
                dbSet.Remove(existdata);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> AttendaceReport(int id, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var data = await hrisDbContext.Database.ExecuteSqlAsync($"spAttendanceReport {id},{fromDate},{toDate}");
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }



        // INSERT
        public async Task<bool> InsertAttnWithSP(DailyAttendence dailyAttendence)
        {
            try
            {
                var existingAttnData = await hrisDbContext.tblDailyAttendance.FirstOrDefaultAsync(x => x.EmployeeId == dailyAttendence.EmployeeId && x.AttendanceDate == dailyAttendence.AttendanceDate);

                if (existingAttnData == null && dailyAttendence.AttendanceId == 0)
                {
                    await hrisDbContext.Database.ExecuteSqlAsync($"EXEC sp_tblDailyAttendanceInsert @empId={dailyAttendence.EmployeeId} , @intime={dailyAttendence.InTime}, @outtime={dailyAttendence.OutTime}, @createBy={dailyAttendence.CreateBy}");

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        // UPDATE
        public async Task<bool> UpdateAttnWithSP(DailyAttendence dailyAttendence)
        {
            try
            {
                var updateData = await hrisDbContext.tblDailyAttendance.FirstOrDefaultAsync(x => x.AttendanceId == dailyAttendence.AttendanceId);

                if (updateData != null)
                {
                    await hrisDbContext.Database.ExecuteSqlAsync($"EXEC sp_tblDailyAttendanceInsert @attnId={dailyAttendence.AttendanceId}, @empId={dailyAttendence.EmployeeId} , @intime={dailyAttendence.InTime}, @outtime={dailyAttendence.OutTime}, @updateBy={dailyAttendence.UpdateBy}");

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        // DELETE
        public async Task<bool> DeleteAttnWithSP(int id)
        {
            try
            {
                var dataToDelete = await hrisDbContext.tblDailyAttendance.FirstOrDefaultAsync(x => x.AttendanceId == id);

                if (dataToDelete != null)
                {
                    await hrisDbContext.Database.ExecuteSqlAsync($"EXEC spGenericDeleteData @tableName = 'tblDailyAttendance', @dataId = {id}");

                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
