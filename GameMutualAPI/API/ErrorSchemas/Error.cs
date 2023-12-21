using System.Net;
using System.Text.Json;

namespace API.ErrorSchemas
{
	public class Error
	{
		private readonly JsonSerializerOptions _jsonSerializerOptions = new()
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
		};

		public HttpStatusCode StatusCode { get; set; }
		public required string ErrorInstance { get; set; }
		public required string Message { get; set; }
		public required string Instance { get; set; }

		public override string ToString()
		{
			return JsonSerializer.Serialize(this, _jsonSerializerOptions);
		}
	}
}
