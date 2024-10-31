using Microsoft.EntityFrameworkCore;
using NorebaseTechnicalChallenge.Contracts;
using NorebaseTechnicalChallenge.Repository;
using NorebaseTechnicalChallenge.Service;
using AspNetCoreRateLimit;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register IMemoryCache
builder.Services.AddMemoryCache();

builder.Services.AddScoped<ILikeService, LikeService>();        
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add rate limiting services
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.AddInMemoryRateLimiting();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseIpRateLimiting();
app.UseAuthorization();

app.MapControllers();

app.Run();
