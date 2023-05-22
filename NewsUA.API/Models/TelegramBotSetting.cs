using System.ComponentModel.DataAnnotations;

namespace NewsUA.API.Models
{
    public class TelegramBotSetting
    {
        [Key]
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}