using DAL.Models.SteamGameModels;
using DAL.Models.SteamUserModels;
using Logic.Interface;
using Newtonsoft.Json;
using SharedObjects;

namespace DAL
{
	public class SteamUserDAL : ISteamUserCollection
	{
		public async Task<IEnumerable<ISteamUser>> GetUserByIDAsync(string steamUserId)
		{
			string baseUrl = $"https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={ApiHelper.key}&steamids={steamUserId}";
			ApiHelper.IntializeClient();
			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(baseUrl))
			{
				try
				{
					var json = await response.Content.ReadAsStringAsync();
					if (string.IsNullOrEmpty(json))
					{
						return null;
					}
					SteamUserResponseModel? steamResponseModel = JsonConvert.DeserializeObject<SteamUserResponseModel>(json);
					return steamResponseModel.Response.Players;
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
		public async Task<string> GetUserByCustomIDAsync(string steamUserCustomId)
		{
			string baseUrl = $"http://api.steampowered.com/ISteamUser/ResolveVanityURL/v0001/?key={ApiHelper.key}&vanityurl={steamUserCustomId}";
			ApiHelper.IntializeClient();
			using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(baseUrl))
			{
				try
				{
					var json = await response.Content.ReadAsStringAsync();
					if (string.IsNullOrEmpty(json))
					{
						return null;
					}
					SteamUserVanityResponseModel responseModel = JsonConvert.DeserializeObject<SteamUserVanityResponseModel>(json);
					return responseModel.Response.SteamID;
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
