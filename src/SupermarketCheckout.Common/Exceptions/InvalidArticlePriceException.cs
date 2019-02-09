namespace SupermarketCheckout.Common.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidArticlePriceException : Exception
    {
        public InvalidArticlePriceException()
        {
            // Add any type-specific logic, and supply the default message.
        }

        public InvalidArticlePriceException(string message) : base(message)
        {
            // Add any type-specific logic.
        }
        public InvalidArticlePriceException(string message, Exception innerException) :
           base(message, innerException)
        {
            // Add any type-specific logic for inner exceptions.
        }
        protected InvalidArticlePriceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            // Implement type-specific serialization constructor logic.
        }
    }
}
