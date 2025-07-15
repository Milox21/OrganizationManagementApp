using System;
using ClassLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMP_API.Models.Contexts;

namespace OMP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupMessageController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public GroupMessageController()
        {
            _context = new();
        }

        [HttpGet("GetByGroup/{groupId}")]
        public async Task<IActionResult> GetByGroup(int groupId)
        {
            var messages = await _context.GroupMessages
                .Where(m => m.GroupId == groupId && !m.IsDeleted)
                .OrderBy(m => m.CreationDate)
                .ToListAsync();

            return Ok(messages);
        }

        [HttpPost]
        public async Task<IActionResult> Post(GroupMessageDTO messageDTO)
        {
            var message = new Models.GroupMessage
            {
                UserId = messageDTO.UserID,
                GroupId = messageDTO.GroupID,
                CreationDate = DateTime.UtcNow,
                Text = messageDTO.Text,
                EditDate = messageDTO.EditDate,
                IsDeleted = messageDTO.IsDeleted,
                DeleteDate = messageDTO.DeleteDate,
            };

            _context.GroupMessages.Add(message);
            await _context.SaveChangesAsync();

            // Return full DTO with user/group populated
            var user = await _context.Users.FindAsync(message.UserId);
            var group = await _context.Groups.FindAsync(message.GroupId);

            var response = new GroupMessageDTO
            {
                Id = message.Id,
                Text = message.Text,
                CreationDate = message.CreationDate,
                EditDate = message.EditDate,
                DeleteDate = message.DeleteDate,
                IsDeleted = message.IsDeleted,
                GroupID = message.GroupId,
                UserID = message.UserId,
                Group = new GroupDTO { Id = group?.Id ?? 0, Title = group?.Title ?? "Unknown" },
                User = new UserDTO { Id = user?.Id ?? 0, Name = user?.Name ?? "?", Surname = user?.Surname ?? "?" }
            };

            return Ok(response);
        }
    }
}
