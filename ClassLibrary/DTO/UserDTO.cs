using ClassLibrary.Models.ModelInterfaces;

namespace ClassLibrary.DTO
{
    public class UserDTO : IBaseModel
    {
        public int Id { get; set; }
        public string IdentityUserId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int? PositionId { get; set; }
        public int CustomerId { get; set; }
        public int? CountryId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual CountryDTO? Country { get; set; }
        public virtual CustomerDTO Customer { get; set; } = null!;
        public virtual ICollection<GroupMessageDTO> GroupMessages { get; set; } = new List<GroupMessageDTO>();
        public virtual ICollection<GroupsUserDTO> GroupsUsers { get; set; } = new List<GroupsUserDTO>();
        public virtual ICollection<NotificationDTO> Notifications { get; set; } = new List<NotificationDTO>();
        public virtual PositionDTO? Position { get; set; }
        public virtual ICollection<PrivateMessageDTO> PrivateMessageUserRecipients { get; set; } = new List<PrivateMessageDTO>();
        public virtual ICollection<PrivateMessageDTO> PrivateMessageUserSenders { get; set; } = new List<PrivateMessageDTO>();
        public virtual ICollection<SpecialGroupsTicketDTO> SpecialGroupsTickets { get; set; } = new List<SpecialGroupsTicketDTO>();
        public virtual ICollection<TaskDTO> Tasks { get; set; } = new List<TaskDTO>();
    }
}
