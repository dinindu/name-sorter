using System.Text;
using NameSorter.Application.Services;
using NameSorter.Application;

namespace NameSorter.Application.Tests.Services;

public class ParsingService_UnitTests
{
    [Fact]
    public void ParseToName_ShouldReturnNullForEmptyString()
    {
        //Arrange
        string nameString = "";

        IParsingService parsingService = new ParsingService();

        //Act
        Name? parsedName = parsingService.ParseToName(nameString);

        //Assert
        parsedName.ShouldBeNull();
    }

    [Fact]
    public void ParseToName_ShouldReturnNullWhenExceedsMaximumNumberOfAllowedGivenNames()
    {
        //Arrange

        StringBuilder sb = new StringBuilder();
        sb.Append("GN1");

        for (int i = 2; i <= Constants.MAX_GIVEN_NAMES_ALLOWED + 1; i++)
        {
            sb.Append($" GN{i}");
        }

        sb.Append(" LN");

        IParsingService parsingService = new ParsingService();

        //Act
        Name? parsedName = parsingService.ParseToName(sb.ToString());

        //Assert
        parsedName.ShouldBeNull();
    }

    [Fact]
    public void ParseToName_ShouldParseNameCorrectly()
    {
        //Arrange
        string nameString = "Abc Def";

        IParsingService parsingService = new ParsingService();

        //Act
        Name? parsedName = parsingService.ParseToName(nameString);

        //Assert
        parsedName.ShouldNotBeNull();
        parsedName.LastName.ShouldBe("Def");
        parsedName.GivenNames.ShouldBe("Abc");
    }

    [Fact]
    public void ParseToName_ShouldParseNameWhenMultipleGivenNames()
    {
        //Arrange
        string nameString = "Abc Def Ghi";

        IParsingService parsingService = new ParsingService();

        //Act
        Name? parsedName = parsingService.ParseToName(nameString);

        //Assert
        parsedName.ShouldNotBeNull();
        parsedName.LastName.ShouldBe("Ghi");
        parsedName.GivenNames.ShouldBe("Abc Def");
    }

    [Fact]
    public void ParseToName_ShouldIgnoreExtraSpaces()
    {
        //Arrange
        string nameString = "Abc    Def  Ghi";

        IParsingService parsingService = new ParsingService();

        //Act
        Name? parsedName = parsingService.ParseToName(nameString);

        //Assert
        parsedName.ShouldNotBeNull();
        parsedName.LastName.ShouldBe("Ghi");
        parsedName.GivenNames.ShouldBe("Abc Def");
    }

    [Fact]
    public void ParseToName_ShouldIgnoreLeadingAndTrailingSpaces()
    {
        //Arrange
        string nameString = "   Abc Def Ghi     ";

        IParsingService parsingService = new ParsingService();

        //Act
        Name? parsedName = parsingService.ParseToName(nameString);

        //Assert
        parsedName.ShouldNotBeNull();
        parsedName.LastName.ShouldBe("Ghi");
        parsedName.GivenNames.ShouldBe("Abc Def");
    }

}
