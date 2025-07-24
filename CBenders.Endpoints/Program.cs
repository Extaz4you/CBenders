
using CBenders.Endpoints.Models;
using CBenders.Endpoints.Services;
using System.Net.Http.Headers;

namespace CBenders.Endpoints
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient<MenuService>(cl =>
            {
                cl.BaseAddress = new Uri(builder.Configuration["ServicesApi:MenuAPI"]);
                cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            builder.Services.AddHttpClient<TableService>(cl =>
            {
                cl.BaseAddress = new Uri(builder.Configuration["ServicesApi:TablesAPI"]);
                cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            builder.Services.AddHttpClient<OrderService>(cl =>
            {
                cl.BaseAddress = new Uri(builder.Configuration["ServicesApi:OrderAPI"]);
                cl.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

            var app = builder.Build();

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
