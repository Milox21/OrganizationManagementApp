using System.Text.Json.Serialization;
using ClassLibrary.Models.ModelInterfaces;

namespace ClassLibrary.DTO
{
    public class UserDTO : IBaseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("identityUserId")]
        public string IdentityUserId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } 

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("role")]
        public string? Role { get; set; }

        [JsonPropertyName("positionId")]
        public int? PositionId { get; set; }

        [JsonPropertyName("customerId")]
        public int CustomerId { get; set; }

        [JsonPropertyName("countryId")]
        public int? CountryId { get; set; }

        [JsonPropertyName("companyName")]
        public string? CompanyName { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonPropertyName("editDate")]
        public DateTime? EditDate { get; set; }

        [JsonPropertyName("deleteDate")]
        public DateTime? DeleteDate { get; set; }

        [JsonPropertyName("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonPropertyName("country")]
        public virtual CountryDTO? Country { get; set; }

        [JsonPropertyName("customer")]
        public virtual CustomerDTO? Customer { get; set; } 

        [JsonPropertyName("groupMessages")]
        public virtual ICollection<GroupMessageDTO>? GroupMessages { get; set; } = new List<GroupMessageDTO>();

        [JsonPropertyName("groupsUsers")]
        public virtual ICollection<GroupsUserDTO>? GroupsUsers { get; set; } = new List<GroupsUserDTO>();

        [JsonPropertyName("notifications")]
        public virtual ICollection<NotificationDTO>? Notifications { get; set; } = new List<NotificationDTO>();

        [JsonPropertyName("position")]
        public virtual PositionDTO? Position { get; set; }

        [JsonPropertyName("privateMessageUserRecipients")]
        public virtual ICollection<PrivateMessageDTO>? PrivateMessageUserRecipients { get; set; } = new List<PrivateMessageDTO>();

        [JsonPropertyName("privateMessageUserSenders")]
        public virtual ICollection<PrivateMessageDTO>? PrivateMessageUserSenders { get; set; } = new List<PrivateMessageDTO>();

        [JsonPropertyName("specialGroupsTickets")]
        public virtual ICollection<SpecialGroupsTicketDTO>? SpecialGroupsTickets { get; set; } = new List<SpecialGroupsTicketDTO>();

        [JsonPropertyName("tasks")]
        public virtual ICollection<TaskDTO>? Tasks { get; set; } = new List<TaskDTO>();
    }
}
