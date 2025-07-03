using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Server.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class ValidValuesAttribute(params string[] allowedValues) : ValidationAttribute
    {
        private readonly string[] _allowedValues = [.. allowedValues.Select(v => v.ToLowerInvariant())];

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            IEnumerable items = value is string or null
                ? new[] { value }
                : (IEnumerable)value;

            foreach (var item in items)
            {
                var str = item?.ToString()?.ToLowerInvariant() ?? "";
                if (!_allowedValues.Contains(str))
                {
                    return new ValidationResult($"Invalid value: {item}. Allowed values: {string.Join(", ", _allowedValues)}.");
                }
            }

            return ValidationResult.Success;
        }
    }
}