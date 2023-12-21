using SharedObjects;

namespace Logic.Objects
{
	public class User : IUser
	{
		public int Id { get; set; }
		public string Subject { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Picture { get; set; }
		public string? SteamId { get; set; }
	}
}
