using System.ComponentModel.DataAnnotations;

namespace API.ValidationAttributes
{
	public class ValidSteam64ID : ValidationAttribute
	{
		protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
		{
			if (value == null)
			{
				return new ValidationResult("Steam64ID is required.");
			}
			if (value.ToString().Length != 17)
			{
				return new ValidationResult("Steam64ID must be 17 characters long.");
			}
			if (!long.TryParse(value.ToString(), out long steam64ID))
			{
				return new ValidationResult("Steam64ID must be a number.");
			}
			return ValidationResult.Success;
		}
	}
}
