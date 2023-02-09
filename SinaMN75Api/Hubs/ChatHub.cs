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

        #region One to One Messaging
        public async Task SendMessageToReceiver(string sender, string receiver, string message)
        {
            var userId = _context.Users.FirstOrDefault(u => u.Id.ToLower() == receiver.ToLower()).Id;

            if (!string.IsNullOrEmpty(userId))
            {
                await Clients.User(userId).SendAsync("MessageReceived", sender, message);

            }
        }

        public async Task SendEditedMessageToReceiver(string sender, string receiver, string message, Guid messageId)
        {
            var userId = _context.Users.FirstOrDefault(u => u.Id.ToLower() == receiver.ToLower()).Id;

            if (!string.IsNullOrEmpty(userId))
            {
                await Clients.User(userId).SendAsync("MessageEdited", sender, message, messageId);

            }
        }

        public async Task SendDeletedMessageToReceiver(string sender, string receiver, Guid messageId)
        {
            var userId = _context.Users.FirstOrDefault(u => u.Id.ToLower() == receiver.ToLower()).Id;

            if (!string.IsNullOrEmpty(userId))
            {
                await Clients.User(userId).SendAsync("MessageDeleted", sender, messageId);

            }
        } 
        #endregion

        public async Task SendMessageToGroup(string roomId, List<string> receiverList, string message)
        {
            await Clients.Users(receiverList).SendAsync("MessageReceivedFromGroup", roomId, message);
        }
        public async Task SendEditedMessageToGroup(string roomId, List<string> receiverList, string message, string messageId)
        {
            await Clients.Users(receiverList).SendAsync("MessageEditedFromGroup", roomId, message, messageId);
        }
        public async Task SendDeletedMessageToGroup(string roomId, List<string> receiverList, string message, string messageId)
        {
            await Clients.Users(receiverList).SendAsync("MessageDeletedFromGroup", roomId, message, messageId);
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
