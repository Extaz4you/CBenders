using CBenders.Service.Menu.Models;
using Microsoft.EntityFrameworkCore;

namespace CBenders.Service.Menu.Db;

public class MenuContext : DbContext
{
    public MenuContext(DbContextOptions<MenuContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<MenuItems> Menu {  get; set; }
}
