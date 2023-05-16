using NewsUA.API.Interfaces;
using NewsUA.API.Models;
using NewsUA.API.Data;
using NewsUA.API.Enums;

namespace NewsUA.API.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly DataContext _db;
        public NewsRepository(DataContext db)
        {
            _db = db;
        }

        public ICollection<News> GetHotNews()
        {
            return _db.News.Where(x => x.HotStatus == HotStatuses.Hot.ToString()).ToList();
        }

        public ICollection<News> GetNewsByType(string type)
        {
            return _db.News.Where(x => x.Type == type).ToList();
        }

        public bool SetToApprovedStatusById(int id)
        {
            var news = _db.News.Find(id);

            if(news == null) return false;

            try {
                news.Status = Statuses.Approved.ToString();

                _db.SaveChanges();

                return true;
            }
            catch {
                return false;
            }
        }

        public bool SetToBasicStatusById(int id)
        {
            var news = _db.News.Find(id);

            if(news == null) return false;

            try {
                news.Status = HotStatuses.Basic.ToString();

                _db.SaveChanges();

                return true;
            }
            catch {
                return false;
            }
        }

        public bool SetToHotStatusById(int id)
        {
            var news = _db.News.Find(id);

            if(news == null) return false;

            try {
                news.HotStatus = HotStatuses.Hot.ToString();

                _db.SaveChanges();

                return true;
            }
            catch {
                return false;
            }
        }

        bool INewsRepository.CreateNews(News news)
        {
            if(news == null) return false;

            try{
                _db.News.Add(news);
                _db.SaveChanges();

                return true;
            }
            catch{
                return false;
            }
        }

        bool INewsRepository.DeleteNewsById(int id)
        {
            var news = _db.News.Find(id);

            if(news == null) return false;

            try{
                _db.News.Remove(news);
                _db.SaveChanges();

                return true;
            }
            catch{
                return false;
            }
        }

        bool INewsRepository.EditNewsById(News news)
        {
            var newsFounded = _db.News.Find(news.Id);
            
            if(news == null) return false;

            try{
                newsFounded.Title = news.Title;
                newsFounded.SubTitle = news.SubTitle;
                newsFounded.Information = news.Information;
                newsFounded.PhotoUrl = news.PhotoUrl;
                newsFounded.AuthorName = news.AuthorName;
                newsFounded.EdittedAt = DateTime.Now;
                newsFounded.Status = Statuses.Editted.ToString();
                newsFounded.HotStatus = news.HotStatus;

                _db.SaveChanges();

                return true;
            }
            catch{
                return false;
            }
        }

        ICollection<News> INewsRepository.GetAll()
        {
            return _db.News.ToList();
        }

        News INewsRepository.GetNewsById(int id)
        {
            return _db.News.Find(id);
        }
    }
}