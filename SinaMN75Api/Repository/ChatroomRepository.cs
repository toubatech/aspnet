using SinaMN75Api.Core;
using SinaMN75Api.Models;

namespace SinaMN75Api.Repository
{
    public interface IChatroomRepository
    {
        Task CreateChatroom(string chatrooomName, string userId);
        Task EditChatroom(string chatrooomName, string userId);
        Task DeleteChatroom(Guid chatroomId, string userId);
        Task<List<ChatRoom>> GetChatroomsByName(string chatroomName);
        Task AddUserToChatroom(Guid chatroomId, string userId);
        Task<List<string>> AddMessageToChatroom(Guid roomId, ChatMessage message);
        Task<List<ChatMessage>> GetChatroomMessages(Guid chatroomId);
        Task<List<string>> EditGroupMessage(Guid roomId, ChatMessage message);
        Task<List<string>> DeleteGroupMessage(Guid roomId, ChatMessage message);
    }
    public class ChatroomRepository : IChatroomRepository
    {
        private readonly AppDbContext _context;

        public ChatroomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<string>> AddMessageToChatroom(Guid roomId, ChatMessage message)
        {
            var room = await _context.Set<ChatRoom>().FirstOrDefaultAsync(x => x.Id == roomId);

            room.Messages.Add(message);
            await _context.SaveChangesAsync();

            var output = room.Users.Select(x => x.ToString()).ToList();

            return output;

        }

        public async Task AddUserToChatroom(Guid chatroomId, string userId)
        {
            var room = await _context.Set<ChatRoom>().FirstOrDefaultAsync(x => x.Id == chatroomId);
            if(room != null)
            {
                room.Users.Add(userId);
                await _context.SaveChangesAsync();
            }

        }

        public async Task CreateChatroom(string chatrooomName, string userId)
        {
            var chatroomToAdd = new ChatRoom
            {
                CreatedAt = DateTime.Now,
                Id = Guid.NewGuid(),
                UpdatedAt = DateTime.Now,
                Name = chatrooomName,
                Creator = userId,
                Users = new List<string> { userId }
            };
            _context.ChatRoom.Add(chatroomToAdd);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteChatroom(Guid chatroomId, string userId)
        {
            var chatroom = await _context.Set<ChatRoom>().FirstOrDefaultAsync(x => x.Id == chatroomId);
            if (chatroom != null)
            {
                if(chatroom.Creator == userId)
                {
                    _context.ChatRoom.Remove(chatroom);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<string>> DeleteGroupMessage(Guid roomId, ChatMessage message)
        {
            var room = await _context.Set<ChatRoom>().FirstOrDefaultAsync(x => x.Id == roomId);
            if (room != null)
            {
                var messageToDelete = room.Messages.FirstOrDefault(x => x.Id == message.Id);
                if (messageToDelete.Id.ToString() == message.FromUserId || messageToDelete.Id.ToString() == room.Creator)
                {
                    room.Messages.Remove(messageToDelete);
                    await _context.SaveChangesAsync();
                }
            }
            var output = room.Users.Select(x => x.ToString()).ToList();

            return output;
        }

        public async Task EditChatroom(string chatrooomName, string userId)
        {
            var chatroom = await _context.Set<ChatRoom>().FirstOrDefaultAsync(x => x.Name == chatrooomName);

            if(chatroom != null)
            {
                if (chatroom.Creator == userId)
                {
                    chatroom.Name = chatrooomName;
                    chatroom.UpdatedAt = DateTime.Now;
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<string>> EditGroupMessage(Guid roomId, ChatMessage message)
        {
            var room = await _context.Set<ChatRoom>().FirstOrDefaultAsync(x => x.Id == roomId);
            if (room != null)
            {
                var messageToEdit = room.Messages.FirstOrDefault(x => x.Id == message.Id);
                if (messageToEdit.Id.ToString() == message.FromUserId)
                {
                    messageToEdit.UpdatedAt = DateTime.Now;
                    messageToEdit.MessageText = message.MessageText;
                }
            }
            var output = room.Users.Select(x => x.ToString()).ToList();

            return output;
        }

        public async Task<List<ChatMessage>> GetChatroomMessages(Guid chatroomId)
        {
            var room = await _context.Set<ChatRoom>().FirstOrDefaultAsync(x => x.Id == chatroomId);
            return room.Messages;

        }

        public async Task<List<ChatRoom>> GetChatroomsByName(string chatroomName)
        {
            var rooms = await _context.Set<ChatRoom>().Where(x => x.Name == chatroomName).ToListAsync();
            return rooms;
        }
    }
}
