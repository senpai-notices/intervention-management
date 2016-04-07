using System;
using System.Runtime.Serialization;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core.Exceptions
{
    [Serializable]
    public class UsernameIsNullOrWhiteSpaceException : Exception
    {
        public UsernameIsNullOrWhiteSpaceException()
        { }

        public UsernameIsNullOrWhiteSpaceException(string message)
            : base(message)
        { }

        public UsernameIsNullOrWhiteSpaceException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected UsernameIsNullOrWhiteSpaceException (SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
