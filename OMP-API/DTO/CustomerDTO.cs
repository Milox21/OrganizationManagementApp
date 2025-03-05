using OMP_API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OMP_API.Models.ModelInterfaces;
using System.Text.Json.Serialization;

namespace OMP_API.DTO
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
        public string Email { get; set; } = null!; 

        [JsonPropertyName("phone_contact")]
        public string PhoneContact { get; set; } = null!; 

        [JsonPropertyName("address")]
        public string Address { get; set; } = null!; 

        [JsonPropertyName("location")]
        public string Location { get; set; } = null!;

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
