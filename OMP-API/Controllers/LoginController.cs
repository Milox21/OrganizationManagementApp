using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace OMP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AdminLoginController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("adminlogin")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                List<string> roles = (List<string>)await _userManager.GetRolesAsync(user);
                if (roles.Contains("Admin"))
                {
                    return Ok(new
                    {
                        accessToken = "huj",
                        expiration = 3600 
                    });
                }
                else
                {
                    return Unauthorized(new
                    {
                        errors = new Dictionary<string, string[]>
                        {
                            { "role", new[] { "User is not admin" } }
                        }
                    });
                }
            }
            return Unauthorized(new
            {
                errors = new Dictionary<string, string[]>
                {
                    { "credentials", new[] { "Invalid email or password." } }
                }
            });
        }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
