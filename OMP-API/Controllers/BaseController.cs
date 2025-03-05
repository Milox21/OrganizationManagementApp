using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;
using OMP_API.Models.Contexts;
using ClassLibrary.Models.ModelInterfaces;

namespace OMP_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<T> : ControllerBase where T : class, IBaseModel
    {
        public readonly DatabaseContext _context;
        public BaseController()
        {
            _context = new();
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<T>>> GetAllAsync()
        {
            List<T> entities = await _context.Set<T>()
                                                .Where(x => x.IsDeleted != true)
                                                .ToListAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<T>> GetByIdAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            T? item = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted != true);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public virtual async Task<ActionResult> CreateAsync([FromBody] T entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return Ok("entity created successfully");
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult> UpdateAsync(int id, [FromBody] T entity)
        {
            if (id == 0 || entity == null)
            {
                return BadRequest();
            }

            T? item = await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted != true);

            if (item == null)
            {
                return NotFound();
            }

            _context.Entry(item).CurrentValues.SetValues(entity);
            item.EditDate = DateTime.Now;

            _context.Set<T>().Update(item);
            await _context.SaveChangesAsync();
            return Ok("entity updated successfully");
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            T? entity = await _context.Set<T>().FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return Ok("entity deleted successfully");
        }
    }
}
