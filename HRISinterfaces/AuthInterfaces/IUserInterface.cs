using HRISdatabaseModels.DatabaseModels.AuthenticationAuthorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.AuthInterfaces
{
    public interface IUserInterface: IGetInterfaces<User>, IInsertInterfaces<User>, IUpdateInterfaces<User>, IDeleteInterfaces<User>
    {
        Task<bool> AuthenticateUser(User user);
        Task<bool> RegisterEmployee(User data);
    }
}
