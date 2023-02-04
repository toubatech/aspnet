using System.ComponentModel.DataAnnotations;

namespace SinaMN75Api.Models
{
    public class ChatRoom : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public List<Guid> Users { get; set; }
        public Guid Creator { get; set; }
    }
}
