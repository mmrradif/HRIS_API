using HRIS.DatabaseContext;
using HRISdatabaseModels.DatabaseModels.EmployeeInformation;
using HRISdatabaseModels.DatabaseModels.Recruitement;
using HRISgenericInterfaces.EmployeeInformationInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericRepositories.EmployeeInformationRepositories
{
    public class EmployeePostingRepo : GenericRepo<EmployeePosting>, IEmployeePosting
    {
        public EmployeePostingRepo(HRISdbContext dbContext) : base(dbContext)
        {
        }



        //get all

        public override Task<List<EmployeePosting>> GetAll()
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

        public override async Task<EmployeePosting> GetById(int id)
        {
            try
            {
                var posting = await dbSet.FirstOrDefaultAsync(item => item.EmployeePostingId == id);
                return posting;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //get by name

        //public override async Task<Candidate> GetByName(string name)
        //{
        //    try
        //    {
        //        var candidate = await dbSet.FirstOrDefaultAsync(item => item.FullName == name || item.FullName.StartsWith(name) || item.FullName.EndsWith(name) || item.FullName.ToLower().StartsWith(name.ToLower()) || item.FullName.ToLower().EndsWith(name.ToLower()) || item.FullName.ToLower().Equals(name.ToLower()));
        //        return candidate;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}


        //insert
        public override async Task Insert(EmployeePosting entity)
        {
            await dbSet.AddAsync(entity);
        }


        //update
        public override async Task<bool> Update(EmployeePosting entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.EmployeePostingId == entity.EmployeePostingId);

                if (existdata != null)
                {
                    existdata.EmployeePostingId= entity.EmployeePostingId;
                    existdata.EmployeeId= entity.EmployeeId;
                    existdata.CompanyId= entity.CompanyId;
                    existdata.GradeId= entity.GradeId;
                    existdata.DesignationId= entity.DesignationId;
                    existdata.DivisionId= entity.DivisionId;
                    existdata.DepartmentId= entity.DepartmentId;
                    existdata.LocationId = entity.LocationId;
                    existdata.RosterId= entity.RosterId;
                    existdata.BankAccountNo= entity.BankAccountNo;
                    existdata.TelephoneExtension= entity.TelephoneExtension;
                    existdata.OfficialEmail= entity.OfficialEmail;
                    existdata.JobEndDate= entity.JobEndDate;
                    existdata.TinNumber= entity.TinNumber;
                    existdata.Status= entity.Status;
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
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.EmployeePostingId == id);
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
