
using CBenders.Service.Tables.Db;
using CBenders.Service.Tables.Services;
using Microsoft.EntityFrameworkCore;

namespace CBenders.Service.Tables;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<TablesContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("Connection2")));
        builder.Services.AddScoped<TablesService>();
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
