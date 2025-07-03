using System.ComponentModel.DataAnnotations;

namespace Server.Attributes
{
    public class ValidContactMethodAttribute : ValidationAttribute
    {
        // Allowed values as used in the HTML form
        private static readonly string[] AllowedMethods = ["email", "phone", "nopreference", ""];

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var str = value?.ToString()?.ToLowerInvariant() ?? "";

            if (AllowedMethods.Contains(str))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Invalid contact method. Allowed values: email, phone, nopreference.");
            }
        }
    }
}