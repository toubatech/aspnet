using SinaMN75Api.Core;
using SinaMN75Api.Models;
using SinaMN75Api.Models.Enums;

namespace SinaMN75Api.Repository
{
    public interface IMessageRepository
    {
        Task AddEmojiToMessage(EmojiEnum emoji, Guid messageId, Guid userId);
    }

    public class MessageRepository : IMessageRepository
    {
        private readonly AppDbContext _context;
        public MessageRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddEmojiToMessage(EmojiEnum emoji, Guid messageId, Guid userId)
        {
            var message = await _context.Set<ChatMessage>().FirstOrDefaultAsync(x => x.Id == messageId);

            if (message != null)
            {
                message.Emojies.Add(new Emoji { EmojiEnum = emoji, UserId = userId });
                await _context.SaveChangesAsync();
            }

        }
    }
}
