using Newtonsoft.Json;
using SharedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.SteamGameModels
{
	public class SteamGameModel : ISteamGame
	{
		[JsonProperty("appid")]
		public int AppID { get; set; }
		[JsonProperty("name")]
		public string Name { get; set; }
	}
}
