using ClassLibrary.Models.ModelInterfaces;

namespace ClassLibrary.DTO
{
    public class GroupDTO : IBaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int CustomerId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual CustomerDTO Customer { get; set; } = null!;
        public virtual ICollection<GroupMessageDTO> GroupMessages { get; set; } = new List<GroupMessageDTO>();
        public virtual ICollection<GroupsUserDTO> GroupsUsers { get; set; } = new List<GroupsUserDTO>();
        public virtual ICollection<TaskDTO> Tasks { get; set; } = new List<TaskDTO>();
    }
}
