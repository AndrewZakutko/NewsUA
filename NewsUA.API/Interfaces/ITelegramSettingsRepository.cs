using NewsUA.API.Models;

namespace NewsUA.API.Interfaces
{
    public interface ITelegramSettingsRepository
    {
        ICollection<TelegramBotSetting> GetAllSettings();
        bool EditSetting(TelegramBotSetting newTgSetting);
        string GetValueByKey(string key);
    }
}