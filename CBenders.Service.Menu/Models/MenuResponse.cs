using System.Net;

namespace CBenders.Service.Menu.Models;

public class MenuResponse
{
    public bool IsSuccess { get; set; } = true;
    public object Data { get; set; }

    public HttpStatusCode StatusCode { get; set; }
    public List<string> Errors { get; set; }

}
