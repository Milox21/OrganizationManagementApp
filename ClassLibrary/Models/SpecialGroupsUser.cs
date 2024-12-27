using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Models;

public partial class SpecialGroupsUser
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("customerId")]
    public int CustomerId { get; set; }

    [Column("specialGroupId")]
    public int SpecialGroupId { get; set; }

    [Column("userId")]
    public int UserId { get; set; }

    [Column("isOwner")]
    public bool IsOwner { get; set; }

    [Column("creationDate", TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column("editDate", TypeName = "datetime")]
    public DateTime? EditDate { get; set; }

    [Column("deleteDate", TypeName = "datetime")]
    public DateTime? DeleteDate { get; set; }

    [Column("isDeleted")]
    public bool IsDeleted { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("SpecialGroupsUsers")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("SpecialGroupId")]
    [InverseProperty("SpecialGroupsUsers")]
    public virtual SpecialGroup SpecialGroup { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("SpecialGroupsUsers")]
    public virtual User User { get; set; } = null!;
}
