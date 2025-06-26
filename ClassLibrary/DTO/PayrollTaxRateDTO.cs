using System.Text.Json.Serialization;
using ClassLibrary.Models.ModelInterfaces;

namespace ClassLibrary.DTO
{
    public class PayrollTaxRateDTO : IBaseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        [JsonPropertyName("rate")]
        public decimal Rate { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; } = null!;

        [JsonPropertyName("customerId")]
        public int CustomerId { get; set; }

        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("editDate")]
        public DateTime? EditDate { get; set; }

        [JsonPropertyName("deleteDate")]
        public DateTime? DeleteDate { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("customer")]
        public virtual CustomerDTO Customer { get; set; } = null!;
    }
}
