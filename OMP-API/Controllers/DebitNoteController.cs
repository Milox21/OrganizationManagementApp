using ClassLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMP_API.Models;
using OMP_API.Models.Contexts;

namespace OMP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebitNoteController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public DebitNoteController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/DebitNote/GetAll/{customerId}
        [HttpGet("GetAll/{customerId}")]
        public async Task<ActionResult<IEnumerable<DebitNoteDTO>>> GetAll(int customerId)
        {
            var items = await _context.DebitNotes
                .Include(d => d.CurrencyNavigation)
                .Where(d => d.CustomerId == customerId && !d.IsDeleted)
                .OrderBy(d => d.CreationDate)
                .Select(d => new DebitNoteDTO
                {
                    Id = d.Id,
                    Title = d.Title,
                    Description = d.Description,
                    Value = d.Value,
                    CurrencyId = d.CurrencyId,
                    CustomerId = d.CustomerId,
                    CreationDate = d.CreationDate,
                    EditDate = d.EditDate,
                    DeleteDate = d.DeleteDate,
                    IsDeleted = d.IsDeleted,
                    Currency = "0",
                    CurrencyNavigation = d.CurrencyNavigation != null
                    ? new CurrencyDTO
                    {
                        Id = d.CurrencyNavigation.Id,
                        Code = d.CurrencyNavigation.Code
                    }
                    : null,
                })

                .ToListAsync();

            return Ok(items);
        }

        // POST: api/DebitNote/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] DebitNoteDTO dto)
        {
            var entity = new DebitNote
            {
                Title = dto.Title,
                Description = dto.Description,
                Value = dto.Value,
                CurrencyId = dto.CurrencyId,
                CustomerId = dto.CustomerId,
                Currency = dto.Currency,
                CreationDate = DateTime.UtcNow,
                IsDeleted = false
            };

            _context.DebitNotes.Add(entity);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // PUT: api/DebitNote/Update
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] DebitNoteDTO dto)
        {
            var entity = await _context.DebitNotes.FindAsync(dto.Id);
            if (entity == null || entity.IsDeleted)
                return NotFound();

            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.Value = dto.Value;
            entity.Currency = dto.Currency;
            entity.CurrencyId = dto.CurrencyId;
            entity.EditDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/DebitNote/Delete/{id}
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.DebitNotes.FindAsync(id);
            if (entity == null || entity.IsDeleted)
                return NotFound();

            entity.IsDeleted = true;
            entity.DeleteDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
