using System.Text.Json.Serialization;
using ClassLibrary.Models;
using ClassLibrary.Models.ModelInterfaces;

namespace ClassLibrary.DTO
{
    public class NotificationDTO :IBaseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("notificationSource")]
        public string NotificationSource { get; set; } = null!;

        [JsonPropertyName("notificationText")]
        public string NotificationText { get; set; } = null!;

        [JsonPropertyName("isSeen")]
        public bool IsSeen { get; set; }

        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("editDate")]
        public DateTime? EditDate { get; set; }

        [JsonPropertyName("deleteDate")]
        public DateTime? DeleteDate { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("user")]
        public virtual User User { get; set; } = null!;
    }
}
