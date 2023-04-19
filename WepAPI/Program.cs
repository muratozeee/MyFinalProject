
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Microsoft.EntityFrameworkCore;

namespace WepAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //IoC container()
            //Also when we see the ICategoryService we can get the CategoryManager  coming with ICategoryService
            //we are used them if they dont have the data
            //data with transiet and scope
            builder.Services.AddSingleton<ICategoryService,CategoryManager>();
            builder.Services.AddSingleton<ICategoryDal, EfCategoryDal>();

            builder.Services.AddSingleton<IProductService, ProductManager>();
            builder.Services.AddSingleton<IProductDal, EfProductDal>();


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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}