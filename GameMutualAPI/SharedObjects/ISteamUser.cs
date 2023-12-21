using Newtonsoft.Json;

namespace SharedObjects
{
	public interface ISteamUser
	{
		[JsonProperty("steamid")]
		public string SteamID { get; set; }
		[JsonProperty("personaname")]
		public string PersonaName { get; set; }
		[JsonProperty("profileurl")]
		public string ProfileURL { get; set; }
		[JsonProperty("avatarfull")]
		public string AvatarFull { get; set; }
	}
}
