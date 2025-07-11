using CBenders.Web.Models;
using CBenders.Web.Services.Interfaces;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CBenders.Web.Services;

public class BaseService : IBaseService
{
    private IHttpClientFactory HttpClient { get; set; }
    public ViewModel Model { get; set; }


    public BaseService(IHttpClientFactory httpClientFactory)
    {
        this.Model = new ViewModel(null);
        this.HttpClient = httpClientFactory;
    }

    public async Task<T> SendASync<T>(ApiRequest request)
    {
        try
        {
            var cl = HttpClient.CreateClient("CBendersAPI");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(request.ApiUrl);
            cl.DefaultRequestHeaders.Clear();
            if (request.Data != null)
            {
                message.Content = new StringContent(JsonSerializer.Serialize(request.Data), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage httpResponse = null;

            switch (request.ApiType)
            {
                case Details.ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case Details.ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case Details.ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get; 
                    break;
            }
            httpResponse = await cl.SendAsync(message);
            var content = await httpResponse.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<T>(content);
            return response;
        }
        catch (Exception ex)
        {
            var x = JsonSerializer.Serialize(new ViewModel(null));
            return JsonSerializer.Deserialize<T>(x);
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }
}
