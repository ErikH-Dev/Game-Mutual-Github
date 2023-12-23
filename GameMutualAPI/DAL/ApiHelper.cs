using System.Net.Http.Headers;

namespace DAL
{
	public class ApiHelper
	{
		public static HttpClient ApiClient { get; set; }

		public static void IntializeClient()
		{
			ApiClient = new HttpClient();
			ApiClient.DefaultRequestHeaders.Accept.Clear();
			ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

	}
}
