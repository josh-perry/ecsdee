using ecsdee.Tests.Components;
using Xunit;

namespace ecsdee.Tests
{
    public class FilterMatchTests
    {
        [Fact]
        public void Test_EntityWithOneMatchingComponent_MatchTrue()
        {
            // Arrange
            var entity = new Entity(new World());

            var transform = new Transform(10f, 10f, 32f, 32f);
            entity.AddComponent(transform);

            var filter = new Filter(new[] { transform.GetType() });

            // Act
            var match = filter.Match(entity);

            // Assert
            Assert.True(match);
        }

        [Fact]
        public void Test_EntityWithNoComponents_MatchFalse()
        {
            // Arrange
            var entity = new Entity(new World());

            var transform = new Transform(10f, 10f, 32f, 32f);

            var filter = new Filter(new[] { transform.GetType() });

            // Act
            var match = filter.Match(entity);

            // Assert
            Assert.False(match);
        }

        [Fact]
        public void Test_EntityWithNoMatchingComponents_MatchFalse()
        {
            // Arrange
            var entity = new Entity(new World());

            var transform = new Transform(10f, 10f, 32f, 32f);

            var filter = new Filter(new[] { typeof(Color) });

            // Act
            var match = filter.Match(entity);

            // Assert
            Assert.False(match);
        }

        [Fact]
        public void Test_EntityWithMultipleMatchingComponents_MatchTrue()
        {
            // Arrange
            var entity = new Entity(new World());

            var transform = new Transform(10f, 10f, 32f, 32f);
            var color = new Color(1f, 0f, 0f);

            entity.AddComponent(transform);
            entity.AddComponent(color);

            var filter = new Filter(new[] { transform.GetType(), color.GetType() });

            // Act
            var match = filter.Match(entity);

            // Assert
            Assert.True(match);
        }

        [Fact]
        public void Test_EntityWithOneMatchingComponentAndNonMatchingComponent_MatchFalse()
        {
            // Arrange
            var entity = new Entity(new World());

            var transform = new Transform(10f, 10f, 32f, 32f);
            var color = new Color(1f, 0f, 0f);

            entity.AddComponent(transform);

            var filter = new Filter(new[] { transform.GetType(), color.GetType() });

            // Act
            var match = filter.Match(entity);

            // Assert
            Assert.False(match);
        }
    }
}