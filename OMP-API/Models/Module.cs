using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OMP_API.Models
{
    public partial class Module
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [InverseProperty("Module")]
        public virtual ICollection<CustomerModule> CustomerModules { get; set; } = new List<CustomerModule>();
    }
}
