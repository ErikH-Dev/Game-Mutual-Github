using Newtonsoft.Json;
using SharedObjects;

namespace DAL.Models.SteamGameModels
{
	public class SteamGameModel : ISteamGame
	{
		[JsonProperty("appid")]
		public int AppID { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
