namespace SupermarketCheckout.Common.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class InvalidDiscountException : Exception
    {
        public InvalidDiscountException()
        {
            // Add any type-specific logic, and supply the default message.
        }

        public InvalidDiscountException(string message) : base(message)
        {
            // Add any type-specific logic.
        }
        public InvalidDiscountException(string message, Exception innerException) :
           base(message, innerException)
        {
            // Add any type-specific logic for inner exceptions.
        }
        protected InvalidDiscountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            // Implement type-specific serialization constructor logic.
        }
    }
}
