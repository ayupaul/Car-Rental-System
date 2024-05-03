
using Buisness_Layer.Iservice;
using Buisness_Layer.Model;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserModel user)
        {
            if (user == null)
            {
                return BadRequest();
            }


            var userObj = await userService.AuthenticateAsync(user);
            if (userObj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new
                {
                    Token = userObj.Token,
                    Message = "Login Succeed"

                });
            }

        }
        [HttpGet("getUser/{id}")]
        public async Task<IActionResult> GetUserName([FromRoute] int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var userName=await userService.GetUserNameAsync(id);
            if (userName == "")
            {
                return NotFound();
            }
            return Ok(userName);
        }
    }
}
