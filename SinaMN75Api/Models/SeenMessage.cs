namespace SinaMN75Api.Models
{
    public class SeenMessage
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsSeen { get; set; }
        public Guid User { get; set; }
    }
}
