using System.Text.Json.Serialization;
using ClassLibrary.Models.ModelInterfaces;

namespace ClassLibrary.DTO
{
    public class CountryDTO : IBaseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

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