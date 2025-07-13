using CBenders.Endpoints.Models;

namespace CBenders.Endpoints.Services;

public class MenuService : BaseService<MenuItem, int>
{
    public MenuService(HttpClient httpClient) : base(httpClient, "api/Menu")
    {
    }
}
