using HRIS.DatabaseContext;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISdatabaseModels.DatabaseModels.SalaryAndBonusInformation;
using HRISgenericInterfaces;
using HRISgenericInterfaces.SalaryFinalizeInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HRISgenericRepositories.SalaryFinalizeRepositories
{
    public class SalaryRepo : GenericRepo<Salary>, ISalary,IAllInterfaces<Salary>
    {
        public SalaryRepo(HRISdbContext dbContext) : base(dbContext)
        {
        }

        // -- Get All
        public override Task<List<Salary>> GetAll()
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


        // -- Get By ID
        public override async Task<Salary> GetById(int id)
        {
            try
            {
                var salary = await dbSet.FirstOrDefaultAsync(item => item.SalaryId == id);
                return salary;
            }
            catch (Exception)
            {
                throw;
            }
        }




        // -------------------------- INSERT
        public override async Task Insert(Salary entity)
        {
            await dbSet.AddAsync(entity);
        }

        // ------------------------------ INSERT RANGE

        public override async Task InsertRange(IEnumerable<Salary> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }



        // ---------------------------- UPDATE
        public override async Task<bool> Update(Salary entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.SalaryId == entity.SalaryId);

                if (existdata != null)
                {
                    existdata.SalaryId= entity.SalaryId;
                    existdata.EmployeeId= entity.EmployeeId;
                    existdata.SalaryMonth= entity.SalaryMonth;
                    existdata.TotalSalary = entity.TotalSalary;
                    existdata.DaysOfMonth= entity.DaysOfMonth;
                    existdata.AcumulatedDays= entity.AcumulatedDays;
                    existdata.GrossPay = entity.GrossPay;
                    existdata.Tax= entity.Tax;
                    existdata.LoanScheduleId= entity.LoanScheduleId;
                    existdata.Arear= entity.Arear;
                    existdata.NetPayout= entity.NetPayout;
                    existdata.Status= entity.Status;
                    existdata.CreateDate= entity.CreateDate;
                    existdata.CreateBy= entity.CreateBy;
                    existdata.LastUpdateDate= entity.LastUpdateDate;
                    existdata.UpdateBy= entity.UpdateBy;
                    existdata.ApproverId = entity.ApproverId;
                    existdata.ApproveDate= entity.ApproveDate;
                    existdata.CompanyId= entity.CompanyId;
                    existdata.GradeId= entity.GradeId;
                    existdata.DesignationId= entity.DesignationId;
                    existdata.DepartmentId= entity.DepartmentId;
                    existdata.DivisionId= entity.DivisionId;
                    existdata.LocationId= entity.LocationId;
                    existdata.EmployeeTypeId= entity.EmployeeTypeId;
                    existdata.BankAccountNo= entity.BankAccountNo;
                    existdata.SalaryRemarks= entity.SalaryRemarks;
                    existdata.PaymentBy= entity.PaymentBy;
                    existdata.PaymentDate= entity.PaymentDate;
                    existdata.IsBankPayment= entity.IsBankPayment;
                    existdata.BankPaymentBy= entity.BankPaymentBy;
                    existdata.BankPaymentDate= entity.BankPaymentDate;
                    existdata.IsCashPayment= entity.IsCashPayment;
                    existdata.CashPaymentBy= entity.CashPaymentBy;
                    existdata.CashPaymentDate= entity.CashPaymentDate;
                    existdata.PaymentConfirmationDate= entity.PaymentConfirmationDate;
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



        // ----------------------------------- DELETE
        public override async Task<bool> Delete(int id)
        {
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.SalaryId == id);
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

        // INSERT SALARY

        public async Task<bool> InsertSalary(Salary data)
        {
            try
            {
                if(data.SalaryId == 0)
                {
                    await hrisDbContext.Database.ExecuteSqlAsync($"EXEC sp_Insert_tblSalary @empId = {data.EmployeeId}, @salaryMonth = {data.SalaryMonth}, @arear = {data.Arear}, @createBy = {data.CreateBy}");

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

        // APPROVE SALARY

        public async Task<bool> ApproveSalary(Salary data)
        {
            try
            {
                var salaryToApprove = await hrisDbContext.tblSalary.FirstOrDefaultAsync(x=>x.SalaryId == data.SalaryId);

                if (salaryToApprove != null)
                {
                    await hrisDbContext.Database.ExecuteSqlAsync($"EXEC sp_Insert_tblSalary @salaryId = {data.SalaryId}, @empId = {data.EmployeeId}, @salaryMonth = {data.SalaryMonth}, @updateBy = {data.UpdateBy}, @approverId = {data.ApproverId}");
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

        // PAYMENT SALARY

        public async Task<bool> SalaryPayment(Salary data)
        {
            try
            {
                var salaryToPayment = await hrisDbContext.tblSalary.FirstOrDefaultAsync(x => x.SalaryId == data.SalaryId);

                if(salaryToPayment != null)
                {
                    var confirmPayment = await hrisDbContext.Database.ExecuteSqlAsync($"EXEC sp_Insert_tblSalary @salaryId = {data.SalaryId}, @empId = {data.EmployeeId}, @salaryMonth = {data.SalaryMonth}, @updateBy ={data.UpdateBy}, @paymentBy = {data.PaymentBy}, @isBankPayment = {data.IsBankPayment}");

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

        public async Task<bool> DeleteSalary(int id)
        {
            try
            {
                var dataToDelete = await hrisDbContext.tblSalary.FirstOrDefaultAsync(x => x.SalaryId == id);

                if (dataToDelete != null)
                {
                    await hrisDbContext.Database.ExecuteSqlAsync($"EXEC spGenericDeleteData @tableName = 'tblSalary', @dataId = {id}");
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

        public async Task CompleteAsync()
        {
            await hrisDbContext.SaveChangesAsync();
            Dispose();
        }

        public void Dispose()
        {
            hrisDbContext.Dispose();
            GC.SuppressFinalize(this);
         }

    }
}
