namespace SupermarketCheckout.Common.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidArticleException : Exception
    {
        public InvalidArticleException()
        {
            // Add any type-specific logic, and supply the default message.
        }

        public InvalidArticleException(string message) : base(message)
        {
            // Add any type-specific logic.
        }
        public InvalidArticleException(string message, Exception innerException) :
           base(message, innerException)
        {
            // Add any type-specific logic for inner exceptions.
        }
        protected InvalidArticleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            // Implement type-specific serialization constructor logic.
        }
    }
}

