using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OMP_API.Models;

public partial class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string Name { get; set; } = null!;

    [Column("surname")]
    [StringLength(255)]
    public string Surname { get; set; } = null!;

    [Column("positionId")]
    public int? PositionId { get; set; }

    [Column("customerId")]
    public int? CustomerId { get; set; }

    [Column("creationDate", TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column("editDate", TypeName = "datetime")]
    public DateTime? EditDate { get; set; }

    [Column("deleteDate", TypeName = "datetime")]
    public DateTime? DeleteDate { get; set; }

    [Column("isDeleted")]
    public bool IsDeleted { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Users")]
    public virtual Customer? Customer { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<GroupMessage> GroupMessages { get; set; } = new List<GroupMessage>();

    [InverseProperty("User")]
    public virtual ICollection<GroupsUser> GroupsUsers { get; set; } = new List<GroupsUser>();

    [InverseProperty("User")]
    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    [InverseProperty("User")]
    public virtual ICollection<NotificationsSubscriber> NotificationsSubscribers { get; set; } = new List<NotificationsSubscriber>();

    [ForeignKey("PositionId")]
    [InverseProperty("Users")]
    public virtual Position? Position { get; set; }

    [InverseProperty("UserRecipient")]
    public virtual ICollection<PrivateMessage> PrivateMessageUserRecipients { get; set; } = new List<PrivateMessage>();

    [InverseProperty("UserSender")]
    public virtual ICollection<PrivateMessage> PrivateMessageUserSenders { get; set; } = new List<PrivateMessage>();

    [InverseProperty("User")]
    public virtual ICollection<SpecialGroupsTicket> SpecialGroupsTickets { get; set; } = new List<SpecialGroupsTicket>();

    [InverseProperty("User")]
    public virtual ICollection<SpecialGroupsUser> SpecialGroupsUsers { get; set; } = new List<SpecialGroupsUser>();

    [InverseProperty("TaskRecipientNavigation")]
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
