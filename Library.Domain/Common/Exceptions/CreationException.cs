namespace Library.Domain.Common.Exceptions;

public class CreationException : Exception
{
	public CreationException()
	{
	}

	public CreationException(string message) : base(message)
	{
	}

	public CreationException(string message, Exception innerException)
		: base(message, innerException)
	{
	}
}