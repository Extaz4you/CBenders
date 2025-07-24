using CBenders.Service.Orders.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace CBenders.Endpoints.Models;

public class Order
{
    public int TableNumber { get; set; }
    public DateTime DateOpen { get; set; } = DateTime.Now;
    public DateTime DateClose { get; set; }
    [Column(TypeName = "jsonb")]
    public List<DishesModel> OrderedDishes { get; set; }
    public double TotalPrice { get; set; }
    public bool isPaid { get; set; } = false;
}
