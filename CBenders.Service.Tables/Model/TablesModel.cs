using System.ComponentModel.DataAnnotations;

namespace CBenders.Service.Tables.Model;

public class TablesModel
{
    [Key]
    public int TableId { get; set; }
    public int TableNumber { get; set; }
    public bool isReserved { get; set; }
}
