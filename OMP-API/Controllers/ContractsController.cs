using ClassLibrary.DTO;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OMP_API.Controllers
{
    public class ContractsController : BaseController<ContractTypeDTO>
    {
        [HttpGet("GetByCustomer/{customerId}")]
        public async Task<ActionResult<IEnumerable<ContractTypeDTO>>> GetByCustomerAsync(int customerId)
        {
            var contracts = await _context.ContractTypes
                .Where(ct => ct.CustomerId == customerId && !ct.IsDeleted)
                .OrderBy(ct => ct.Title)
                .Select(ct => new ContractTypeDTO
                {
                    Id = ct.Id,
                    Title = ct.Title,
                    Type = ct.Type,
                    BaseRatePerHourBrutto = ct.BaseRatePerHourBrutto,
                    Country = ct.Country,
                    CustomerId = ct.CustomerId,
                    CreationDate = ct.CreationDate,
                    EditDate = ct.EditDate,
                    DeleteDate = ct.DeleteDate,
                    IsDeleted = ct.IsDeleted
                }).ToListAsync();

            return Ok(contracts);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateAsync([FromBody] ContractTypeDTO dto)
        {
            var entity = new Models.ContractType
            {
                Title = dto.Title,
                Type = dto.Type,
                BaseRatePerHourBrutto = dto.BaseRatePerHourBrutto,
                Country = dto.Country,
                CustomerId = dto.CustomerId,
                CreationDate = DateTime.UtcNow,
                IsDeleted = false
            };

            _context.ContractTypes.Add(entity);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> UpdateAsync(int id, [FromBody] ContractTypeDTO dto)
        {
            var entity = await _context.ContractTypes.FindAsync(id);

            if (entity == null || entity.IsDeleted)
                return NotFound();

            entity.Title = dto.Title;
            entity.Type = dto.Type;
            entity.BaseRatePerHourBrutto = dto.BaseRatePerHourBrutto;
            entity.Country = dto.Country;
            entity.EditDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var entity = await _context.ContractTypes.FindAsync(id);

            if (entity == null || entity.IsDeleted)
                return NotFound();

            entity.IsDeleted = true;
            entity.DeleteDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
