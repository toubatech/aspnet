using System.ComponentModel.DataAnnotations;

namespace SinaMN75Api.Models
{
    public class ChatRoom : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public List<string> Users { get; set; }
        public string Creator { get; set; }
        public List<ChatMessage> Messages { get; set; }
    }
}
