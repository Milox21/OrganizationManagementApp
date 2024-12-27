using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMP_API.DTO;
using OMP_API.Models;

namespace OMP_API.Controllers
{
    public class CustomerController : BaseController<CustomerDTO>
    {
        [HttpGet]
        public override async Task<ActionResult<IEnumerable<CustomerDTO>>> GetAllAsync()
        {
            var customers = await _context.Customers
                                     .Include(t => t.CustomerModules)
                                     .ThenInclude(t => t.Module)
                                     .Where(x => x.IsDeleted == false)
                                     .ToListAsync();

            var customersDTO = customers.Select(item => new CustomerDTO
            {
                Id = item.Id,
                Name = item.Name,
                CreationDate = item.CreationDate,
                Modules = item.CustomerModules.Select(cm => new ModuleDTO
                {
                    Id = cm.Module.Id,
                    Name = cm.Module.Name,
                    Description = cm.Module.Description,

                }).ToList(),
            }).ToList();
                                   
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
                CreationDate= entity.CreationDate,
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
            item.Password = entity.Password;
            item.EditDate = DateTime.Now;
            item.DeleteDate= entity.DeleteDate;
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
    }
}
