using ClassLibrary.DTO;
using OMP_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMP_API.Models.Contexts;

namespace OMP_API.Controllers
{
    [Route("api/[controller]")]
    public class TaxController : Controller
    {
        public readonly DatabaseContext _context;
        public TaxController()
        {
            _context = new();
        }

        [HttpGet("GetInvoiceTaxRates/{customerId}")]
        public async Task<ActionResult<IEnumerable<InvoiceTaxRateDTO>>> GetInvoiceTaxRates(int customerId)
        {
            var rates = await _context.InvoiceTaxRates
                .Where(r => r.CustomerId == customerId)
                .Select(r => new InvoiceTaxRateDTO
                {
                    Id = r.Id,
                    Title = r.Title,
                    Type = r.Type,
                    Rate = r.Rate,
                    Country = r.Country,
                    CustomerId = r.CustomerId,
                    CreationDate = DateTime.Now,
                    IsDeleted = false
                })
                .ToListAsync();

            return rates;
        }

        [HttpGet("GetPayrollTaxRates/{customerId}")]
        public async Task<ActionResult<IEnumerable<PayrollTaxRateDTO>>> GetPayrollTaxRates(int customerId)
        {
            var rates = await _context.PayrollTaxRates
                .Where(r => r.CustomerId == customerId)
                .Select(r => new PayrollTaxRateDTO
                {
                    Id = r.Id,
                    Title = r.Title,
                    Description = r.Description,
                    Rate = r.Rate,
                    Country = r.Country,
                    CustomerId = r.CustomerId,
                })
                .ToListAsync();

            return rates;
        }

        [HttpPost("AddInvoice/{customerId}")]
        public async Task<ActionResult<InvoiceTaxRateDTO>> AddInvoice(int customerId, [FromBody] InvoiceTaxRateDTO dto)
        {
            if (dto == null) return BadRequest("Invalid data.");

            var entity = new InvoiceTaxRate
            {
                Title = dto.Title,
                Type = dto.Type,
                Rate = dto.Rate,
                Country = dto.Country,
                CustomerId = customerId,
                CreationDate = DateTime.Now,
                IsDeleted = false
            };

            if (entity != null)
            {
                _context.InvoiceTaxRates.Add(entity);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("AddPayroll/{customerId}")]
        public async Task<ActionResult<PayrollTaxRateDTO>> AddPayroll(int customerId, [FromBody] PayrollTaxRateDTO dto)
        {
            if (dto == null) return BadRequest("Invalid data.");

            var entity = new PayrollTaxRate
            {
                Title = dto.Title,
                Description = dto.Description,
                Rate = dto.Rate,
                Country = dto.Country,
                CustomerId = customerId,
                CreationDate = DateTime.Now,
                IsDeleted = false
            };

            _context.PayrollTaxRates.Add(entity);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("UpdatePayroll/{id}")]
        public async Task<IActionResult> UpdatePayroll(int id, [FromBody] PayrollTaxRateDTO dto)
        {
            var entity = await _context.PayrollTaxRates.FindAsync(id);
            if (entity == null)
                return NotFound();

            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.Rate = dto.Rate;
            entity.Country = dto.Country;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("UpdateInvoice/{id}")]
        public async Task<IActionResult> UpdateInvoice(int id, [FromBody] InvoiceTaxRateDTO dto)
        {
            var entity = await _context.InvoiceTaxRates.FindAsync(id);
            if (entity == null)
                return NotFound();

            entity.Title = dto.Title;
            entity.Type = dto.Type;
            entity.Rate = dto.Rate;
            entity.Country = dto.Country;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("DeletePayroll/{id}")]
        public async Task<IActionResult> DeletePayroll(int id)
        {
            var entity = await _context.PayrollTaxRates.FindAsync(id);
            if (entity == null)
                return NotFound();

            _context.PayrollTaxRates.Remove(entity);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("DeleteInvoice/{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var entity = await _context.InvoiceTaxRates.FindAsync(id);
            if (entity == null)
                return NotFound();

            _context.InvoiceTaxRates.Remove(entity);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
