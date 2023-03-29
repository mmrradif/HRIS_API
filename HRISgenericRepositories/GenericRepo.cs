using HRIS.DatabaseContext;
using HRISgenericInterfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericRepositories
{
    public class GenericRepo<T> : IGetInterfaces<T>, IInsertInterfaces<T>, IUpdateInterfaces<T>, IDeleteInterfaces<T> where T : class
    {

        public HRISdbContext hrisDbContext = default!;
        internal DbSet<T> dbSet = default!;


        public GenericRepo(HRISdbContext dbContext)
        {
            this.hrisDbContext = dbContext;
            this.dbSet = this.hrisDbContext.Set<T>();
        }


        // --------------------------------- NORMAL
        // Get All Informations
        public virtual Task<List<T>> GetAll()
        {
            return this.dbSet.ToListAsync();
        }



        // -- Get Informations By ID
        public virtual Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }


        // -- Get Informations By Name
        public virtual Task<T> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        // ---------------------------- GET END 
        // --------------------------------------- INSERT START



        // ----------------------- NORMAL
        public virtual Task Insert(T entity)
        {
            throw new NotImplementedException();
           
        }

        public virtual Task InsertRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
           
        }

        // -------------------------------- WITH STORE PROCEDURE

        public virtual Task<bool> CreateWithSP(T entity)
        {
            throw new NotImplementedException();
        }





        // -------------------------------- INSERT END
        // -------------------------------------------------UPDATE START


        // ----------------------------- NORMAL
        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> UpdateWithSP(T entity)
        {
            throw new NotImplementedException();
        }




        // ---------------------------------- UPDATE END
        // -------------------------------------------------- DELETE START

        // ---------------------------NORMAL
        public virtual Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }


        // ------------------------------------- WITH STORE PROCEDURE
        public virtual Task<bool> DeleteWithSP(int id)
        {
            throw new NotImplementedException();
        }
    }
}
