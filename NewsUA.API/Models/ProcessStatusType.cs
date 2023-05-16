using System.ComponentModel.DataAnnotations;

namespace NewsUA.API.Models
{
    public class ProcessStatusType
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
    }
}