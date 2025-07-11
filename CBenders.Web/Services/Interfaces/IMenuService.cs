using CBenders.W.Menu.Models;
using CBenders.Web.Models;

namespace CBenders.Web.Services.Interfaces;

public interface IMenuService
{
    Task<T> GetAllMenuAsync<T>();
    Task<T> GetMenuItemAsync<T>(int id);
    Task<T> CreateMenuItemAsync<T>(MenuItems item);
    Task<T> DeleteMenuItemAsync<T>(int id);
    Task<T> UpdateMenuItemAsync<T>(MenuItems item);
}
