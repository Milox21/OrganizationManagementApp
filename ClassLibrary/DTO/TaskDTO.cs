using System.Text.Json.Serialization;
using ClassLibrary.Models.ModelInterfaces;

namespace ClassLibrary.DTO
{
    public class TaskDTO : IBaseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("taskRecipient")]
        public int TaskRecipient { get; set; }

        [JsonPropertyName("taskSender")]
        public int TaskSender { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;

        [JsonPropertyName("text")]
        public string Text { get; set; } = null!;

        [JsonPropertyName("deadlineTime")]
        public DateTime DeadlineTime { get; set; }

        [JsonPropertyName("lateTime")]
        public DateTime? LateTime { get; set; }

        [JsonPropertyName("completionTime")]
        public DateTime? CompletionTime { get; set; }

        [JsonPropertyName("isMeeting")]
        public bool IsMeeting { get; set; }

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
