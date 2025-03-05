using ClassLibrary.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OMP_API.Controllers
{
    public class UserController : BaseController<UserDTO>
    {
        [HttpGet("GetByCustomer/{id}")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllAsync(int id)
        {
            var usersDTO = await _context.Users
                .Where(e => e.CustomerId == id && e.IsDeleted == false)
                .Select(item => new UserDTO
            {
                Id = item.Id,
                IdentityUserId = item.IdentityUserId,
                Name = item.Name,
                Surname = item.Surname,
                CustomerId = item.CustomerId,
                PositionId = item.PositionId,
                CountryId = item.CountryId,
                CreationDate = item.CreationDate,
                EditDate = item.EditDate,
                Position = new PositionDTO
                {
                    Id = item.Position != null ? item.Position.Id : 0,
                    Name = item.Position.Name,
                    Description = item.Position.Description
                }
            }).ToListAsync();

            return usersDTO;
        }

        [HttpPut("{id}")]
        public override async Task<ActionResult> UpdateAsync(int id, [FromBody] UserDTO entity)
        {
            if (id == 0 || entity == null)
            {
                return BadRequest();
            }

            var item = await _context.Users
                                     .FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted == false);

            if (item == null)
            {
                return NotFound();
            }

            item.Name = entity.Name;
            item.Surname = entity.Surname;
            item.PositionId = entity.PositionId;
            item.CountryId = entity.CountryId;
            item.EditDate = entity.EditDate;

            item.DeleteDate = entity.DeleteDate;
            item.IsDeleted = entity.IsDeleted;

            await _context.SaveChangesAsync();


            return Ok("entity updated successfully");
        }

        [HttpGet("GetByGroup/{id}")]
        public async Task<ActionResult> GetByGroup(int id)
        {
            var usersDTO = await _context.Users
                .Where(user => _context.GroupsUsers.Any(gu => gu.GroupId == id && gu.UserId == user.Id))
                .Select(item => new UserDTO
                {
                    Id = item.Id,
                    IdentityUserId = item.IdentityUserId,
                    Name = item.Name,
                    Surname = item.Surname,
                    CustomerId = item.CustomerId,
                    PositionId = item.PositionId,
                    CountryId = item.CountryId,
                    CreationDate = item.CreationDate,
                    EditDate = item.EditDate,
                    Position = new PositionDTO
                    {
                        Id = item.Position.Id,
                        Name = item.Position.Name,
                        Description = item.Position.Description
                    }
                })
                .ToListAsync();

            if (usersDTO == null || !usersDTO.Any())
            {
                return NotFound(new { message = "No users found in this group." });
            }

            return Ok(usersDTO);
        }

    }
}
