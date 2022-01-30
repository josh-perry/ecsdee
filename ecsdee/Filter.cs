using System;
using System.Collections.Generic;
using System.Linq;
using ecsdee.Exceptions;

namespace ecsdee
{
    public class Filter
    {
        private readonly Type[] _matchTypes;

        public Filter(params Type[] matchTypes)
        {
            _matchTypes = matchTypes;
            ValidateTypes();
        }

        /// <summary>
        /// Checks all match types to ensure that each of them implements
        /// IComponent.
        ///
        /// Throws an exception with a list of invalid Types.
        /// </summary>
        /// <exception cref="InvalidComponentsException"></exception>
        private void ValidateTypes()
        {
            var invalidTypes = new List<Type>();

            foreach (var type in _matchTypes)
            {
                var interfaces = type.GetInterfaces();
                var component = interfaces.FirstOrDefault(x => x == typeof(IComponent));
                var valid = component != null;

                if (valid)
                {
                    continue;
                }

                invalidTypes.Add(type);
            }

            if (invalidTypes.Count > 0)
            {
                throw new InvalidComponentsException(invalidTypes);
            }
        }

        /// <summary>
        /// Returns true if the entity matches all of the match types.
        /// </summary>
        /// <param name="entity">The entity to test.</param>
        /// <returns>True if the entity applies, false otherwise.</returns>
        public bool Match(Entity entity)
        {
            foreach(var type in _matchTypes)
            {
                // If any of the types aren't a match, then this entity doesn't apply
                if(!entity.HasComponent(type))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
