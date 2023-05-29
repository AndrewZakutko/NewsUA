using NewsUA.API.Models;

namespace NewsUA.API.Interfaces
{
    public interface INewsTypesRepository
    {
        ICollection<NewsType> GetAll();
    }
}