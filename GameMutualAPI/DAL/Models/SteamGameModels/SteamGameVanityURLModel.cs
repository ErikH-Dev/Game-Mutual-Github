using Newtonsoft.Json;

namespace DAL.Models.SteamGameModels
{
	public class SteamGameVanityURLModel
	{
		[JsonProperty("steamid")]
		public string SteamID { get; set; }
		[JsonProperty("success")]
		public int Success { get; set; }
	}
}
