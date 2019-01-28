using System.Collections.Generic;

namespace ecsdee
{
    public class World
    {
        /// <summary>
        /// All the entities the world is concerned with.
        /// </summary>
        public List<Entity> Entities = new List<Entity>();

        /// <summary>
        /// Entity caches for each filter.
        /// </summary>
        public Dictionary<Filter, List<Entity>> FilterEntityCache = new Dictionary<Filter, List<Entity>>();

        /// <summary>
        /// Creates an entity and adds it to the entities list.
        /// </summary>
        /// <returns>The new entity.</returns>
        public Entity CreateEntity()
        {
            var entity = new Entity(this);

            Entities.Add(entity);

            return entity;
        }
        
        /// <summary>
        /// Removes an entity from the world.
        /// </summary>
        /// <param name="entity"></param>
        public void RemoveEntity(Entity entity)
        {
            Entities.Remove(entity);
        }

        /// <summary>
        /// Get the cached list entities matching the filter.
        /// </summary>
        /// <param name="filter">The filter to match against.</param>
        /// <returns>A list of entities matching the filter.</returns>
        public List<Entity> GetEntitiesMatching(Filter filter)
        {
            if(!FilterEntityCache.ContainsKey(filter))
            {
                _initializeFilterEntityCache(filter);
            }

            return FilterEntityCache[filter];
        }

        /// <summary>
        /// Creates a new entity cache for a filter.
        /// </summary>
        /// <param name="filter">The filter to cache.</param>
        private void _initializeFilterEntityCache(Filter filter)
        {
            var entities = new List<Entity>();

            foreach(var entity in Entities)
            {
                if(filter.Match(entity))
                {
                    entities.Add(entity);
                }
            }

            FilterEntityCache[filter] = entities;
        }

        /// <summary>
        /// Updates all filter caches for an entity.
        /// </summary>
        /// <param name="entity">The entity to update caches for</param>
        public void UpdateFilterEntityCaches(Entity entity)
        {
            // Iterate over all filter caches and update them
            foreach(var filter in FilterEntityCache.Keys)
            {
                UpdateFilterEntityCache(filter, entity);
            }
        }

        /// <summary>
        /// Updates a specific filter cache for an entity.
        /// </summary>
        /// <param name="filter">The filter to update the cache of.</param>
        /// <param name="entity">The entity to update the cache of.</param>
        public void UpdateFilterEntityCache(Filter filter, Entity entity)
        {
            var cache = FilterEntityCache[filter];

            // If the entity is no longer in the world entities list, purge it
            // from the cache
            if(!Entities.Contains(entity))
            {
                cache.Remove(entity);
                return;
            }

            // If the entity should be in the cache and isn't already: add it
            if(filter.Match(entity) && !cache.Contains(entity))
            {
                cache.Add(entity);
            }
            // If the entity is in the cache but now shouldn't be: remove it
            else if(cache.Contains(entity) && !filter.Match(entity))
            {
                cache.Remove(entity);
            }
        }
    }
}