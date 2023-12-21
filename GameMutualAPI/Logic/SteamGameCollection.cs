using Logic.Interface;
using SharedObjects;

namespace Logic
{
	public class SteamGameCollection
	{
		private readonly ISteamGameCollection _iSteamGameCollection;

		public SteamGameCollection(ISteamGameCollection iSteamGameCollection)
		{
			_iSteamGameCollection = iSteamGameCollection;
		}
		public async Task<IEnumerable<ISteamGame>> GetGamesOfUserAsync(string steamUserId)
		{
			return await _iSteamGameCollection.GetGamesOfUserAsync(steamUserId);
		}
		public async Task<IEnumerable<ISteamGame>> GetMutualGamesAsync(List<string> steamUserIDs)
		{
			Dictionary<string, IEnumerable<ISteamGame>> gamesPerUser = new Dictionary<string, IEnumerable<ISteamGame>>();
			foreach (string userId in steamUserIDs)
			{
				gamesPerUser.Add(userId, await _iSteamGameCollection.GetGamesOfUserAsync(userId));
			}
			return FilterMutualGames(gamesPerUser);
		}

		private IEnumerable<ISteamGame> FilterMutualGames(Dictionary<string, IEnumerable<ISteamGame>> gamesPerUser)
		{
			SteamGameEqualityComparer equalityComparer = new SteamGameEqualityComparer();
			Dictionary<string, IEnumerable<ISteamGame>>? sortedDictionary = SortDictionaryByListCount(gamesPerUser);
			IEnumerable<ISteamGame> commonObjects = sortedDictionary.First().Value;

			foreach (var value in sortedDictionary.Values.Skip(1))
			{
				commonObjects = commonObjects.Intersect(value, equalityComparer).ToList();
			}

			return commonObjects;
		}
		private Dictionary<string, IEnumerable<ISteamGame>> SortDictionaryByListCount(Dictionary<string, IEnumerable<ISteamGame>> gamesPerUser)
		{
			return gamesPerUser.OrderBy(kv => kv.Value.Count()).ToDictionary(kv => kv.Key, kv => kv.Value);
		}

		public class SteamGameEqualityComparer : IEqualityComparer<ISteamGame>
		{
			public bool Equals(ISteamGame x, ISteamGame y)
			{
				return x.AppID == y.AppID;
			}

			public int GetHashCode(ISteamGame obj)
			{
				return obj.AppID.GetHashCode();
			}
		}
	}
}
