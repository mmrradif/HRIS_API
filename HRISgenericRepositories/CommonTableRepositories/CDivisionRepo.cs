using HRIS.DatabaseContext;
using HRIS.DatabaseModels.CompanyInformation;
using HRIS.Interfaces.CompanyInterfaces;
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
    public class CDivisionRepo : GenericRepo<CDivision>, ICDivision
    {
        public CDivisionRepo(HRISdbContext dbContext) : base(dbContext)
        {
        }



        // -- Get All
        public override Task<List<CDivision>> GetAll()
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
        public override async Task<CDivision> GetById(int id)
        {
            try
            {
                var division = await dbSet.FirstOrDefaultAsync(item => item.CDivisionId == id);
                return division;
            }
            catch (Exception)
            {
                throw;
            }
        }





        // -------------------------- INSERT
        public override async Task Insert(CDivision entity)
        {
            await dbSet.AddAsync(entity);
        }




        // ------------------------------ INSERT RANGE

        public override async Task InsertRange(IEnumerable<CDivision> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }



        // ---------------------------- UPDATE
        public override async Task<bool> Update(CDivision entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.CDivisionId == entity.CDivisionId);

                if (existdata != null)
                {
                    existdata.DivisionName = entity.DivisionName;

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
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.CDivisionId == id);
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
