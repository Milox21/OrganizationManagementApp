using OMP_API.Models;
using OMP_API.Models.ModelInterfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OMP_API.DTO
{
    public class GroupMessageDTO : IBaseModel
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual GroupDTO Group { get; set; } = null!;
        public virtual UserDTO User { get; set; } = null!;
    }
}
