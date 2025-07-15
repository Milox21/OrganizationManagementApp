using System.Text.Json.Serialization;
using ClassLibrary.Models.ModelInterfaces;

namespace ClassLibrary.DTO
{
    public class GroupMessageDTO : IBaseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; } = null!;

        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("editDate")]
        public DateTime? EditDate { get; set; }

        [JsonPropertyName("deleteDate")]
        public DateTime? DeleteDate { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("groupId")]
        public int GroupID { get; set; }

        [JsonPropertyName("userId")]
        public int UserID { get; set; }

        [JsonPropertyName("group")]
        public GroupDTO? Group { get; set; }

        [JsonPropertyName("user")]
        public UserDTO? User { get; set; }
    }
}
