using CBenders.Endpoints.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http;

namespace CBenders.Endpoints.Services;

public class BaseService<TDto, TId> : IApiService<TDto, TId> where TDto : class
{
    private HttpClient client;
    private readonly string apiEndpoint;
    private ILogger<BaseService<TDto, TId>> logger;
    private readonly IMemoryCache cache;

    public BaseService(HttpClient httpClient, string endpoint, ILogger<BaseService<TDto, TId>> log, IMemoryCache memoryCache)
    {
        client = httpClient;
        apiEndpoint = endpoint;
        logger = log;
        cache = memoryCache;
    }
    public async Task<TDto> CreateAsync(TDto dto)
    {
        LogOperationStart("Create");
        var response = await client.PostAsJsonAsync($"{apiEndpoint}/Create", dto);

        response.EnsureSuccessStatusCode();
        cache.Remove($"{typeof(TDto).Name}_GetAll");
        return await response.Content.ReadFromJsonAsync<TDto>();
    }

    public async Task<bool> DeleteAsync(TId id)
    {
        LogOperationStart("Delete", id);
        var response = await client.DeleteAsync($"{apiEndpoint}/Delete/{id}");
        response.EnsureSuccessStatusCode();

        cache.Remove($"{typeof(TDto).Name}_GetById_{id}");
        cache.Remove($"{typeof(TDto).Name}_GetAll");
        if (response.IsSuccessStatusCode) return true;
        return false;
    }

    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        var cacheKey = $"{typeof(TDto).Name}_GetAll";

        if (cache.TryGetValue(cacheKey, out IEnumerable<TDto> cachedItems))
        {
            logger.LogInformation($"[{typeof(TDto).Name}] GetAll returned from cache");
            return cachedItems;
        }


        LogOperationStart("GetAll");
        var response = await client.GetAsync($"{apiEndpoint}/All");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<IEnumerable<TDto>>() ?? Enumerable.Empty<TDto>();
        cache.Set(cacheKey, result, TimeSpan.FromMinutes(5));
        return result;
    }

    public async Task<TDto> GetByIdAsync(TId id)
    {
        var cacheKey = $"{typeof(TDto).Name}_GetById_{id}";
        if (cache.TryGetValue(cacheKey, out TDto cachedItem))
        {
            logger.LogInformation($"[{typeof(TDto).Name}] GetById ID: {id} returned from cache");
            return cachedItem;
        }

        LogOperationStart("GetById", id);
        var response = await client.GetAsync($"{apiEndpoint}/Get/{id}");
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<TDto>();
        cache.Set(cacheKey, result, TimeSpan.FromMinutes(5));
        return result;
    }

    public async Task<TDto?> UpdateAsync(TDto dto)
    {
        LogOperationStart("Update");
        var response = await client.PutAsJsonAsync($"{apiEndpoint}/Update", dto);
        response.EnsureSuccessStatusCode();

        cache.Remove($"{typeof(TDto).Name}_GetAll");

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
