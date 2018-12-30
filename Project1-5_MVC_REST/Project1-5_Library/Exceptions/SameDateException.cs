using System;
using System.Collections.Generic;
using System.Text;

namespace Project1_5_Library.Exceptions
{
    [Serializable()]
    public class SameDateException : System.Exception
    {
        public SameDateException() : base() { }
        public SameDateException(string message) : base(message) { }
        public SameDateException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client. 
        protected SameDateException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
