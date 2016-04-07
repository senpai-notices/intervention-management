using System;
using System.Runtime.Serialization;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core.Exceptions
{
    [Serializable]
    public class PasswordIsNullOrWhiteSpaceException : Exception
    {
        public PasswordIsNullOrWhiteSpaceException()
        { }

        public PasswordIsNullOrWhiteSpaceException(string message)
            : base(message)
        { }

        public PasswordIsNullOrWhiteSpaceException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected PasswordIsNullOrWhiteSpaceException (SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
