using CBenders.Endpoints.Models;

namespace CBenders.Endpoints.Services;

public class TableService: BaseService<Tables, int>
{
    public TableService(HttpClient httpClient) : base(httpClient, "api/Tables") { }

}
