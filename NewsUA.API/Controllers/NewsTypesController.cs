using NewsUA.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NewsUA.API.Models;

namespace NewsUA.API.Controllers
{
    public class NewsTypesController : BaseApiController
    {
        private readonly INewsTypesRepository _newsTypesRepository;
        public NewsTypesController(INewsTypesRepository newsTypesRepository)
        {
            _newsTypesRepository = newsTypesRepository;
        }

        [HttpGet]
        public ICollection<NewsType> GetAll()
        {
            return _newsTypesRepository.GetAll();
        }
    }
}