
using CBenders.Endpoints.Models;
using CBenders.Endpoints.Services;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System.Net.Http.Headers;

namespace CBenders.Endpoints
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(builder.Configuration["SerilogWeb"]))
                {
                    IndexFormat = "gateway-logs-{0:yyyy.MM.dd}",
                    AutoRegisterTemplate = true,
                    MinimumLogEventLevel = Serilog.Events.LogEventLevel.Information,
                })
                .Enrich.WithProperty("Service", "Gateway") 
                .Enrich.FromLogContext()  
                .CreateLogger();

            builder.Host.UseSerilog();

            builder.Host.UseSerilog();

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
