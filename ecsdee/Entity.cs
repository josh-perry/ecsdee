using ecsdee.Exceptions;
using System;
using System.Collections.Generic;

namespace ecsdee
{
    public class Entity
    {
        /// <summary>
        /// The entity's list of components.
        /// </summary>
        public List<IComponent> Components = new List<IComponent>();

        /// <summary>
        /// The world the entity belongs to.
        /// </summary>
        private readonly World _world;

        public Entity(World world)
        {
            _world = world;
        }

        /// <summary>
        /// Checks whether the Entity has an IComponent.
        /// </summary>
        /// <param name="componentType">The type of component to check for.</param>
        /// <returns>True if the Entity has the component, false otherwise.</returns>
        public bool HasComponent(Type componentType)
        {
            return GetComponent(componentType) != null;
        }

        /// <summary>
        /// Checks whether the Entity has an IComponent.
        /// </summary>
        /// <typeparam name="T">The type of component to check for.</typeparam>
        /// <returns>True if the Entity has the component, false otherwise.</returns>
        public bool HasComponent<T>() where T : IComponent
        {
            return HasComponent(typeof(T));
        }

        /// <summary>
        /// Returns the specified IComponent if the Entity has it.
        /// </summary>
        /// <param name="componentType">The type of component to get.</param>
        /// <returns>The IComponent</returns>
        public IComponent GetComponent(Type componentType)
        {
            return Components.Find((IComponent c) =>
            {
                return c.GetType() == componentType;
            });
        }

        /// <summary>
        /// Returns the specified IComponent if the Entity has it.
        /// </summary>
        /// <typeparam name="T">The type of component to get.</typeparam>
        /// <returns>The IComponent</returns>
        public T GetComponent<T>() where T : IComponent
        {
            return (T)GetComponent(typeof(T));
        }

        /// <summary>
        /// Adds the specified IComponent to the Entity's component list.
        /// Throws an exception if the IComponent already exists.
        /// </summary>
        /// <param name="component">The IComponent to add.</param>
        public void AddComponent(IComponent component)
        {
            if (HasComponent(component.GetType()))
            {
                throw new ComponentAlreadyExistsException(component, this);
            }

            Components.Add(component);

            _world.UpdateFilterEntityCaches(this);
        }

        /// <summary>
        /// Removes the specified IComponent from the entity.
        /// Throws an exception if the IComponent doesn't exist.
        /// </summary>
        /// <param name="componentType">The IComponent type to remove.</param>
        public void RemoveComponent(Type componentType)
        {
            if(!HasComponent(componentType))
            {
                throw new ComponentDoesntExistException(componentType, this);
            }

            var component = GetComponent(componentType);
            Components.Remove(component);

            _world.UpdateFilterEntityCaches(this);
        }

        /// <summary>
        /// Removes the specified IComponent from the entity.
        /// Throws an exception if the IComponent doesn't exist.
        /// </summary>
        /// <typeparam name="T">The IComponent type to remove.</typeparam>
        public void RemoveComponent<T>() where T : IComponent
        {
            RemoveComponent(typeof(T));
        }
    }
}
