using OMP_API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OMP_API.Models.ModelInterfaces;

namespace OMP_API.DTO
{
    public class ReccuringIncomeInvoiceDTO : IBaseModel
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string Description { get; set; } = null!;
        public string Frequency { get; set; } = null!;
        public DateTime NextDueDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual InvoiceIncomeDTO Invoice { get; set; } = null!;
    }
}
