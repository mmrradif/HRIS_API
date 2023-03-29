using HRIS.DatabaseContext;
using HRIS.DatabaseModels.CompanyInformation;
using HRIS.Interfaces.CompanyInterfaces;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISgenericInterfaces;
using HRISgenericRepositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HRIS.Repositories.CompanyRepositories
{
    public class DesignationRepo : GenericRepo<Designation>, IDesignation,IAllInterfaces<Designation>
    {
        public DesignationRepo(HRISdbContext dbContext) : base(dbContext)
        {
        }


        // -- Get All
        public override Task<List<Designation>> GetAll()
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
        public override async Task<Designation> GetById(int id)
        {
            try
            {
                var designation = await dbSet.FirstOrDefaultAsync(item => item.GradeId == id);
                return designation;
            }
            catch (Exception)
            {
                throw;
            }
        }



        // -- GET BY NAME
        public override async Task<Designation> GetByName(string name)
        {
            try
            {
                var designation = await dbSet.FirstOrDefaultAsync(item => item.DesignationName == name || item.DesignationName.StartsWith(name) || item.DesignationName.EndsWith(name) || item.DesignationName.ToLower().StartsWith(name.ToLower()) || item.DesignationName.ToLower().EndsWith(name.ToLower()) || item.DesignationName.ToLower().Equals(name.ToLower()));
                return designation;
            }
            catch (Exception)
            {
                throw;
            }
        }





        // -------------------------- INSERT
        public override async Task Insert(Designation entity)
        {
            await dbSet.AddAsync(entity);
        }




        // ------------------------------ INSERT RANGE

        public override async Task InsertRange(IEnumerable<Designation> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }



        // ---------------------------- UPDATE
        public override async Task<bool> Update(Designation entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.DesignationId == entity.DesignationId);

                if (existdata != null)
                {
                    existdata.DesignationName = entity.DesignationName;
                    existdata.GradeId = entity.GradeId;
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
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.DesignationId == id);
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
