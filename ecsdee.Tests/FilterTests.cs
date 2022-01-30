using ecsdee.Exceptions;
using Xunit;

namespace ecsdee.Tests
{
    public class FilterTests
    {
        private class InvalidComponent
        {
        }

        private class ValidComponent : IComponent
        {
        }

        [Fact]
        public void Test_FilterWithInvalidComponents_ThrowsException()
        {
            // Arrange
            // Act
            // Assert
            var exception = Assert.Throws<InvalidComponentsException>(() => {
                var filter = new Filter(typeof(InvalidComponent));
            });

            Assert.Contains(typeof(InvalidComponent), exception.Types);
        }

        [Fact]
        public void Test_FilterWithValidComponents_NoException()
        {
            // Arrange
            // Act
            // Assert
            var filter = new Filter(typeof(ValidComponent));
        }
    }
}
