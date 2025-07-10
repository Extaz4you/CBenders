using System.ComponentModel.DataAnnotations;

namespace CBenders.Service.Menu.Models;

public class MenuItems
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    [Required]
    [Range(1,10000)]
    public double Price { get; set; }

    public MenuItems()
    {
        
    }
    public MenuItems(ViewModel view)
    {
        this.Name = view.Name;
        this.Price = view.Price;
    }
}
