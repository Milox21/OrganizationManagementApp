using ClassLibrary.DTO;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMP_API.Models;

namespace OMP_API.Controllers
{
    [Route("api/[controller]")]
    public class GroupUserController : BaseController<GroupsUserDTO>
    {
        [HttpPost("AddToGroup/{groupid}/{userid}")]
        public async Task<ActionResult> AddToGroup(int groupid, int userid)
        {
            if (userid == 0 || groupid == 0)
            {
                return BadRequest("Invalid group ID or user ID.");
            }

            bool exists = await _context.GroupsUsers
                .AnyAsync(e => e.GroupId == groupid && e.UserId == userid);

            if (exists)
            {
                return Conflict("User is already in the group.");
            }

            Models.GroupsUser connection = new()
            {
                GroupId = groupid,
                UserId = userid
            };

            await _context.GroupsUsers.AddAsync(connection);
            await _context.SaveChangesAsync();

            return Ok("User added to the group.");
        }

        [HttpDelete("DeleteFromGroup/{groupid}/{userid}")]
        public async Task<ActionResult> DeleteFromGroup(int groupid, int userid)
        {
            if (userid == 0 || groupid == 0)
            {
                return BadRequest("Invalid group ID or user ID.");
            }

            var connection = await _context.GroupsUsers
                .FirstOrDefaultAsync(e => e.GroupId == groupid && e.UserId == userid);

            if (connection == null)
            {
                return NotFound("User not found in the group.");
            }

            _context.GroupsUsers.Remove(connection);
            await _context.SaveChangesAsync();

            return Ok("User removed from the group.");
        }
    }

}
