using CBenders.Endpoints.Models;

namespace CBenders.Endpoints.Services;

public class OrderService
{
    private HttpClient client;
    public OrderService(HttpClient httpClient)
    {
        client = httpClient;
    }
    
    public async Task<IEnumerable<Order>> GetAll()
    {
        var response = await client.GetAsync($"All");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<Order>>();
    }
    public async Task<Order> GetById(int id)
    {
        var response = await client.GetAsync($"Get/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Order>();
    }
    public async Task<Order> Update(Order order)
    {
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
        var response = await client.PostAsJsonAsync($"Create", order);

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Order>();
    }
}
