using System.Text.Json.Serialization;
using ClassLibrary.Models.ModelInterfaces;

namespace ClassLibrary.DTO
{
    public class CustomerDTO : IBaseModel
    {

        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;
        [JsonPropertyName("password")]
        public string Password { get; set; } = null!;

        [JsonPropertyName("email")]
        public string Email { get; set; } 

        [JsonPropertyName("phone_contact")]
        public string PhoneContact { get; set; } 

        [JsonPropertyName("address")]
        public string Address { get; set; } 

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }
        [JsonPropertyName("editDate")]
        public DateTime? EditDate { get; set; }
        [JsonPropertyName("deleteDate")]
        public DateTime? DeleteDate { get; set; }
        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }
        [JsonPropertyName("Modules")]
        public virtual ICollection<ModuleDTO> Modules { get; set; } = new List<ModuleDTO>();

    }
}
