using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SteamUserModels
{
	public class UserResponseModel
	{
		[JsonProperty("players")]
		public List<SteamUserModel> Players { get; set; }
	}
}
