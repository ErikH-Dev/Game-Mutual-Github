using System.Net.Http.Headers;

namespace DAL
{
	public class ApiHelper
	{
		public static string key = "6AC5CEA343B2F0F4D431E0287C8D1F77";
		public static HttpClient ApiClient { get; set; }

		public static void IntializeClient()
		{
			ApiClient = new HttpClient();
			ApiClient.DefaultRequestHeaders.Accept.Clear();
			ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

	}
}
