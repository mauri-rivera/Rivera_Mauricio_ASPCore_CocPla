using System.ComponentModel.DataAnnotations;

namespace CocPla.DAO
{
    public class ValidaCaloriasAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("La cantidad de calorías es requerida!");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
