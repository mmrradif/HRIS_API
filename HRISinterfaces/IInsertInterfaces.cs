using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces
{
    public interface IInsertInterfaces<T> where T : class
    {
        Task Insert(T entity);

        Task InsertRange(IEnumerable<T> entities);



        // --------------------- Store Procedures
        Task<bool> CreateWithSP(T entity);      
    }
}
