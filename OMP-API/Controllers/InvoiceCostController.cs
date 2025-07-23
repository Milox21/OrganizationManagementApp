using ClassLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMP_API.Models;
using OMP_API.Models.Contexts;


namespace OMP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceCostController : BaseController<InvoiceCostDTO>
    {
        private readonly DatabaseContext _context;
        public InvoiceCostController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll/{customerId}")]
        public async Task<ActionResult<IEnumerable<InvoiceCostDTO>>> GetAll(int customerId)
        {
            var items = await _context.InvoiceCosts
                .Where(i => i.CustomerId == customerId && !i.IsDeleted)
                .OrderBy(i => i.CreationDate)
                .Select(i => new InvoiceCostDTO
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

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] InvoiceCostDTO dto)
        {
            var entity = new InvoiceCost
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
            _context.InvoiceCosts.Add(entity);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] InvoiceCostDTO dto)
        {
            var entity = await _context.InvoiceCosts.FindAsync(dto.Id);
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

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.InvoiceCosts.FindAsync(id);
            if (entity == null || entity.IsDeleted) return NotFound();

            entity.IsDeleted = true;
            entity.DeleteDate = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("MakeReccuring")]
        public async Task<IActionResult> MakeReccuring([FromBody] ReccuringCostInvoiceDTO item)
        {
            var newInvoice = new ReccuringCostInvoice
            {
                InvoiceId = item.InvoiceId,
                Description = item.Description,
                Frequency = item.Frequency,
                NextDueDate = DateTime.UtcNow,
                CreationDate = item.CreationDate,
                DeleteDate = item.DeleteDate,
                IsDeleted = item.IsDeleted,
            };

            await _context.ReccuringCostInvoices.AddAsync(newInvoice);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("GetReccuring")]
        public async Task<ActionResult<IEnumerable<ReccuringCostInvoiceDTO>>> GetReccuring()
        {

            var items = await _context.ReccuringCostInvoices
               .Where(item => !item.IsDeleted)
               .Select(item => new ReccuringCostInvoiceDTO
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
