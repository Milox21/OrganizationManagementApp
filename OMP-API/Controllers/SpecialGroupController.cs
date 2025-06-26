using ClassLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMP_API.Models;

namespace OMP_API.Controllers
{
    public class SpecialGroupController : BaseController<SpecialGroupDTO>
    {
        [HttpGet("GetByCustomer/{id}")]
        public async Task<ActionResult<IEnumerable<SpecialGroupDTO>>> GetAllAsync(int id)
        {
            var groups = await _context.SpecialGroups.Where(e => e.CustomerId == id && e.IsDeleted != true)
                .Select(item => new SpecialGroupDTO
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
        public async Task<ActionResult<IEnumerable<SpecialGroupDTO>>> GetByUser(int id)
        {
            var groups = await _context.Groups
                .Where(g => _context.GroupsUsers
                    .Any(gu => gu.UserId == id && gu.GroupId == g.Id) && g.IsDeleted != true)
                .Select(item => new SpecialGroupDTO
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

        [HttpGet("{id}")]
        public override async Task<ActionResult<SpecialGroupDTO>> GetByIdAsync(int id)
        {
            var groupDto = await _context.SpecialGroups
                .Where(e => e.Id == id && e.IsDeleted == false)
                .Select(item => new SpecialGroupDTO
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    CustomerId = item.CustomerId,
                    CreationDate = item.CreationDate,
                    EditDate = item.EditDate,
                    IsDeleted = item.IsDeleted,
                    Users = item.SpecialGroupsUsers
                        .Where(gu => gu.SpecialGroupId == item.Id)
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

        [HttpPut("{id}")]
        public override async Task<ActionResult> UpdateAsync(int id, [FromBody] SpecialGroupDTO entity)
        {
            if (id == 0 || entity == null)
            {
                return BadRequest();
            }

            var item = await _context.SpecialGroups
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
        public override async Task<ActionResult> CreateAsync([FromBody] SpecialGroupDTO entity)
        {
            if (entity == null)
            {
                return BadRequest();
            }

            SpecialGroup model = new()
            {
                Title = entity.Title,
                Description = entity.Description,
                CustomerId = entity.CustomerId,
                IsDeleted = entity.IsDeleted,
                CreationDate = entity.CreationDate
            };

            await _context.SpecialGroups.AddAsync(model);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }

            return Ok("entity created successfully");
        }


        [HttpGet("AddAdmin/{id}/{selectedUserId}")]
        public async Task<ActionResult> AddAdmin(int id, int selectedUserId)
        {
            if (id == null || selectedUserId == null)
            {
                return BadRequest();
            }

            var group = await _context.SpecialGroups.FirstOrDefaultAsync(a => a.Id == id);

            var specialgroup = await _context.SpecialGroupsUsers.FirstOrDefaultAsync(a => a.SpecialGroupId == id);

            if (specialgroup != null)
            {
                specialgroup.UserId = selectedUserId;
                try
                {
                    await _context.SaveChangesAsync();
                    return Ok("User promoted to Admin.");
                }
                catch (Exception e)
                {
                    return Ok("Error");
                }
            }
            else
            {
                SpecialGroupsUser model = new()
                {
                    CustomerId = group.CustomerId,
                    SpecialGroupId = group.Id,
                    UserId = selectedUserId,
                    IsOwner = true,
                    CreationDate = DateTime.Now,
                    IsDeleted = false
                };

                await _context.SpecialGroupsUsers.AddAsync(model);
                try
                {
                    await _context.SaveChangesAsync();
                    return Ok("User promoted to Admin.");
                }
                catch (Exception e)
                {
                    return Ok("Error");
                }
            }

        }

        [HttpGet("GetAdmin/{id}")]
        public async Task<ActionResult<UserDTO>> GetAdminAsync(int id)
        {
            var result = await _context.SpecialGroupsUsers
                .Where(gu => gu.SpecialGroupId == id)
                .Join(
                    _context.Users,
                    gu => gu.UserId,
                    u => u.Id,
                    (gu, u) => new UserDTO
                    {
                        Id = u.Id,
                        IdentityUserId = u.IdentityUserId,
                        Name = u.Name,
                        Surname = u.Surname,
                        PositionId = u.PositionId,
                        CustomerId = u.CustomerId,
                        CountryId = u.CountryId,
                        CreationDate = u.CreationDate
                    })
                .FirstOrDefaultAsync();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost("CreateTicket")]
        public async Task<ActionResult> CreateTicketAsync([FromBody] SpecialGroupsTicketDTO entity)
        {
            var ticket = new SpecialGroupsTicket()
            {
                UserId = entity.UserId,
                SpecialGroupId = entity.SpecialGroupId,
                Title = entity.Title,
                Text = entity.Text,
                CreationDate = entity.CreationDate,
                IsDeleted = entity.IsDeleted
            };

            var result = await _context.SpecialGroupsTickets.AddAsync(ticket);
            await _context.SaveChangesAsync();

            if (result == null)
            {
                return NotFound();
            }
            return Ok("Ticket Created");
        }

        [HttpGet("GetTickets/{specialgroupid}")]
        public async Task<ActionResult<List<SpecialGroupsTicketDTO>>> GetTicketsAsync(int specialgroupid)
        {
            var items = await _context.SpecialGroupsTickets
                .Where(item => item.SpecialGroupId == specialgroupid && item.IsDeleted != true)
                .OrderByDescending(item => item.CreationDate)
                .Take(20)
                .Select(item => new SpecialGroupsTicketDTO
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    SpecialGroupId = item.SpecialGroupId,
                    Title = item.Title,
                    Text = item.Text,
                    CreationDate = item.CreationDate,
                    EditDate = item.EditDate,
                    DeleteDate = item.DeleteDate,
                    IsDeleted = item.IsDeleted
                }).ToListAsync();

            return items;
        }
    }
}
