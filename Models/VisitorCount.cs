namespace server.Models
{
    public class VisitorCount
    {
        public int Id { get; set; } = 1;
        public int Count { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}