using CBenders.Web.Services.Interfaces;

namespace CBenders.Web.Services;

public abstract class BaseApiClient<TDto, TId> : IApiClient<TDto, TId> where TDto : class
{
    private IHttpClientFactory httpClient;
    private readonly string apiEndpoint;

    protected BaseApiClient(string endpoint, IHttpClientFactory httpClientFactory)
    {
        httpClient = httpClientFactory;
        apiEndpoint = endpoint;
    }
    public async Task<IEnumerable<TDto>> All()
    {
        var client = httpClient.CreateClient();
        var url = $"{apiEndpoint}/all";

        var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<IEnumerable<TDto>>();

    }

    public Task<TDto> CreateAsync(TDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<TDto> DeleteAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<TDto> GetAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<TDto> UpdateAsync(TDto dto)
    {
        throw new NotImplementedException();
    }
}
