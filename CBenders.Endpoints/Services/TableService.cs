using CBenders.Endpoints.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CBenders.Endpoints.Services;

public class TableService: BaseService<Tables, int>
{
    public TableService(HttpClient httpClient, ILogger<BaseService<Tables, int>> log, IMemoryCache cache)
        : base(httpClient, "api/Tables", log, cache) { }

}
