using Logic.Interface;
using Newtonsoft.Json;
using SharedObjects.SteamUserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
	public class SteamUserDAL : ISteamUserCollection
	{
		public async Task<List<SteamUserModel>> GetUserAsync(string steamUserId)
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
					return steamResponseModel.response.players.ToList();
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
