using Data_Access_Layer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.IRepository
{
    public interface IUserRepo
    {
        Task<UserEntity> VerifyUserAsync(string email,string password);
        Task<string> GetUserNameAsync(int id);
    }
}
