using CBenders.Web.Models.DTOs;

namespace CBenders.Web.Services.Clients
{
    public class MenuClient : BaseApiClient<MenuDto, int>
    {
        public MenuClient(IHttpClientFactory httpClientFactory) : base("api/Menu", httpClientFactory) { }
    }
}
