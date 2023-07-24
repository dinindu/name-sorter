using FakeItEasy;

namespace NameSorter.Infrastructure.Tests;

public class FileReader_UnitTests
{
    [Fact]
    public void ReadLines_Should_ThrowAnError_When_FileIsNotFound()
    {
        // Arrange
        IFileReader fileReader = new FileReader();
        string unknownFile = "unknown-file.txt";

        string expectedErrorMessage = "file not found: 'unknown-file.txt'";

        // Act & Assert
        Exception ex = Should.Throw<Exception>(() => fileReader.ReadLines(unknownFile));

        ex.Message.ShouldBeEquivalentTo(expectedErrorMessage);
    }
}