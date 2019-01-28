using ecsdee.Tests.Components;
using Xunit;

namespace ecsdee.Tests
{
    public class HasComponentTests
    {
        [Fact]
        public void Test_AddComponent_GenericHasComponentIsTrue()
        {
            // Arrange
            var entity = new Entity(new World());
            entity.AddComponent(new Transform(10f, 10f, 32f, 32f));

            // Act
            var hasComponent = entity.HasComponent<Transform>();

            // Assert
            Assert.True(hasComponent);
        }

        [Fact]
        public void Test_AddComponent_HasComponentIsTrue()
        {
            // Arrange
            var entity = new Entity(new World());

            var transform = new Transform(10f, 10f, 32f, 32f);
            entity.AddComponent(transform);

            // Act
            var hasComponent = entity.HasComponent(transform.GetType());

            // Assert
            Assert.True(hasComponent);
        }

        [Fact]
        public void Test_NonexistantComponent_GenericHasComponentIsFalse()
        {
            // Arrange
            var entity = new Entity(new World());

            // Act
            var hasComponent = entity.HasComponent<Transform>();

            // Assert
            Assert.False(hasComponent);
        }

        [Fact]
        public void Test_NonexistantComponent_HasComponentIsFalse()
        {
            // Arrange
            var entity = new Entity(new World());

            var transform = new Transform(10f, 10f, 32f, 32f);

            // Act
            var hasComponent = entity.HasComponent(transform.GetType());

            // Assert
            Assert.False(hasComponent);
        }
    }
}
