using CBenders.Endpoints.Models;

namespace CBenders.Endpoints.Services;

public class TableService: BaseService<Tables, int>
{
    public TableService(HttpClient httpClient, ILogger<BaseService<Tables, int>> log) : base(httpClient, "api/Tables", log) { }

}
