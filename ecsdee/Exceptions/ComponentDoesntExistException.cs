using System;
using System.Runtime.Serialization;

namespace ecsdee
{
    public class ComponentDoesntExistException : Exception
    {
        public Type componentType;
        public Entity entity;

        public ComponentDoesntExistException(Type componentType, Entity entity)
            : base("Trying to remove a component that Entity doesn't have!")
        {
            this.componentType = componentType;
            this.entity = entity;
        }
    }
}