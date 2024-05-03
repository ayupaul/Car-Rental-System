using Buisness_Layer.Iservice;
using Buisness_Layer.Model;
using Data_Access_Layer.Entity;
using Data_Access_Layer.IRepository;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Buisness_Layer.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepo userRepo;

        public UserService(IUserRepo userRepo )
        {
            this.userRepo = userRepo;
        }
        public async Task<UserModel?> AuthenticateAsync(UserModel user)
        {
            var email=user.Email;
            var password=user.Password;
            var userObj = await userRepo.VerifyUserAsync(email, password);
            if (userObj == null)
            {
                return null;
            }
            else
            {
                var token = CreateJwt(userObj);
                user.Token = token;
                return user;
            }
        }

        public async Task<string> GetUserNameAsync(int id)
        {
            var userName=await userRepo.GetUserNameAsync(id);
            return userName;
        }

        private string CreateJwt(UserEntity user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysecret.....");
            var identity = new ClaimsIdentity(new Claim[]
            {

                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Name,user.Email),
                 new Claim("UserId", user.Id.ToString())
            });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
