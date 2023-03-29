using HRIS.DatabaseContext;
using HRIS.Interfaces;
using HRIS.Repositories;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISgenericInterfaces;
using HRISgenericInterfaces.CompanyInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericRepositories.CompanyRepositories
{
    public class RosterRepo : GenericRepo<Roster>, IRoster,IAllInterfaces<Roster>
    {
        private readonly HRISdbContext context;
        public RosterRepo(HRISdbContext dbContext) : base(dbContext)
        {
            this.context = dbContext;

        }

        // -- Get All
        public override Task<List<Roster>> GetAll()
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
        public override async Task<Roster> GetById(int id)
        {
            try
            {
                var roster = await dbSet.FirstOrDefaultAsync(item => item.RosterId == id);
                return roster;
            }
            catch (Exception)
            {
                throw;
            }
        }
     





        // -------------------------- INSERT
        public override async Task Insert(Roster entity)
        {
            await dbSet.AddAsync(entity);
        }




        // ------------------------------ INSERT RANGE

        public override async Task InsertRange(IEnumerable<Roster> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }



        // ---------------------------- UPDATE
        public override async Task<bool> Update(Roster entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.RosterId == entity.RosterId);

                if (existdata != null)
                {
                    existdata.RosterMonth = entity.RosterMonth;
                    existdata.LocationId = entity.LocationId;
                    existdata.RosterInTime = entity.RosterInTime;
                    existdata.RosterOutTime = entity.RosterOutTime;
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
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.RosterId == id);
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
