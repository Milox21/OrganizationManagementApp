using OMP_API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OMP_API.Models.ModelInterfaces;

namespace OMP_API.DTO
{
    public class InvoiceIncomeDTO : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Unit { get; set; } = null!;
        public decimal Quantity { get; set; }
        public decimal PriceNetto { get; set; }
        public decimal ValueNetto { get; set; }
        public int? VatTax { get; set; }
        public decimal? VatTaxValue { get; set; }
        public decimal? ValueBrutto { get; set; }
        public int CustomerId { get; set; }
        public int? CurrencyId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual CurrencyDTO? Currency { get; set; }
        public virtual CustomerDTO Customer { get; set; } = null!;
        public virtual ICollection<ReccuringIncomeInvoiceDTO> ReccuringIncomeInvoices { get; set; } = new List<ReccuringIncomeInvoiceDTO>();
        public virtual InvoiceTaxRateDTO? VatTaxNavigation { get; set; }
    }
}
