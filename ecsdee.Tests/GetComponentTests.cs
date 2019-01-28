using ecsdee.Tests.Components;
using Xunit;

namespace ecsdee.Tests
{
    public class GetComponentTests
    {
        [Fact]
        public void Test_GetExistingComponent_GetComponent()
        {
            // Arrange
            var entity = new Entity(new World());

            var transform = new Transform(10f, 10f, 32f, 32f);
            entity.AddComponent(transform);

            // Act
            var component = entity.GetComponent<Transform>();

            // Assert
            Assert.Same(transform, component);
        }

        [Fact]
        public void Test_AddTwoComponents_GetCorrectComponent()
        {
            // Arrange
            var entity = new Entity(new World());

            var transform = new Transform(10f, 10f, 32f, 32f);
            entity.AddComponent(transform);

            var color = new Color(1f, 0f, 0f);
            entity.AddComponent(color);

            // Act
            var retrievedTransform = entity.GetComponent<Transform>();
            var retrievedColor = entity.GetComponent<Color>();

            // Assert
            Assert.Same(transform, retrievedTransform);
            Assert.Same(color, retrievedColor);
        }

        [Fact]
        public void Test_GetNonexistingComponent_ThrowsException()
        {
            // Arrange
            var entity = new Entity(new World());

            // Act
            // Assert
            Assert.Null(entity.GetComponent<Transform>());
        }
    }
}
