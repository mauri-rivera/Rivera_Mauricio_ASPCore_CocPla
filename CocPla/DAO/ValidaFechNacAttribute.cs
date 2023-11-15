using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CocPla.DAO
{
    public class ValidaFechNacAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime fechaActual = DateTime.Today;
            TimeSpan difFechas = fechaActual - Convert.ToDateTime(value);
            int edad = (int)(difFechas.TotalDays / 365.225);

            if (value == null)
            {
                return new ValidationResult("La fecha de nacimiento es requerida!");
            }

            if (edad < 18)
            {
                return new ValidationResult("El cocinero debe tener al menos 18 años!");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
