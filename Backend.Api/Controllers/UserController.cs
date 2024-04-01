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

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetUserList());
        }

        [HttpPost]
        public IActionResult AddUser(UserModel user)
        {
            bool res = _userService.AddUser(user);
            if (res) { return Ok("User Added");  }
            return BadRequest("Error Occured");
        }
    }
}
