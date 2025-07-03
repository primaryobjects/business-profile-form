using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Server.Attributes
{
    public class ValidServiceAttribute : ValidationAttribute
    {
        // Allowed values as used in the HTML form
        private static readonly string[] AllowedServices = ["consulting", "support", "training"];

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IEnumerable<string> services)
            {
                foreach (var service in services)
                {
                    var str = service?.ToLowerInvariant() ?? "";
                    if (!AllowedServices.Contains(str))
                    {
                        return new ValidationResult($"Invalid service: {service}. Allowed values: consulting, support, training.");
                    }
                }
                return ValidationResult.Success;
            }

            // If value is not a list, treat as invalid
            return new ValidationResult("Services must be a list of strings.");
        }
    }
}