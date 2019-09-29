using System;
using System.Runtime.Serialization;

namespace PgnToFen
{
    [Serializable]
    internal class InvalidArgsException : Exception
    {
        public InvalidArgsException()
        {
        }

        public InvalidArgsException(string message) : base(message)
        {
        }

        public InvalidArgsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidArgsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}