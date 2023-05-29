using NewsUA.API.Interfaces;
using NewsUA.API.Models;
using Azure.Storage.Blobs;

namespace NewsUA.API.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly string _blobConnectionString;
        private readonly string _blobContainerName;
        private readonly BlobContainerClient _blobContainerClient;
        public BlobStorageService(IConfiguration configuration)
        {
            _blobConnectionString = configuration.GetSection("BlobStorage:BlobConnectionString").Value;
            _blobContainerName = configuration.GetSection("BlobStorage:BlobContainerName").Value;

            _blobContainerClient = new BlobContainerClient(_blobConnectionString, _blobContainerName);
        }

        public async void UploadLogFile(News news)
        {
            var directory = Directory.GetCurrentDirectory();
            var uniqueLogFileName = "create-new-news-" + Guid.NewGuid().ToString() + ".txt";
            var filePath = Path.Combine(directory, uniqueLogFileName);

            GenerateLogFile(filePath, news);

            var blobClient = _blobContainerClient.GetBlobClient(uniqueLogFileName);
            using FileStream uploadFileStream = System.IO.File.OpenRead(filePath);
            await blobClient.UploadAsync(uploadFileStream, true);
            uploadFileStream.Close();

            System.IO.File.Delete(filePath);
        }

        private void GenerateLogFile(string filePath, News news) 
        {
            var sw = new StreamWriter(filePath);
            sw.WriteLine("New news has been created!");
            sw.WriteLine("");
            sw.WriteLine("Data:");
            sw.WriteLine($"Title - {news.Title}");
            sw.WriteLine($"Sub title - {news.SubTitle}");
            sw.WriteLine($"Information - {news.Information}");
            sw.WriteLine($"Type - {news.Type}");
            sw.WriteLine($"Is hot? - {news.IsHot}");
            sw.WriteLine("");
            sw.WriteLine($"Created by - {news.AuthorName}");
            sw.WriteLine($"Date - {news.PublishedAt}");
            sw.Close();
        }
    }
}