using System.ComponentModel.DataAnnotations;

namespace API.ValidationAttributes
{
	public class ValidSteamVanityURL : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			string steamVanityURL = value as string;
			if (steamVanityURL.Length < 3 || steamVanityURL.Length > 32)
			{
				return new ValidationResult("Steam Vanity URL must be between 3 and 32 characters long.");
			}
			foreach (char c in steamVanityURL)
			{
				if (!char.IsLetterOrDigit(c) && c != '_')
				{
					return new ValidationResult("Steam Vanity URL can only contain letters, numbers, and underscores.");
				}
			}
			return ValidationResult.Success;
		}
	}
}
