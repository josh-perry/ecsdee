using ecsdee.Tests.Components;
using Xunit;

namespace ecsdee.Tests
{
    public class FilterEntityCacheTests
    {
        [Fact]
        public void Test_EntityAddFilteredComponent_CacheContainsEntity()
        {
            // Arrange
            var world = new World();
            var entity = world.CreateEntity();
            var filter = new Filter(new[] { typeof(Transform) });

            entity.AddComponent(new Transform(0f, 0f, 0f, 0f));

            // Act
            var entities = world.GetEntitiesMatching(filter);

            // Assert
            Assert.Single(entities);
            Assert.Contains(entity, world.FilterEntityCache[filter]);
        }

        [Fact]
        public void Test_EntityRemoveFilteredComponent_CacheDoesNotContainEntity()
        {
            // Arrange
            var world = new World();
            var entity = world.CreateEntity();
            var filter = new Filter(new[] { typeof(Transform) });

            entity.AddComponent(new Transform(0f, 0f, 0f, 0f));

            world.GetEntitiesMatching(filter);

            // Act
            entity.RemoveComponent<Transform>();

            // Assert
            Assert.DoesNotContain(entity, world.FilterEntityCache[filter]);
        }


        [Fact]
        public void Test_EntitAddFilteredComponentExistingCache_CacheContainsEntity()
        {
            // Arrange
            var world = new World();
            var entity = world.CreateEntity();
            var filter = new Filter(new[] { typeof(Transform) });

            world.GetEntitiesMatching(filter);
            Assert.DoesNotContain(entity, world.FilterEntityCache[filter]);

            // Act
            entity.AddComponent(new Transform(0f, 0f, 0f, 0f));

            // Assert
            Assert.Contains(entity, world.FilterEntityCache[filter]);
        }
    }
}
