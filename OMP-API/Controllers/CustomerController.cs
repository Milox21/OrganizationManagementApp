using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.DTO;
using OMP_API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace OMP_API.Controllers
{
    public class CustomerController : BaseController<CustomerDTO>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public CustomerController(UserManager<IdentityUser> userManager) : base()
        {
            _userManager = userManager;
        }

        [HttpGet]
        public override async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllAsync()
        {
            var customersDTO = await _context.Customers
                                     .Where(x => x.IsDeleted == false)
                                     .Select(item => new CustomerDTO
                                     {
                                         Id = item.Id,
                                         Name = item.Name,
                                         Address = item.Address,
                                         Password = item.Password,
                                         Email = item.Email,
                                         Location = item.Location,
                                         PhoneContact = item.PhoneContact,
                                         CreationDate = item.CreationDate,
                                         Modules = item.CustomerModules.Select(cm => new ModuleDTO
                                         {
                                             Id = cm.Module.Id,
                                             Name = cm.Module.Name,
                                             Description = cm.Module.Description,

                                         }).ToList(),
                                     }).ToListAsync();

            return Ok(customersDTO);
        }




        [HttpPost]
        public override async Task<ActionResult> CreateAsync([FromBody] CustomerDTO entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            Customer model = new()
            {
                Name = entity.Name,
                Address = entity.Address,
                Email = entity.Email,
                Location = entity.Location,
                PhoneContact = entity.PhoneContact,
                CreationDate = entity.CreationDate,
                Password = entity.Password,
                IsDeleted = entity.IsDeleted,
            };

            await _context.Customers.AddAsync(model);
            await _context.SaveChangesAsync();
            return Ok("entity created successfully");
        }

        [HttpPut("{id}")]
        public override async Task<ActionResult> UpdateAsync(int id, [FromBody] CustomerDTO entity)
        {
            if (id == 0 || entity == null)
            {
                return BadRequest();
            }

            Customer? item = await _context.Customers
                                      .FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted == false);

            if (item == null)
            {
                return NotFound();
            }

            item.Id = id;
            item.Name = entity.Name;
            item.Email = entity.Email;
            item.Location = entity.Location;
            item.PhoneContact = entity.PhoneContact;
            item.Password = entity.Password;
            item.EditDate = DateTime.Now;
            item.DeleteDate = entity.DeleteDate;
            item.IsDeleted = entity.IsDeleted;


            List<CustomerModule> CM = await _context.CustomerModules
                .Where(e => e.CustomerId == id)
                .ToListAsync();

            var modelsToRemove = CM.Where(m => !entity.Modules.Any(module => module.Id == m.ModuleId)).ToList();
            _context.CustomerModules.RemoveRange(modelsToRemove);


            var modelsToAdd = entity.Modules
                .Where(module => !CM.Any(m => m.ModuleId == module.Id))
                .Select(module => new CustomerModule
                {
                    CustomerId = id,
                    ModuleId = module.Id
                })
                .ToList();
            await _context.CustomerModules.AddRangeAsync(modelsToAdd);

            await _context.SaveChangesAsync();

            return Ok("entity updated successfully");
        }

        //change to post
        [HttpGet("GetByPassword/{password}")]
        public async Task<ActionResult> GetByPassword(string password)
        {
            Customer? entity = await _context.Customers
                                   .Where(c => c.Password.Trim() == password.Trim())
                                   .FirstOrDefaultAsync();
            if (entity != null)
            {
                return Ok(new CustomerDTO
                {
                    Name = entity.Name,
                    Password = entity.Password
                });
            }
            return Ok(new CustomerDTO
            {
                Name = " ",
                Password = " "
            });

        }
        //add customer password to dto
        [HttpPost("CreateUser/{customerPassword}")]
        public async Task<ActionResult> CreateUser(string customerPassword, [FromBody] CustomerDTO customerDTO)
        {
            var user = await _userManager.FindByEmailAsync(customerDTO.Email);
            var customer = await _context.Customers.Where(c => c.Password == customerPassword).FirstOrDefaultAsync();

            if (customer == null || user == null || string.IsNullOrWhiteSpace(customerPassword))
            {
                return BadRequest("Invalid customer or user information.");
            }


            var userExistsForCustomer = await _context.Users.AnyAsync(u => u.CustomerId == customer.Id);
            var role = userExistsForCustomer ? "User" : "Manager";

            await _context.Users.AddAsync(new User
            {
                Name = string.Empty,
                Surname = string.Empty,
                CustomerId = customer.Id,
                IdentityUserId = user.Id

            });
            await _context.SaveChangesAsync();

            if (!await _userManager.IsInRoleAsync(user, role))
            {
                await _userManager.AddToRoleAsync(user, role);
            }

            return Ok("User created and role assigned successfully.");
        }
    }
}   
