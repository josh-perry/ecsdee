using System;
using System.Collections.Generic;

namespace ecsdee.Exceptions
{
    public class InvalidComponentsException : Exception
    {
        public List<Type> Types;

        public InvalidComponentsException(List<Type> types)
            : base("Attempted to add non-component types to filter!")
        {
            Types = types;
        }
    }
}
