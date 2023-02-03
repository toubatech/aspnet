using SinaMN75Api.Models;
using SinaMN75Api.Core;
using SinaMN75Api.Hubs;

namespace signalrtest.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ChatHub _hub;

        public ChatController(AppDbContext context, ChatHub hub)
        {
            _context = context;
            _hub = hub;
        }

        [HttpPost]
        [Route("/[controller]/send-message")]
        public async Task<ActionResult> SendMessage (ChatMessage message)
        {
            var receiver = await _context.Users.FirstOrDefaultAsync(x => x.Id == message.ToUserId);
            if (receiver == null)
                return BadRequest();
            else
            {
                //Todo: change IsLoggedIn to IsOnline (Add IsOnline to utility entity)
                if(receiver.IsLoggedIn)
                {
                    await _hub.SendMessageToReceiver(message.FromUserId, message.ToUserId, message.MessageText);
                    return Ok();
                } else
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
        public async Task<ActionResult> ModifyOnlineStatus (string userId, bool status)
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

    }
}
