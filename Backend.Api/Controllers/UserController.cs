using Backend.Api.ActionFilter;
using Backend.Api.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IConfiguration _config;

        public UserController(IUserService userService, IConfiguration config) 
        {
            _userService = userService;
            _config  = config;  
        }

        [HttpGet]
       /* [ApiKeyFilter]*/
        public async Task<IActionResult> GetUsers()
        {
            var res = await _userService.GetUserList();
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserModel user)
        {
            bool res = await _userService.AddUser(user);
            if (res) { return Ok("User Added");  }
            return BadRequest("Error Occured");
        }
    }
}
