﻿using System;
using System.Runtime.Serialization;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core.Exceptions
{
    [Serializable]
    class UserIdIsNegativeException : Exception
    {
        public UserIdIsNegativeException()
        { }

        public UserIdIsNegativeException(string message)
            : base(message)
        { }

        public UserIdIsNegativeException(string message, Exception innerException)
            : base(message, innerException)
        { }

        protected UserIdIsNegativeException (SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}
