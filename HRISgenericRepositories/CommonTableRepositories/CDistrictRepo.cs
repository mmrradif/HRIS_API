using HRIS.DatabaseContext;
using HRIS.DatabaseModels.CompanyInformation;
using HRIS.Repositories;
using HRISdatabaseModels.DatabaseModels.CommonTables;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISgenericInterfaces.CompanyInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericRepositories.CompanyRepositories
{
    public class CDistrictRepo : GenericRepo<CDistrict>, ICDistrict
    {
        public CDistrictRepo(HRISdbContext dbContext) : base(dbContext)
        {
        }

        // -- Get All
        public override Task<List<CDistrict>> GetAll()
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
        public override async Task<CDistrict> GetById(int id)
        {
            try
            {
                var district = await dbSet.FirstOrDefaultAsync(item => item.DistrictId == id);
                return district;
            }
            catch (Exception)
            {
                throw;
            }
        }





        // -------------------------- INSERT
        public override async Task Insert(CDistrict entity)
        {
            await dbSet.AddAsync(entity);
        }




        // ------------------------------ INSERT RANGE

        public override async Task InsertRange(IEnumerable<CDistrict> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }



        // ---------------------------- UPDATE
        public override async Task<bool> Update(CDistrict entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.DistrictId == entity.DistrictId);

                if (existdata != null)
                {
                    existdata.DistrictName = entity.DistrictName;
                    existdata.CDivisionId = entity.CDivisionId;

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
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.DistrictId == id);
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
