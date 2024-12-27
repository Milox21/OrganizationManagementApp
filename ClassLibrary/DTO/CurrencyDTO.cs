using ClassLibrary.Models.ModelInterfaces;

namespace ClassLibrary.DTO
{
    public class CurrencyDTO : IBaseModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public decimal ExchangeRateToDollar { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
