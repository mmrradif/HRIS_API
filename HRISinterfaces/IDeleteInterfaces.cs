using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces
{
    public interface IDeleteInterfaces<T> where T : class
    {

        Task<bool> Delete(int id);


        //void DeleteRange(IEnumerable<T> entities);



        // ------------ Store Procedures
        Task<bool> DeleteWithSP(int id);
    }
}
