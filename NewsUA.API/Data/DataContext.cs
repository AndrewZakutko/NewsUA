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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<News>().HasData(
                new Models.News() 
                { 
                    Id = 1,
                    Title = "Title 1",
                    SubTitle = "SubTitle 1",
                    AuthorName = "Author name 1",
                    Information = "Information 1",
                    Status = Statuses.InProcess.ToString(),
                    HotStatus = HotStatuses.Basic.ToString()
                },
                new Models.News() 
                { 
                    Id = 2,
                    Title = "Title 2",
                    SubTitle = "SubTitle 2",
                    AuthorName = "Author name 2",
                    Information = "Information 2",
                    Status = Statuses.InProcess.ToString(),
                    HotStatus = HotStatuses.Hot.ToString()
                },
                new Models.News() 
                { 
                    Id = 3,
                    Title = "Title 3",
                    SubTitle = "SubTitle 3",
                    AuthorName = "Author name 3",
                    Information = "Information 3",
                    Status = Statuses.InProcess.ToString(),
                    HotStatus = HotStatuses.Basic.ToString()
                },
                new Models.News() 
                { 
                    Id = 4,
                    Title = "Title 4",
                    SubTitle = "SubTitle 4",
                    AuthorName = "Author name 4",
                    Information = "Information 4",
                    Status = Statuses.InProcess.ToString(),
                    HotStatus = HotStatuses.Basic.ToString()
                },
                new Models.News() 
                { 
                    Id = 5,
                    Title = "Title 5",
                    SubTitle = "SubTitle 5",
                    AuthorName = "Author name 5",
                    Information = "Information 5",
                    Status = Statuses.InProcess.ToString(),
                    HotStatus = HotStatuses.Basic.ToString()
                }
            );
        }
    }
}