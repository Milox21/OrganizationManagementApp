using ClassLibrary.Models.ModelInterfaces;
using System;
using System.Text.Json.Serialization;

namespace ClassLibrary.DTO
{
    public class SpecialGroupsTicketDTO : IBaseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userId")]
        public int UserId { get; set; }

        [JsonPropertyName("specialGroupId")]
        public int SpecialGroupId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;

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
    }
}