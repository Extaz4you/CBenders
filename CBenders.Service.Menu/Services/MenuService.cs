using CBenders.Service.Menu.Db;
using CBenders.Service.Menu.Models;
using CBenders.Service.Menu.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace CBenders.Service.Menu.Services;

public class MenuService : IMenuRepositories
{
    private MenuContext context;
    private ILogger<MenuService> logger;

    public MenuService(MenuContext db, ILogger<MenuService> log, IConvertModel convertModel)
    {
        context = db;
        logger = log;
    }

    public async Task<MenuItems> Create(MenuItems item)
    {
        await context.Menu.AddAsync(item);
        await context.SaveChangesAsync();
        item.Id = context.Menu.Count() > 0 ? context.Menu.Max(x => x.Id) : 1;
        return item;
    }

    public async Task<bool> Delete(int id)
    {
        var item = await context.Menu.FirstOrDefaultAsync(x => x.Id == id);
        if (item != null)
        {
            context.Menu.Remove(item);
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<MenuItems> Get(int id) =>  await context.Menu.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<MenuItems>> GetAll() => await context.Menu.ToListAsync();

    public async Task<MenuItems> Update(MenuItems item)
    {
        var updatedItem = await context.Menu.FirstOrDefaultAsync(x => x.Id == item.Id);
        if (updatedItem != null)
        {
            context.Update(item);
            await context.SaveChangesAsync();
            return item;
        }
        else return null;
    }

}
