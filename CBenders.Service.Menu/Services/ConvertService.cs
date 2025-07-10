using CBenders.Service.Menu.Models;
using CBenders.Service.Menu.Repository;
using System.Linq;

namespace CBenders.Service.Menu.Services;

public class ConvertService : IConvertModel
{
    public IEnumerable<ViewModel> GetList(IEnumerable<MenuItems> items) 
        => items.Select(x => new ViewModel(x)).ToList();

    public  IEnumerable<MenuItems> GetList(IEnumerable<ViewModel> items)
        =>  items.Select(x => new MenuItems(x)).ToList();

    public  ViewModel GetSingle(MenuItems item) 
        => new ViewModel(item);

    public  MenuItems GetSingle(ViewModel item)
        =>  new MenuItems(item);

}
