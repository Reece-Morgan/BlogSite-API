using BlogSite_API.Helpers;
using BlogSite_API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddDbContext<BlogContext>(opt => opt.UseInMemoryDatabase("BlogList"));
builder.Services.AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase("Users"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.WithOrigins(new[] {"http://localhost:3000"} ).AllowAnyHeader().AllowAnyMethod().AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();
