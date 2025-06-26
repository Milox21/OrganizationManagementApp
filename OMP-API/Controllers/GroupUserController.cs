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

        [HttpGet("AddAdmin/{groupid}/{userid}")]
        public async Task<ActionResult> AddAdmin(int groupid, int userid)
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
            connection.IsOwner = true;
            await _context.SaveChangesAsync();

            return Ok("User promoted to Admin.");
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

        [HttpGet("GetAdmins/{groupid}")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAdmins(int groupid)
        {
            var usersDTO = await _context.GroupsUsers
                .Where(gu => gu.GroupId == groupid && gu.IsOwner == true)
                .Select(gu => new UserDTO
                {
                    Id = gu.User.Id,
                    IdentityUserId = gu.User.IdentityUserId,
                    Name = gu.User.Name,
                    Surname = gu.User.Surname,
                    CustomerId = gu.User.CustomerId,
                    PositionId = gu.User.PositionId,
                    CountryId = gu.User.CountryId,
                    CreationDate = gu.User.CreationDate,
                    EditDate = gu.User.EditDate,
                    Position = new PositionDTO
                    {
                        Id = gu.User.Position != null ? gu.User.Position.Id : 0,
                        Name = gu.User.Position.Name,
                        Description = gu.User.Position.Description
                    }
                })
                .ToListAsync();

            return usersDTO;
        }
    }

}
