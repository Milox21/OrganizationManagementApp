using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Models;

public partial class SpecialGroup
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    [StringLength(255)]
    public string Title { get; set; } = null!;

    [Column("description")]
    public string Description { get; set; } = null!;

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
    [InverseProperty("SpecialGroups")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("SpecialGroup")]
    public virtual ICollection<SpecialGroupsTicket> SpecialGroupsTickets { get; set; } = new List<SpecialGroupsTicket>();

    [InverseProperty("SpecialGroup")]
    public virtual ICollection<SpecialGroupsUser> SpecialGroupsUsers { get; set; } = new List<SpecialGroupsUser>();
}
