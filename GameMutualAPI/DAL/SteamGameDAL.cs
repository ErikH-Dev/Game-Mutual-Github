using DAL.SteamGameModels;
using Logic.Interface;
using Newtonsoft.Json;
using SharedObjects;

namespace DAL
{
	public class SteamGameDAL : ISteamGameCollection
	{
		public async Task<IEnumerable<ISteamGame>> GetGamesOfUserAsync(string steamUserId)
		{
			string baseUrl = $"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key={ApiHelper.key}&steamids={steamUserId}&include_appinfo=true&include_played_free_games=true&format=json&steamid={steamUserId}&format=json";
			ApiHelper.IntializeClient();
			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(baseUrl))
			{
				try
				{
					var json = await response.Content.ReadAsStringAsync();
					if (string.IsNullOrEmpty(json))
					{
						return new List<SteamGameModel>();
					}
					SteamGameResponseModel? steamResponseModel = JsonConvert.DeserializeObject<SteamGameResponseModel>(json);
					return steamResponseModel.Response.Games.ToList();
				}
				catch (JsonSerializationException ex)
				{
					throw new Exception("Failed to deserialize JSON response.", ex);
				}
				catch (Exception ex)
				{
					throw new Exception("An error occurred while processing the API response.", ex);
				}
			}
		}
	}
}