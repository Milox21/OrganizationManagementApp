using ClassLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMP_API.Services;

namespace OMP_API.Controllers
{
    public class CurrencyController : BaseController<CurrencyDTO>
    {
        [HttpGet]
        public override async Task<ActionResult<IEnumerable<CurrencyDTO>>> GetAllAsync()
        {
            var currencies = await _context.Currencies
                .OrderBy(c => c.Code)
                .Select(c => new CurrencyDTO
                {
                    Id = c.Id,
                    Code = c.Code,
                    ExchangeRateToDollar = c.ExchangeRateToDollar,
                    CreationDate = c.CreationDate,
                    EditDate = c.EditDate,
                    DeleteDate = c.DeleteDate,
                    IsDeleted = c.IsDeleted
                })
                .ToListAsync();

            return Ok(currencies);
        }

        [HttpGet("Refresh")]
        public async Task<ActionResult<IEnumerable<CurrencyDTO>>> RefreshGetAllAsync()
        {
            await SeedingService.RefreshCurrenciesAsync();

            return await GetAllAsync();
        }
    }
}
