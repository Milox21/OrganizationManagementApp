using ClassLibrary.Models.ModelInterfaces;

namespace ClassLibrary.DTO
{
    public class ReccuringCostInvoiceDTO : IBaseModel
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
        public virtual InvoiceCostDTO Invoice { get; set; } = null!;
    }
}
