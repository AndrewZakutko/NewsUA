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

builder.Services.AddCors(opt => opt.AddPolicy("OpenCORSPolicy", builder => {
    builder.WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

var app = builder.Build();

app.UseCors("OpenCORSPolicy");   
app.MapControllers();

app.Run();
