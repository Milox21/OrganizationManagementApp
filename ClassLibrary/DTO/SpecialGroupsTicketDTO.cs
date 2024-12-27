using ClassLibrary.Models.ModelInterfaces;

namespace ClassLibrary.DTO
{
    public class SpecialGroupsTicketDTO : IBaseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SpecialGroupId { get; set; }
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual SpecialGroupDTO SpecialGroup { get; set; } = null!;
        public virtual UserDTO User { get; set; } = null!;
    }
}
