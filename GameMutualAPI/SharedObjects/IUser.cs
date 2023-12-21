namespace SharedObjects
{
	public interface IUser
	{
		int Id { get; set; }
		string Subject { get; set; }
		string Name { get; set; }
		string Email { get; set; }
		string Picture { get; set; }
		string? SteamId { get; set; }
	}
}
