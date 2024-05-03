
using Buisness_Layer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Iservice
{
    public interface IUserService
    {
         Task<UserModel> AuthenticateAsync(UserModel user);
        Task<string> GetUserNameAsync(int id);
    }
}
