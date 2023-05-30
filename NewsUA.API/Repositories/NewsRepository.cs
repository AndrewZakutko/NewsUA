using NewsUA.API.Interfaces;
using NewsUA.API.Models;
using NewsUA.API.Data;
using NewsUA.API.Enums;
using NewsUA.API.DTOs;

namespace NewsUA.API.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly DataContext _db;
        private readonly IBlobStorageService _blobStorageService;

        public NewsRepository(DataContext db, IBlobStorageService blobStorageService)
        {
            _db = db;
            _blobStorageService = blobStorageService;
        }

        public ICollection<News> GetApprovedOrEdittedNews()
        {
            return _db.News.Where(x => x.Status == Statuses.Approved.ToString() || x.Status == Statuses.Editted.ToString()).OrderByDescending(x => x.Id).ToList();
        }

        public ICollection<News> GetHotNews()
        {
            return _db.News.Where(x => x.IsHot && x.Status == Statuses.Approved.ToString()
                || x.IsHot && x.Status == Statuses.Editted.ToString()).OrderByDescending(x => x.Id).ToList();
        }

        public ICollection<News> GetInProcessNews()
        {
            return _db.News.Where(x => x.Status == Statuses.InProcess.ToString()).ToList();
        }

        public ICollection<News> GetPaginationListNews(int pageNumber, int pageSize)
        {
            var newsList = _db.News.ToList();

            newsList = newsList.OrderByDescending(x => x.Id).ToList();


			return newsList.Where(x => x.Status == Statuses.Approved.ToString() && x.IsHot == false 
                || x.Status == Statuses.Editted.ToString() && x.IsHot == false).Skip(pageNumber * pageSize).Take(pageSize).ToList();
        }   

        public bool SetToApprovedStatusById(int id)
        {
            var news = _db.News.Find(id);

            if(news == null) return false;

            try {
                news.Status = Statuses.Approved.ToString();
                news.PublishedAt = DateTime.Now;

                _blobStorageService.UploadLogFile(news);

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
                news.IsHot = false;

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
                news.IsHot = true;

                _db.SaveChanges();

                return true;
            }
            catch {
                return false;
            }
        }

        bool INewsRepository.CreateNews(NewsDto newsDto)
        {
            if(newsDto == null) return false;

            try
            {
                var newsToAdd = new News()
                {
                    Title = newsDto.Title,
                    SubTitle = newsDto.SubTitle,
                    AuthorName = newsDto.AuthorName,
                    Information = newsDto.Information,
                    Status = newsDto.Status,
                    IsHot = newsDto.IsHot,
                    Type = newsDto.Type
                };

                _db.News.Add(newsToAdd);
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

        bool INewsRepository.EditNews(NewsDto newsDto)
        {
            var newsFounded = _db.News.Find(newsDto.Id);
            
            if(newsFounded == null) return false;

            try{
                newsFounded.Title = newsDto.Title;
                newsFounded.SubTitle = newsDto.SubTitle;
                newsFounded.Information = newsDto.Information;
                newsFounded.AuthorName = newsDto.AuthorName;
                newsFounded.EdittedAt = DateTime.Now;
                newsFounded.Status = Statuses.Editted.ToString();
                newsFounded.IsHot = newsDto.IsHot;
                newsFounded.Type = newsDto.Type;

                _db.SaveChanges();

                return true;
            }
            catch{
                return false;;
            }
        }

        News INewsRepository.GetNewsById(int id)
        {
            return _db.News.Find(id);
        }
    }
}