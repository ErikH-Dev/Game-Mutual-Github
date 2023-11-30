using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.SteamGameModels
{
	public class GameResponseModel
	{
		public int game_count { get; set; }
		public List<SteamGameModel> games { get; set; }
	}
}
