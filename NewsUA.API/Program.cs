using Microsoft.EntityFrameworkCore;
using NewsUA.API.Data;
using NewsUA.API.Interfaces;
using NewsUA.API.Repositories;
using NewsUA.API.Services;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<ITelegramSettingsRepository, TelegramSettingsRepository>();
builder.Services.AddScoped<IBlobStorageService, BlobStorageService>();
builder.Services.AddScoped<INewsTypesRepository, NewsTypesRepository>();

builder.Services.AddCors(opt => opt.AddPolicy("OpenCORSPolicy", builder => {
    builder.WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader();
}));
builder.Services.AddAzureClients(clientBuilder =>
{
	clientBuilder.AddBlobServiceClient(builder.Configuration["BlobStorage:BlobConnectionString:blob"], preferMsi: true);
	clientBuilder.AddQueueServiceClient(builder.Configuration["BlobStorage:BlobConnectionString:queue"], preferMsi: true);
});
builder.Services.AddAzureClients(clientBuilder =>
{
	clientBuilder.AddBlobServiceClient(builder.Configuration["BlobStorage:BlobConnectionString:blob"], preferMsi: true);
	clientBuilder.AddQueueServiceClient(builder.Configuration["BlobStorage:BlobConnectionString:queue"], preferMsi: true);
});
builder.Services.AddAzureClients(clientBuilder =>
{
	clientBuilder.AddBlobServiceClient(builder.Configuration["BlobStorage:BlobConnectionString:blob"], preferMsi: true);
	clientBuilder.AddQueueServiceClient(builder.Configuration["BlobStorage:BlobConnectionString:queue"], preferMsi: true);
});

var app = builder.Build();

app.UseCors("OpenCORSPolicy");   

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.Run();
