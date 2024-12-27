using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary.Models;

public partial class PrivateMessage
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("userSenderId")]
    public int UserSenderId { get; set; }

    [Column("userRecipientId")]
    public int UserRecipientId { get; set; }

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

    [ForeignKey("UserRecipientId")]
    [InverseProperty("PrivateMessageUserRecipients")]
    public virtual User UserRecipient { get; set; } = null!;

    [ForeignKey("UserSenderId")]
    [InverseProperty("PrivateMessageUserSenders")]
    public virtual User UserSender { get; set; } = null!;
}
