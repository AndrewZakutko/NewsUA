using System.ComponentModel.DataAnnotations;

namespace NewsUA.API.Models
{
    public class NewsType
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
    }
}