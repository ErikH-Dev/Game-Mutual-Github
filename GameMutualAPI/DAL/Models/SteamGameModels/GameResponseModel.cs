using Newtonsoft.Json;

namespace DAL.Models.SteamGameModels
{
	public class GameResponseModel
	{
		[JsonProperty("game_count")]
		public int GameCount { get; set; }
		[JsonProperty("games")]
		public List<SteamGameModel> Games { get; set; }
	}
}
