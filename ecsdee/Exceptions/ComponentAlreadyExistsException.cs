using System;

namespace ecsdee.Exceptions
{
    public class ComponentAlreadyExistsException : Exception
    {
        public IComponent Component;
        public Entity Entity;

        public ComponentAlreadyExistsException(IComponent component, Entity entity) 
            : base("Entity already contains an instance of component!")
        {
            Component = component;
            Entity = entity;
        }
    }
}
