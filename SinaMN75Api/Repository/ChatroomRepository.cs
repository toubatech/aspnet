using SinaMN75Api.Core;
using SinaMN75Api.Models;

namespace SinaMN75Api.Repository
{
    public interface IChatroomRepository
    {
        Task CreateChatroom(string chatrooomName, Guid userId);
        Task EditChatroom(string chatrooomName, Guid userId);
        Task DeleteChatroom(Guid chatroomId, Guid userId);
        Task<List<ChatRoom>> GetChatroomsByName(string chatroomName);
        Task AddUserToChatroom(Guid chatroomId, Guid userId);
    }
    public class ChatroomRepository : IChatroomRepository
    {
        private readonly AppDbContext _context;

        public ChatroomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddUserToChatroom(Guid chatroomId, Guid userId)
        {
            var room = await _context.Set<ChatRoom>().FirstOrDefaultAsync(x => x.Id == chatroomId);
            if(room != null)
            {
                room.Users.Add(userId);
                await _context.SaveChangesAsync();
            }

        }

        public async Task CreateChatroom(string chatrooomName, Guid userId)
        {
            var chatroomToAdd = new ChatRoom
            {
                CreatedAt = DateTime.Now,
                Id = Guid.NewGuid(),
                UpdatedAt = DateTime.Now,
                Name = chatrooomName,
                Creator = userId,
                Users = new List<Guid> { userId }
            };
            _context.ChatRoom.Add(chatroomToAdd);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteChatroom(Guid chatroomId, Guid userId)
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

        public async Task EditChatroom(string chatrooomName, Guid userId)
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

        public async Task<List<ChatRoom>> GetChatroomsByName(string chatroomName)
        {
            var rooms = await _context.Set<ChatRoom>().Where(x => x.Name == chatroomName).ToListAsync();
            return rooms;
        }
    }
}
