using System;
using System.Runtime.Serialization;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core.Exceptions
{
    [Serializable]
    public class NameRegexException : Exception
    {
        public NameRegexException()
        { }

        public NameRegexException(string message)
            : base(message)
        { }

        public NameRegexException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected NameRegexException (SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
