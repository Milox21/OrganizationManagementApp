using ClassLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMP_API.Models;
using OMP_API.Models.Contexts;
using OMP_API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceIncomeController : BaseController<InvoiceIncomeDTO>
    {
        private readonly DatabaseContext _context;
        public InvoiceIncomeController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceIncome/GetAll/{customerId}
        [HttpGet("GetAll/{customerId}")]
        public async Task<ActionResult<IEnumerable<InvoiceIncomeDTO>>> GetAll(int customerId)
        {
            var items = await _context.InvoiceIncomes
                .Where(i => i.CustomerId == customerId && !i.IsDeleted)
                .OrderBy(i => i.CreationDate)
                .Select(i => new InvoiceIncomeDTO
                {
                    Id = i.Id,
                    Name = i.Name,
                    Unit = i.Unit,
                    Quantity = i.Quantity,
                    PriceNetto = i.PriceNetto,
                    VatTax = i.VatTax,
                    CurrencyId = i.CurrencyId,
                    ValueNetto = i.ValueNetto,
                    ValueBrutto = i.ValueBrutto,
                    CustomerId = i.CustomerId,
                    CreationDate = i.CreationDate,
                    EditDate = i.EditDate,
                    DeleteDate = i.DeleteDate,
                    IsDeleted = i.IsDeleted
                })
                .ToListAsync();

            return Ok(items);
        }

        // POST: api/InvoiceIncome/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] InvoiceIncomeDTO dto)
        {
            var entity = new InvoiceIncome
            {
                Name = dto.Name,
                Unit = dto.Unit,
                Quantity = dto.Quantity,
                PriceNetto = dto.PriceNetto,
                VatTax = dto.VatTax,
                CurrencyId = dto.CurrencyId,
                ValueNetto = dto.Quantity * dto.PriceNetto,
                VatTaxValue = dto.ValueNetto * dto.VatTax.Value,
                ValueBrutto = dto.ValueNetto + dto.ValueNetto * dto.VatTax.Value,
                CustomerId = dto.CustomerId,
                CreationDate = DateTime.UtcNow,
                IsDeleted = false
            };
            _context.InvoiceIncomes.Add(entity);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // PUT: api/InvoiceIncome/Update/{id}
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] InvoiceIncomeDTO dto)
        {
            var entity = await _context.InvoiceIncomes.FindAsync(id);
            if (entity == null || entity.IsDeleted) return NotFound();

            entity.Name = dto.Name;
            entity.Unit = dto.Unit;
            entity.Quantity = dto.Quantity;
            entity.PriceNetto = dto.PriceNetto;
            entity.VatTax = dto.VatTax;
            entity.CurrencyId = dto.CurrencyId;
            entity.ValueNetto = dto.Quantity * dto.PriceNetto;
            entity.VatTaxValue = dto.ValueNetto * dto.VatTax.Value;
            entity.ValueBrutto = dto.ValueNetto + dto.ValueNetto * dto.VatTax.Value;
            entity.EditDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/InvoiceIncome/Delete/{id}
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.InvoiceIncomes.FindAsync(id);
            if (entity == null || entity.IsDeleted) return NotFound();

            entity.IsDeleted = true;
            entity.DeleteDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
