using CBenders.Service.Menu.Models;

namespace CBenders.Service.Menu.Repository;

public interface IMenuRepositories
{
    Task<IEnumerable<MenuItems>> GetAll();
    Task<MenuItems> Get(int id);
    Task<MenuItems> Update(MenuItems item);
    Task<bool> Delete(int id);
    Task<MenuItems> Create(MenuItems item);
}
