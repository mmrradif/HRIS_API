using HRIS.DatabaseContext;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISgenericInterfaces;
using HRISgenericInterfaces.CompanyInterfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericRepositories.CompanyRepositories
{
    public class GradeRepo : GenericRepo<Grade>, IGrade,IAllInterfaces<Grade>
    {
        public GradeRepo(HRISdbContext dbContext) : base(dbContext)
        {

        }
            
        // -- Get All
        public override Task<List<Grade>> GetAll()
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
        public override async Task<Grade> GetById(int id)
        {
            try
            {
                var grade = await dbSet.FirstOrDefaultAsync(item => item.GradeId == id);
                return grade;
            }
            catch (Exception)
            {
                throw;
            }
        }



        // -- GET BY NAME
        public override async Task<Grade> GetByName(string name)
        {
            try
            {
                var grade = await dbSet.FirstOrDefaultAsync(item => item.GradeName == name || item.GradeName.StartsWith(name) || item.GradeName.EndsWith(name) || item.GradeName.ToLower().StartsWith(name.ToLower()) || item.GradeName.ToLower().EndsWith(name.ToLower()) || item.GradeName.ToLower().Equals(name.ToLower()));
                return grade;
            }
            catch (Exception)
            {
                throw;
            }
        }


      


        // -------------------------- INSERT
        public override async Task Insert(Grade entity)
        {
            await dbSet.AddAsync(entity);
        }




        // ------------------------------ INSERT RANGE

        public override async Task InsertRange(IEnumerable<Grade> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }



        // ---------------------------- UPDATE
        public override async Task<bool> Update(Grade entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.CompanyId == entity.CompanyId);

                if (existdata != null)
                {
                    existdata.GradeName = entity.GradeName;
                    existdata.CompanyId = entity.CompanyId;
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
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.GradeId == id);
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



        // ----------------- Store Procedures
        // --------------------------------- Call Generic Store Procedure For Create
        public async Task<bool> CreateWithSP(Grade grade)
        {
            try
            {
                var columnNames = "GradeName, CompanyId, IsActive, CreateBy, CreateDate, UpdateBy, UpdateDate";
                var values = $"N'{grade.GradeName}', {grade.CompanyId}, {grade.IsActive}, {grade.CreateBy}, '{grade.CreateDate}', {grade.UpdateBy}, '{grade.UpdateDate}'";
                var identityColumnName = "GradeId";
                int identityValue = 0;

                hrisDbContext.Database.ExecuteSqlRaw("EXECUTE spGenericInsert @tableName, @columnNames, @values, @identityColumnName, @identityValue OUTPUT;",
                    new SqlParameter("@tableName", "tblGrade"),
                    new SqlParameter("@columnNames", columnNames),
                    new SqlParameter("@values", values),
                    new SqlParameter("@identityColumnName", identityColumnName),
                    new SqlParameter("@identityValue", SqlDbType.Int) { Direction = ParameterDirection.Output }
                );

                grade.GradeId = identityValue;

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }




        // --------------------------------- Call Generic Store Procedure For Update
        public async Task<bool> UpdateWithSP(Grade grade)
        {
            try
            {
                var existdata = await hrisDbContext.tblGrade.FirstOrDefaultAsync(item => item.GradeId == grade.GradeId);

                if (existdata != null)
                {
                    var setValues = $"GradeName = N'{grade.GradeName}', CompanyId = {grade.CompanyId}, IsActive = {grade.IsActive}, UpdateBy = {grade.UpdateBy}, UpdateDate = '{grade.UpdateDate}'";
                    var whereClause = $"GradeId = {grade.GradeId}";

                    hrisDbContext.Database.ExecuteSqlRaw("EXECUTE spGenericUpdate @tableName, @setValues, @whereClause;",
                        new SqlParameter("@tableName", "tblGrade"),
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
        public async Task<bool> DeleteWithSP(int gradeId)
        {
            try
            {
                var existdata = await hrisDbContext.tblGrade.FirstOrDefaultAsync(item => item.GradeId == gradeId);

                if (existdata != null)
                {
                    var tableName = "tblGrade";
                    var primaryKeyColumnName = "GradeId";
                    var primaryKeyValue = gradeId;

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
