using NewsUA.API.Data;
using NewsUA.API.Interfaces;
using NewsUA.API.Models;

namespace NewsUA.API.Repositories
{
    public class NewsTypesRepository : INewsTypesRepository
    {
        private readonly DataContext _db;
        public NewsTypesRepository(DataContext db)
        {
            _db = db;
        }

        public ICollection<NewsType> GetAll()
        {
            return _db.NewsTypes.ToList();
        }
    }
}