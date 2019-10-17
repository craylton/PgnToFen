using System;
using System.Runtime.Serialization;

namespace PgnToFen
{
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

        protected InvalidArgumentsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}