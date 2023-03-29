using HRIS.DatabaseContext;
using HRIS.DatabaseModels.CompanyInformation;
using HRIS.Repositories;
using HRISdatabaseModels.DatabaseModels.CommonTables;
using HRISgenericInterfaces.CompanyInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericRepositories.CompanyRepositories
{
    public class CUpazilaRepo : GenericRepo<CUpazila>, ICUpazila
    {
        public CUpazilaRepo(HRISdbContext dbContext) : base(dbContext)
        {
        }

        // -- Get All
        public override Task<List<CUpazila>> GetAll()
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
        public override async Task<CUpazila> GetById(int id)
        {
            try
            {
                var district = await dbSet.FirstOrDefaultAsync(item => item.CUpazilaId == id);
                return district;
            }
            catch (Exception)
            {
                throw;
            }
        }





        // -------------------------- INSERT
        public override async Task Insert(CUpazila entity)
        {
            await dbSet.AddAsync(entity);
        }




        // ------------------------------ INSERT RANGE

        public override async Task InsertRange(IEnumerable<CUpazila> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }



        // ---------------------------- UPDATE
        public override async Task<bool> Update(CUpazila entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.CUpazilaId == entity.CUpazilaId);

                if (existdata != null)
                {
                    existdata.UpazilaName = entity.UpazilaName;
                    existdata.CDistrictId = entity.CDistrictId;

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
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.CUpazilaId == id);
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
    }
}
