using System.Globalization;
using ClassLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OMP_API.Controllers
{
    public class TaskController : BaseController<TaskDTO>
    {
        [HttpPost]
        public override async Task<ActionResult> CreateAsync([FromBody] TaskDTO entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            Models.Task model = new()
            {
                TaskRecipient = entity.TaskRecipient,
                TaskSender = entity.TaskSender,
                Title = entity.Title,
                Text = entity.Text,
                DeadlineTime = entity.DeadlineTime,
                IsMeeting = entity.IsMeeting,
                CreationDate = DateTime.Now,
                IsDeleted = false
            };

            await _context.Tasks.AddAsync(model);
            

            //Send notification to Recipient 
            _context.Notifications.Add(new Models.Notification
            {
                UserId = entity.TaskRecipient,
                NotificationSource = "Tasks",
                NotificationText = "New Task: " + entity.Title,
                IsSeen = false,
                CreationDate = DateTime.Now,
                IsDeleted = false
            });

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }

            return Ok("entity created successfully");
        }

        [HttpGet("GetByGroup/{GroupId}")]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetByGroup(int groupid)
        {
            var tasksDTO = await _context.Tasks
                .Where(task => task.TaskSender == groupid && task.IsDeleted == false)
                .Select(item => new TaskDTO
                {
                    Id = item.Id,
                    TaskRecipient = item.TaskRecipient,
                    TaskSender = item.TaskSender,
                    Title = item.Title,
                    Text = item.Text,
                    DeadlineTime = item.DeadlineTime,
                    LateTime = item.LateTime,
                    CompletionTime = item.CompletionTime,
                    IsMeeting = item.IsMeeting,
                    CreationDate = item.CreationDate,

                }).ToListAsync();

            return tasksDTO;
        }

        [HttpGet("GetByUser/{UserId}")]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetByUser(int userid)
        {
            var tasksDTO = await _context.Tasks
                .Where(task => task.TaskRecipient == userid && task.IsDeleted == false)
                .Select(item => new TaskDTO
                {
                    Id = item.Id,
                    TaskRecipient = item.TaskRecipient,
                    TaskSender = item.TaskSender,
                    Title = item.Title,
                    Text = item.Text,
                    DeadlineTime = item.DeadlineTime,
                    LateTime = item.LateTime,
                    CompletionTime = item.CompletionTime,
                    IsMeeting = item.IsMeeting,
                    CreationDate = item.CreationDate,

                }).ToListAsync();

            return tasksDTO;
        }

        [HttpGet("GetByUserAndDate/{UserId}/{datestring}")]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetByUserAndDate(int userid, string datestring)
        {
                if (!DateTime.TryParseExact(datestring, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime targetDate))
                {
                    return BadRequest($"Invalid date format. Expected yyyy-MM-dd, received: {datestring}");
                }

                // Get start and end of the target date for precise filtering
                var startOfDay = targetDate.Date;
                var endOfDay = targetDate.Date.AddDays(1).AddTicks(-1);

                var tasksDTO = await _context.Tasks
                    .Where(task => task.TaskRecipient == userid
                                && task.IsDeleted == false
                                && task.DeadlineTime >= startOfDay
                                && task.DeadlineTime <= endOfDay)
                    .OrderBy(task => task.DeadlineTime)
                    .Select(item => new TaskDTO
                    {
                        Id = item.Id,
                        TaskRecipient = item.TaskRecipient,
                        TaskSender = item.TaskSender,
                        Title = item.Title,
                        Text = item.Text,
                        DeadlineTime = item.DeadlineTime,
                        LateTime = item.LateTime,
                        CompletionTime = item.CompletionTime,
                        IsMeeting = item.IsMeeting,
                        CreationDate = item.CreationDate,
                    }).ToListAsync();

                return Ok(tasksDTO);

        }

        [HttpPut("{id}")]
        public override async Task<ActionResult> UpdateAsync(int id, [FromBody] TaskDTO entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            var existingTask = await _context.Tasks.FindAsync(id);
            if (existingTask == null)
            {
                return NotFound($"Task with ID {id} not found");
            }

            existingTask.TaskRecipient = entity.TaskRecipient;
            existingTask.TaskSender = entity.TaskSender;
            existingTask.Title = entity.Title;
            existingTask.Text = entity.Text;
            existingTask.DeadlineTime = entity.DeadlineTime;
            existingTask.CompletionTime = entity.CompletionTime;
            existingTask.LateTime = entity.LateTime;
            existingTask.IsMeeting = entity.IsMeeting;
            existingTask.CreationDate = entity.CreationDate;
            existingTask.IsDeleted = entity.IsDeleted;
            existingTask.EditDate = entity.EditDate;

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
