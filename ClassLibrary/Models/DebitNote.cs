using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Models;

[Table("DebitNote")]
public partial class DebitNote
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    [StringLength(255)]
    public string Title { get; set; } = null!;

    [Column("description")]
    public string Description { get; set; } = null!;

    [Column("value", TypeName = "decimal(10, 2)")]
    public decimal Value { get; set; }

    [Column("currency")]
    [StringLength(10)]
    public string Currency { get; set; } = null!;

    [Column("customerId")]
    public int CustomerId { get; set; }

    [Column("currencyId")]
    public int? CurrencyId { get; set; }

    [Column("creationDate", TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column("editDate", TypeName = "datetime")]
    public DateTime? EditDate { get; set; }

    [Column("deleteDate", TypeName = "datetime")]
    public DateTime? DeleteDate { get; set; }

    [Column("isDeleted")]
    public bool IsDeleted { get; set; }

    [ForeignKey("CurrencyId")]
    [InverseProperty("DebitNotes")]
    public virtual Currency? CurrencyNavigation { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("DebitNotes")]
    public virtual Customer Customer { get; set; } = null!;
}
