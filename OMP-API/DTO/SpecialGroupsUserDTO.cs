using OMP_API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OMP_API.DTO
{
    public class SpecialGroupsUserDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int SpecialGroupId { get; set; }
        public int UserId { get; set; }
        public bool IsOwner { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Customer Customer { get; set; } = null!;
        public virtual SpecialGroup SpecialGroup { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
