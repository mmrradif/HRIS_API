using HRIS.DatabaseContext;
using HRIS.Repositories;
using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using HRISdatabaseModels.DatabaseModels.SalaryStructure;
using HRISgenericInterfaces;
using HRISgenericInterfaces.SalaryStructureInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HRISgenericRepositories.SalaryStructureRepositories
{
    public class PayGradeScaleRepo: GenericRepo<PayGradeScale>, IPayGradeScale, IAllInterfaces<PayGradeScale>
    {
        public PayGradeScaleRepo(HRISdbContext dbContext) : base(dbContext)
        {

        }


        // -- Get All
        public override Task<List<PayGradeScale>> GetAll()
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
        public override async Task<PayGradeScale> GetById(int id)
        {
            try
            {
                var payGradeScale = await dbSet.FirstOrDefaultAsync(item => item.PayGradeScaleId == id);
                return payGradeScale;
            }
            catch (Exception)
            {
                throw;
            }
        }



        // -------------------------- INSERT
        public override async Task Insert(PayGradeScale entity)
        {
            await dbSet.AddAsync(entity);
        }

        // ------------------------------ INSERT RANGE

        public override async Task InsertRange(IEnumerable<PayGradeScale> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }



        // ---------------------------- UPDATE
        public override async Task<bool> Update(PayGradeScale entity)
        {
            try
            {
                var existdata = await dbSet.FirstOrDefaultAsync(item => item.PayGradeScaleId == entity.PayGradeScaleId);

                if (existdata != null)
                {
                    existdata.GradeId = entity.GradeId;
                    existdata.SalaryComponentId = entity.SalaryComponentId;
                    existdata.SalaryComponentAmount = entity.SalaryComponentAmount;
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
            var existdata = await dbSet.FirstOrDefaultAsync(item => item.PayGradeScaleId == id);
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

        // INSERT

        public async Task<bool> CreatePayGradeScale(PayGradeScale data)
        {
            try
            {
                if(data.PayGradeScaleId == 0)
                {
                    var createScale = await hrisDbContext.Database.ExecuteSqlAsync($"sp_Insert_tblPayGradeScale @gradeId= {data.GradeId}, @payScaleGrade={data.PayScaleGrade}, @salaryComponentId = {data.SalaryComponentId}, @salaryComponentAmount = {data.SalaryComponentAmount}, @isActive = {data.IsActive}, @createBy = {data.CreateBy}");

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


        // UPDATE

        public async Task<bool> UpdatePayGradeScale(PayGradeScale data)
        {
            try
            {
                var updateScale = await hrisDbContext.tblPayGradeScale.FirstOrDefaultAsync(x=>x.PayGradeScaleId == data.PayGradeScaleId);

                if (updateScale != null)
                {
                    await hrisDbContext.Database.ExecuteSqlAsync($"sp_Insert_tblPayGradeScale @payGradeScaleId={data.PayGradeScaleId},@payScaleGrade={data.PayScaleGrade}, @gradeId= {data.GradeId}, @salaryComponentId = {data.SalaryComponentId}, @salaryComponentAmount = {data.SalaryComponentAmount}, @isActive = {data.IsActive}, @updateBy = {data.UpdateBy}");

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

        // DELETE

        public async Task<bool> DeletePayGradeScale(int id)
        {
            try
            {
                var dataToDelete = await hrisDbContext.tblPayGradeScale.FirstOrDefaultAsync(x => x.PayGradeScaleId == id);

                if (dataToDelete != null)
                {
                    await hrisDbContext.Database.ExecuteSqlAsync($"EXEC spGenericDeleteData @tableName = 'tblPayGradeScale', @dataId = {id}");
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
