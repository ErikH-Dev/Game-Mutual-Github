using System.Runtime.Serialization;

namespace Exceptions.DbExceptions
{
	[Serializable]
	public class ObjectReferenceException : DBException
	{
		public ObjectReferenceException()
		{
		}

		public ObjectReferenceException(string? message) : base(message)
		{
		}

		public ObjectReferenceException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected ObjectReferenceException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}