using System;

namespace PgnToFen;

[Serializable]
internal class InvalidArgumentsException : Exception
{
    public InvalidArgumentsException()
    {
    }

    public InvalidArgumentsException(string message) : base(message)
    {
    }

    public InvalidArgumentsException(string message, Exception innerException) : base(message, innerException)
    {
    }
}