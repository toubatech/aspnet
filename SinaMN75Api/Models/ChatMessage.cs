using System.ComponentModel.DataAnnotations;

namespace SinaMN75Api.Models
{
    public class ChatMessage : BaseEntity
	{
		public string FromUserId { get; set; } = null!;
		public string ToUserId { get; set; } = null!;

		[StringLength(2000)]
		public string MessageText { get; set; } = null!;

		public bool ReadMessage { get; set; }
        public List<Emoji> Emojies { get; set; } = new List<Emoji>();
    }
}
