using HRIS.DatabaseContext;
using HRIS.Repositories;
using HRISdatabaseModels.DatabaseModels.SalaryStructure;
using HRISgenericInterfaces;
using HRISgenericInterfaces.SalaryStructureInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HRISgenericRepositories.SalaryStructureRepositories
{
    public class SalaryComponenetRepo: GenericRepo<SalaryComponent>, ISalaryComponent,IAllInterfaces<SalaryComponent>
    {

        public SalaryComponenetRepo(HRISdbContext dbContext) : base(dbContext)
        {

        }
        // -- Get All
        public override Task<List<SalaryComponent>> GetAll()
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
        public override async Task<SalaryComponent> GetById(int id)
        {
            try
            {
                var salaryComponent = await dbSet.FirstOrDefaultAsync(item => item.SalaryComponentId == id);
                return salaryComponent;
            }
            catch (Exception)
            {
                throw;
            }
        }



        // -------------------------- INSERT
        public override async Task Insert(SalaryComponent entity)
        {
            await dbSet.AddAsync(entity);
        }

        // ------------------------------ INSERT RANGE

        public override async Task InsertRange(IEnumerable<SalaryComponent> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }



        // ---------------------------- UPDATE
        public override async Task<bool> Update(SalaryComponent entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.SalaryComponentId == entity.SalaryComponentId);

                if (existdata != null)
                {
                    existdata.SalaryComponentCode = entity.SalaryComponentCode;
                    existdata.SalaryComponentCode = entity.SalaryComponentCode;
                    existdata.SalaryComponentCode = entity.SalaryComponentCode;
                    existdata.IsBonus= entity.IsBonus;
                    existdata.BonusEligibility= entity.BonusEligibility;
                    existdata.IsActive = entity.IsActive;
                    existdata.CreateBy = entity.CreateBy;
                    existdata.CreateDate = entity.CreateDate;
                    existdata.UpdateBy = entity.UpdateBy;
                    existdata.UpdateDate = entity.UpdateDate;
                    existdata.IsBonus = entity.IsBonus;
                    existdata.BonusEligibility = entity.BonusEligibility;
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
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.SalaryComponentId == id);
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
        public async Task<bool> CreateSalaryComponent(SalaryComponent data)
        {
            try
            {
                if(data.SalaryComponentId == 0)
                {
                    var insertData = await hrisDbContext.Database.ExecuteSqlAsync($"EXEC sp_Insert_tblSalaryComponent @salaryComponentCode = {data.SalaryComponentCode}, @salaryComponentName = {data.SalaryComponentName}, @salaryComoponentTypeId = {data.SalaryComponentType}, @isBonus = {data.IsBonus}, @bonusEligibility = {data.BonusEligibility}, @isActive = {data.BonusEligibility}, @createBy = {data.CreateBy}");

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
        public async Task<bool> UpdateSalaryComponent(SalaryComponent data)
        {
            try
            {
                var updateData = await hrisDbContext.tblSalaryComponent.FirstOrDefaultAsync(x=>x.SalaryComponentId == data.SalaryComponentId);

                if(updateData != null)
                {
                    await hrisDbContext.Database.ExecuteSqlAsync($"EXEC sp_Insert_tblSalaryComponent  @salaryComponentId ={data.SalaryComponentId}, @salaryComponentCode = {data.SalaryComponentCode}, @salaryComponentName = {data.SalaryComponentName}, @salaryComoponentTypeId = {data.SalaryComponentType}, @isBonus = {data.IsBonus}, @bonusEligibility = {data.BonusEligibility}, @isActive = {data.BonusEligibility}, @updateBy = {data.UpdateBy}");

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

        public async Task<bool> DeleteSalaryComponent(int id)
        {
            try
            {
                var dataToDelete = await hrisDbContext.tblSalaryComponent.FirstOrDefaultAsync(x => x.SalaryComponentId == id);

                if(dataToDelete!= null)
                {
                    await hrisDbContext.Database.ExecuteSqlAsync($"EXEC spGenericDeleteData @tableName = 'tblSalaryComponent', @dataId = {id}");

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
