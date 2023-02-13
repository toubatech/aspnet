using System.ComponentModel.DataAnnotations;

namespace SinaMN75Api.Models
{
    public class ChatMessage : BaseEntity
	{
		public string FromUserId { get; set; } = null!;
		public string ToUserId { get; set; } = null!;
        public Guid ToGroupId { get; set; }

        [StringLength(2000)]
		public string MessageText { get; set; } = null!;
        public bool ReadPrivateMessage { get; set; } = false;
        public List<SeenMessage> SeenStatus { get; set; } = new List<SeenMessage>();
        public List<Emoji> Emojies { get; set; } = new List<Emoji>();
        public Guid RepliedTo { get; set; }
    }

    public class ChatMessageInputDto
    {
        public string FromUserId { get; set; } = null!;
        public string ToUserId { get; set; } = null!;
        public Guid ToGroupId { get; set; }

        [StringLength(2000)]
        public string MessageText { get; set; } = null!;
        public Guid RepliedTo { get; set; }
    }

    public class ChatMessageDeleteDto
    {
        public Guid MessageId { get; set; }
        public Guid UserId { get; set; }
    }

    public class ChatMessageEditDto
    {
        public Guid MessageId { get; set; }
        public string FromUserId { get; set; } = null!;
        public string ToUserId { get; set; } = null!;
        public Guid ToGroupId { get; set; }

        [StringLength(2000)]
        public string MessageText { get; set; } = null!;
        public Guid RepliedTo { get; set; }
    }

}
