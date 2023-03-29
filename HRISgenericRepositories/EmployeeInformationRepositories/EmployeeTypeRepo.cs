using HRIS.DatabaseContext;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISdatabaseModels.DatabaseModels.EmployeeInformation;
using HRISgenericInterfaces.EmployeeInformationInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericRepositories.EmployeeInformationRepositories
{
    public class EmployeeTypeRepo : GenericRepo<EmployeeType>, IEmployeeType
    {
        public EmployeeTypeRepo(HRISdbContext dbContext) : base(dbContext)
        {
        }

        //get all

        public override Task<List<EmployeeType>> GetAll()
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

        //get by id

        public override async Task<EmployeeType> GetById(int id)
        {
            try
            {
                var emptype = await dbSet.FirstOrDefaultAsync(item => item.EmployeeTypeId == id);
                return emptype;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //get by name

        public override async Task<EmployeeType> GetByName(string name)
        {
            try
            {
                var emptype = await dbSet.FirstOrDefaultAsync(item => item.EmployeeTypeName == name || item.EmployeeTypeName.StartsWith(name) || item.EmployeeTypeName.EndsWith(name) || item.EmployeeTypeName.ToLower().StartsWith(name.ToLower()) || item.EmployeeTypeName.ToLower().EndsWith(name.ToLower()) || item.EmployeeTypeName.ToLower().Equals(name.ToLower()));
                return emptype;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //insert
        public override async Task Insert(EmployeeType entity)
        {
            await dbSet.AddAsync(entity);
        }


        //update
        public override async Task<bool> Update(EmployeeType entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.EmployeeTypeId == entity.EmployeeTypeId);

                if (existdata != null)
                {
                    existdata.EmployeeTypeId= entity.EmployeeTypeId;
                    existdata.EmployeeTypeName = entity.EmployeeTypeName;
                    existdata.EmployeeTypeCode= entity.EmployeeTypeCode;
                    existdata.NoticePeriod = entity.NoticePeriod;
                    existdata.IsOverTimeAllowed= entity.IsOverTimeAllowed;
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


        //delete
        public override async Task<bool> Delete(int id)
        {
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.EmployeeTypeId == id);
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
