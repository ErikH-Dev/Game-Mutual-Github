using Newtonsoft.Json;

namespace DAL.Models.SteamGameModels
{
	public class SteamGameResponseModel
	{
		[JsonProperty("response")]
		public GameResponseModel Response { get; set; }
	}
}
