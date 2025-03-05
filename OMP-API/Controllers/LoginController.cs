using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OMP_API.Models.Contexts;
using ClassLibrary.DTO;

namespace OMP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        public readonly DatabaseContext _context;

        public AdminLoginController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = new DatabaseContext();
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
                        accessToken = " ",
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

        [HttpPost("userlogin")]
        public async Task<IActionResult> UserLogin( [FromBody] LoginModel model)
        {
            var identityuser = await _userManager.FindByEmailAsync(model.Email);
            if (identityuser != null && await _userManager.CheckPasswordAsync(identityuser, model.Password))
            {

                var userRoles = await _userManager.GetRolesAsync(identityuser);

                var user = await _context.Users
                    .Where(u => u.IdentityUserId == identityuser.Id)
                    .Join(
                        _context.Customers,
                        u => u.CustomerId,
                        c => c.Id,
                        (u, c) => new { User = u, Customer = c }
                    )
                    .Select(uc => new UserDTO
                    {
                        Id = uc.User.Id,
                        Name = uc.User.Name,
                        Surname = uc.User.Surname,
                        CompanyName = uc.User.Customer.Name,
                        CustomerId = uc.User.CustomerId,
                        Email = model.Email,
                        Country = new CountryDTO
                        {
                            Name = uc.User.Country.Name,
                            Description = uc.User.Country.Description
                        },
                        Position = new PositionDTO 
                        {
                            Name = uc.User.Position.Name,
                            Description = uc.User.Position.Description
                        },
                        Role = userRoles.FirstOrDefault()
                    })
                    .FirstOrDefaultAsync();

                if (user != null)
                {
                    return Ok(user); 
                }

                return Unauthorized(new
                {
                    errors = new Dictionary<string, string[]>
            {
                { "user", new[] { "No matching user found for the provided customer." } }
            }
                });
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

    

