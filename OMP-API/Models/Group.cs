using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OMP_API.Models;

public partial class Group
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
    [InverseProperty("Groups")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("Group")]
    public virtual ICollection<GroupMessage> GroupMessages { get; set; } = new List<GroupMessage>();

    [InverseProperty("Group")]
    public virtual ICollection<GroupsUser> GroupsUsers { get; set; } = new List<GroupsUser>();

    [InverseProperty("TaskSenderNavigation")]
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
