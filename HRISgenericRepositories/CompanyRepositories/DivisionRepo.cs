using HRIS.DatabaseContext;
using HRIS.DatabaseModels.CompanyInformation;
using HRIS.Interfaces.CompanyInterfaces;
using HRISgenericInterfaces;
using HRISgenericRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HRIS.Repositories.CompanyRepositories
{
    public class DivisionRepo : GenericRepo<Division>, IDivision,IAllInterfaces<Division>
    {
        public DivisionRepo(HRISdbContext dbContext) : base(dbContext)
        {
        }

        // -- Get All
        public override Task<List<Division>> GetAll()
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
        public override async Task<Division> GetById(int id)
        {
            try
            {
                var division = await dbSet.FirstOrDefaultAsync(item => item.DivisionId == id);
                return division;
            }
            catch (Exception)
            {
                throw;
            }
        }



        // -- GET BY NAME
        public override async Task<Division> GetByName(string name)
        {
            try
            {
                var division = await dbSet.FirstOrDefaultAsync(item => item.DivisionName == name || item.DivisionName.StartsWith(name) || item.DivisionName.EndsWith(name) || item.DivisionName.ToLower().StartsWith(name.ToLower()) || item.DivisionName.ToLower().EndsWith(name.ToLower()) || item.DivisionName.ToLower().Equals(name.ToLower()));
                return division;
            }
            catch (Exception)
            {
                throw;
            }
        }





        // -------------------------- INSERT
        public override async Task Insert(Division entity)
        {
            await dbSet.AddAsync(entity);
        }




        // ------------------------------ INSERT RANGE

        public override async Task InsertRange(IEnumerable<Division> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }



        // ---------------------------- UPDATE
        public override async Task<bool> Update(Division entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.DivisionId == entity.DivisionId);

                if (existdata != null)
                {
                    existdata.DivisionName = entity.DivisionName;
                    existdata.DivisionCode = entity.DivisionCode;
                    existdata.CompanyId = entity.CompanyId;
                    existdata.IsActive = entity.IsActive;
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
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.DivisionId == id);
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
