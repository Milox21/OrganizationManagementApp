using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Models
{
    public partial class CustomerModule
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("customerId")]
        public int CustomerId { get; set; }

        [Column("moduleId")]
        public int ModuleId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty(nameof(Customer.CustomerModules))]
        public virtual Customer Customer { get; set; } = null!;

        [ForeignKey(nameof(ModuleId))]
        [InverseProperty(nameof(Module.CustomerModules))]
        public virtual Module Module { get; set; } = null!;
    }
}
