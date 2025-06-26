using ClassLibrary.DTO;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMP_API.Models;

namespace OMP_API.Controllers
{
    public class GroupController : BaseController<GroupDTO>
    {
        [HttpGet("GetByCustomer/{id}")]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetAllAsync(int id)
        {
            var groups = await _context.Groups.Where(e => e.CustomerId == id && e.IsDeleted != true).Select(item => new GroupDTO
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                CustomerId = item.CustomerId,
                CreationDate = item.CreationDate,
                EditDate = item.EditDate,
                IsDeleted = item.IsDeleted
            }).ToListAsync();

            return groups;
        }

        [HttpGet("GetByUser/{id}")]
        public async Task<ActionResult<IEnumerable<GroupDTO>>> GetByUser(int id)
        {
            var groups = await _context.Groups
                .Where(g => _context.GroupsUsers
                    .Any(gu => gu.UserId == id && gu.GroupId == g.Id) && g.IsDeleted != true)
                .Select(item => new GroupDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    CustomerId = item.CustomerId,
                    CreationDate = item.CreationDate,
                    EditDate = item.EditDate,
                    IsDeleted = item.IsDeleted
                })
                .ToListAsync();

            return groups;
        }


        [HttpPut("{id}")]
        public override async Task<ActionResult> UpdateAsync(int id, [FromBody] GroupDTO entity)
        {
            if (id == 0 || entity == null)
            {
                return BadRequest();
            }

            var item = await _context.Groups
                                     .FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted == false);

            if (item == null)
            {
                return NotFound();
            }

            item.Title = entity.Title;
            item.Description = entity.Description;
            item.EditDate = item.EditDate;

            item.DeleteDate = item.DeleteDate;
            item.IsDeleted = entity.IsDeleted;

            await _context.SaveChangesAsync();


            return Ok("entity updated successfully");
        }

        [HttpPost]
        public override async Task<ActionResult> CreateAsync([FromBody] GroupDTO entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            Models.Group model = new()
            {
                Title = entity.Title,
                Description = entity.Description,
                CustomerId = entity.CustomerId,
                IsDeleted = entity.IsDeleted,
                CreationDate = entity.CreationDate
            };

            await _context.Groups.AddAsync(model);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }

            return Ok("entity created successfully");
        }

        [HttpGet("{id}")]
        public override async Task<ActionResult<GroupDTO>> GetByIdAsync(int id)
        {
            var groupDto = await _context.Groups
                .Where(e => e.Id == id && e.IsDeleted == false)
                .Select(item => new GroupDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    CustomerId = item.CustomerId,
                    CreationDate = item.CreationDate,
                    EditDate = item.EditDate,
                    IsDeleted = item.IsDeleted,
                    Users = item.GroupsUsers
                        .Where(gu => gu.GroupId == item.Id)
                        .Select(gu => new UserDTO
                        {
                            Id = gu.User.Id,
                            Name = gu.User.Name,
                            Surname = gu.User.Surname,
                            CustomerId = gu.User.CustomerId,
                            PositionId = gu.User.PositionId,
                            CountryId = gu.User.CountryId,
                            CreationDate = gu.User.CreationDate,
                            EditDate = gu.User.EditDate,
                            Position = new PositionDTO
                            {
                                Id = gu.User.Position.Id,
                                Name = gu.User.Position.Name,
                                Description = gu.User.Position.Description
                            }
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();

            if (groupDto == null)
            {
                return NotFound($"Group with id {id} not found or has been deleted.");
            }

            return Ok(groupDto);
        }

    }
}
