namespace SupermarketCheckout.Common.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class PriceNotFoundException : Exception
    {
        public PriceNotFoundException()
        {
            // Add any type-specific logic, and supply the default message.
        }

        public PriceNotFoundException(string message) : base(message)
        {
            // Add any type-specific logic.
        }
        public PriceNotFoundException(string message, Exception innerException) :
           base(message, innerException)
        {
            // Add any type-specific logic for inner exceptions.
        }
        protected PriceNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            // Implement type-specific serialization constructor logic.
        }
    }
}
