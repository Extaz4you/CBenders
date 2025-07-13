using CBenders.Service.Tables.Db;
using CBenders.Service.Tables.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CBenders.Service.Tables.Services;

public class TablesService
{
    private TablesContext context;
    public TablesService(TablesContext tablesContext)
    {
        context = tablesContext;
    }
    public async Task<IEnumerable<TablesModel>> All() => await context.Tables.ToListAsync();
    public async Task<TablesModel> GetById(int id) => await context.Tables.FirstOrDefaultAsync(x => x.TableId == id);
    public async Task Delete(int id) => context.Remove(id);
    public async Task Update(TablesModel model) => context.Update(model);
    public async Task Create(TablesModel model) => await context.AddAsync(model);
    public async Task SaveAsync() => await context.SaveChangesAsync();
}
