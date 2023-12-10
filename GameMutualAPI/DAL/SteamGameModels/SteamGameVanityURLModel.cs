using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SteamGameModels
{
	public class SteamGameVanityURLModel
	{
		[JsonProperty("steamid")]
		public string SteamID { get; set; }
		[JsonProperty("success")]
		public int Success { get; set; }
	}
}
