using Data_Access_Layer.Db;
using Data_Access_Layer.Entity;
using Data_Access_Layer.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDbContext appDbContext;

        public UserRepo(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<string> GetUserNameAsync(int id)
        {
           var user= await appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
           if(user == null)
            {
                return "";
            }
            return user.Email;
        }

        public async Task<UserEntity?> VerifyUserAsync(string email,string password)
        {
            var user=await appDbContext.Users.FirstOrDefaultAsync(x=> x.Email == email && x.Password==password);
            return user;
        }
    }
}
