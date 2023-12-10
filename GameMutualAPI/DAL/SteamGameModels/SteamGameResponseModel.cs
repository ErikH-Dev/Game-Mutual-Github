using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SteamGameModels
{
	public class SteamGameResponseModel
	{
		[JsonProperty("response")]
		public GameResponseModel Response { get; set; }
	}
}
