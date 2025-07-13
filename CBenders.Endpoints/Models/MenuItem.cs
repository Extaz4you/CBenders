using System.ComponentModel.DataAnnotations;

namespace CBenders.Endpoints.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Price { get; set; }
    }
}
