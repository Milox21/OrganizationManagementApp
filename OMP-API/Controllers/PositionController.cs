using BlazorBootstrap;
using ClassLibrary.DTO;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OMP_API.Controllers
{
    public class PositionController : BaseController<PositionDTO>
    {
        [HttpGet("GetByCustomer/{id}")]
        public async Task<ActionResult<IEnumerable<PositionDTO>>> GetAllByIdAsync(int id)
        {
            var positions = await _context.Positions
                                        .Where(x => x.IsDeleted == false && x.CustomerId == id)
                                        .Select(item => new PositionDTO
                                        {
                                            Id = item.Id,
                                            Name = item.Name,
                                            Description = item.Description,
                                            CustomerId = item.CustomerId

                                        }).ToListAsync();
            return Ok(positions);
        }

        [HttpPost]
        public override async Task<ActionResult> CreateAsync([FromBody] PositionDTO entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            Models.Position model = new()
            {
                Name = entity.Name,
                Description = entity.Description,
                CustomerId = entity.CustomerId,
                IsDeleted = false,
                CreationDate = DateTime.Now
            };

            await _context.Positions.AddAsync(model);
            await _context.SaveChangesAsync();
            return Ok("entity created successfully");
        }

        [HttpPut("{id}")]
        public override async Task<ActionResult> UpdateAsync(int id, [FromBody] PositionDTO entity)
        {
            if (id == 0 || entity == null)
            {
                return BadRequest();
            }

             var item = await _context.Positions
                                      .FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted == false);

            if (item == null)
            {
                return NotFound();
            }

            item.Name = entity.Name;
            item.Description = entity.Description;
            item.CustomerId = entity.CustomerId;
            item.IsDeleted = entity.IsDeleted;
            item.EditDate = entity.EditDate;
            item.DeleteDate = entity.DeleteDate;

            await _context.SaveChangesAsync();
            

            return Ok("entity updated successfully");
        }
    }
}
