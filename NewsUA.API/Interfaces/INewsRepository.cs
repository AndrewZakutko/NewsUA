using NewsUA.API.DTOs;
using NewsUA.API.Models;

namespace NewsUA.API.Interfaces
{
    public interface INewsRepository
    {
        ICollection<News> GetInProcessNews();
        ICollection<News> GetApprovedOrEdittedNews();
        News GetNewsById(int id);
        bool CreateNews(NewsDto newsDto);
        bool EditNews(NewsDto newsDto);
        bool DeleteNewsById(int id); 
        bool SetToApprovedStatusById(int id);
        bool SetToHotStatusById(int id);
        bool SetToBasicStatusById(int id);
        ICollection<News> GetHotNews();
        ICollection<News> GetPaginationListNews(int pageNumber, int pageSize);
    }
}