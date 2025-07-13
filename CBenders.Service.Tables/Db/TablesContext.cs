using CBenders.Service.Tables.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CBenders.Service.Tables.Db;

public class TablesContext: DbContext
{
    public TablesContext(DbContextOptions<TablesContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<TablesModel> Tables { get; set; }
}
