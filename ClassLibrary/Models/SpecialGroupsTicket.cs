using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Models;

public partial class SpecialGroupsTicket
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("userId")]
    public int UserId { get; set; }

    [Column("specialGroupId")]
    public int SpecialGroupId { get; set; }

    [Column("title")]
    [StringLength(255)]
    public string Title { get; set; } = null!;

    [Column("text")]
    public string Text { get; set; } = null!;

    [Column("creationDate", TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column("editDate", TypeName = "datetime")]
    public DateTime? EditDate { get; set; }

    [Column("deleteDate", TypeName = "datetime")]
    public DateTime? DeleteDate { get; set; }

    [Column("isDeleted")]
    public bool IsDeleted { get; set; }

    [ForeignKey("SpecialGroupId")]
    [InverseProperty("SpecialGroupsTickets")]
    public virtual SpecialGroup SpecialGroup { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("SpecialGroupsTickets")]
    public virtual User User { get; set; } = null!;
}
