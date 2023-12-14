using System.ComponentModel.DataAnnotations;
namespace API.Models
{
	public class UserCredentialsModel
	{
		[Required]
		public string Subject { get; set; }
		[Required]
		public string Nickname { get; set; }
		[Url]
		public string Picture { get; set; }
		[EmailAddress]
		public string Email { get; set; }
	}	
}
