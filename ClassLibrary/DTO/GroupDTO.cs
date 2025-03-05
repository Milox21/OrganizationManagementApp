using System.Text.Json.Serialization;
using ClassLibrary.Models.ModelInterfaces;

namespace ClassLibrary.DTO
{
    public class GroupDTO : IBaseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        [JsonPropertyName("customer_id")]
        public int CustomerId { get; set; }

        [JsonPropertyName("creation_date")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("edit_date")]
        public DateTime? EditDate { get; set; }

        [JsonPropertyName("delete_date")]
        public DateTime? DeleteDate { get; set; }

        [JsonPropertyName("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("group_messages")]
        public virtual ICollection<GroupMessageDTO>? GroupMessages { get; set; } = new List<GroupMessageDTO>();

        [JsonPropertyName("groups_users")]
        public virtual ICollection<GroupsUserDTO>? GroupsUsers { get; set; } = new List<GroupsUserDTO>();

        [JsonPropertyName("tasks")]
        public virtual ICollection<TaskDTO>? Tasks { get; set; } = new List<TaskDTO>();
    }
}
