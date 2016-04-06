using System;
using System.Runtime.Serialization;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core.Exceptions
{
    [Serializable]
    class UsernameRegexException : Exception
    {
        public UsernameRegexException()
        { }

        public UsernameRegexException(string message)
            : base(message)
        { }

        public UsernameRegexException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected UsernameRegexException (SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
