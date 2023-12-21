using SharedObjects;

namespace Logic.Interface
{
	public interface ISteamUserCollection
	{
		Task<IEnumerable<ISteamUser>> GetUserByIDAsync(string steamUserId);
		Task<string> GetUserByCustomIDAsync(string steamUserCustomId);
	}
}
