using BookStore.Application.Services;
using BookStore.Core.Abstractions;
using BookStore.Data;
using BookStore.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString(nameof(BookStoreDbContext))));

            builder.Services.AddScoped<IBooksRepository, BooksRepository>();
            builder.Services.AddScoped<IAuthorsRepository, AuthorsRepository>();

            builder.Services.AddScoped<IBooksService, BooksService>();
            builder.Services.AddScoped<IAuthorsService, AuthorsService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(x =>
            {
                x.WithHeaders().AllowAnyHeader();
                x.WithOrigins("http://localhost:3000");
                x.WithMethods().AllowAnyMethod();
            });

            app.MapControllers();

            app.Run();
        }
    }
}
