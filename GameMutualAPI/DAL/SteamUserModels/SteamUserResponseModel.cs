using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SteamUserModels
{
	public class SteamUserResponseModel
	{
		[JsonProperty("response")]
		public UserResponseModel Response { get; set; }
	}
}
