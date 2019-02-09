namespace SupermarketCheckout.Common.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidBasketException : Exception
    {
        public InvalidBasketException()
        {
            // Add any type-specific logic, and supply the default message.
        }

        public InvalidBasketException(string message) : base(message)
        {
            // Add any type-specific logic.
        }
        public InvalidBasketException(string message, Exception innerException) :
           base(message, innerException)
        {
            // Add any type-specific logic for inner exceptions.
        }
        protected InvalidBasketException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            // Implement type-specific serialization constructor logic.
        }
    }
}
