using Microsoft.Extensions.Caching.Memory;
using SharedObjects;

namespace Logic
{
	public class SteamGameCacheHandler
	{
		private readonly SteamGameCollection _steamGameCollection;
		private readonly IMemoryCache _memoryCache;
		private readonly TimeSpan CACHE_DURATION = TimeSpan.FromMinutes(5);

		public SteamGameCacheHandler(IMemoryCache memoryCache, SteamGameCollection steamGameCollection)
		{
			_memoryCache = memoryCache;
			_steamGameCollection = steamGameCollection;
		}

		public async Task<IEnumerable<ISteamGame>> GetGamesOfUser(string steamUserId)
		{
			string cacheKey = $"GamesOfUser_{steamUserId}";

			return await GetOrSetCache(cacheKey, async () => await FetchGamesOfUser(steamUserId));
		}

		public async Task<IEnumerable<ISteamGame>> GetMutualGames(List<string> steamUserIDs)
		{
			string cacheKey = $"MutualGames_{string.Join("_", steamUserIDs)}";

			return await GetOrSetCache(cacheKey, async () => await FetchMutualGames(steamUserIDs));
		}

		private async Task<T> GetOrSetCache<T>(string cacheKey, Func<Task<T>> fetchData)
		{
			if (!_memoryCache.TryGetValue(cacheKey, out T cachedData))
			{
				cachedData = await fetchData();
				_memoryCache.Set(cacheKey, cachedData, CACHE_DURATION);
			}
			return cachedData;
		}
		private async Task<IEnumerable<ISteamGame>> FetchGamesOfUser(string steamUserId)
		{
			return await _steamGameCollection.GetGamesOfUserAsync(steamUserId);
		}
		private async Task<IEnumerable<ISteamGame>> FetchMutualGames(List<string> steamUserIDs)
		{
			return await _steamGameCollection.GetMutualGamesAsync(steamUserIDs);
		}
	}
}
