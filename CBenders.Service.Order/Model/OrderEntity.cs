using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;

namespace CBenders.Service.Orders.Model;

public class OrderEntity
{
    [Key]
    public int Id { get; set; }
    public int TableNumber { get; set; }
    public DateTime DateOpen { get; set; } = DateTime.Now;
    public DateTime DateClose { get; set; }
    [Column(TypeName = "jsonb")]
    public List<DishesModel> OrderedDishes { get; set; }
    public double TotalPrice { get; set; }
    public bool isPaid { get; set; } = false;
}
