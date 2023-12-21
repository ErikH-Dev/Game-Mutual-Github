using Newtonsoft.Json;

namespace DAL.Models.SteamUserModels
{
	public class SteamUserResponseModel
	{
		[JsonProperty("response")]
		public UserResponseModel Response { get; set; }
	}
}
