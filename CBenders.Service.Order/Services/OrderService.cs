using CBenders.Service.Orders.Db;
using CBenders.Service.Orders.Model;
using Microsoft.EntityFrameworkCore;

namespace CBenders.Service.Orders.Services;

public class OrderService
{
    private OrdersContext context;

    public OrderService(OrdersContext ordersContext)
    {
        context = ordersContext;
    }

    public async Task<IEnumerable<OrderEntity>> GetAll()
    {
        return await context.Orders.ToListAsync();
    }
    public async Task<OrderEntity> GetById(int id)
    {
        try
        {
            return context.Orders.FirstOrDefault(x => x.Id == id);
        }
        catch { return new OrderEntity(); }
    }

    public async Task<bool> Create(OrderEntity order)
    {
        await context.Orders.AddAsync(order);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(OrderEntity order)
    {
        var findOrder = context.Orders.FirstOrDefault(x => x.Id == order.Id);
        if (findOrder == null) return false;
        try
        {
            context.Update(order);
            await context.SaveChangesAsync();
            return true;
        }
        catch { return true; }

    }
}
