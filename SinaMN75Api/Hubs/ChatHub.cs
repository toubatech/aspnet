using Microsoft.AspNetCore.SignalR;
using SinaMN75Api.Core;

namespace SinaMN75Api.Hubs
{
    public class ChatHub : Hub
    {
        private readonly AppDbContext _context;
        public ChatHub(AppDbContext db)
        {
            _context = db;
        }

        public async Task SendMessageToReceiver(string sender, string receiver, string message)
        {
            var userId = _context.Users.FirstOrDefault(u => u.Id.ToLower() == receiver.ToLower()).Id;

            if (!string.IsNullOrEmpty(userId))
            {
                await Clients.User(userId).SendAsync("MessageReceived", sender, message);

            }
        }

        public async Task NotifySeenMessage(string senderId, string receiverId, Guid messageId)
        {
            var userId = _context.Users.FirstOrDefault(u => u.Id.ToLower() == senderId.ToLower()).Id;

            if (!string.IsNullOrEmpty(userId))
            {
                await Clients.User(userId).SendAsync("MessageSeen", senderId, receiverId, messageId);

            }
        }

    }
}
