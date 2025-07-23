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
                    VatTaxValue = i.VatTaxValue,
                    CurrencyId = i.CurrencyId,
                    ValueNetto = i.ValueNetto,
                    ValueBrutto = i.ValueBrutto,
                    CustomerId = i.CustomerId,
                    CreationDate = i.CreationDate,
                    VatTaxRate = i.VatTaxRate,
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
                CurrencyId = dto.CurrencyId,
                ValueNetto = dto.ValueNetto,
                VatTaxRate = dto.VatTaxRate,
                VatTaxValue = dto.VatTaxValue,
                ValueBrutto = dto.ValueBrutto,
                CustomerId = dto.CustomerId,
                CreationDate = DateTime.UtcNow,
                IsDeleted = false
            };
            _context.InvoiceIncomes.Add(entity);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // PUT: api/InvoiceIncome/Update/{id}
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] InvoiceIncomeDTO dto)
        {
            var entity = await _context.InvoiceIncomes.FindAsync(dto.Id);
            if (entity == null || entity.IsDeleted) return NotFound();

            entity.Name = dto.Name;
            entity.Unit = dto.Unit;
            entity.Quantity = dto.Quantity;
            entity.PriceNetto = dto.PriceNetto;
            entity.CurrencyId = dto.CurrencyId;
            entity.VatTaxRate = dto.VatTaxRate;
            entity.VatTaxRate = dto.VatTaxRate;
            entity.VatTaxValue = dto.VatTaxValue;
            entity.ValueBrutto = dto.ValueBrutto;
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

        [HttpPost("MakeReccuring")]
        public async Task<IActionResult> MakeReccuring([FromBody] ReccuringIncomeInvoiceDTO item)
        {
            var newInvoice = new ReccuringIncomeInvoice
            {
                InvoiceId = item.InvoiceId,
                Description = item.Description,
                Frequency = item.Frequency,
                NextDueDate = DateTime.UtcNow,
                CreationDate = item.CreationDate,
                DeleteDate = item.DeleteDate,
                IsDeleted = item.IsDeleted
            };

            await _context.ReccuringIncomeInvoices.AddAsync(newInvoice);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("GetReccuring")]
        public async Task<ActionResult<IEnumerable<ReccuringIncomeInvoiceDTO>>> GetReccuring()
        {

            var items = await _context.ReccuringIncomeInvoices
               .Where(item => !item.IsDeleted)
               .Select(item => new ReccuringIncomeInvoiceDTO
               {
                   InvoiceId = item.InvoiceId,
                   Description = item.Description,
                   Frequency = item.Frequency,
                   NextDueDate = DateTime.UtcNow,
                   CreationDate = item.CreationDate,
                   DeleteDate = item.DeleteDate,
                   IsDeleted = item.IsDeleted
               })
               .ToListAsync();

            return Ok(items);
        }
    }
}
