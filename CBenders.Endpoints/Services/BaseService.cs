using CBenders.Endpoints.Services.Interfaces;
using System.Net.Http;

namespace CBenders.Endpoints.Services;

public class BaseService<TDto, TId> : IApiService<TDto, TId> where TDto : class
{
    private HttpClient client;
    private readonly string apiEndpoint;

    public BaseService(HttpClient httpClient, string endpoint)
    {
        client = httpClient;
        apiEndpoint = endpoint;
    }
    public async Task<TDto> CreateAsync(TDto dto)
    {
        var response = await client.PostAsJsonAsync($"{apiEndpoint}/Create", dto);

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TDto>();
    }

    public async Task<bool> DeleteAsync(TId id)
    {
        var response = await client.DeleteAsync($"{apiEndpoint}/Delete/{id}");
        response.EnsureSuccessStatusCode();
        if (response.IsSuccessStatusCode) return true;
        return false;
    }

    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        var response = await client.GetAsync($"{apiEndpoint}/All");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<TDto>>()??Enumerable.Empty<TDto>();
    }

    public async Task<TDto> GetByIdAsync(TId id)
    {

        var response = await client.GetAsync($"{apiEndpoint}/Get/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TDto>();
    }

    public async Task<TDto?> UpdateAsync(TDto dto)
    {
        var response = await client.PutAsJsonAsync($"{apiEndpoint}/Update", dto);
        response.EnsureSuccessStatusCode();

        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
        {
            return default;
        }

        return await response.Content.ReadFromJsonAsync<TDto>();
    }
}
