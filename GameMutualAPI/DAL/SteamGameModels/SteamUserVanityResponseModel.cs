using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SteamGameModels
{
	public class SteamUserVanityResponseModel
	{
		[JsonProperty("response")]
		public SteamGameVanityURLModel Response { get; set; }
	}
}
