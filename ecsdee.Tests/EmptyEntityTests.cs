using Xunit;

namespace ecsdee.Tests
{
    public class EmptyEntityTests
    {
        [Fact]
        public void Test_NewEntity_HasNoComponents()
        {
            // Arrange
            var entity = new Entity(new World());

            // Act

            // Assert
            Assert.Empty(entity.Components);
        }
    }
}
