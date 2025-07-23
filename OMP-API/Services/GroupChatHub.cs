using ClassLibrary.DTO;
using Microsoft.AspNetCore.SignalR;
using OMP_API.Models.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

public class GroupChatHub : Hub
{
    private readonly DatabaseContext _context;

    public GroupChatHub(DatabaseContext context)
    {
        _context = context;
    }

    public async Task SendMessage(GroupMessageDTO messageDTO)
    {
        var message = new OMP_API.Models.GroupMessage
        {
            Text = messageDTO.Text,
            CreationDate = DateTime.UtcNow,
            EditDate = null,
            DeleteDate = null,
            IsDeleted = false,
            GroupId = messageDTO.GroupID,
            UserId = messageDTO.UserID
        };

        _context.GroupMessages.Add(message);
        await _context.SaveChangesAsync();

        var user = await _context.Users.FindAsync(message.UserId);
        var group = await _context.Groups.FindAsync(message.GroupId);

        var fullDto = new GroupMessageDTO
        {
            Id = message.Id,
            Text = message.Text,
            CreationDate = message.CreationDate,
            EditDate = message.EditDate,
            DeleteDate = message.DeleteDate,
            IsDeleted = message.IsDeleted,
            GroupID = message.GroupId,
            UserID = message.UserId,
            User = new UserDTO { Id = user.Id, Name = user.Name, Surname = user.Surname },
            Group = new GroupDTO { Id = group.Id, Title = group.Title }
        };

        // Step 3: Broadcast to group
        await Clients.Group(message.GroupId.ToString())
                     .SendAsync("ReceiveMessage", fullDto);
    }

    public override async Task OnConnectedAsync()
    {
        var httpContext = Context.GetHttpContext();
        var groupId = httpContext?.Request.Query["groupId"];

        if (!string.IsNullOrEmpty(groupId))
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
        }

        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var httpContext = Context.GetHttpContext();
        var groupId = httpContext?.Request.Query["groupId"];

        if (!string.IsNullOrEmpty(groupId))
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupId);
        }

        await base.OnDisconnectedAsync(exception);
    }
}
