using System.Text.Json.Serialization;
using ClassLibrary.Models.ModelInterfaces;

namespace ClassLibrary.DTO
{
    public class ContractTypeDTO : IBaseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;

        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;

        [JsonPropertyName("baseRatePerHourBrutto")]
        public decimal BaseRatePerHourBrutto { get; set; }

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
    }
}
