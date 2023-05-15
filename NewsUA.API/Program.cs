using Microsoft.EntityFrameworkCore;
using NewsUA.API.Data;
using NewsUA.API.Interfaces;
using NewsUA.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt => {
    opt.UseSqlServer(@"Data Source=.\SQL2016;Initial Catalog=NewsDb;Trusted_Connection=True;TrustServerCertificate=True");
});
builder.Services.AddScoped<INewsRepository, NewsRepository>();

var app = builder.Build();

app.MapControllers();

app.Run();
