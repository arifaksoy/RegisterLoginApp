using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RegisterLoginApp.Server.DTO;

namespace RegisterLoginApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        //api/auth/register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.UserName,
                Email=  registerRequestDTO.UserName
            };

            var result = await _userManager.CreateAsync(identityUser,registerRequestDTO.Password);

            if(result.Succeeded)
            {
                if(registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                {
                    result = await _userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);
                    if(result.Succeeded)
                    {
                        return Ok("Register was success.");
                    }
                }
                
            }
            return BadRequest("something was wrong.");
        }
        //api/auth/login

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginRequestDTO.UserName);

            if(user != null) 
            {
                var checkPassword = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
                if (checkPassword)
                {
                    //create token
                    return Ok("logined");
                }
            }

            return BadRequest("username or password incorrect!");
        }
    }
}
