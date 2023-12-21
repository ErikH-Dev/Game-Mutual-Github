using SharedObjects;

namespace Logic.Objects
{
	internal class SteamGame : ISteamGame
	{
		public int AppID { get; set; }
		public string Name { get; set; }
	}
}
