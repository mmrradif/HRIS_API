using HRIS.DatabaseContext;
using HRIS_Models.DatabaseModels.SalaryFinalize;
using HRISdatabaseModels.DatabaseModels.SalaryAndBonusInformation;
using HRISgenericInterfaces;
using HRISgenericInterfaces.SalaryFinalizeInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericRepositories.SalaryFinalizeRepositories
{
    public class SalaryDetailsRepo : GenericRepo<SalaryDetails>, ISalaryDetails,IAllInterfaces<SalaryDetails>
    {
        public SalaryDetailsRepo(HRISdbContext dbContext) : base(dbContext)
        {
        }


        // -- Get All
        public override Task<List<SalaryDetails>> GetAll()
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
        public override async Task<SalaryDetails> GetById(int id)
        {
            try
            {
                var salary = await dbSet.FirstOrDefaultAsync(item => item.SalaryDetailsId == id);
                return salary;
            }
            catch (Exception)
            {
                throw;
            }
        }



        // -------------------------- INSERT
        public override async Task Insert(SalaryDetails entity)
        {
            await dbSet.AddAsync(entity);
        }

        // ------------------------------ INSERT RANGE

        public override async Task InsertRange(IEnumerable<SalaryDetails> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }



        // ---------------------------- UPDATE
        public override async Task<bool> Update(SalaryDetails entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.SalaryDetailsId == entity.SalaryDetailsId);

                if (existdata != null)
                {
                    existdata.SalaryDetailsId=entity.SalaryDetailsId;
                    existdata.SalaryId=entity.SalaryId;
                    existdata.SalaryComponentId=entity.SalaryComponentId;
                    existdata.SalaryComponentValue=entity.SalaryComponentValue;
                    existdata.SalaryComponentType=entity.SalaryComponentType;
                    existdata.Status=entity.Status;
                    existdata.CreateBy= entity.CreateBy;
                    existdata.CreateDate= entity.CreateDate;
                    existdata.UpdateBy= entity.UpdateBy;
                    existdata.UpdateDate= entity.UpdateDate;
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
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.SalaryDetailsId == id);
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
