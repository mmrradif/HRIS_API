using HRIS.DatabaseContext;
using HRIS.DatabaseModels.CompanyInformation;
using HRIS.Interfaces.CompanyInterfaces;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISgenericInterfaces;
using HRISgenericRepositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HRIS.Repositories.CompanyRepositories
{
    public class DepartmentRepo : GenericRepo<Department>, IDepartment,IAllInterfaces<Department>
    {
        public DepartmentRepo(HRISdbContext dbContext) : base(dbContext)
        {
        }

        // -- Get All
        public override Task<List<Department>> GetAll()
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
        public override async Task<Department> GetById(int id)
        {
            try
            {
                var department = await dbSet.FirstOrDefaultAsync(item => item.DepartmentId == id);
                return department;
            }
            catch (Exception)
            {
                throw;
            }
        }



        // -- GET BY NAME
        public override async Task<Department> GetByName(string name)
        {
            try
            {
                var department = await dbSet.FirstOrDefaultAsync(item => item.DepartmentName == name || item.DepartmentName.StartsWith(name) || item.DepartmentName.EndsWith(name) || item.DepartmentName.ToLower().StartsWith(name.ToLower()) || item.DepartmentName.ToLower().EndsWith(name.ToLower()) || item.DepartmentName.ToLower().Equals(name.ToLower()));
                return department;
            }
            catch (Exception)
            {
                throw;
            }
        }





        // -------------------------- INSERT
        public override async Task Insert(Department entity)
        {
            await dbSet.AddAsync(entity);
        }




        // ------------------------------ INSERT RANGE

        public override async Task InsertRange(IEnumerable<Department> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }



        // ---------------------------- UPDATE
        public override async Task<bool> Update(Department entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.DepartmentId == entity.DepartmentId);

                if (existdata != null)
                {
                    existdata.DepartmentName = entity.DepartmentName;
                    existdata.DepartmentCode = entity.DepartmentCode;
                    existdata.DivisionId = entity.DivisionId;
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
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.DepartmentId == id);
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



        public override async Task<bool> CreateWithSP(Department department)
        {
            try
            {
                var columnNames = "DepartmentName, DepartmentCode, DivisionId, IsActive, CreateBy, CreateDate, UpdateBy, UpdateDate";

                var values = $"N'{department.DepartmentName}', N'{department.DepartmentCode}', {department.DivisionId}, {department.IsActive}, {department.CreateBy}, '{department.CreateDate}', {department.UpdateBy}, '{department.UpdateDate}'";

                var identityColumnName = "DepartmentId";
                int identityValue = 0;

                hrisDbContext.Database.ExecuteSqlRaw("EXECUTE spGenericInsert @tableName, @columnNames, @values, @identityColumnName, @identityValue OUTPUT;",

                    new SqlParameter("@tableName", "tblDepartment"),
                    new SqlParameter("@columnNames", columnNames),
                    new SqlParameter("@values", values),
                    new SqlParameter("@identityColumnName", identityColumnName),
                    new SqlParameter("@identityValue", SqlDbType.Int) { Direction = ParameterDirection.Output }
                );

                department.DepartmentId = identityValue;

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public override async Task<bool> UpdateWithSP(Department department)
        {
            try
            {
                var existingData = await hrisDbContext.tblDepartment.FirstOrDefaultAsync(item => item.DepartmentId == department.DepartmentId);

                if (existingData != null)
                {
                    var setValues = $"DepartmentName = N'{department.DepartmentName}', DepartmentCode = N'{department.DepartmentCode}', DivisionId = {department.DivisionId}, IsActive = {department.IsActive}, UpdateBy = {department.UpdateBy}, UpdateDate = '{department.UpdateDate}'";
                    var whereClause = $"DepartmentId = {department.DepartmentId}";

                    hrisDbContext.Database.ExecuteSqlRaw("EXECUTE spGenericUpdate @tableName, @setValues, @whereClause;",
                        new SqlParameter("@tableName", "tblDepartment"),
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
        public override async Task<bool> DeleteWithSP(int departmentId)
        {
            try
            {
                var existdata = await hrisDbContext.tblDepartment.FirstOrDefaultAsync(item => item.DepartmentId == departmentId);

                if (existdata != null)
                {
                    var tableName = "tblDepartment";
                    var primaryKeyColumnName = "DepartmentId";
                    var primaryKeyValue = departmentId;

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
