using ClassLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMP_API.Services;

namespace OMP_API.Controllers
{
    public class CountryController : BaseController<CountryDTO>
    {
        [HttpGet]
        public override async Task<ActionResult<IEnumerable<CountryDTO>>> GetAllAsync()
        {
            var countries = await _context.Countries
                .OrderBy(c => c.Name)
                .Select(item => new CountryDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    CreationDate = item.CreationDate, 
                    EditDate = item.EditDate,
                    DeleteDate = item.DeleteDate,
                    IsDeleted = item.IsDeleted

                }).ToListAsync();

            return Ok(countries);
        }

        [HttpGet("Refresh")]
        public async Task<ActionResult<IEnumerable<CountryDTO>>> RefreshGetAllAsync()
        {
            await SeedingService.RefreshCoutnriesAsync();

            return await GetAllAsync();
        }
    }
}
