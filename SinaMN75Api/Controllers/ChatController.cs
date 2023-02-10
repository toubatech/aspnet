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

        #region One to One Messaging
        [HttpPost]
        [Route("/[controller]/send-private-message")]
        public async Task<ActionResult> SendPrivateMessage(ChatMessage message)
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

        [HttpGet]
        [Route("[controller]/get-one-to-one-messages/{firstUserId}/{secondUserId}")]
        public async Task<IActionResult> GetPrivateMessages(string firstUserId, string secondUserId)
        {
            var messages = await _messagerepository.GetPrivateMessages(firstUserId, secondUserId);
            if (messages == null)
                return NoContent();

            return Ok(messages);

        }

        [HttpPut]
        [Route("[controller]/edit-one-to-one-messages/{senderId}/{receiverId}/{messageText}/{messageId}")]
        public async Task<IActionResult> EditPrivateMessages(string senderId, string receiverId, string messageText, Guid messageId)
        {
            await _messagerepository.EditPrivateMessages(messageText, messageId);

            await _hub.SendEditedMessageToReceiver(senderId, receiverId, messageText, messageId);

            return Ok();

        }
        [HttpDelete]
        [Route("[controller]/delete-one-to-one-messages/{senderId}/{receiverId}/{messageId}")]
        public async Task<IActionResult> DeletePrivateMessages(string senderId, string receiverId, Guid messageId)
        {
            await _messagerepository.DeletePrivateMessage(messageId);

            await _hub.SendDeletedMessageToReceiver(senderId, receiverId, messageId);

            return Ok();

        }
        #endregion

        #region Group Messaging
        [HttpPost]
        [Route("/[controller]/send-group-message/{roomId}")]
        public async Task<ActionResult> SendGroupMessage(ChatMessage message, Guid roomId)
        {
            var roomUsers = await _chatroomRepository.AddMessageToChatroom(roomId, message);

            await _hub.SendMessageToGroup(roomId.ToString(), roomUsers, message.MessageText);

            return Ok();
        }

        [HttpGet]
        [Route("/[controller]/get-group-message/{roomId}")]
        public async Task<ActionResult> GetGroupMessage(Guid roomId)
        {
            var roomMessages = await _chatroomRepository.GetChatroomMessages(roomId);

            return Ok(roomMessages);
        }

        [HttpPut]
        [Route("/[controller]/edit-group-message/{roomId}")]
        public async Task<ActionResult> EditGroupMessage(Guid roomId, ChatMessage message)
        {
            var roomUsers = await _chatroomRepository.EditGroupMessage(roomId, message);

            await _hub.SendEditedMessageToGroup(roomId.ToString(), roomUsers, message.MessageText, message.Id.ToString());

            return Ok();
        }

        [HttpDelete]
        [Route("/[controller]/delete-group-message/{roomId}")]
        public async Task<ActionResult> DeleteGroupMessage(Guid roomId, ChatMessage message)
        {
            var roomUsers = await _chatroomRepository.DeleteGroupMessage(roomId, message);

            await _hub.SendDeletedMessageToGroup(roomId.ToString(), roomUsers, message.MessageText, message.Id.ToString());

            return Ok();
        }
        #endregion

        #region Seen/Online/Emoji
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
        public async Task<ActionResult> CreateChatroom(string chatroomName, string userId)
        {
            if (string.IsNullOrEmpty(chatroomName))
                return BadRequest();

            await _chatroomRepository.CreateChatroom(chatroomName, userId);
            return Ok();
        }

        [HttpPut]
        [Route("/[controller]/edit-chatroom/{userId}/{chatroomName}")]
        public async Task<ActionResult> EditChatroom(string chatroomName, string userId)
        {
            if (string.IsNullOrEmpty(chatroomName) || userId == null)
                return BadRequest();

            await _chatroomRepository.EditChatroom(chatroomName, userId);
            return Ok();
        }

        [HttpDelete]
        [Route("/[controller]/delete-chatroom/{userId}/{chatroomId}")]
        public async Task<ActionResult> DeleteChatroom(Guid chatroomId, string userId)
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
        public async Task<ActionResult> AddUserToChatroom(Guid chatroomId, string userId)
        {
            await _chatroomRepository.AddUserToChatroom(chatroomId, userId);
            return Ok();
        }
        #endregion

    }
}
