using NewsUA.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NewsUA.API.Models;

namespace NewsUA.API.Controllers
{
    public class NewsController : BaseApiController
    {
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

        [HttpPost("create")]
        public bool Create([FromBody]News news){
            return _newsRepository.CreateNews(news);
        }

        [HttpDelete("delete/{id}")]
        public bool Delete(int id){
            return _newsRepository.DeleteNewsById(id);
        }

        [HttpPut("edit")]
        public bool Edit(News news){
            return _newsRepository.EditNewsById(news);
        }

        [HttpGet("SetToApproved/{id}")]
        public bool SetToApprovedStatusById(int id){
            return _newsRepository.SetToApprovedStatusById(id);
        }

        [HttpGet("SetToBasic/{id}")]
        public bool SetToBasicStatusById(int id){
            return _newsRepository.SetToBasicStatusById(id);
        }

        [HttpGet("SetToHot/{id}")]
        public bool SetToHotStatusById(int id){
            return _newsRepository.SetToHotStatusById(id);
        }

        [HttpGet("Hot")]
        public ICollection<News> GetHotNews(){
            return _newsRepository.GetHotNews();
        }

        [HttpGet("type={type}")]
        public ICollection<News> GetNewsByType(string type){
            return _newsRepository.GetNewsByType(type);
        }
    }
}