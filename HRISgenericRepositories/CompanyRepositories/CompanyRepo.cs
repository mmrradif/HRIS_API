using HRIS.DatabaseContext;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISgenericInterfaces;
using HRISgenericInterfaces.CompanyInterfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HRISgenericRepositories.CompanyRepositories
{
    public class CompanyRepo : GenericRepo<Company>, ICompany,IAllInterfaces<Company>
    {

        public CompanyRepo(HRISdbContext dbContext) : base(dbContext)
        {

        }


        // -- Get All
        public override Task<List<Company>> GetAll()
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
        public override async Task<Company> GetById(int id)
        {
            try
            {
                var company = await dbSet.FirstOrDefaultAsync(item => item.CompanyId == id);              
                return company;
            }
            catch (Exception)
            {
                throw;
            }
        }



        // -- GET BY NAME
        public override async Task<Company> GetByName(string name)
        {
            try
            {
                var company = await dbSet.FirstOrDefaultAsync(item => item.CompanyName == name || item.CompanyName.StartsWith(name) || item.CompanyName.EndsWith(name) || item.CompanyName.ToLower().StartsWith(name.ToLower()) || item.CompanyName.ToLower().EndsWith(name.ToLower()) || item.CompanyName.ToLower().Equals(name.ToLower()));
                return company;
            }
            catch (Exception)
            {
                throw;
            }
        }




        // GET COMPANY WITH GRADE
        // WITHOUT VIRTUAL AND OVVERRIDE CONDITION
        // IN ICOMAPNY INTERFACES
        public IEnumerable<Company> GetCompanyWithGrade()
        {
            try
            {
                var CompanyWithGrade = hrisDbContext.tblCompany.Include(c => c.Grades).ToList();
                return CompanyWithGrade;
            }
            catch (Exception)
            {
                throw;
            }
        }




        // -------------------------- INSERT
        public override async Task Insert(Company entity)
        {
            await dbSet.AddAsync(entity);
        }

        // ------------------------------ INSERT RANGE

        public override async Task InsertRange(IEnumerable<Company> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }



        // ---------------------------- UPDATE
        public override async Task<bool> Update(Company entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.CompanyId == entity.CompanyId);

                if (existdata != null)
                {
                    existdata.CompanyName = entity.CompanyName;
                    existdata.CompanyAlias = entity.CompanyAlias;
                    existdata.Address = entity.Address;
                    existdata.Phone = entity.Phone;
                    existdata.Fax = entity.Fax;
                    existdata.Email = entity.Email;
                    existdata.Website = entity.Website;
                    existdata.CompanyRegisterNo = entity.CompanyRegisterNo;
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
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.CompanyId == id);
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




        // ------------------------------------------------------ STORE PROCEDURES
        // --------------------------------------------->>> START


        // --------------------------------- Call Generic Store Procedure For Create
        public override async Task<bool> CreateWithSP(Company company)
        {
            try
            {
                var columnNames = "CompanyName, CompanyAlias, Address, Phone, Fax, Email, Website, CompanyRegisterNo, IsActive, CreateBy, CreateDate, UpdateBy, UpdateDate";

                var values = $"N'{company.CompanyName}', N'{company.CompanyAlias}', N'{company.Address}', N'{company.Phone}', N'{company.Fax}', N'{company.Email}', N'{company.Website}', N'{company.CompanyRegisterNo}', {company.IsActive}, {company.CreateBy}, '{company.CreateDate}', {company.UpdateBy}, '{company.UpdateDate}'";

                var identityColumnName = "CompanyId";
                int identityValue = 0;

                hrisDbContext.Database.ExecuteSqlRaw("EXECUTE spGenericInsert @tableName, @columnNames, @values, @identityColumnName, @identityValue OUTPUT;",

                    new SqlParameter("@tableName", "tblCompany"),
                    new SqlParameter("@columnNames", columnNames),
                    new SqlParameter("@values", values),
                    new SqlParameter("@identityColumnName", identityColumnName),
                    new SqlParameter("@identityValue", SqlDbType.Int) { Direction = ParameterDirection.Output }
                );

                company.CompanyId = identityValue;

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        // --------------------------------- Call Generic Store Procedure For Update
        public override async Task<bool> UpdateWithSP(Company company)
        {
            try
            {
                var existdata = await hrisDbContext.tblCompany.FirstOrDefaultAsync(item => item.CompanyId == company.CompanyId);

                if (existdata != null)
                {
                    var setValues = $"CompanyName = N'{company.CompanyName}', CompanyAlias = N'{company.CompanyAlias}', Address = N'{company.Address}', Phone = N'{company.Phone}', Fax = N'{company.Fax}', Email = N'{company.Email}', Website = N'{company.Website}', CompanyRegisterNo = N'{company.CompanyRegisterNo}', IsActive = {company.IsActive}, UpdateBy = {company.UpdateBy}, UpdateDate = '{company.UpdateDate}'";
                    var whereClause = $"CompanyId = {company.CompanyId}";

                    hrisDbContext.Database.ExecuteSqlRaw("EXECUTE spGenericUpdate @tableName, @setValues, @whereClause;",
                        new SqlParameter("@tableName", "tblCompany"),
                        new SqlParameter("@setValues", setValues),
                        new SqlParameter("@whereClause", whereClause)
                    );

                    return true;
                }

                return false;
                
            }
            catch (Exception)
            {
                throw;
            }
        }


        // --------------------------------- Call Generic Store Procedure For Delete
        public override async Task<bool> DeleteWithSP(int companyId)
        {
            try
            {
                var existdata = await hrisDbContext.tblCompany.FirstOrDefaultAsync(item => item.CompanyId == companyId);

                if (existdata != null)
                {
                    var tableName = "tblCompany";
                    var primaryKeyColumnName = "CompanyId";
                    var primaryKeyValue = companyId;

                    hrisDbContext.Database.ExecuteSqlRaw("EXECUTE spGenericDelete @tableName, @primaryKeyColumnName, @primaryKeyValue;",
                        new SqlParameter("@tableName", tableName),
                        new SqlParameter("@primaryKeyColumnName", primaryKeyColumnName),
                        new SqlParameter("@primaryKeyValue", primaryKeyValue)
                    );

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
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
