using CBenders.Endpoints.Models;

namespace CBenders.Endpoints.Services;

public class OrderService
{
    private HttpClient client;
    private ILogger<OrderService> logger;
    public OrderService(HttpClient httpClient, ILogger<OrderService> log)
    {
        client = httpClient;
        logger = log;
    }
    
    public async Task<IEnumerable<Order>> GetAll()
    {
        logger.LogInformation("try to get all");
        var response = await client.GetAsync($"All");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<Order>>();
    }
    public async Task<Order> GetById(int id)
    {
        logger.LogInformation($"try to get by {id}");
        var response = await client.GetAsync($"Get/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Order>();
    }
    public async Task<Order> Update(Order order)
    {
        logger.LogInformation($"try to update");
        var response = await client.PutAsJsonAsync($"Update", order);
        response.EnsureSuccessStatusCode();

        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
        {
            return default;
        }

        return await response.Content.ReadFromJsonAsync<Order>();
    }
    public async Task<Order> Create(Order order)
    {
        logger.LogInformation($"try to create");
        var response = await client.PostAsJsonAsync($"Create", order);

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Order>();
    }
}
