using Microsoft.AspNetCore.SignalR;

namespace OMP_API.Services
{
    public class TaskChatHub : Hub
    {
        public async Task SendMessageToTask(int taskId, object message)
        {
            await Clients.Group($"Task-{taskId}").SendAsync("ReceiveMessage", message);
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var taskId = httpContext?.Request.Query["taskId"];
            if (int.TryParse(taskId, out int tid))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, $"Task-{tid}");
            }
            await base.OnConnectedAsync();
        }
    }
}
