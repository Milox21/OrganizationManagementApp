using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Models;

public partial class Error
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("topic")]
    [StringLength(255)]
    public string Topic { get; set; } = null!;

    [Column("text")]
    public string Text { get; set; } = null!;

    [Column("customerId")]
    public int CustomerId { get; set; }

    [Column("creationDate", TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column("editDate", TypeName = "datetime")]
    public DateTime? EditDate { get; set; }

    [Column("deleteDate", TypeName = "datetime")]
    public DateTime? DeleteDate { get; set; }

    [Column("isDeleted")]
    public bool IsDeleted { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Errors")]
    public virtual Customer Customer { get; set; } = null!;
}
