using ClassLibrary.Models.ModelInterfaces;

namespace ClassLibrary.DTO
{
    public class DebitNoteDTO : IBaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Value { get; set; }
        public string Currency { get; set; } = null!;
        public int CustomerId { get; set; }
        public int? CurrencyId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual CurrencyDTO? CurrencyNavigation { get; set; }
        public virtual CustomerDTO Customer { get; set; } = null!;
    }
}
