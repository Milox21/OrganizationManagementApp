using OMP_API.Models;
using OMP_API.Models.ModelInterfaces;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OMP_API.DTO
{
    public class ErrorDTO : IBaseModel
    {
        public int Id { get; set; }
        public string Topic { get; set; } = null!;
        public string Text { get; set; } = null!;
        public int CustomerId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual CustomerDTO Customer { get; set; } = null!;
    }
}
