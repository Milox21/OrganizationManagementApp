

using System.Text.Json.Serialization;
using OMP_API.Models.ModelInterfaces;

namespace OMP_API.DTO
{
    public class ModuleDTO : IBaseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
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
