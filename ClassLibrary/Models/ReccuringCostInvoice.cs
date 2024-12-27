using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Models;

[Table("ReccuringCostInvoice")]
public partial class ReccuringCostInvoice
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("invoiceId")]
    public int InvoiceId { get; set; }

    [Column("description")]
    public string Description { get; set; } = null!;

    [Column("frequency")]
    [StringLength(50)]
    public string Frequency { get; set; } = null!;

    [Column("nextDueDate", TypeName = "datetime")]
    public DateTime NextDueDate { get; set; }

    [Column("creationDate", TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column("editDate", TypeName = "datetime")]
    public DateTime? EditDate { get; set; }

    [Column("deleteDate", TypeName = "datetime")]
    public DateTime? DeleteDate { get; set; }

    [Column("isDeleted")]
    public bool IsDeleted { get; set; }

    [ForeignKey("InvoiceId")]
    [InverseProperty("ReccuringCostInvoices")]
    public virtual InvoiceCost Invoice { get; set; } = null!;
}
