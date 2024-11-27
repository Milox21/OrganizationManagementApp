using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OMP_API.Models;

public partial class Task
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    public int TaskRecipient { get; set; }

    public int TaskSender { get; set; }

    [Column("title")]
    [StringLength(255)]
    public string Title { get; set; } = null!;

    [Column("text")]
    public string Text { get; set; } = null!;

    [Column("deadlineTime", TypeName = "datetime")]
    public DateTime DeadlineTime { get; set; }

    [Column("lateTime", TypeName = "datetime")]
    public DateTime? LateTime { get; set; }

    [Column("completionTime", TypeName = "datetime")]
    public DateTime? CompletionTime { get; set; }

    [Column("isMeeting")]
    public bool IsMeeting { get; set; }

    [Column("creationDate", TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column("editDate", TypeName = "datetime")]
    public DateTime? EditDate { get; set; }

    [Column("deleteDate", TypeName = "datetime")]
    public DateTime? DeleteDate { get; set; }

    [Column("isDeleted")]
    public bool IsDeleted { get; set; }

    [ForeignKey("TaskRecipient")]
    [InverseProperty("Tasks")]
    public virtual User TaskRecipientNavigation { get; set; } = null!;

    [ForeignKey("TaskSender")]
    [InverseProperty("Tasks")]
    public virtual Group TaskSenderNavigation { get; set; } = null!;
}
