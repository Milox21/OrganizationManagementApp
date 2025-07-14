using ClassLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMP_API.Models;
using OMP_API.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public PayrollController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Payroll/GetAll/{customerId}
        [HttpGet("GetAll/{customerId}")]
        public async Task<ActionResult<IEnumerable<PayrollDTO>>> GetAll(int customerId)
        {
            // 1. Load raw data from DB into memory
            var rawItems = await _context.Payrolls
                .Include(p => p.Currency)
                .Include(p => p.ContractTypeNavigation)
                .Where(p => p.CustomerId == customerId && p.IsDeleted != true)
                .OrderBy(p => p.CreationDate)
                .ToListAsync();

            // 2. Map to DTOs in memory (safe to use Convert.ToDecimal)
            var items = rawItems.Select(p => new PayrollDTO
            {
                Id = p.Id,
                Name = p.Name,
                Surname = p.Surname,
                ContractType = p.ContractType,
                RatePerHourBrutto = p.RatePerHourBrutto,
                Hours = p.Hours,
                PayrollTaxRateIds = p.PayrollTaxRateIds,
                CurrencyId = p.CurrencyId,
                CustomerId = p.CustomerId,
                CreationDate = p.CreationDate,
                EditDate = p.EditDate,
                DeleteDate = p.DeleteDate,
                IsDeleted = p.IsDeleted,
                TaxRate = decimal.TryParse(p.PayrollTaxRateIds, out var rate) ? rate : 0m, // Safe fallback
                ContractTypeNavigation = new ContractTypeDTO
                {
                    Id = p.ContractTypeNavigation.Id,
                    Title = p.ContractTypeNavigation.Title
                },
                Currency = p.Currency != null
                    ? new CurrencyDTO
                    {
                        Id = p.Currency.Id,
                        Code = p.Currency.Code
                    }
                    : null,
            }).ToList();

            return Ok(items);
        }

        // POST: api/Payroll/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] PayrollDTO dto)
        {
            var entity = new Payroll
            {
                Name = dto.Name,
                Surname = dto.Surname,
                ContractType = dto.ContractType,
                RatePerHourBrutto = dto.RatePerHourBrutto,
                Hours = dto.Hours,
                PayrollTaxRateIds = dto.TaxRate.ToString(),
                CurrencyId = dto.CurrencyId,
                CustomerId = dto.CustomerId,
                CreationDate = DateTime.UtcNow,
                IsDeleted = false
            };

            _context.Payrolls.Add(entity);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // PUT: api/Payroll/Update
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] PayrollDTO dto)
        {
            var entity = await _context.Payrolls.FindAsync(dto.Id);
            if (entity == null || entity.IsDeleted) return NotFound();

            entity.Name = dto.Name;
            entity.Surname = dto.Surname;
            entity.ContractType = dto.ContractType;
            entity.RatePerHourBrutto = dto.RatePerHourBrutto;
            entity.Hours = dto.Hours;
            entity.PayrollTaxRateIds = dto.TaxRate.ToString(); 
            entity.CurrencyId = dto.CurrencyId;
            entity.EditDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Payroll/Delete/{id}
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Payrolls.FindAsync(id);
            if (entity == null || entity.IsDeleted) return NotFound();

            entity.IsDeleted = true;
            entity.DeleteDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
