using Microsoft.AspNetCore.Mvc;
using OMP_API.Models.Contexts;
using ClassLibrary.DTO;
using Microsoft.EntityFrameworkCore;

namespace OMP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FMSummaryController : Controller
    {
        public readonly DatabaseContext _context;
        public FMSummaryController()
        {
            _context = new();
        }


        [HttpGet("GetAll/{customerId}/{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<FMSummaryDTO>>> GetAll(int customerId, DateTime startDate, DateTime endDate)
        {
            var IncomeOccurance = await _context.ReccuringIncomeInvoices.Where(i => i.IsDeleted != true).ToListAsync();
            var CostOccurance = await _context.ReccuringCostInvoices.Where(i => i.IsDeleted != true).ToListAsync();
            //Debit note
            var DebitNotes = await _context.DebitNotes
                .Include(d => d.CurrencyNavigation)
                .Where(d => d.CustomerId == customerId && !d.IsDeleted)
                .OrderBy(d => d.CreationDate)
                .Select(d => new DebitNoteDTO
                {
                    Id = d.Id,
                    Title = d.Title,
                    Description = d.Description,
                    Value = d.Value,
                    CurrencyId = d.CurrencyId,
                    CustomerId = d.CustomerId,
                    CreationDate = d.CreationDate,
                    EditDate = d.EditDate,
                    DeleteDate = d.DeleteDate,
                    IsDeleted = d.IsDeleted,
                    Currency = "0",
                    CurrencyNavigation = d.CurrencyNavigation != null
                    ? new CurrencyDTO
                    {
                        Id = d.CurrencyNavigation.Id,
                        Code = d.CurrencyNavigation.Code
                    }
                    : null,
                })

                .ToListAsync();

            //Income
            var IncomeInvoices = await _context.InvoiceIncomes
                .Where(i => i.CustomerId == customerId
                    && !i.IsDeleted
                    && i.CreationDate >= startDate
                    && i.CreationDate <= endDate)
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

            //Cost
            var CostInvoices = await _context.InvoiceCosts
            .Where(i => i.CustomerId == customerId
                && !i.IsDeleted
                && i.CreationDate >= startDate
                && i.CreationDate <= endDate)
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

            //Payroll
            var items = await _context.Payrolls
                .Include(p => p.Currency)
                .Include(p => p.ContractTypeNavigation)
                .Where(i => i.CustomerId == customerId
                    && !i.IsDeleted
                    && i.CreationDate >= startDate
                    && i.CreationDate <= endDate)
                .OrderBy(p => p.CreationDate)
                .ToListAsync();

            var Payrolls = items.Select(p => new PayrollDTO
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

            //Meging 
            List<FMSummaryDTO> CompleateSummary = new();


            CompleateSummary.AddRange(DebitNotes.Select(i => new FMSummaryDTO
            {
                DatabaseId = i.Id,
                Type = "Debit Note",
                Title = $"{i.Title} (Debit Note)",
                Occurance = 1,
                Brutto = i.Value,
                Netto = i.Value,
                Tax = 0,
                TaxValue = 0,
                CurrencyId = i.CurrencyId,
                CreationDate = i.CreationDate
            }));

            CompleateSummary.AddRange(IncomeInvoices.Select(i =>
            {
                var occurance = IncomeOccurance.FirstOrDefault(o => o.InvoiceId == i.Id);

                int occuranceCount = 1; // default

                if (occurance != null)
                {
                    DateTime effectiveStart = occurance.CreationDate > startDate ? occurance.CreationDate : startDate;
                    DateTime effectiveEnd = (occurance.DeleteDate.HasValue && occurance.DeleteDate.Value < endDate)
                                            ? occurance.DeleteDate.Value : endDate;

                    if (effectiveEnd > effectiveStart && int.TryParse(occurance.Frequency, out int freq) && freq > 0)
                    {
                        int monthsDiff = ((effectiveEnd.Year - effectiveStart.Year) * 12) + effectiveEnd.Month - effectiveStart.Month;
                        occuranceCount = (monthsDiff / freq) + 1; // +1 to count the start month
                    }
                }

                return new FMSummaryDTO
                {
                    DatabaseId = i.Id,
                    Type = "Income",
                    Title = $"{i.Name} (Income)",
                    Occurance = occuranceCount,
                    Brutto = Math.Round(i.ValueBrutto.GetValueOrDefault() * occuranceCount, 2, MidpointRounding.AwayFromZero),
                    Netto = Math.Round(i.ValueNetto * occuranceCount, 2, MidpointRounding.AwayFromZero),
                    Tax = Math.Round(i.VatTaxRate.GetValueOrDefault(), 2, MidpointRounding.AwayFromZero),
                    TaxValue = Math.Round(i.VatTaxValue.GetValueOrDefault() * occuranceCount, 2, MidpointRounding.AwayFromZero),
                    CurrencyId = i.CurrencyId,
                    CreationDate = i.CreationDate
                };
            }));

            CompleateSummary.AddRange(CostInvoices.Select(i =>
            {
                var occurance = CostOccurance.FirstOrDefault(o => o.InvoiceId == i.Id);

                int occuranceCount = 1;

                if (occurance != null)
                {
                    DateTime effectiveStart = occurance.CreationDate > startDate ? occurance.CreationDate : startDate;
                    DateTime effectiveEnd = (occurance.DeleteDate.HasValue && occurance.DeleteDate.Value < endDate)
                                            ? occurance.DeleteDate.Value : endDate;

                    if (effectiveEnd > effectiveStart && int.TryParse(occurance.Frequency, out int freq) && freq > 0)
                    {
                        int monthsDiff = ((effectiveEnd.Year - effectiveStart.Year) * 12) + effectiveEnd.Month - effectiveStart.Month;
                        occuranceCount = (monthsDiff / freq) + 1;
                    }
                }

                return new FMSummaryDTO
                {
                    DatabaseId = i.Id,
                    Type = "Cost",
                    Title = $"{i.Name} (Cost)",
                    Occurance = occuranceCount,
                    Brutto = Math.Round(i.ValueBrutto.GetValueOrDefault() * occuranceCount, 2, MidpointRounding.AwayFromZero),
                    Netto = Math.Round(i.ValueNetto * occuranceCount, 2, MidpointRounding.AwayFromZero),
                    Tax = Math.Round(i.VatTaxRate.GetValueOrDefault(), 2, MidpointRounding.AwayFromZero),
                    TaxValue = Math.Round(i.VatTaxValue.GetValueOrDefault() * occuranceCount, 2, MidpointRounding.AwayFromZero),
                    CurrencyId = i.CurrencyId,
                    CreationDate = i.CreationDate
                };
            }));

            foreach (var p in Payrolls)
            {
                // Determine when the payroll is active
                var payrollStart = p.CreationDate.Date;
                var payrollEnd = p.DeleteDate?.Date ?? endDate.Date;

                // Skip payrolls that are completely outside the range
                if (payrollEnd < startDate || payrollStart > endDate)
                    continue;

                // Determine effective range to calculate occurance
                var effectiveStart = payrollStart > startDate ? payrollStart : startDate;
                var effectiveEnd = payrollEnd < endDate ? payrollEnd : endDate;

                // Count number of full months with payment day (8th)
                int occurance = 0;
                var current = new DateTime(effectiveStart.Year, effectiveStart.Month, 8);
                var last = new DateTime(effectiveEnd.Year, effectiveEnd.Month, 8);

                while (current <= last)
                {
                    if (current >= effectiveStart && current <= effectiveEnd)
                        occurance++;

                    current = current.AddMonths(1);
                }

                if (occurance == 0)
                    continue; // Skip if not active in range

                var brutto = p.RatePerHourBrutto * p.Hours;
                var taxRate = p.TaxRate;
                var netto = taxRate != 0 ? brutto / (1 + (taxRate / 100)) : brutto;
                var taxValue = brutto - netto;

                CompleateSummary.Add(new FMSummaryDTO
                {
                    DatabaseId = p.Id,
                    Type = "Payroll",
                    Title = $"{p.Name} {p.Surname} ({p.ContractTypeNavigation?.Title})",
                    Occurance = occurance,
                    Brutto = Math.Round(brutto * occurance, 2, MidpointRounding.AwayFromZero),
                    Netto = Math.Round(netto * occurance, 2, MidpointRounding.AwayFromZero),
                    Tax = Math.Round(taxRate, 2, MidpointRounding.AwayFromZero),
                    TaxValue = Math.Round(taxValue * occurance, 2, MidpointRounding.AwayFromZero),
                    CurrencyId = p.CurrencyId,
                    CreationDate = p.CreationDate
                });
            }

            return Ok(CompleateSummary);
        }
    }
}
