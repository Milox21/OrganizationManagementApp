using OMP_API.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OMP_API.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public int TaskRecipient { get; set; }
        public int TaskSender { get; set; }
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
        public DateTime DeadlineTime { get; set; }
        public DateTime? LateTime { get; set; }
        public DateTime? CompletionTime { get; set; }
        public bool IsMeeting { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual UserDTO TaskRecipientNavigation { get; set; } = null!;
        public virtual GroupDTO TaskSenderNavigation { get; set; } = null!;
    }
}
