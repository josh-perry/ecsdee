using System;

namespace ecsdee
{
    public class Filter
    {
        private Type[] _matchTypes;

        public Filter(Type[] matchTypes)
        {
            _matchTypes = matchTypes;
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
