using System.Text.Json.Serialization;
using ClassLibrary.Models.ModelInterfaces;

namespace ClassLibrary.DTO
{
    public class CurrencyDTO : IBaseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; } = null!;

        [JsonPropertyName("exchange_rate_to_dollar")]
        public decimal ExchangeRateToDollar { get; set; }

        [JsonPropertyName("creation_date")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("edit_date")]
        public DateTime? EditDate { get; set; }

        [JsonPropertyName("delete_date")]
        public DateTime? DeleteDate { get; set; }

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }
    }
}
