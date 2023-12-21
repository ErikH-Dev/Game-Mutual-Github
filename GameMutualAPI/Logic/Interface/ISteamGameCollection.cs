using SharedObjects;

namespace Logic.Interface
{
	public interface ISteamGameCollection
	{
		Task<IEnumerable<ISteamGame>> GetGamesOfUserAsync(string steamUserId);
	}
}
