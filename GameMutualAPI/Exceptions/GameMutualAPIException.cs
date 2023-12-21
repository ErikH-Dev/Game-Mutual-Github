using System.Runtime.Serialization;

namespace Exceptions
{
	[Serializable]
	public class GameMutualAPIException : Exception
	{
		public GameMutualAPIException()
		{
		}

		public GameMutualAPIException(string? message) : base(message)
		{
		}

		public GameMutualAPIException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected GameMutualAPIException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}