using CBenders.Endpoints.Services.Interfaces;
using System.Net.Http;

namespace CBenders.Endpoints.Services;

public class BaseService<TDto, TId> : IApiService<TDto, TId> where TDto : class
{
    private HttpClient client;
    private readonly string apiEndpoint;
    private ILogger<BaseService<TDto, TId>> logger;

    public BaseService(HttpClient httpClient, string endpoint, ILogger<BaseService<TDto, TId>> log)
    {
        client = httpClient;
        apiEndpoint = endpoint;
        logger = log;
    }
    public async Task<TDto> CreateAsync(TDto dto)
    {
        LogOperationStart("Create");
        var response = await client.PostAsJsonAsync($"{apiEndpoint}/Create", dto);

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TDto>();
    }

    public async Task<bool> DeleteAsync(TId id)
    {
        LogOperationStart("Delete", id);
        var response = await client.DeleteAsync($"{apiEndpoint}/Delete/{id}");
        response.EnsureSuccessStatusCode();
        if (response.IsSuccessStatusCode) return true;
        return false;
    }

    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        LogOperationStart("GetAll");
        var response = await client.GetAsync($"{apiEndpoint}/All");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<TDto>>()??Enumerable.Empty<TDto>();
    }

    public async Task<TDto> GetByIdAsync(TId id)
    {
        LogOperationStart("GetById", id);
        var response = await client.GetAsync($"{apiEndpoint}/Get/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TDto>();
    }

    public async Task<TDto?> UpdateAsync(TDto dto)
    {
        LogOperationStart("Update");
        var response = await client.PutAsJsonAsync($"{apiEndpoint}/Update", dto);
        response.EnsureSuccessStatusCode();

        if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
        {
            return default;
        }

        return await response.Content.ReadFromJsonAsync<TDto>();
    }

    private void LogOperationStart(string operationName, object? id = null)
    {
        logger.LogInformation($"[{typeof(TDto).Name}] Starting {operationName} ID:{(id != null ? id : 0)}");
    }
}
