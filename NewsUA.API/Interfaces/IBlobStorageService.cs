using NewsUA.API.Models;

namespace NewsUA.API.Interfaces
{
    public interface IBlobStorageService
    {
        void UploadLogFile(News news);
    }
}