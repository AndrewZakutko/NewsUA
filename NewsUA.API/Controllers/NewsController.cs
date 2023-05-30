using NewsUA.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NewsUA.API.Models;
using NewsUA.API.DTOs;

namespace NewsUA.API.Controllers
{
    public class NewsController : BaseApiController
    {   
        private string azureFunctionUrl = $"https://telegram-message-sender.azurewebsites.net/api/SendMessage?code=jj4D3A6KwYwT4arp3Avr2aEXHcFsxLE-A0vYIFqbkJbKAzFugp-tdw==";
        private readonly INewsRepository _newsRepository;
        private string _chatId;
        private string _botApiKey;
        public NewsController(INewsRepository newsRepository, ITelegramSettingsRepository telegramSettingsRepository)
        {
            _newsRepository = newsRepository;
            _chatId = telegramSettingsRepository.GetValueByKey("chatId");
            _botApiKey = telegramSettingsRepository.GetValueByKey("botApiKey");
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
        public IActionResult CreateAsync([FromBody]NewsDto news){
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
            if(_newsRepository.EditNews(newsDto)){
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
                var mes = GenerateMassageStr(news);
                System.Net.WebRequest reqGet = System.Net.WebRequest.Create(azureFunctionUrl + $"&chatId={_chatId}" + $"&botKey={_botApiKey}" + $"&message={mes}");
                reqGet.GetResponse();
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

        [HttpGet("pageNumber={pageNumber}&pageSize={pageSize}")]
        public ICollection<News> GetPaginationListNews(int pageNumber, int pageSize)
        {
            return _newsRepository.GetPaginationListNews(pageNumber, pageSize);
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
