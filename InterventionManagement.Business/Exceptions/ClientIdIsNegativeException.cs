using System;
using System.Runtime.Serialization;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Exceptions
{
    [Serializable]
    public class ClientIdIsNegativeException : Exception
    {
        public ClientIdIsNegativeException()
        { }

        public ClientIdIsNegativeException(string message)
            : base(message)
        { }

        public ClientIdIsNegativeException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected ClientIdIsNegativeException (SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
