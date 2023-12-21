using SharedObjects;

namespace Logic.Objects
{
	internal class SteamUser : ISteamUser
	{
		public string SteamID { get; set; }
		public string PersonaName { get; set; }
		public string ProfileURL { get; set; }
		public string AvatarFull { get; set; }
	}
}
