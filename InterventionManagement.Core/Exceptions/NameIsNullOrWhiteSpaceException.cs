﻿using System;
using System.Runtime.Serialization;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core.Exceptions
{
    [Serializable]
    class NameIsNullOrWhiteSpaceException : Exception
    {
        public NameIsNullOrWhiteSpaceException()
        { }

        public NameIsNullOrWhiteSpaceException(string message)
            : base(message)
        { }

        public NameIsNullOrWhiteSpaceException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected NameIsNullOrWhiteSpaceException (SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
