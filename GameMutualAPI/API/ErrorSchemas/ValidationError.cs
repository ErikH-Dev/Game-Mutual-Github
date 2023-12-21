namespace API.ErrorSchemas
{
	public class ValidationError : Error
	{
		public required Dictionary<string, List<string>> ValidationErrors { get; set; }
	}
}
