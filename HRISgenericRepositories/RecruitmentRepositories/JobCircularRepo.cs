using HRIS.DatabaseContext;
using HRISdatabaseModels.DatabaseModels.Recruitement;
using HRISgenericInterfaces.RecruitmentInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericRepositories.RecruitmentRepositories
{
    public class JobCircularRepo : GenericRepo<JobCircular>, IJobCircular
    {
        public JobCircularRepo(HRISdbContext dbContext) : base(dbContext)
        {
        }

        //get all

        public override Task<List<JobCircular>> GetAll()
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

        public override async Task<JobCircular> GetById(int id)
        {
            try
            {
                var jobCircular = await dbSet.FirstOrDefaultAsync(item => item.JobCircularId == id);
                return jobCircular;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //get by name

        //public override async Task<JobCircular> GetByName(string name)
        //{
        //    try
        //    {
        //        var jobCircular = await dbSet.FirstOrDefaultAsync(item => item.FullName == name || item.FullName.StartsWith(name) || item.FullName.EndsWith(name) || item.FullName.ToLower().StartsWith(name.ToLower()) || item.FullName.ToLower().EndsWith(name.ToLower()) || item.FullName.ToLower().Equals(name.ToLower()));
        //        return jobCircular;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        //insert
        public override async Task Insert(JobCircular entity)
        {
            await dbSet.AddAsync(entity);
        }


        //update
        public override async Task<bool> Update(JobCircular entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.JobCircularId == entity.JobCircularId);

                if (existdata != null)
                {
                    existdata.JobCircularId= entity.JobCircularId;
                    existdata.PublishDate= entity.PublishDate;
                    existdata.LiveTime= entity.LiveTime;
                    existdata.CompanyId= entity.CompanyId;
                    existdata.GradeId= entity.GradeId;
                    existdata.DesignationId= entity.DesignationId;
                    existdata.DivisionId= entity.DivisionId;
                    existdata.DesignationId=entity.DesignationId;
                    existdata.LocationId= entity.LocationId;
                    existdata.IsActive= entity.IsActive;
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


        //delete
        public override async Task<bool> Delete(int id)
        {
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.JobCircularId == id);
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
