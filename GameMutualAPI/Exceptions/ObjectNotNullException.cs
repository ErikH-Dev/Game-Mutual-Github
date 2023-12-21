using System.Runtime.Serialization;

namespace Exceptions
{
	[Serializable]
	public class ObjectNotNullException : GameMutualAPIException
	{
		public ObjectNotNullException()
		{
		}

		public ObjectNotNullException(string? message) : base(message)
		{
		}

		public ObjectNotNullException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected ObjectNotNullException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}