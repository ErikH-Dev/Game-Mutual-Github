using SharedObjects;
using System.ComponentModel.DataAnnotations;

namespace API.Models.General
{
	public class UserModel : IUser
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Subject { get; set; }
		[Required]
		public string Name { get; set; }
		[EmailAddress]
		public string Email { get; set; }
		[Url]
		public string Picture { get; set; }
		public string? SteamId { get; set; }
	}
}
