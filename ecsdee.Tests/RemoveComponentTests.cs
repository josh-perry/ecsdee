using ecsdee.Tests.Components;
using Xunit;

namespace ecsdee.Tests
{
    public class RemoveComponentTests
    {
        [Fact]
        public void Test_RemoveNonexistantComponent_ComponentDoesntExistException()
        {
            // Arrange
            var entity = new Entity(new World());

            var transform = new Transform(10f, 10f, 32f, 32f);

            // Act
            // Assert
            Assert.Throws<ComponentDoesntExistException>(() => entity.RemoveComponent(transform.GetType()));
        }

        [Fact]
        public void Test_RemoveNonexistantComponentGeneric_ComponentDoesntExistException()
        {
            // Arrange
            var entity = new Entity(new World());

            // Act
            // Assert
            Assert.Throws<ComponentDoesntExistException>(() => entity.RemoveComponent<Transform>());
        }

        [Fact]
        public void Test_RemoveExistingComponent_ComponentRemoved()
        {
            // Arrange
            var entity = new Entity(new World());

            var transform = new Transform(10f, 10f, 32f, 32f);
            entity.AddComponent(transform);

            var componentCount = entity.Components.Count;

            // Act
            entity.RemoveComponent<Transform>();

            // Assert
            Assert.Equal(componentCount - 1, entity.Components.Count);
        }
    }
}
