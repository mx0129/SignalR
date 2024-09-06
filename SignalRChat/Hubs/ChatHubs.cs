using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            Context.Items.Add(Context.ConnectionId+DateTime.Now.ToString(), message);
            await Clients.All.SendAsync("ReceiveMessage", $"[{user}]", message);
        }
        public async Task Login(string user)
        {
            Context.Items.Add(Context.ConnectionId, "user");
           await Clients.All.SendAsync("LoginMessage", $"[{user}] 加入了聊天~~~");
        }
        public async Task Exit(string user)
        {
            await Clients.All.SendAsync("ExitMessage", $"[{user}] 退出了聊天~~~");
        }
    }
}