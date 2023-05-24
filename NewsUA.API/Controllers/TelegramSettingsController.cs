using NewsUA.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NewsUA.API.Models;

namespace NewsUA.API.Controllers
{
    public class TelegramSettingsController : BaseApiController
    {
        private readonly ITelegramSettingsRepository _tgRepository;
        public TelegramSettingsController(ITelegramSettingsRepository telegramSettingsRepository)
        {
            _tgRepository = telegramSettingsRepository;
        }

        [HttpGet]
        public ICollection<TelegramBotSetting> GetAll()
        {
            return _tgRepository.GetAllSettings();
        }

        [HttpPut("edit")]
        public IActionResult Edit(TelegramBotSetting telegramBotSetting)
        {
            if(_tgRepository.EditSetting(telegramBotSetting))
            {
                return Ok();
            };

            return BadRequest();
        }
    }
}