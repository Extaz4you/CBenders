using CBenders.Endpoints.Models;

namespace CBenders.Endpoints.Services;

public class MenuService : BaseService<MenuItem, int>
{
    private ILogger<MenuService> logger;
    public MenuService(HttpClient httpClient, ILogger<BaseService<MenuItem, int>> log) : base(httpClient, "api/Menu", log)
    {

    }
}
