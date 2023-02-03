using System.ComponentModel.DataAnnotations;

namespace SinaMN75Api.Models
{
    public class ChatRoom
    {
        [Required]
        public string Name { get; set; }
        public int Id { get; set; }
    }
}
