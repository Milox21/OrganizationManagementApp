using ClassLibrary.DTO;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OMP_API.Controllers
{
    public class NotificationController : BaseController<NotificationDTO>
    {
        [HttpPost]
        public override async Task<ActionResult> CreateAsync([FromBody] NotificationDTO entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            Models.Notification model = new()
            {
                Id = entity.Id,
                UserId = entity.UserId,
                NotificationSource = entity.NotificationSource,
                NotificationText = entity.NotificationText,
                IsSeen = entity.IsSeen,
                CreationDate = DateTime.Now,
                IsDeleted = false
            };

            await _context.Notifications.AddAsync(model);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }

            return Ok("entity created successfully");
        }

        [HttpGet("GetByUser/{id}")]
        public virtual async Task<ActionResult<IEnumerable<NotificationDTO>>> GetByUserAsync(int id)
        {
            var nots = await _context.Notifications
                .Where(not => not.UserId == id && not.IsDeleted == false)
                .Select(item => new NotificationDTO
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    NotificationSource = item.NotificationSource,
                    NotificationText = item.NotificationText,
                    IsSeen = item.IsSeen,
                    IsDeleted = item.IsDeleted,
                    CreationDate = item.CreationDate,

                }).ToListAsync();

            return nots;
        }

        [HttpPut("{id}")]
        public override async Task<ActionResult> UpdateAsync(int id, [FromBody] NotificationDTO entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            var existingItem = await _context.Notifications.FindAsync(id);
            if (existingItem == null)
            {
                return NotFound($"Task with ID {id} not found");
            }

            existingItem.UserId = entity.UserId;
            existingItem.NotificationSource = entity.NotificationSource;
            existingItem.NotificationText = entity.NotificationText;
            existingItem.IsSeen = entity.IsSeen;
            existingItem.EditDate = DateTime.Now;
            existingItem.CreationDate = entity.CreationDate;
            existingItem.IsDeleted = entity.IsDeleted;
            existingItem.EditDate = entity.EditDate;

            try
            {
                await _context.SaveChangesAsync();
                return Ok("Entity updated successfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Internal server error: {e.Message}");
            }
        }
    }
}
