using Newtonsoft.Json;

namespace DAL.Models.SteamGameModels
{
	public class SteamUserVanityResponseModel
	{
		[JsonProperty("response")]
		public SteamGameVanityURLModel Response { get; set; }
	}
}
