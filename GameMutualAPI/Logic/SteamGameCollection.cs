using Logic.Interface;
using Newtonsoft.Json;
using SharedObjects.SteamGameModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SteamGameCollection
	{
		private readonly ISteamGameCollection _iSteamGameCollection;

		public SteamGameCollection(ISteamGameCollection iSteamGameCollection)
		{
			_iSteamGameCollection = iSteamGameCollection;
		}
		public async Task<List<SteamGameModel>> GetGamesOfUserAsync(string steamUserId)
		{
			return await _iSteamGameCollection.GetGamesOfUserAsync(steamUserId);
		}
		public async Task<List<SteamGameModel>> GetMutualGamesAsync(List<string> steamUserIDs)
		{
            Dictionary<string, List<SteamGameModel>> gamesPerUser = new Dictionary<string, List<SteamGameModel>>();
			foreach (string userId in steamUserIDs)
			{
				gamesPerUser.Add(userId, await _iSteamGameCollection.GetGamesOfUserAsync(userId));
			}
			return FilterMutualGames(gamesPerUser);
		}

		private List<SteamGameModel> FilterMutualGames(Dictionary<string, List<SteamGameModel>> gamesPerUser)
		{
			SteamGameEqualityComparer equalityComparer = new SteamGameEqualityComparer();
            Dictionary<string, List<SteamGameModel>>? sortedDictionary = SortDictionaryByListCount(gamesPerUser);
            List<SteamGameModel> commonObjects = sortedDictionary.First().Value;

			foreach (var value in sortedDictionary.Values.Skip(1))
			{
				commonObjects = commonObjects.Intersect(value, equalityComparer).ToList();
			}

			return commonObjects;
		}
		private  Dictionary<string, List<SteamGameModel>> SortDictionaryByListCount(Dictionary<string, List<SteamGameModel>> gamesPerUser)
		{
			return gamesPerUser.OrderBy(kv => kv.Value.Count).ToDictionary(kv => kv.Key, kv => kv.Value);
		}

		public class SteamGameEqualityComparer : IEqualityComparer<SteamGameModel>
		{
			public bool Equals(SteamGameModel x, SteamGameModel y)
			{
				return x.appid == y.appid;
			}

			public int GetHashCode(SteamGameModel obj)
			{
				return obj.appid.GetHashCode();
			}
		}
	}
}
