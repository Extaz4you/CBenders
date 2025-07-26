
using CBenders.Service.Menu.Db;
using CBenders.Service.Menu.Repository;
using CBenders.Service.Menu.Services;
using Microsoft.EntityFrameworkCore;

namespace CBenders.Service.Menu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddDbContext<MenuContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));
            builder.Services.AddDbContext<MenuContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("Connection2")));
            builder.Services.AddScoped<IMenuRepositories, MenuService>();
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
