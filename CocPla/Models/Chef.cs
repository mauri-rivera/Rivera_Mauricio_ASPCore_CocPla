using CocPla.DAO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CocPla.Models
{
    public class Chef
    {
        [Key]
        [Required]
        public int ChefId { get; set; }

        [Required(ErrorMessage = "El nombre del Chef es requerido")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El apellido del Chef es requerido")]
        public string LastName { get; set; }

        public string? NombreCompleto { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [DataType(DataType.Date)]
        [ValidaFechNac]
        public DateTime DateBirth { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Dish> TotalPlatos { get; set; } = new List<Dish>();
    }
}
