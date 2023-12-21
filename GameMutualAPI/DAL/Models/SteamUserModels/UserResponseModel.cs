using Newtonsoft.Json;

namespace DAL.Models.SteamUserModels
{
	public class UserResponseModel
	{
		[JsonProperty("players")]
		public List<SteamUserModel> Players { get; set; }
	}
}
