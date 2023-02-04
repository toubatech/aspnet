using SinaMN75Api.Models;
using SinaMN75Api.Core;
using SinaMN75Api.Hubs;
using SinaMN75Api.Repository;
using SinaMN75Api.Models.Enums;

namespace signalrtest.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ChatHub _hub;
        private readonly IChatroomRepository _chatroomRepository;
        private readonly IMessageRepository _messagerepository;

        public ChatController(AppDbContext context, ChatHub hub, IChatroomRepository chatroomRepository, IMessageRepository messageRepository)
        {
            _context = context;
            _hub = hub;
            _chatroomRepository = chatroomRepository;
            _messagerepository = messageRepository;
        }

        #region Messaging
        [HttpPost]
        [Route("/[controller]/send-message")]
        public async Task<ActionResult> SendMessage(ChatMessage message)
        {
            var receiver = await _context.Users.FirstOrDefaultAsync(x => x.Id == message.ToUserId);
            if (receiver == null)
                return BadRequest();
            else
            {
                //Todo: change IsLoggedIn to IsOnline (Add IsOnline to utility entity)
                if (receiver.IsLoggedIn)
                {
                    await _hub.SendMessageToReceiver(message.FromUserId, message.ToUserId, message.MessageText);
                    return Ok();
                }
                else
                {
                    await _context.ChatMessages.AddAsync(message);
                    await _context.SaveChangesAsync();

                    //push notification to receiver

                    return Ok();

                }
            }
        }

        //Todo: change method parameters to a dto
        [HttpPut]
        [Route("/[controller]/modify-online-status/{userId}/{status}")]
        public async Task<ActionResult> ModifyOnlineStatus(string userId, bool status)
        {
            //Todo: change IsLoggedIn to IsOnline
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user == null)
                return BadRequest();

            user.IsLoggedIn = status;
            await _context.SaveChangesAsync();
            return Ok();

        }

        //Todo: change method parameters to a dto
        [HttpPut]
        [Route("/[controller]/seen-message/{messageId}/receiverUser/senderUser")]
        public async Task<ActionResult> HasSeenMessage(Guid messageId, string receiverUser, string senderUser)
        {
            var messageInDB = await _context.ChatMessages.FirstOrDefaultAsync(x => x.Id == messageId);
            if (messageInDB == null)
                return BadRequest();

            messageInDB.ReadMessage = true;
            await _context.SaveChangesAsync();

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == senderUser);
            if (user == null)
                return BadRequest();

            //Todo:change IsLoggedIn to IsOnline
            if (user.IsLoggedIn)
                _hub.NotifySeenMessage(senderUser, receiverUser, messageId);

            return Ok();

        }

        [HttpPut]
        [Route("/[controller]/add-emoji/{emoji}/{messageId}/{userId}")]
        public async Task<ActionResult> AddEmojiToMessage(EmojiEnum emoji, Guid messageId, Guid userId)
        {
            await _messagerepository.AddEmojiToMessage(emoji, messageId, userId);
            return Ok();

        }

        #endregion

        #region Chatroom
        [HttpPost]
        [Route("/[controller]/post-chatroom/{userId}/{chatroomName}")]
        public async Task<ActionResult> CreateChatroom(string chatroomName, Guid userId)
        {
            if (string.IsNullOrEmpty(chatroomName))
                return BadRequest();

            await _chatroomRepository.CreateChatroom(chatroomName, userId);
            return Ok();
        }

        [HttpPut]
        [Route("/[controller]/edit-chatroom/{userId}/{chatroomName}")]
        public async Task<ActionResult> EditChatroom(string chatroomName, Guid userId)
        {
            if (string.IsNullOrEmpty(chatroomName) || userId == null)
                return BadRequest();

            await _chatroomRepository.EditChatroom(chatroomName, userId);
            return Ok();
        }

        [HttpDelete]
        [Route("/[controller]/delete-chatroom/{userId}/{chatroomId}")]
        public async Task<ActionResult> DeleteChatroom(Guid chatroomId, Guid userId)
        {
            if (string.IsNullOrEmpty(chatroomId.ToString()) || userId == null)
                return BadRequest();

            await _chatroomRepository.DeleteChatroom(chatroomId, userId);
            return Ok();
        }

        [HttpGet]
        [Route("/[controller]/get-chatroom/{chatroomName}")]
        public async Task<ActionResult> GetChatroomsByName(string chatroomName)
        {
            if (string.IsNullOrEmpty(chatroomName))
                return BadRequest();

            var result = await _chatroomRepository.GetChatroomsByName(chatroomName);
            return Ok(result);
        }

        [HttpPut]
        [Route("/[controller]/add-user-to-chatroom/{chatroomId}")]
        public async Task<ActionResult> AddUserToChatroom(Guid chatroomId, Guid userId)
        {
            await _chatroomRepository.AddUserToChatroom(chatroomId, userId);
            return Ok();
        }
        #endregion

    }
}
