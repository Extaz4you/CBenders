namespace CBenders.Endpoints.Services.Interfaces;

public interface IApiService<TDto, TId> where TDto : class
{
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<TDto> GetByIdAsync(TId id);
    Task<bool> DeleteAsync(TId id);
    Task<TDto> UpdateAsync(TDto dto);
    Task<TDto> CreateAsync(TDto dto);
}
