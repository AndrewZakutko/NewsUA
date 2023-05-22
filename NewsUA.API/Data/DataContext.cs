using Microsoft.EntityFrameworkCore;
using NewsUA.API.Models;
using NewsUA.API.Enums;

namespace NewsUA.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<News> News { get; set; }
        public DbSet<NewsType> NewsTypes { get; set; }
        public DbSet<ProcessStatusType> ProcessStatuses { get; set; }
        public DbSet<TelegramBotSetting> TelegramBotSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TelegramBotSetting>().HasData(
                new TelegramBotSetting {
                    Id = 1,
                    Key = "botApiKey",
                    Value = "6083733825:AAG3K3fm9JfTpa7ed1JVPJJiie0_KAw23Do"
                },
                new TelegramBotSetting {
                    Id = 2,
                    Key = "chatId",
                    Value = "@some_channel_1"
                }
            );

            modelBuilder.Entity<NewsType>().HasData(
                new NewsType {
                    Id = 1,
                    Value = "World"
                },
                new NewsType {
                    Id = 2,
                    Value = "Local"
                },
                new NewsType {
                    Id = 3,
                    Value = "Sport"
                },
                new NewsType {
                    Id = 4,
                    Value = "Business"
                },
                new NewsType {
                    Id = 5,
                    Value = "Technology"
                },
                new NewsType {
                    Id = 6,
                    Value = "Science"
                },
                new NewsType{
                    Id = 7,
                    Value = "Health"
                },
                new NewsType{
                    Id = 8,
                    Value = "Entertainment"
                }
            );

            modelBuilder.Entity<ProcessStatusType>().HasData(
                new ProcessStatusType{
                    Id = 1,
                    Value = "InProcess"
                },
                new ProcessStatusType{
                    Id = 2,
                    Value = "Approved"
                },
                new ProcessStatusType{
                    Id = 3,
                    Value = "Editted"
                },
                new ProcessStatusType{
                    Id = 4,
                    Value = "Deleted"
                }
            );

            modelBuilder.Entity<News>().HasData(
                new Models.News() 
                { 
                    Id = 1,
                    Title = "Title 1",
                    SubTitle = "SubTitle 1",
                    AuthorName = "Author name 1",
                    Information = "Information 1",
                    Status = Statuses.InProcess.ToString(),
                    IsHot = false,
                    Type = Enums.NewsTypes.Entertainment.ToString()
                },
                new Models.News() 
                { 
                    Id = 2,
                    Title = "Title 2",
                    SubTitle = "SubTitle 2",
                    AuthorName = "Author name 2",
                    Information = "Information 2",
                    Status = Statuses.InProcess.ToString(),
                    IsHot = true,
                    Type = Enums.NewsTypes.Entertainment.ToString()
                },
                new Models.News() 
                { 
                    Id = 3,
                    Title = "Title 3",
                    SubTitle = "SubTitle 3",
                    AuthorName = "Author name 3",
                    Information = "Information 3",
                    Status = Statuses.InProcess.ToString(),
                    IsHot = false,
                    Type = Enums.NewsTypes.Science.ToString()
                },
                new Models.News() 
                { 
                    Id = 4,
                    Title = "Title 4",
                    SubTitle = "SubTitle 4",
                    AuthorName = "Author name 4",
                    Information = "Information 4",
                    Status = Statuses.InProcess.ToString(),
                    IsHot = true,
                    Type = Enums.NewsTypes.Sport.ToString()
                },
                new Models.News() 
                { 
                    Id = 5,
                    Title = "Title 5",
                    SubTitle = "SubTitle 5",
                    AuthorName = "Author name 5",
                    Information = "Information 5",
                    Status = Statuses.InProcess.ToString(),
                    IsHot = false,
                    Type = Enums.NewsTypes.Technology.ToString()
                }
            );
        }
    }
}