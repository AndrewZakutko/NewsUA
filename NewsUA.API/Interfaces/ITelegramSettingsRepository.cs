using NewsUA.API.Models;

namespace NewsUA.API.Interfaces
{
    public interface ITelegramSettingsRepository
    {
        ICollection<TelegramBotSetting> GetSettings();
        bool EditSetting(int id);
    }
}