using static CBenders.Web.Details;

namespace CBenders.Web.Models;

public class ApiRequest
{
    public ApiType ApiType { get; set; } = ApiType.GET;
    public string ApiUrl { get; set; }
    public object Data { get; set; }
    public string Token { get; set; }
}
