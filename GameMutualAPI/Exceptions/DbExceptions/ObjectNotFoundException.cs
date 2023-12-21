using System.Runtime.Serialization;

namespace Exceptions.DbExceptions
{
	[Serializable]
	public class ObjectNotFoundException : DBException
	{
		public ObjectNotFoundException()
		{
		}

		public ObjectNotFoundException(string? message) : base(message)
		{
		}

		public ObjectNotFoundException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected ObjectNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}