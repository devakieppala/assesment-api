using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet_Assesment.Controllers
{

    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("userlogin")]
        public IActionResult ValidateUserLogin([FromBody]LoginRequest loginRequest)
        {
            //var obj = { "result":true };
            if(loginRequest.UserName == null || loginRequest.Password == null)
            {
                return BadRequest();
            }

            if(loginRequest.UserName.Contains("admin") && loginRequest.Password == "Password12345")
            {
                return Ok(new { Status="true",Message="Login Successfull"});
            }
            return Ok(new {Status=false,Message="Invalid user login"});
        }
    }
}

