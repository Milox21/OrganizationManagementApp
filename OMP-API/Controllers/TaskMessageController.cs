using ClassLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using OMP_API.Models.Contexts;
using OMP_API.Models;
using Microsoft.EntityFrameworkCore;

namespace OMP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskMessageController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public TaskMessageController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("ByTask/{taskId}")]
        public async Task<ActionResult<IEnumerable<TaskMessageDTO>>> GetMessages(int taskId)
        {
            var messages = await _context.TaskMessages
                .Include(m => m.UserSender) 
                .Where(m => m.TaskId == taskId && !m.IsDeleted)
                .OrderBy(m => m.CreationDate)
                .Select(m => new TaskMessageDTO
                {
                    Id = m.Id,
                    TaskId = m.TaskId,
                    Text = m.Text,
                    CreationDate = m.CreationDate,
                    Username = m.UserSender != null ? m.UserSender.Name + " " + m.UserSender.Surname : "Unknown",
                    UserSenderId = m.UserSenderId
                })
                .ToListAsync();

            return messages;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TaskMessageDTO dto)
        {
            var entity = new TaskMessage
            {
                TaskId = dto.TaskId,
                Text = dto.Text,
                CreationDate = DateTime.UtcNow,
                UserSenderId = dto.UserSenderId,
                IsDeleted = false
            };

            _context.TaskMessages.Add(entity);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

}
