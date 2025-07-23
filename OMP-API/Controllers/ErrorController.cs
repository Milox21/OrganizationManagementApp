using System;
using ClassLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OMP_API.Models;
using OMP_API.Models.Contexts;

namespace OMP_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ErrorController(DatabaseContext context)
        {
            _context = context;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<ErrorDTO>>> GetAll()
        {
            var errors = await _context.Errors
                .Where(e => !e.IsDeleted)
                .Include(e => e.Customer)
                .Select(e => new ErrorDTO
                {
                    Id = e.Id,
                    Topic = e.Topic,
                    Text = e.Text,
                    CompanyName = e.Customer.Name,
                    CreationDate = e.CreationDate,
                    IsDeleted = e.IsDeleted,
                    EditDate = e.EditDate,
                    DeleteDate = e.DeleteDate
                })
                .ToListAsync();

            return Ok(errors);
        }

        [HttpPost("Post")]
        public async Task<ActionResult> Post([FromBody] ErrorDTO dto)
        {
            var error = new Error
            {
                Id= dto.Id,
                Topic = dto.Topic,
                Text = dto.Text,
                CustomerId = dto.CustomerId, // Replace with your logic
                CreationDate = DateTime.Now,
                IsDeleted = false
            };

            _context.Errors.Add(error);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var error = await _context.Errors.FindAsync(id);
            if (error == null)
                return NotFound();

            error.IsDeleted = true;
            error.DeleteDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
