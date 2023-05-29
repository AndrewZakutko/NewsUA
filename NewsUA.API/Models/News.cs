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
        public string Status { get; set; }
        public bool IsHot { get; set; }
        public string? Type { get; set; }
        public DateTime? PublishedAt { get; set; }
        public DateTime? EdittedAt { get; set; }
    }
}