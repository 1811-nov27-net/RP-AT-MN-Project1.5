using System;
using System.Collections.Generic;
using System.Text;

namespace Project1_5_Library.Exceptions
{
    [Serializable()]
    public class EndDateBeforeStartDateException : System.Exception
    {
        public EndDateBeforeStartDateException() : base() { }
        public EndDateBeforeStartDateException(string message) : base(message) { }
        public EndDateBeforeStartDateException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected EndDateBeforeStartDateException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
