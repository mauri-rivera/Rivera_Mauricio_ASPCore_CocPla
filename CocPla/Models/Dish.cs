using CocPla.DAO;
using System.ComponentModel.DataAnnotations;

namespace CocPla.Models
{
    public class Dish
    {
        [Key]
        [Required]
        public int DishId { get; set; }

        [Required(ErrorMessage = "El nombre del plato es requerido")]
        public string Name { get; set; }

        [Required]
        [ValidaCalorias]
        public int Calories { get; set; }

        [Required]
        public int Tastiness { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int? ChefId { get; set; }

        public Chef? Cocinero { get; set; } 
    }
}
