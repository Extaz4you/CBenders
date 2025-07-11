namespace CBenders.Web.Services.Interfaces;

public interface IApiClient<TDto, TId> where TDto : class 
{
    Task<IEnumerable<TDto>> All();
    Task<TDto> GetAsync(TId id);
    Task<TDto> DeleteAsync(TId id);

    Task<TDto> UpdateAsync(TDto dto);
    Task<TDto> CreateAsync(TDto dto);
}
