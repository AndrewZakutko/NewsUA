using System.ComponentModel.DataAnnotations;

namespace NewsUA.API.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string AuthorName { get; set; }
        public string Information { get; set; }
        public string? PhotoUrl { get; set; }
        public string Status { get; set; }
        public string HotStatus { get; set; }
        public string? Type { get; set; }
        public DateTime PublishedAt { get; set; } = DateTime.Now;
        public DateTime? EdittedAt { get; set; }
    }
}