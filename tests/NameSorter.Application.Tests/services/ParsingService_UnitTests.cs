using System.Text;
using NameSorter.Application.Services;
using NameSorter.Application;

namespace NameSorter.Application.Tests.Services;

public class ParsingService_UnitTests
{
    [Fact]
    public void ParseName_ShouldReturnNullForEmptyString()
    {
        //Arrange
        string nameString = "";

        IParsingService parsingService = new ParsingService();

        //Act
        Name? parsedName = parsingService.ParseName(nameString);

        //Assert
        parsedName.ShouldBeNull();
    }

    [Fact]
    public void ParseName_ShouldReturnNullWhenExceedsMaximumNumberOfAllowedGivenNames()
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
        Name? parsedName = parsingService.ParseName(sb.ToString());

        //Assert
        parsedName.ShouldBeNull();
    }

    [Fact]
    public void ParseName_ShouldReturnNullWhenOnlyOneName()
    {
        //Arrange
        string nameString = "Abc";

        IParsingService parsingService = new ParsingService();

        //Act
        Name? parsedName = parsingService.ParseName(nameString);

        //Assert
        parsedName.ShouldBeNull();
    }

    [Fact]
    public void ParseName_ShouldParseNameCorrectly()
    {
        //Arrange
        string nameString = "Abc Def";

        IParsingService parsingService = new ParsingService();

        //Act
        Name? parsedName = parsingService.ParseName(nameString);

        //Assert
        parsedName.ShouldNotBeNull();
        parsedName.LastName.ShouldBe("Def");
        parsedName.GivenNames.ShouldBe("Abc");
    }

    [Fact]
    public void ParseName_ShouldParseNameWhenMultipleGivenNames()
    {
        //Arrange
        string nameString = "Abc Def Ghi";

        IParsingService parsingService = new ParsingService();

        //Act
        Name? parsedName = parsingService.ParseName(nameString);

        //Assert
        parsedName.ShouldNotBeNull();
        parsedName.LastName.ShouldBe("Ghi");
        parsedName.GivenNames.ShouldBe("Abc Def");
    }

    [Fact]
    public void ParseName_ShouldIgnoreExtraSpaces()
    {
        //Arrange
        string nameString = "Abc    Def  Ghi";

        IParsingService parsingService = new ParsingService();

        //Act
        Name? parsedName = parsingService.ParseName(nameString);

        //Assert
        parsedName.ShouldNotBeNull();
        parsedName.LastName.ShouldBe("Ghi");
        parsedName.GivenNames.ShouldBe("Abc Def");
    }

    [Fact]
    public void ParseName_ShouldIgnoreLeadingAndTrailingSpaces()
    {
        //Arrange
        string nameString = "   Abc Def Ghi     ";

        IParsingService parsingService = new ParsingService();

        //Act
        Name? parsedName = parsingService.ParseName(nameString);

        //Assert
        parsedName.ShouldNotBeNull();
        parsedName.LastName.ShouldBe("Ghi");
        parsedName.GivenNames.ShouldBe("Abc Def");
    }


    [Fact]
    public void ParseToNamesList_ShouldReturnNamesCorrectly()
    {
        //Arrange
        IEnumerable<string> nameStrings = new List<string>(){
            "Abc Def",
            "Ghi Jkl"
        };

        IParsingService parsingService = new ParsingService();

        IEnumerable<Name> expectedNames = new List<Name>(){
            new Name{ GivenNames = "Abc", LastName = "Def"},
            new Name{ GivenNames = "Ghi", LastName = "Jkl"}
        };

        //Act
        IEnumerable<Name> parsedNames = parsingService.ParseToNamesList(nameStrings);

        //Assert
        parsedNames.ShouldNotBeNull();
        parsedNames.Count().ShouldBe(expectedNames.Count());
        parsedNames.ToList().ShouldBeEquivalentTo(expectedNames);
    }

    [Fact]
    public void ParseToNamesList_ShouldIgnoreInvalidNames()
    {
        //Arrange
        IEnumerable<string> nameStrings = new List<string>(){
            "Abc Def",
            "A B C D E F",
            "Ghi Jkl"
        };

        IParsingService parsingService = new ParsingService();

        IEnumerable<Name> expectedNames = new List<Name>(){
            new Name{ GivenNames = "Abc", LastName = "Def"},
            new Name{ GivenNames = "Ghi", LastName = "Jkl"}
        };

        //Act
        IEnumerable<Name> parsedNames = parsingService.ParseToNamesList(nameStrings);

        //Assert
        parsedNames.ShouldNotBeNull();
        parsedNames.Count().ShouldBe(expectedNames.Count());
        parsedNames.ToList().ShouldBeEquivalentTo(expectedNames);
    }

    [Fact]
    public void ParseToNamesList_ShouldIgnoreEmptyStrings()
    {
        //Arrange
        IEnumerable<string> nameStrings = new List<string>(){
            "Abc Def",
            "",
            "Ghi Jkl"
        };

        IParsingService parsingService = new ParsingService();

        IEnumerable<Name> expectedNames = new List<Name>(){
            new Name{ GivenNames = "Abc", LastName = "Def"},
            new Name{ GivenNames = "Ghi", LastName = "Jkl"}
        };

        //Act
        IEnumerable<Name> parsedNames = parsingService.ParseToNamesList(nameStrings);

        //Assert
        parsedNames.ShouldNotBeNull();
        parsedNames.Count().ShouldBe(expectedNames.Count());
        parsedNames.ToList().ShouldBeEquivalentTo(expectedNames);
    }


    [Fact]
    public void ParseToStringList_ShouldParseNamesCorrectly()
    {
        //Arrange
        IEnumerable<Name> names = new List<Name>(){
            new Name{ GivenNames = "Abc", LastName = "Def"},
            new Name{ GivenNames = "Ghi", LastName = "Jkl"}
        };

        IEnumerable<string> expectedNameStrings = new List<string>(){
            "Abc Def",
            "Ghi Jkl"
        };

        IParsingService parsingService = new ParsingService();

        //Act
        IEnumerable<string> parsedNameStrings = parsingService.ParseToStringList(names);

        //Assert
        parsedNameStrings.ShouldNotBeNull();
        parsedNameStrings.Count().ShouldBe(expectedNameStrings.Count());
        parsedNameStrings.ToList().ShouldBeEquivalentTo(expectedNameStrings);
    }
}
