
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.DTO;


namespace OMP_API.Controllers
{
    public class ModuleController : BaseController<ModuleDTO>
    {
        [HttpGet]
        public override async Task<ActionResult<IEnumerable<ModuleDTO>>> GetAllAsync()
        {
            var modules = await _context.Modules
                                        .ToListAsync();
            return Ok(modules);
        }

        [HttpGet("GetByCustomer/{id}")]
        public async Task<ActionResult<IEnumerable<ModuleDTO>>> GetByCustomerAsync(int id)
        {
            var modules = await _context.CustomerModules
                .Where(cm => cm.CustomerId == id)
                .Join(
                    _context.Modules,
                    customerModule => customerModule.ModuleId,
                    module => module.Id,
                    (customerModule, module) => new ModuleDTO
                    {
                        Id = module.Id,
                        Name = module.Name,
                        Description = module.Description
                    })
                .ToListAsync();

            return Ok(modules);
        }


    }
}
