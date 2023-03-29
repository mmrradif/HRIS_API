using HRISdatabaseModels.DatabaseModels.CompanyInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces
{
    public interface IGetInterfaces<T> where T : class
    {
        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        Task<T> GetByName(string name);

    }
}
