using CBenders.Service.Menu.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CBenders.Service.Menu.Repository;

public interface IConvertModel
{
     ViewModel GetSingle(MenuItems item);
     MenuItems GetSingle(ViewModel item);
     IEnumerable<MenuItems> GetList(IEnumerable<ViewModel> items);
     IEnumerable<ViewModel> GetList(IEnumerable<MenuItems> items);
}
