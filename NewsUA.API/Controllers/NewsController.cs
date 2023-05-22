using NewsUA.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NewsUA.API.Models;
using Telegram.Bot.Types;
using Telegram.Bot;
using NewsUA.API.DTOs;

namespace NewsUA.API.Controllers
{
    public class NewsController : BaseApiController
    {
        const string CHAT_ID = "@some_channel_1";
        private CancellationToken _cancellationToken = new();        
        private readonly Telegram.Bot.TelegramBotClient _tgClient = new Telegram.Bot.TelegramBotClient("6083733825:AAG3K3fm9JfTpa7ed1JVPJJiie0_KAw23Do");
        private readonly INewsRepository _newsRepository;
        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpGet]
        public ICollection<News> GetAll(){
            return _newsRepository.GetAll();
        }

        [HttpGet("id={id}")]
        public News GetById(int id){
            return _newsRepository.GetNewsById(id);
        }

        [HttpGet("ApprovedOrEditted")]
        public ICollection<News> GetApprovedOrEdittedNews(){
            return _newsRepository.GetApprovedOrEdittedNews();
        }

        [HttpGet("InProcess")]
        public ICollection<News> GetInProcessNews(){
            return _newsRepository.GetInProcessNews();
        }

        [HttpPost("create")]
        public IActionResult CreateAsync([FromBody]News news){
            if(_newsRepository.CreateNews(news)){
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id){
            if(_newsRepository.DeleteNewsById(id)){
                return Ok();
            }
            else {
                return BadRequest();
            }
        }

        [HttpPut("Edit")]
        public IActionResult Edit(NewsDto newsDto){
            if(_newsRepository.EditNewsById(newsDto)){
                return Ok();
            }
            else {
                return BadRequest();
            }
        }

        [HttpGet("SetToApproved/{id}")]
        public IActionResult SetToApprovedStatusById(int id){
            if(_newsRepository.SetToApprovedStatusById(id)){
                var news = _newsRepository.GetNewsById(id);
                SendMessage(news);
                return Ok();
            }
            else {
                return BadRequest();
            }
        }

        [HttpGet("SetToBasic/{id}")]
        public IActionResult SetToBasicStatusById(int id){
            if(_newsRepository.SetToBasicStatusById(id)){
                return Ok();
            }
            else {
                return BadRequest();
            }
        }

        [HttpGet("SetToHot/{id}")]
        public IActionResult SetToHotStatusById(int id){
            if(_newsRepository.SetToHotStatusById(id)){
                return Ok();
            }
            else {
                return BadRequest();
            }
        }

        [HttpGet("Hot")]
        public ICollection<News> GetHotNews(){
            return _newsRepository.GetHotNews();
        }

        [HttpGet("type={type}")]
        public ICollection<News> GetNewsByType(string type){
            return _newsRepository.GetNewsByType(type);
        }

        private async void SendMessage(News news){
            Message message = await _tgClient.SendTextMessageAsync(
                    chatId: CHAT_ID,
                    text: GenerateMassageStr(news),
                    parseMode: Telegram.Bot.Types.Enums.ParseMode.Html,
                    cancellationToken: _cancellationToken);
        }

        private string GenerateMassageStr(News news){
            var text = @"<b>New post!</b>" + '\n' +
                @$"<b>Title:</b> <i>{news.Title}</i>" + '\n' + '\n' + 
                @$"<i>{news.SubTitle}</i>" + '\n' + '\n' +
                @$"Перейдите на <a href='https://www.google.com/'>сайт</a>, чтобы прочесть подробнее" + '\n' +
                @$"<i>{news.PublishedAt}</i>";

            return text;
        }
    }
}
