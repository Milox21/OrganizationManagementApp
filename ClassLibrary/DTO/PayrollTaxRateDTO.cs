using ClassLibrary.Models.ModelInterfaces;

namespace ClassLibrary.DTO
{
    public class PayrollTaxRateDTO : IBaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Rate { get; set; }
        public string Country { get; set; } = null!;
        public int CustomerId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual CustomerDTO Customer { get; set; } = null!;
    }
}
