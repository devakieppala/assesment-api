using DotNet_Assesment.Services;
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
        private readonly JWTTokenService _jwtTokenService;
        public LoginController(JWTTokenService jWTTokenService)
        {

            this._jwtTokenService = jWTTokenService;
        }

        [HttpPost]
        [Route("userlogin")]
        public IActionResult ValidateUserLogin([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest.UserName == null || loginRequest.Password == null)
            {
                return BadRequest();
            }

            if (loginRequest.UserName.Contains("admin") && loginRequest.Password == "Password12345")
            {
                var _token = _jwtTokenService.GenerateToken(loginRequest.UserName, loginRequest.UserName, new List<string>() { "Admin" });
                return Ok(new { Status = "true", Message = "Login Successfull", Token = _token });
            }
            return Ok(new { Status = false, Message = "Invalid user login" });
        }
    }
}

