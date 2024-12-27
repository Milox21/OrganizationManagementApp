
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMP_API.DTO;


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

    }
}
