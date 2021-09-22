using System;

namespace Ivy.Entities
{
    public class OrderException : Exception
    {
        public OrderException(string message) : base(message)
        {
            
        }
    }
}