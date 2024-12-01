using OMP_API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OMP_API.Models.ModelInterfaces;

namespace OMP_API.DTO
{
    public class InvoiceTaxRateDTO : IBaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!;
        public decimal Rate { get; set; }
        public string Country { get; set; } = null!;
        public int CustomerId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual CustomerDTO Customer { get; set; } = null!;
        public virtual ICollection<InvoiceCostDTO> InvoiceCosts { get; set; } = new List<InvoiceCostDTO>();
        public virtual ICollection<InvoiceIncomeDTO> InvoiceIncomes { get; set; } = new List<InvoiceIncomeDTO>();
    }
}
