using NewsUA.API.Interfaces;
using NewsUA.API.Models;
using NewsUA.API.Data;

namespace NewsUA.API.Repositories
{
    public class TelegramSettingsRepository : ITelegramSettingsRepository
    {
        private readonly DataContext _db;

        public TelegramSettingsRepository(DataContext db)
        {
            _db = db;
        }

        public bool EditSetting(TelegramBotSetting newTgSetting)
        {
            var tgSettingToEdit = _db.TelegramBotSettings.Find(newTgSetting.Id);

            if(tgSettingToEdit == null) return false;

            try {
                tgSettingToEdit.Value = newTgSetting.Value;

                _db.SaveChanges();

                return true;
            }
            catch {
                return false;
            }
        }

        public ICollection<TelegramBotSetting> GetAllSettings()
        {
            return _db.TelegramBotSettings.ToList();
        }
    }
}