using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ClassLibrary.DTO
{
    public class TaskMessageDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userSenderId")]
        public int UserSenderId { get; set; }

        [JsonPropertyName("taskId")]
        public int TaskId { get; set; }

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

        [JsonPropertyName("username")]
        public string? Username { get; set; } // Optional for UI
    }

}
