using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Application.IService;

namespace TestProjectCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public LoginController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        [HttpPost]
        public async Task<IActionResult> Login(string user_id, string password, string userType)
        {
            var token = await _tokenService.GenerateJWToken(user_id, password, userType);
            return Ok(token);
        }
    }
}
