using HRIS.DatabaseContext;
using HRIS.DatabaseModels.CompanyInformation;
using HRISdatabaseModels.DatabaseModels.EmployeeTaxInformation;
using HRISdatabaseModels.DatabaseModels.Loan;
using HRISgenericInterfaces;
using HRISgenericInterfaces.EmployeeTaxInformationInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HRISgenericRepositories.EmployeeTaxInformationRepositories
{
    public class EmployeeTaxInformationRepo : GenericRepo<EmployeeTaxInfo>, IEmployeeTaxInformation, IAllInterfaces<EmployeeTaxInfo>
    {
        public EmployeeTaxInformationRepo(HRISdbContext dbContext) : base(dbContext)
        {
        }

        // -- Get All
        
        public override Task<List<EmployeeTaxInfo>> GetAll()
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

        public override async Task<EmployeeTaxInfo> GetById(int id)
        {
            try
            {
                var taxInfo = await dbSet.FirstOrDefaultAsync(x=>x.EmployeeTaxInfoId == id);
                return taxInfo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // -------------------------- INSERT

        public override async Task Insert(EmployeeTaxInfo empTaxInfo) 
        {
            try
            {
                await dbSet.AddAsync(empTaxInfo);
                
            }
            catch (Exception)
            {

                throw;
            }
        }


        // ------------------------------ INSERT RANGE

        public override async Task InsertRange(IEnumerable<EmployeeTaxInfo> empTaxInfos)
        {
            try
            {
                await dbSet.AddRangeAsync(empTaxInfos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // ---------------------------- UPDATE
        public override async Task<bool> Update(EmployeeTaxInfo entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.EmployeeTaxInfoId == entity.EmployeeTaxInfoId);

                if (existdata != null)
                {
                    existdata.EmployeeTaxInfoId = entity.EmployeeTaxInfoId;
                    existdata.EmployeeId = entity.EmployeeId;
                    existdata.TaxAmount = entity.TaxAmount;
                    existdata.EffectiveDate = entity.EffectiveDate;
                    existdata.Status = entity.Status;
                    existdata.CreateBy = entity.CreateBy;
                    existdata.CreateDate = entity.CreateDate;
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

        // ----------------------------------- DELETE
        public override async Task<bool> Delete(int id)
        {
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.EmployeeTaxInfoId == id);
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


        // INSERT
        public async Task<bool> InsertEmployeeTaxInformation(EmployeeTaxInfo data)
        {
            try
            {
                
                if(data.EmployeeTaxInfoId == 0)
                {
                    var insertData = await hrisDbContext.Database.ExecuteSqlAsync($"EXEC sp_Insert_tblEmployeeTaxInfo @empId={data.EmployeeId}, @taxAmount={data.TaxAmount}, @effectiveDate={data.EffectiveDate}, @status={data.Status}, @createBy={data.CreateBy}");
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
        public async Task<bool> UpdateEmployeeTaxInformation(EmployeeTaxInfo data)
        {
            try
            {
                var taxInfoToUpdate = await hrisDbContext.tblEmployeeTaxInfo.FirstOrDefaultAsync(x=>x.EmployeeTaxInfoId == data.EmployeeTaxInfoId);

                if (taxInfoToUpdate != null)
                {
                    var updateData = await hrisDbContext.Database.ExecuteSqlAsync($"EXEC sp_Insert_tblEmployeeTaxInfo @empTaxInfoId ={data.EmployeeTaxInfoId}, @empId={data.EmployeeId}, @taxAmount={data.TaxAmount}, @effectiveDate={data.EffectiveDate}, @status={data.Status}, @updateBy={data.UpdateBy}");
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
        public async Task<bool> DeleteEmployeeTaxInformation(int id)
        {
            try
            {
                var taxInfoToDelete = await hrisDbContext.tblEmployeeTaxInfo.FirstOrDefaultAsync(x => x.EmployeeTaxInfoId == id);

                if (taxInfoToDelete != null)
                {
                    var deleteTax = await hrisDbContext.Database.ExecuteSqlAsync($"EXEC spGenericDeleteData @tableName = 'tblEmployeeTaxInfo', @dataId = {id}");
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
