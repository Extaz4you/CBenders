using CBenders.Endpoints.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CBenders.Endpoints.Services;

public class MenuService : BaseService<MenuItem, int>
{
    private ILogger<MenuService> logger;
    public MenuService(HttpClient httpClient, ILogger<BaseService<MenuItem, int>> log, IMemoryCache cache) 
        : base(httpClient, "api/Menu", log, cache){}
}
