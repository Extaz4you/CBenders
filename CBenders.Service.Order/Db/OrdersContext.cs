using CBenders.Service.Orders.Model;
using Microsoft.EntityFrameworkCore;

namespace CBenders.Service.Orders.Db;

public class OrdersContext : DbContext
{
    public OrdersContext(DbContextOptions<OrdersContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderEntity>()
            .Property(o => o.OrderedDishes)
            .HasColumnType("jsonb");
    }
    public DbSet<OrderEntity> Orders { get; set; }
}
