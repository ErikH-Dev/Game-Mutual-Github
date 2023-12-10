using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SteamGameModels
{
	public class GameResponseModel
	{
		[JsonProperty("game_count")]
		public int GameCount { get; set; }
		[JsonProperty("games")]
		public List<SteamGameModel> Games { get; set; }
	}
}
