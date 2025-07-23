using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OMP_API.Models
{
    [Table("TaskMessages")]
    public class TaskMessage
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_sender_id")]
        public int UserSenderId { get; set; }

        [Column("task_id")]
        public int TaskId { get; set; }

        [Required]
        [Column("text")]
        public string Text { get; set; } = null!;

        [Column("creation_date")]
        public DateTime CreationDate { get; set; }

        [Column("edit_date")]
        public DateTime? EditDate { get; set; }

        [Column("delete_date")]
        public DateTime? DeleteDate { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        // Optional: Navigation properties
        [ForeignKey("UserSenderId")]
        public virtual User? UserSender { get; set; }

        [ForeignKey("TaskId")]
        public virtual Task? Task { get; set; }
    }

}
