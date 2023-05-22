using NewsUA.API.DTOs;
using NewsUA.API.Models;

namespace NewsUA.API.Interfaces
{
    public interface INewsRepository
    {
        ICollection<News> GetAll();
        ICollection<News> GetInProcessNews();
        ICollection<News> GetApprovedOrEdittedNews();
        News GetNewsById(int id);
        bool CreateNews(News news);
        bool EditNewsById(NewsDto news);
        bool DeleteNewsById(int id); 
        bool SetToApprovedStatusById(int id);
        bool SetToHotStatusById(int id);
        bool SetToBasicStatusById(int id);
        ICollection<News> GetHotNews();
        ICollection<News> GetNewsByType(string type);
    }
}