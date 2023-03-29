using HRIS.DatabaseContext;
using HRIS.DatabaseModels.CompanyInformation;
using HRIS.Interfaces.CompanyInterfaces;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISgenericInterfaces;
using HRISgenericRepositories;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Repositories.CompanyRepositories
{
    public class LocationRepo : GenericRepo<Location>, ILocation, IAllInterfaces<Location>
    {
        public LocationRepo(HRISdbContext dbContext) : base(dbContext)
        {
        }


        // -- Get All
        public override Task<List<Location>> GetAll()
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
        public override async Task<Location> GetById(int id)
        {
            try
            {
                var grade = await dbSet.FirstOrDefaultAsync(item => item.LocationId == id);
                return grade;
            }
            catch (Exception)
            {
                throw;
            }
        }



        // -- GET BY NAME
        public override async Task<Location> GetByName(string name)
        {
            try
            {
                var location = await dbSet.FirstOrDefaultAsync(item => item.LocationName == name || item.LocationName.StartsWith(name) || item.LocationName.EndsWith(name) || item.LocationName.ToLower().StartsWith(name.ToLower()) || item.LocationName.ToLower().EndsWith(name.ToLower()) || item.LocationName.ToLower().Equals(name.ToLower()));
                return location;
            }
            catch (Exception)
            {
                throw;
            }
        }



        // -------------------------- INSERT
        public override async Task Insert(Location entity)
        {
            await dbSet.AddAsync(entity);
        }




        // ------------------------------ INSERT RANGE

        public override async Task InsertRange(IEnumerable<Location> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }



        // ---------------------------- UPDATE
        public override async Task<bool> Update(Location entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.LocationId == entity.LocationId);

                if (existdata != null)
                {
                    existdata.LocationName = entity.LocationName;
                    existdata.LocationAddress = entity.LocationAddress;
                    existdata.DepartmentId = entity.DepartmentId;
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
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.LocationId == id);
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
